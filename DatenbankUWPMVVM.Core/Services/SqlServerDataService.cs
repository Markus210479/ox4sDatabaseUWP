using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
//using MySql.Data.MySqlClient;

using DatenbankUWPMVVM.Core.Models;

namespace DatenbankUWPMVVM.Core.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // More information on using and configuring this service can be found at https://github.com/microsoft/TemplateStudio/blob/main/docs/UWP/services/sql-server-data-service.md
    // TODO: Change your code to use this instead of the SampleDataService.
    public static class SqlServerDataService
    {
        // TODO: Specify the connection string in a config file or below.
        private static string GetConnectionString()
        {
            // Attempt to get the connection string from a config file
            // Learn more about specifying the connection string in a config file at https://docs.microsoft.com/dotnet/api/system.configuration.configurationmanager?view=netframework-4.7.2
            var conStr = ConfigurationManager.ConnectionStrings["MyAppConnectionString"]?.ConnectionString;

            if (!string.IsNullOrWhiteSpace(conStr))
            {
                return conStr;
            }
            else
            {
                // If no connection string is specified in a config file, use this as a fallback.
                return @"Data Source=*server*\*instance*;Initial Catalog=*dbname*;Integrated Security=SSPI";
            }
        }

        //public static async Task<IEnumerable<SampleOrder>> AllOrders()
        //{
        //    // List orders from all companies
        //    var companies = await AlleBauteile();
        //    return companies.SelectMany(c => c.Orders);
        //}

        // This method returns data with the same structure as the SampleDataService but based on the NORTHWIND sample database.
        // Use this as an alternative to the sample data to test using a different datasource without changing any other code.
        // TODO: Remove this when or if it isn't needed.
        public static async Task<IEnumerable<Bauteil>> AlleBauteile()
        {           

            const string getSampleDataQuery = "SELECT * FROM ARTIKEL";

            var BauteilList = new List<Bauteil>();

            try
            {
                using (var conn = new MySqlConnection(GetConnectionString()))
                //using (var conn = new SqlConnection(GetConnectionString()))
                {
                    await conn.OpenAsync();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = getSampleDataQuery;

                            using (var reader = await cmd.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {                                                                     
                                    // Product Data
                                    var id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                                    var hersteller = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                                    var lieferant_1 = !reader.IsDBNull(2) ? reader.GetString(2): string.Empty;
                                    var lieferant_2 = !reader.IsDBNull(3) ? reader.GetString(3): string.Empty;
                                    var lieferant_3 = !reader.IsDBNull(4) ? reader.GetString(4): string.Empty;
                                    var lieferant_4 = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                    var lieferant_5 = !reader.IsDBNull(6) ? reader.GetString(6): string.Empty;
                                    var lieferant_6 = !reader.IsDBNull(7) ? reader.GetString(7): string.Empty;
                                    var lieferant_7 = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty;
                                    var positionsName = !reader.IsDBNull(9) ? reader.GetString(9) : string.Empty;
                                    var kurzName = !reader.IsDBNull(10) ? reader.GetString(10) : string.Empty;
                                    var langName = !reader.IsDBNull(11) ? reader.GetString(11) : string.Empty;
                                    var kategorie = !reader.IsDBNull(12) ? reader.GetString(12) : string.Empty;
                                    var herstellerArtikelNr = !reader.IsDBNull(13) ? reader.GetString(13) : string.Empty;
                                    var lieferantenArtikelNr = !reader.IsDBNull(13) ? reader.GetString(13) : string.Empty;

                                    BauteilList.Add(new Bauteil()
                                    {
                                        ID = id.ToString(),
                                        Hersteller = hersteller,
                                        Lieferant_1 = lieferant_1,
                                        Lieferant_2 = lieferant_2,
                                        Lieferant_3 = lieferant_3,
                                        Lieferant_4 = lieferant_4,
                                        Lieferant_5 = lieferant_5,
                                        Lieferant_6 = lieferant_6,
                                        Lieferant_7 = lieferant_7,
                                        PositionsName = positionsName,
                                        KurzName = kurzName,
                                        LangName = langName,
                                        Kategorie = kategorie,
                                        HerstellerArtikelNr = herstellerArtikelNr,
                                        LieferantenArtikelNr = lieferantenArtikelNr
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                // Your code may benefit from more robust error handling or logging.
                // This logging is just a reminder that you should handle exceptions when connecting to remote data.
                System.Diagnostics.Debug.WriteLine($"Exception: {eSql.Message} {eSql.InnerException?.Message}");
            }

            return BauteilList;
        }
    }
}
