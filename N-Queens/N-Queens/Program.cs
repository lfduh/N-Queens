namespace N_Queens
{
    class Program
    {
        static void Main ( string[] _args )
        {
            Console.WriteLine( "What's the target size?(above 0):" );
            var pattenSize = Int32.Parse( Console.ReadLine() );
            var pattens = GetNextPattens( pattenSize, new List<int>() );

            Console.WriteLine( String.Format( "Total Pattens Count:{0}\nShow Pattens?y/n:", pattens.Count ));
            var isShowPattens = Console.ReadLine();
            if( String.Compare( isShowPattens, "y" ) == 0 )            
                ShowPattens( pattens );

            Console.WriteLine( "==End==" );
        }             

        static List<List<int>> GetNextPattens ( int _targetPattenSize, List<int> _currentPatten )
        {
            var pattens = new List<List<int>>();

            if( _currentPatten.Count == _targetPattenSize )
            {
                pattens.Add( _currentPatten );
                return pattens;
            }

            for( int _positionX = 0; _positionX < _targetPattenSize; _positionX++ )
            {                
                if( HasNoCollisions( _positionX, _currentPatten ) )
                {                  
                    var nextPatten = new List<int>( _currentPatten );
                    nextPatten.Add( _positionX );
                    var nextPattens = GetNextPattens( _targetPattenSize, nextPatten );
                    pattens.AddRange( nextPattens );
                }
            }

            return pattens;
        }

        static bool HasNoCollisions ( int _positionX, List<int> _currentPatten )
        {
            for( int i = 0; i < _currentPatten.Count; i++ )
            {
                if( _currentPatten[i] == _positionX || Math.Abs( _currentPatten[i] - _positionX ) == (_currentPatten.Count - i) )               
                    return false;              
            }            
          
            return true;
        }

        static void ShowPattens ( List<List<int>> _pattens )
        {
            if( _pattens == null || _pattens.Count <= 0 ) return;         

            var patten = _pattens.First();
            
            for( int y = 0; y < patten.Count; y++ )
            {
                for( int x = 0; x < patten.Count; x++ )
                {
                    Console.Write( x == (patten[y])? "*": "." );                   
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            _pattens.Remove( patten );
            ShowPattens( _pattens );
        }
    }
}