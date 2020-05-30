using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

           public static bool register(string FullName,bool Role, string address, string email, string pos, string dep, string phone, float wage,float Hours, int reprCount, string pwd)
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
            int id, reprimentQuantity;
            string fullName, addres, email, position, departament, phoneNumber, password;
            bool role;
            float wage, hours;

            string FullName
            {
                get
                {
                    return fullName;
                }
                set
                {
                    fullName = value;
                }
            }
            string Addres
            {
                get
                {
                    return addres;
                }
                set
                {
                    addres = value;
                }
            }
            string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    email = value;
                }
            }
            string Position
            {
                get
                {
                    return position;
                }
                set
                {
                    position = value;
                }
            }
            string Departament
            {
                get
                {
                    return departament;
                }
                set
                {
                    departament = value;
                }
            }
            string PhoneNumber
            {
                get
                {
                    return phoneNumber;
                }
                set
                {
                    phoneNumber = value;
                }
            }
            string Password
            {
                get
                {
                    return password;
                }
                set
                {
                    password = value;
                }
            }
            bool Role
            {
                get
                {
                    return role;
                }
                set
                {
                    role = value;
                }
            }
            float Wage
            {
                get
                {
                    return wage;
                }
                set
                {
                    wage = value;
                }
            }
            float Hours
            {
                get
                {
                    return hours;
                }
                set
                {
                    hours = value;
                }
            }
            int Id
            {
                get
                {
                    return id;
                }
            }
            int ReprimentQuantity
            {
                get
                {
                    return reprimentQuantity;
                }
                set
                {
                    reprimentQuantity = value;
                }
            }
            public User()
            {
                this.id = -1;
                reprimentQuantity = 0;
                fullName = "";
                addres = "";
                email = "";
                position = "";
                departament = "";
                phoneNumber = "";
                password = "";
                role = false;
                wage = 0;
                hours = 0;
            }
            public User(int id)
            {
                
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select * from users where Id = "+id, sqlConnection);
                SqlDataReader reader = sql.ExecuteReader();
                reader.Read();
                this.id = (int)reader["Id"];
                reprimentQuantity = (int)reader["ReprimentQantity"];
                fullName = reader["FullName"].ToString();
                addres = reader["Addres"].ToString();
                email = reader["Email"].ToString();
                position = reader["Position"].ToString();
                departament = reader["Departament"].ToString();
                phoneNumber = reader["PhoneNumber"].ToString();
                password = reader["Password"].ToString();
                role = (bool)reader["Role"];
                wage = (float)reader["Wage"];
                hours = (float)reader["Hours"];
            }
            static public int getIdByEmail(string email)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select id from users where Email = " + email, sqlConnection);
                SqlDataReader reader = sql.ExecuteReader();
                reader.Read();
                return (int)reader["Id"];
            }

            public bool Save()
            {
                if (id == -1)
                {
                    return Users.register(fullName,role,addres,email,position,departament,phoneNumber,wage,hours,reprimentQuantity,password);
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection(connectionstr);
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand($"UPDATE users SET FullName = {fullName}, Role = {role}, Addres = {addres}, Email = {email}, Position = {position}, Department = {departament}, PhoneNumber = {phoneNumber}, Wage = {wage}, Hours = {hours}, ReprimantQuantity = {reprimentQuantity}, Password = {password}", sqlConnection);
                    try
                    {
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        sqlConnection.Close();
                        return false;
                    }
                    return true;
                }
            }

            public bool AddTime(float time){
                hours += time;
                return Save();
            }
        }
    }

}