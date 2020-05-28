using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {

    class Database
    {
        static string getHash(string str)
        {
            HashAlgorithm hAlg = HashAlgorithm.Create(HashAlgorithmName.SHA256.Name);
            return BitConverter.ToString(hAlg.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }
        static string connectionstr = "Data Source=WorkingDataBase.mssql.somee.com;Initial Catalog=WorkingDataBase;Persist Security Info=True;User ID=Qwertytrewq123_SQLLogin_2;Password=yz9ic6ap3t";
        public class Users
        {

           public static bool register(string FullName,string Role, string address, string email, string pos, string dep, string phone, double wage,int Hours, int reprCount, string pwd)
            {
                pwd = getHash(pwd);
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($"Insert into users(FullName, Role, Addres, Email, Position, Department, PhoneNumber, Wage, Hours, ReprimantQuantity, Password) VALUES('{FullName}','{Role}','{address}','{email}','{pos}','{dep}','{phone}','{wage}','{Hours}','{reprCount}','{pwd}')", sqlConnection);

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

        public class User
        {
            int id, ReprimentQuantity;
            string FullName, Addres, Email, Position, Departament, PhoneNumber, Password;
            bool Role;
            float Wage, Hours;
            public User(int id)
            {
                
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select * from users where Id = "+id, sqlConnection);
                SqlDataReader reader = sql.ExecuteReader();
                reader.Read();
                //id = reader["Id"];

            }
        }
    }

}