using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

public class MysqTest
{
    public static void Main()
    {
        string connStr = "server=localhost;user=root;database=gdelattre;port=3306;password=;";
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            // Perform database operations
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        // SQL request
        string sql = "SELECT * FROM user";
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            Console.WriteLine(rdr[0] + " -- " + rdr[1]);
        }
        rdr.Close();

        conn.Close();
        Console.WriteLine("Done.");

        Console.WriteLine("Press any key to stop");
        do
        {
            while (!Console.KeyAvailable)
            {
                // Do something
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}