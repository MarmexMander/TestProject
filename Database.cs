using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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

            public static bool register(string FullName, string address, string email, string pos, string dep, string phone, double wage, int reprCount, string pwd)
            {
                pwd = getHash(pwd);
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($"Insert into users(FullName, Addres, Email, Position, Department, PhoneNumber, Wage, ReprimantQuantity, Password) VALUES('{FullName}','{address}','{email}','{pos}','{dep}','{phone}','{wage}','{reprCount}','{pwd}')", sqlConnection);

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
                this.id = (int)reader["Id"];
                ReprimentQuantity = (int)reader["ReprimentQantity"];
                FullName = reader["FullName"].ToString();
                Addres = reader["Addres"].ToString();
                Email = reader["Email"].ToString();
                Position = reader["Position"].ToString();
                Departament = reader["Departament"].ToString();
                PhoneNumber = reader["PhoneNumber"].ToString();
                Password = reader["Password"].ToString();
                Role = (bool)reader["Role"];
                Wage = (float)reader["Wage"];
                Hours = (float)reader["Hours"];
            }
        }
    }

}