using System;

using System.Data.SqlClient;
namespace open
{
    class Program
    {
        public static void Main(string[] args)
        {
            SqlConnection sqlconnection;
            string path = @"server =CHANDUU\SQLEXPRESS;initial catalog=COdb; integrated security=SSPI ";
            try
            {
                sqlconnection = new SqlConnection(path);
                sqlconnection.Open();
                //operations
                Console.WriteLine("enter the name");
                string userName = Console.ReadLine();
                Console.WriteLine("enter thee age");
                int userAge = int.Parse(Console.ReadLine());
                string insertQuery = "INSERT INTO Details(User_Name,User_Age)VALUES('" + userName + "'," + userAge + ")";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconnection);
                insertCommand.ExecuteNonQuery();

                // retrive 
                string retriveQuery = "SELECT * FROM DETAILS";
                SqlCommand ReadData= new SqlCommand(retriveQuery,sqlconnection);
                SqlDataReader sqlDataReader = ReadData.ExecuteReader();
                while(sqlDataReader.Read())
                {
                    Console.WriteLine("Id : "+ sqlDataReader.GetValue(0).ToString());
                    Console.WriteLine("Name : "+ sqlDataReader.GetValue(1).ToString());
                    Console.WriteLine("Age : "+ sqlDataReader.GetValue(2).ToString());
                }
                sqlDataReader.Close();
                //update
                int id;
                int age;
                Console.WriteLine("enter the user id");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the updated age value");
                age = int.Parse(Console.ReadLine());
                string UpdateQueary = "UPDATE Details SET User_Age=" + age + " WHERE User_id=" + id + " ";
                SqlCommand updateCommand = new SqlCommand(UpdateQueary, sqlconnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("update successfuly");
                //delete
                Console.WriteLine("eneter the deleted age");
                int _age=int.Parse(Console.ReadLine());
                string deletedQuery = "DELETE From Details Where User_Age=" + _age + " ";
                SqlCommand sqlCommand = new SqlCommand(deletedQuery, sqlconnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("DELETED successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

