using System;
using System.Collections.Generic;

namespace SportsScores
{
    static class DataUtilityClass
    {

        static System.Data.SqlClient.SqlConnection conn = null;

        static void ConnectToDB()
        {
                conn = new System.Data.SqlClient.SqlConnection();
                conn.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\databasescores.mdf;Integrated Security=True";
                conn.Open();
        }

        static public List<ClassScore> GetScores()
        {
            List<ClassScore> listScores = new List<ClassScore>();
            try
            {
                ConnectToDB();
                string sql = "SELECT scoredate, score FROM score ORDER BY scoredate";
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, conn);
                System.Data.SqlClient.SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listScores.Add(new ClassScore(reader["scoredate"].ToString(), Convert.ToInt16(reader["score"])));
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex);
                listScores = null; 
            }
            CloseDBConn();
            return listScores;
        }

        static public void AddScore(ClassScore score)
        {
            try
            {
                ConnectToDB();
                string sql = "insert into score(scoredate, score) values('" + score.ScoreDate + "', " + score.Score + ")";
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                
                Console.WriteLine("\n\t\tScore has been added!!!");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("An error has occurred: {0}", ex);
            }
            CloseDBConn();
        }

        static public void CloseDBConn()
        {
            conn.Close();
        }
    }
}
