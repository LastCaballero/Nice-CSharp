using System;
using System.Net;
using System.Text ;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


class Start
{
    static void Main( string[] args )
    {
        switch ( args.Length )
        {
            case 1:
                {
			new Server( int.Parse( args[0] ) ) ;
			break ;
                }
            case 2:
                {
			new Client( args[0], int.Parse( args[1] ) ) ;
			break ;
                }
            default: {
			Console.WriteLine( "Something wrong happened... :-)" ) ;
                	break; 
		}
        }
    }
}

class Client {
	private TcpClient 	_client ;
	
	public Client( string target, int port ) {
		_client = new TcpClient( target, port ) ;
		new Thread( ReadMessages ).Start() ;
		SendMessages() ;
	}

	private void ReadMessages ()
    	{
    		if ( _client.Available > 0 ) {
			    byte[] buffer = new byte[_client.Available] ;
			    _client.Client.Receive( buffer ) ;
			    char[] chars = Encoding.UTF8.GetChars( buffer ) ;
			    string message = new string( chars ) ;
			    Console.Write( message ) ;
		}
		Thread.Sleep( 1000 ) ;
		new Thread( ReadMessages ).Start() ;
	}
	private void SendMessages () {
		while ( true ) {
			byte[] bytes = Encoding.UTF8.GetBytes( Console.ReadLine() + "\n" ) ;
			_client.Client.Send( bytes ) ;
		}
	}

}


class Server
{
	private TcpListener 	_listener;
	private TcpClient 	_client ;
	

    	public Server(int port)
    	{
        	_listener = new TcpListener(IPAddress.Any, port);
		_listener.Start();
		_client = _listener.AcceptTcpClient();
		new Thread( ReadMessages ).Start() ;
		SendMessages() ;
    	}

    	private void ReadMessages ()
    	{
    		if ( _client.Available > 0 ) {
			  byte[] buffer = new byte[_client.Available] ;
			  _client.Client.Receive( buffer ) ;
			  char[] chars = Encoding.UTF8.GetChars( buffer ) ;
			  string message = new string( chars ) ;
			  Console.Write( message ) ;
		}
		Thread.Sleep( 1000 ) ;
		new Thread( ReadMessages ).Start() ;
	}
	private void SendMessages () {
		while ( true ) {
			byte[] bytes = Encoding.UTF8.GetBytes( Console.ReadLine() + "\n" ) ;
			_client.Client.Send( bytes ) ;
		}
	}
}

