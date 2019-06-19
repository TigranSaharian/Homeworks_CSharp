﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCommandBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source = .\SQLEXPRESS;" +
                                      "Initial Catalog = test;" +
                                      "Integrated Security = true";

            string sql = "UPDATE Test_Employee set FirstName = '444' where Id = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];
                // добавим новую строку
                DataRow newRow = dt.NewRow();
                newRow["FirstName"] = "Alice";
                newRow["Age"] = 24;
                dt.Rows.Add(newRow);

                // создаем объект SqlCommandBuilder
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                // альтернативный способ - обновление только одной таблицы
                //adapter.Update(dt);
                // заново получаем данные из бд
                // очищаем полностью DataSet
                ds.Clear();
                // перезагружаем данные
                adapter.Fill(ds);

                foreach (DataColumn column in dt.Columns)
                    Console.Write("\t{0}", column.ColumnName);
                Console.WriteLine();
                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                        Console.Write("\t{0}", cell);
                    Console.WriteLine();
                }
            }
            Console.Read();
        }
    }
}
