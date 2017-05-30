using System;
using System.Linq;

namespace TimetrackerOdataClient
{
    internal class Program
    {
        private const string DateParametersFormat = @"yyyy-MM-dd";

        private static void Main ( string[] args )
        {
            // Get parameters
            var cmd = new CommandLine( args );

            if ( !cmd.IsParsed )
                return;

            // Create OData service context
            var context = cmd.IsWindowsAuth
                ? new TimetrackerOdataContext( cmd.ServiceUri )
                : new TimetrackerOdataContext( cmd.ServiceUri, cmd.Token );

            // Perform query for 3 last months
            var startDate = DateTime.Today.AddMonths( -3 ).ToString( DateParametersFormat );
            var endDate = DateTime.Today.ToString( DateParametersFormat );

            var timeExport = context.Container.TimeExport( startDate, endDate, null, null, null );
            var timeExportResult = timeExport.ToArray();

            // Print out the result
            foreach ( var row in timeExportResult )
                Console.WriteLine( "{0:g} {1} {2}", row.RecordDate, row.TeamMember, row.DurationInSeconds );
        }
    }
}