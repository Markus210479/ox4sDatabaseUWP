using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
//using MySql.Data.MySqlClient;

using DatenbankUWPMVVM.Core.Models;
using Org.BouncyCastle.Asn1.X509.Qualified;

namespace DatenbankUWPMVVM.Core.Services
{    
    // This class holds sample data used by some generated pages to show how they can be used.
    // More information on using and configuring this service can be found at https://github.com/microsoft/TemplateStudio/blob/main/docs/UWP/services/sql-server-data-service.md
    // TODO: Change your code to use this instead of the SampleDataService.
    public static class SqlServerDataService<T>
    {

        private static string GetConnectionString()
        {
            // Attempt to get the connection string from a config file
            // Learn more about specifying the connection string in a config file at https://docs.microsoft.com/dotnet/api/system.configuration.configurationmanager?view=netframework-4.7.2
            var conStr = ConfigurationManager.ConnectionStrings["ox4sConnectionString"]?.ConnectionString;

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

        public static async Task<IEnumerable<T>> allSqlData(string database)
        {
            string getSampleDataQuery = $"SELECT * FROM {database}";

            var List = new List<T>();

            try
            {
                using (var conn = new MySqlConnection(GetConnectionString()))
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
                                  switch(List.GetType().Name)
                                    {
                                        case "Bauteil":
                                            return (IEnumerable<T>)AlleBauteile(cmd);
                                        case "Service":
                                            return (IEnumerable<T>)AlleServices(cmd);
                                        case "Baugruppen":
                                            return (IEnumerable<T>)AlleBaugruppen(cmd);
                                        default:break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }

            return List;
        }

        private static async Task<IEnumerable<Bauteil>> AlleBauteile(MySqlCommand cmd)
        {
            var BauteilList = new List<Bauteil>();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                    var hersteller = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                    var lieferant_1 = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
                    var lieferant_2 = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                    var lieferant_3 = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                    var lieferant_4 = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                    var lieferant_5 = !reader.IsDBNull(6) ? reader.GetString(6) : string.Empty;
                    var lieferant_6 = !reader.IsDBNull(7) ? reader.GetString(7) : string.Empty;
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
            
            return BauteilList;
        }

        //public static async Task<IEnumerable<Bauteil>> AlleBauteile()
        //{           

        //    const string getSampleDataQuery = "SELECT * FROM ARTIKEL";

        //    var BauteilList = new List<Bauteil>();

        //    try
        //    {
        //        using (var conn = new MySqlConnection(GetConnectionString()))
        //        {
        //            await conn.OpenAsync();

        //            if (conn.State == System.Data.ConnectionState.Open)
        //            {
        //                using (var cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = getSampleDataQuery;

        //                    using (var reader = await cmd.ExecuteReaderAsync())
        //                    {
        //                        while (await reader.ReadAsync())
        //                        {                                                                     
        //                            var id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
        //                            var hersteller = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
        //                            var lieferant_1 = !reader.IsDBNull(2) ? reader.GetString(2): string.Empty;
        //                            var lieferant_2 = !reader.IsDBNull(3) ? reader.GetString(3): string.Empty;
        //                            var lieferant_3 = !reader.IsDBNull(4) ? reader.GetString(4): string.Empty;
        //                            var lieferant_4 = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
        //                            var lieferant_5 = !reader.IsDBNull(6) ? reader.GetString(6): string.Empty;
        //                            var lieferant_6 = !reader.IsDBNull(7) ? reader.GetString(7): string.Empty;
        //                            var lieferant_7 = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty;
        //                            var positionsName = !reader.IsDBNull(9) ? reader.GetString(9) : string.Empty;
        //                            var kurzName = !reader.IsDBNull(10) ? reader.GetString(10) : string.Empty;
        //                            var langName = !reader.IsDBNull(11) ? reader.GetString(11) : string.Empty;
        //                            var kategorie = !reader.IsDBNull(12) ? reader.GetString(12) : string.Empty;
        //                            var herstellerArtikelNr = !reader.IsDBNull(13) ? reader.GetString(13) : string.Empty;
        //                            var lieferantenArtikelNr = !reader.IsDBNull(13) ? reader.GetString(13) : string.Empty;

        //                            BauteilList.Add(new Bauteil()
        //                            {
        //                                ID = id.ToString(),
        //                                Hersteller = hersteller,
        //                                Lieferant_1 = lieferant_1,
        //                                Lieferant_2 = lieferant_2,
        //                                Lieferant_3 = lieferant_3,
        //                                Lieferant_4 = lieferant_4,
        //                                Lieferant_5 = lieferant_5,
        //                                Lieferant_6 = lieferant_6,
        //                                Lieferant_7 = lieferant_7,
        //                                PositionsName = positionsName,
        //                                KurzName = kurzName,
        //                                LangName = langName,
        //                                Kategorie = kategorie,
        //                                HerstellerArtikelNr = herstellerArtikelNr,
        //                                LieferantenArtikelNr = lieferantenArtikelNr
        //                            });
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception eSql)
        //    {
        //        // Your code may benefit from more robust error handling or logging.
        //        // This logging is just a reminder that you should handle exceptions when connecting to remote data.
        //        System.Diagnostics.Debug.WriteLine($"Exception: {eSql.Message} {eSql.InnerException?.Message}");
        //    }

        //    return BauteilList;
        //}

        public static async Task<IEnumerable<Service>> AlleServices(MySqlCommand cmd)
        {          
            var ServiceList = new List<Service>();

            try
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                        var serviceId = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                        var hersteller = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
                        var lieferant_1 = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                        var lieferant_2 = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                        var lieferant_3 = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                        var lieferant_4 = !reader.IsDBNull(6) ? reader.GetString(6) : string.Empty;
                        var lieferant_5 = !reader.IsDBNull(7) ? reader.GetString(7) : string.Empty;
                        var lieferant_6 = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty;
                        var lieferant_7 = !reader.IsDBNull(9) ? reader.GetString(9) : string.Empty;
                        var positionsName = !reader.IsDBNull(10) ? reader.GetString(10) : string.Empty;
                        var kurzName = !reader.IsDBNull(11) ? reader.GetString(11) : string.Empty;
                        var langName = !reader.IsDBNull(12) ? reader.GetString(12) : string.Empty;
                        var kategorie = !reader.IsDBNull(13) ? reader.GetString(13) : string.Empty;
                        var herstellerArtikelNr = !reader.IsDBNull(14) ? reader.GetString(14) : string.Empty;
                        var nettoStueckPreis_1 = !reader.IsDBNull(15) ? reader.GetString(15) : string.Empty;

                        ServiceList.Add(new Service()
                        {
                            ID = id.ToString(),
                            Service_ID = serviceId,
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
                            NettoStueckPreis_1 = nettoStueckPreis_1
                        });
                    }
                }
            }
            catch (Exception eSql)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {eSql.Message} {eSql.InnerException?.Message}");
            }

            return ServiceList;
        }

        //public static async Task<IEnumerable<Service>> AlleServices()
        //{

        //    const string getSampleDataQuery = "SELECT * FROM SERVICES";

        //    var ServiceList = new List<Service>();

        //    try
        //    {
        //        using (var conn = new MySqlConnection(GetConnectionString()))
        //        {
        //            await conn.OpenAsync();

        //            if (conn.State == System.Data.ConnectionState.Open)
        //            {
        //                using (var cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = getSampleDataQuery;

        //                    using (var reader = await cmd.ExecuteReaderAsync())
        //                    {
        //                        while (await reader.ReadAsync())
        //                        {
        //                            var id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
        //                            var serviceId = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
        //                            var hersteller = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
        //                            var lieferant_1 = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
        //                            var lieferant_2 = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
        //                            var lieferant_3 = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
        //                            var lieferant_4 = !reader.IsDBNull(6) ? reader.GetString(6) : string.Empty;
        //                            var lieferant_5 = !reader.IsDBNull(7) ? reader.GetString(7) : string.Empty;
        //                            var lieferant_6 = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty;
        //                            var lieferant_7 = !reader.IsDBNull(9) ? reader.GetString(9) : string.Empty;
        //                            var positionsName = !reader.IsDBNull(10) ? reader.GetString(10) : string.Empty;
        //                            var kurzName = !reader.IsDBNull(11) ? reader.GetString(11) : string.Empty;
        //                            var langName = !reader.IsDBNull(12) ? reader.GetString(12) : string.Empty;
        //                            var kategorie = !reader.IsDBNull(13) ? reader.GetString(13) : string.Empty;
        //                            var herstellerArtikelNr = !reader.IsDBNull(14) ? reader.GetString(14) : string.Empty;
        //                            var nettoStueckPreis_1 = !reader.IsDBNull(15) ? reader.GetString(15) : string.Empty;

        //                            ServiceList.Add(new Service()
        //                            {
        //                                ID = id.ToString(),
        //                                Service_ID = serviceId,
        //                                Hersteller = hersteller,
        //                                Lieferant_1 = lieferant_1,
        //                                Lieferant_2 = lieferant_2,
        //                                Lieferant_3 = lieferant_3,
        //                                Lieferant_4 = lieferant_4,
        //                                Lieferant_5 = lieferant_5,
        //                                Lieferant_6 = lieferant_6,
        //                                Lieferant_7 = lieferant_7,
        //                                PositionsName = positionsName,
        //                                KurzName = kurzName,
        //                                LangName = langName,
        //                                Kategorie = kategorie,
        //                                HerstellerArtikelNr = herstellerArtikelNr,
        //                                NettoStueckPreis_1 = nettoStueckPreis_1
        //                            });
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception eSql)
        //    {
        //        // Your code may benefit from more robust error handling or logging.
        //        // This logging is just a reminder that you should handle exceptions when connecting to remote data.
        //        System.Diagnostics.Debug.WriteLine($"Exception: {eSql.Message} {eSql.InnerException?.Message}");
        //    }

        //    return ServiceList;
        //}

        public static async Task<IEnumerable<Baugruppen>> AlleBaugruppen(MySqlCommand cmd)
        {


            var BaugruppenList = new List<Baugruppen>();

            try
            {
               
                            using (var reader = await cmd.ExecuteReaderAsync())
                            {
                                while (await reader.ReadAsync())
                                {
                                    // Product Data
                                    var id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
                                    var bomId = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                                    var bezeichnung = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
                                    var kommentar = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                                    var ekKosten = !reader.IsDBNull(4) ? reader.GetDouble(4) : -1;
                                    var eku = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                    var vk_10 = !reader.IsDBNull(6) ? reader.GetString(6) : string.Empty;
                                    var vk_15 = !reader.IsDBNull(7) ? reader.GetString(7) : string.Empty;
                                    var vk_20 = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty;

                                    BaugruppenList.Add(new Baugruppen()
                                    {
                                        ID = id.ToString(),
                                        BOM_ID = bomId,
                                        Bezeichnung = bezeichnung,
                                        Kommentar = kommentar,
                                        Letzte_EK_Kosten = ekKosten,
                                        EKU = eku,
                                        VK_10 = vk_10,
                                        VK_15 = vk_15,
                                        VK_20 = vk_20
                                    });
                                }
                            }
                        
                    
                
            }
            catch (Exception eSql)
            {
                // Your code may benefit from more robust error handling or logging.
                // This logging is just a reminder that you should handle exceptions when connecting to remote data.
                System.Diagnostics.Debug.WriteLine($"Exception: {eSql.Message} {eSql.InnerException?.Message}");
            }

            return BaugruppenList;
        }

    }

    //    public static async Task<IEnumerable<Baugruppen>> AlleBaugruppen()
    //    {

    //        const string getSampleDataQuery = "SELECT * FROM BAUGRUPPEN";

    //        var BaugruppenList = new List<Baugruppen>();

    //        try
    //        {
    //            using (var conn = new MySqlConnection(GetConnectionString()))
    //            {
    //                await conn.OpenAsync();

    //                if (conn.State == System.Data.ConnectionState.Open)
    //                {
    //                    using (var cmd = conn.CreateCommand())
    //                    {
    //                        cmd.CommandText = getSampleDataQuery;

    //                        using (var reader = await cmd.ExecuteReaderAsync())
    //                        {
    //                            while (await reader.ReadAsync())
    //                            {
    //                                // Product Data
    //                                var id = !reader.IsDBNull(0) ? reader.GetInt32(0) : -1;
    //                                var bomId = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
    //                                var bezeichnung = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
    //                                var kommentar = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
    //                                var ekKosten = !reader.IsDBNull(4) ? reader.GetDouble(4) : -1;
    //                                var eku = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
    //                                var vk_10 = !reader.IsDBNull(6) ? reader.GetString(6) : string.Empty;
    //                                var vk_15 = !reader.IsDBNull(7) ? reader.GetString(7) : string.Empty;
    //                                var vk_20 = !reader.IsDBNull(8) ? reader.GetString(8) : string.Empty;

    //                                BaugruppenList.Add(new Baugruppen()
    //                                {
    //                                    ID = id.ToString(),
    //                                    BOM_ID = bomId,
    //                                    Bezeichnung = bezeichnung,
    //                                    Kommentar = kommentar,
    //                                    Letzte_EK_Kosten = ekKosten,
    //                                    EKU = eku,
    //                                    VK_10 = vk_10,
    //                                    VK_15 = vk_15,
    //                                    VK_20 = vk_20
    //                                });
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception eSql)
    //        {
    //            // Your code may benefit from more robust error handling or logging.
    //            // This logging is just a reminder that you should handle exceptions when connecting to remote data.
    //            System.Diagnostics.Debug.WriteLine($"Exception: {eSql.Message} {eSql.InnerException?.Message}");
    //        }

    //        return BaugruppenList;
    //    }

    //}

}

