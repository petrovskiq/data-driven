using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class01Homework
{
    class Program
    {
        private static string _connectionString = "Server=DESKTOP-GSKL72N\\SQLEXPRESS;Database=BooksDB;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            AddAuthor();
            Console.ReadLine();
            SelectingAuthors();
            Console.WriteLine("Choose by id Author to edit");
            int chosenid = int.Parse(Console.ReadLine());
            EditAuthor(chosenid);
            


            Console.ReadLine();
        }

        private static void AddAuthor()
        {
            
            

            
            Console.Write("Enter Firstname:");
            string firstName = Console.ReadLine();
            Console.Write("Enter Lastname:");
            string lastName = Console.ReadLine();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = String.Format("insert into dbo.Author(firstName, lastName) values ('{0}', '{1}')", firstName, lastName);
            connection.Open();

            cmd.ExecuteNonQuery();
            
            connection.Close(); 
        }

        private static void EditAuthor(int inputId)
        {

            Console.Write("Enter Firstname:");
            string firstName = Console.ReadLine();
            Console.Write("Enter Lastname:");
            string lastName = Console.ReadLine();
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"update Author set FirstName='{firstName}', LastName = '{lastName}' WHERE ID={inputId}";
            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }



        private static void SelectingAuthors()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            
            connection.Open();


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = String.Format("Select * From Author");
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int id = (int)dr["Id"];
                string firstname = (string)dr["FirstName"];
                string lastname = (string)dr["LastName"];

                Console.WriteLine($"ID: {id} | Firstname: {firstname} | Lastname: {lastname}");

            }

            connection.Close();
        }

        private static void DropTable()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = String.Format("DROP TABLE Author");
            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
