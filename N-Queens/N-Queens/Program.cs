namespace N_Queens
{
    class Program
    {
        static void Main ( string[] _args )
        {
            Console.WriteLine( "Hello, World!" );
           
            var pattenSize = Int32.Parse( Console.ReadLine() );
           
            var pattens = GetNextPattens( pattenSize, new List<int>() );
            Console.WriteLine( "pattens count: " + pattens.Count );
            Output( pattens );
            Console.ReadKey();
        }             

        static List<List<int>> GetNextPattens ( int _targetPattenSize, List<int> _currentPatten )
        {
            Console.WriteLine( "GetAllPattens " + String.Join(",", _currentPatten.ToArray())  );

            if( _currentPatten.Count == _targetPattenSize )
            {
                Console.WriteLine( "_currentPatten.Count == _size" );
                var list = new List<List<int>>();
                list.Add( _currentPatten );
                return list;
            }

            var pattens = new List<List<int>>();

            //foreach( var i in Enumerable.Range( 1, 100 ))
            for( int x = 0; x < _targetPattenSize; x++ )
            {
                Console.WriteLine( "to add: " + x + " " + _targetPattenSize );
                //Console.WriteLine( "check pos: " + pos );
                if( HasNoCollisions( x, _currentPatten ) )
                {
                    Console.WriteLine( "add: " + x );
                    //var newList = new List<int>( _currentPatten );
                    var nextPatten = new List<int>( _currentPatten );
                    nextPatten.Add( x );
                    var nextLayer = GetNextPattens( _targetPattenSize, nextPatten );
                    for( int i = 0; i< nextLayer.Count; i ++ ) 
                    {
                        var result = nextLayer[i];
                        Console.WriteLine( "add result" + result.Count );
                        pattens.Add( result );
                        Console.WriteLine( "pattens:" + pattens.Count );
                    }

                    //GetAllPattens( _size, state ).ForEach( _size => pattens.Add( _size ) );
                }
            }

            Console.WriteLine( "pattens count: " + pattens.Count );
            return pattens;
        }

        static bool HasNoCollisions ( int _positionX, List<int> _currentPatten )
        {
            Console.WriteLine( "HasNoCollisions: " + String.Join( ",", _currentPatten.ToArray()) + " " + _positionX );                      
            
            for( int i = 0; i < _currentPatten.Count; i ++ )
            {
                if( _currentPatten[i] == _positionX )
                {
                    //Console.WriteLine( "HasNoCollisions:no1" );
                    return false;
                }

                if( Math.Abs( _currentPatten[i] - _positionX ) == (_currentPatten.Count - i) )
                {
                    //Console.WriteLine( "HasNoCollisions:no2" );
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
            Console.WriteLine( "result: " + String.Join( ",", patten.ToArray() ) + patten.Count );
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