using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace USG
{
    /* Это статитстика - её надо доработать
        public class Statistics
        {
            public Statistics(string database, string uid, int pwd, int port)
            {
                string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql_cmd_str = "CREATE TABLE IF NOT EXISTS stats(" +
                    "player VARCHAR(10)," +
                    "liveshots INT," +
                    "blankshots INT," +
                    "wins INT," +
                    "used_items INT); ALTER TABLE stats CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci;";
                MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                sql_cmd_str = "INSERT INTO stats (player, liveshots, blankshots, wins, used_items) SELECT 'Красный', 0, 0, 0, 0  FROM DUAL WHERE NOT EXISTS (SELECT * FROM stats WHERE player = 'Красный' AND liveshots = 0 + liveshots AND blankshots = 0 + blankshots AND wins = 0 + wins AND used_items = 0 + used_items LIMIT 1);";
                command = new MySqlCommand(sql_cmd_str, conn);
                reader = command.ExecuteReader();
                reader.Close();
                sql_cmd_str = "INSERT INTO stats (player, liveshots, blankshots, wins, used_items) SELECT 'Синий', 0, 0, 0, 0 FROM DUAL WHERE NOT EXISTS (SELECT * FROM stats WHERE player = 'Синий' AND liveshots = 0 + liveshots AND blankshots = 0 + blankshots AND wins = 0 + wins AND used_items = 0 + used_items LIMIT 1);";
                command = new MySqlCommand(sql_cmd_str, conn);
                reader = command.ExecuteReader();
                reader.Close();
            }
            public void RedWins(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET wins = wins + 1 WHERE player = 'Красный';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void BlueWins(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET wins = wins + 1 WHERE player = 'Синий';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void RedLiveShoots(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET liveshots = liveshots + 1 WHERE player = 'Красный';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void BlueLiveShoots(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET liveshots = liveshots + 1 WHERE player = 'Синий';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void RedBlankShoots(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET blankshots = blankshots + 1 WHERE player = 'Красный';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void BlueBlankShoots(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET blankshots = blankshots + 1 WHERE player = 'Синий';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void CheckStats(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "SELECT * FROM stats;";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    Console.Clear();
                    Console.Write("--------------------------------------------------------------------------------------------------------\r\n                                                                                                      \r\n                                              Статистика                                              \r\n                                                                                                      \r\n                                                                                                      \r\n                                                                                                      \r\n   ");
                    while (reader.Read())
                    {
                        Console.Write(reader[0].ToString() + " игрок - Выстрелов: " + reader[1].ToString() + " ; Попыток выстрелить: " + reader[2].ToString() + "  ; Побед: " + reader[3].ToString() + " ; Использованных предметов: " + reader[4].ToString() + ".\r\n                                                                                                      \r\n                                                                                                      \r\n                                                                                                      \r\n                                                                                                      \r\n                                                                                                      \r\n                                                                                                      \r\n                                                                                                      \r\n   ");
                    };
                    reader.Close();
                    Console.Write("\r\n---------------------------------------------------------------------------------------------------------\r\n Enter для перехода на следующее меню...");
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void RedItems(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET used_items = used_items + 1 WHERE player = 'Красный';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
            public void BlueItems(string database, string uid, int pwd, int port)
            {
                try
                {
                    string connStr = $"Server=localhost;port={port};database={database};Uid={uid};pwd={pwd};CHARSET=cp1251";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    string sql_cmd_str = "UPDATE stats SET used_items = used_items + 1 WHERE player = 'Синий';";
                    MySqlCommand command = new MySqlCommand(sql_cmd_str, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                catch (Exception e) { Console.WriteLine("error"); }
            }
        }
        */
}
