using Microsoft.Data.SqlClient;
using System.Data;
namespace DatabaseConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string CONN_STRING = "Data Source=DESKTOP-2ESDHDD;Initial Catalog= DataBaseCommands;Integrated Security=True;Encrypt=False;";
            SqlConnection con = new SqlConnection(CONN_STRING);
            con.Open();
            //SqlCommand cmd = new SqlCommand("deleteWithOrderDetails", con);
            SqlCommand cmd = con.CreateCommand();

            //selecting and display of table data
            /*SqlDataReader reader = cmd.ExecuteReader();
            //cmd.CommandText = "SELECT * FROM orderDetails";
            Console.WriteLine("OrderID  CustomerID    OrderDate");
            while (reader.Read())
            { 
                Console.WriteLine($"{reader.GetInt32(0)}      {reader.GetInt32(1)}          {reader.GetDateTime(2).ToShortDateString()}");
            }


            /*passing a parameter from user to sql
            int id = Convert.ToInt32(Console.ReadLine());
            string name = Console.ReadLine();
            int salary = Convert.ToInt32(Console.ReadLine());
            string Gender = Console.ReadLine();
            int deptID = Convert.ToInt32(Console.ReadLine());
            cmd.CommandText = $"insert into EmployeeDB values({id},'{name}',{salary},'{Gender}',{deptID})" +
                              $"select * from EmployeeDB";

            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("ID\t\tName\t\tSalary\t\tGender\t\tDepartmentID");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}\t\t{reader.GetString(1)}\t\t{reader.GetInt32(2)}\t\t{reader.GetString(3)}\t\t{reader.GetInt32(4)}");
            }*/
            //updation of a table
            try
            {
                int id1 = Convert.ToInt32(Console.ReadLine());
                cmd.CommandText = $"select count(*) from EmployeeDB where Id={id1}";
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    cmd.CommandText = $"UPDATE EmployeeDB set Salary= 20000 where Id = {id1}" +
                        $"Select * from EmployeeDB where Id = {id1}";
                    cmd.ExecuteReader().Close();

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32(0)}\t\t{rd.GetString(1)}\t\t{rd.GetInt32(2)}\t\t{rd.GetString(3)}\t\t{rd.GetInt32(4)}");
                    }
                }
                else
                {
                    Console.WriteLine("the employee doesnot exist");
                }

            }
            catch(SqlException e)
            {
                Console.WriteLine ($"Error: {e.Message}");
            }
            

            //stored Procedure
            /*int input = int.Parse(Console.ReadLine());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@S_orderId", SqlDbType.Int).Value = input;

            */
            /*reader.Close();
            con.Close();*/

        }
    }
}