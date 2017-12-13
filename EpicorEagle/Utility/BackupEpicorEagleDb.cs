using EpicorEagle.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace EpicorEagle.Utility
{
    public class BackupEpicorEagleDb
    {
        //BACKUP EPICOR EAGLE (TO FILE)(*.SQL)
        public static void BackupMySqlDatabaseByTable()
        {
            //get connection string
            string myConnectionString = EpicorEagleConnect.GetSqlConnectionString();
            //string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
            //string myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e;";
            //string myConnectionString = "SERVER=localhost; " +
            //    "DATABASE=travelexperts; " +
            //    "UID=root; " +
            //    "PASSWORD=;";

            try
            {
                string file = @"C:\_000_BACKUP\EpicorEagleDb.sql";
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            //List<string> myTableList = new List<string> { "customers", "agents" };
                            List<string> myTableList = new List<string> { "ADR", "ADRV" };
                            mb.ExportInfo.TablesToBeExportedList = myTableList;
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (MySqlException ex1)
            {
                Console.WriteLine("Message: " + ex1.Message + "\nStack: " + ex1.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message + "\nStack: " + ex.StackTrace);
            }

        }

        //BACKUP EPICOR EAGLE (TO FILE)(*.SQL)
        public static void BackupMySqlDatabaseAll()
        {
            //get connection string
            //string myConnectionString = EpicorEagleConnect.GetSqlConnectionString();
            //string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
            //string myConnectionString = "SERVER=10.0.1.7; " +
            //    "DATABASE=EAGLEDW; " +
            //    "UID=dbread; " +
            //    "PASSWORD=havemox1e;";
            string myConnectionString = "SERVER=localhost; " +
                "DATABASE=travelexperts; " +
                "UID=root; " +
                "PASSWORD=;";

            try
            {
                string file = @"C:\_000_BACKUP\EpicorEagleDb.sql";
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (MySqlException ex1)
            {
                Console.WriteLine("Message: " + ex1.Message + "\nStack: " + ex1.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message: " + ex.Message + "\nStack: " + ex.StackTrace);
            }

        }
    }
}
