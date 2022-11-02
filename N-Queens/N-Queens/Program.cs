namespace N_Queens
{
    class Program
    {
        static void Main ( string[] _args )
        {                       
            var pattenSize = Int32.Parse( Console.ReadLine() );           
            var pattens = GetNextPattens( pattenSize, new List<int>() );           
            Output( pattens );            
        }             

        static List<List<int>> GetNextPattens ( int _targetPattenSize, List<int> _currentPatten )
        {
            if( _currentPatten.Count == _targetPattenSize )
            {
                var list = new List<List<int>>();
                list.Add( _currentPatten );
                return list;
            }

            var pattens = new List<List<int>>();

            //foreach( var i in Enumerable.Range( 1, 100 ))
            for( int x = 0; x < _targetPattenSize; x++ )
            {                
                if( HasNoCollisions( x, _currentPatten ) )
                {                  
                    var nextPatten = new List<int>( _currentPatten );
                    nextPatten.Add( x );
                    var nextLayer = GetNextPattens( _targetPattenSize, nextPatten );
                    for( int i = 0; i< nextLayer.Count; i ++ ) 
                    {
                        var result = nextLayer[i];                       
                        pattens.Add( result );                      
                    }
                }
            }

            return pattens;
        }

        static bool HasNoCollisions ( int _positionX, List<int> _currentPatten )
        {
            for( int i = 0; i < _currentPatten.Count; i ++ )
            {
                if( _currentPatten[i] == _positionX )
                {                   
                    return false;
                }

                if( Math.Abs( _currentPatten[i] - _positionX ) == (_currentPatten.Count - i) )
                {
                    return false;
                }
            }            
          
            return true;
        }

        static void Output ( List<List<int>> _pattens )
        {
            if( _pattens == null || _pattens.Count <=0 )
            {
                Console.WriteLine( "=End=" );
                return;
            }

            var patten = _pattens.First();
            
            for( int y = 0; y < patten.Count; y++ )
            {
                for( int x = 0; x < patten.Count; x++ )
                {
                    if( x == (patten[y]) )
                    {
                        Console.Write( "*" );
                    }
                    else
                    {
                        Console.Write( "." );
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            _pattens.Remove( patten );

            Output( _pattens );



            /*
            foreach( var _patten in _pattens )
            {
                Console.WriteLine( "result: " + String.Join( ",", _patten.ToArray() ));


                for( int y = 0; y < _patten.Count; y++ )
                {
                    for( int x = 0; x < _patten.Count; x++ )
                    { 
                        if( x == (_patten[y] ) )
                        {
                            Console.Write( "*" );
                        }
                        else
                        {
                            Console.Write( "." );
                        }                        
                    }

                    Console.WriteLine();

                }

                Console.WriteLine();
                Console.WriteLine();
            }  
            */
        }
    }
}