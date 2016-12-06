using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetrackerOdataClient
{
    public class CommandLine
    {
        private readonly string[] _args;

        public CommandLine ( string[] args )
        {
            _args = args;

            Init();
        }

        private void Init ()
        {
            if ( _args.Length < 2 || _args.Length > 3 )
            {
                Help();
                return;
            }

            // OData service uri
            try
            {
                ServiceUri = new Uri( _args[0] );
            }
            catch ( Exception )
            {
                Help();
                return;
            }

            // Mode
            var mode = _args[1];

            switch ( mode )
            {
                case "-t":
                    // Token
                    Token = _args[2];
                    break;

                case "-w":
                    IsWindowsAuth = true;
                    break;

                default:
                    Help();
                    return;
            }

            IsParsed = true;
        }

        public bool IsParsed { get; private set; }

        public Uri ServiceUri { get; private set; }

        public bool IsWindowsAuth { get; private set; }

        public string Token { get; private set; }

        public void Help ()
        {
            Console.WriteLine( "--------------------------------------------" );
            Console.WriteLine( "VSTS usage (token auth): {0} ServiceURI -t Token", System.AppDomain.CurrentDomain.FriendlyName );
            Console.WriteLine( "On-premise usage (NTLM auth): {0} ServiceURI -w", System.AppDomain.CurrentDomain.FriendlyName );
        }
    }
}