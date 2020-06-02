using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestProject { 

    public class Database
    {
        static string getHash(string str)
        {
            HashAlgorithm hAlg = HashAlgorithm.Create("SHA256");
            return BitConverter.ToString(hAlg.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }
        static string connectionstr = "Data Source=WorkingDataBase.mssql.somee.com;Initial Catalog=WorkingDataBase;Persist Security Info=True;User ID=Qwertytrewq123_SQLLogin_2;Password=yz9ic6ap3t";
        public class User
        {

            public static bool register(string FullName, string address, string email, string pos, string dep, string phone, double wage, string pwd)
            {
                pwd = getHash(pwd);
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($"Insert into users(FullName, Addres, Email, Position, Department, PhoneNumber, Wage, Password) VALUES('{FullName}','{address}','{email}','{pos}','{dep}','{phone}','{wage}','{pwd}')", sqlConnection);

                DataTable dt = new DataTable();
                try
                {
                    sql.Fill(dt);
                }
                catch
                {
                    sqlConnection.Close();
                    return false;
                }

                return true;
            }

            public static bool remove(int userID)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($@"delete from users where id = {userID}", sqlConnection);
                DataTable dt = new DataTable();
                try
                {
                    sql.Fill(dt);
                }
                catch
                {
                    sqlConnection.Close();
                    return false;
                }
                sqlConnection.Close();
                return true;
            }

            public static bool logout(int userID)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($@"insert into logging values({userID}, 'logout')", sqlConnection);
                DataTable dt = new DataTable();
                try
                {
                    sql.Fill(dt);
                }
                catch
                {
                    sqlConnection.Close();
                    return false;
                }
                sqlConnection.Close();
                return true;
            }

            public static bool login(string email, string pwd)
            {
                using (SqlConnection conn = new SqlConnection(connectionstr))
                {
                    pwd = getHash(pwd);
                    string sql = @"select * from  users where 'Email' = 'email' and 'Password' = 'pwd'";
                    SqlCommand comm = new SqlCommand(sql, conn);
                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        Console.WriteLine("true");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error" + ex);
                        Console.ReadKey();
                        return false;

                    }
                }

            }

        }

    }

}