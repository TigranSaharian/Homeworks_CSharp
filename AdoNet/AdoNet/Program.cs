using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //with this string we trying to conect the local database
            string conStr = @"Data Source = .\SQLEXPRESS;" +
                            "Initial Catalog = AdvantureWorks2016CTR3;" +
                            "Integrated Security = true";

            string queryString = "select * from Production.Product " +
                    "where ProductLine = 'S' and DaysToManufacture < @days " +
                    "Order by DaysToManufacture";
            
            //SqlConnection connection = new SqlConnection(conStr);

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@days", 5);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Console.Read();
            }

            //try
            //{
            //    //open the connection of data base
            //    connection.Open();
            //    Console.WriteLine(connection.State);

            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    //close the connection of date base
            //    connection.Close();
            //    Console.WriteLine(connection.State);
            //}
            //Console.Read();
        }
    }
}
