﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{

    public class Database
    {
        static string getHash(string str)
        {
            HashAlgorithm hAlg = HashAlgorithm.Create("SHA256");
            return BitConverter.ToString(hAlg.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }
        static string connectionstr = "Data Source=WorkingDataBase.mssql.somee.com;Initial Catalog=WorkingDataBase;Persist Security Info=True;User ID=Qwertytrewq123_SQLLogin_2;Password=yz9ic6ap3t";

        public class Users
        {

            public static bool register(string FullName, bool Role, string address, string email, string pos, string dep, string phone, float wage, float Hours, int reprCount, string pwd)
            {
                pwd = getHash(pwd);
                Hours = (int)Hours;
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

                pwd = getHash(pwd);
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"select * from  users where Email = '{email}' and Cast(Password as varchar(max)) = '{pwd}'", sqlConnection);
                SqlDataReader reader;
                try
                {
                    reader = sql.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                    //Console.ReadKey();
                    return false;

                }
                if (reader.Read())
                    return true;
                return false;

            }

           

            public static int calcWage(int userID)
            {
                User user = new User(userID);
                return (int)(user.Wage * user.Hours);

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
            public static List<User> GetUsers()
            {
                List<User> users = new List<User>();
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select id from users", sqlConnection);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User((int)reader["id"]));

                }
                return users;


            }

        }

        public class Repriment
        {
            int id, user_id;
            string text;
            public int Id
            {
                get
                {
                    return id;
                }
            }
            public int UserId
            {
                get
                {
                    return user_id;
                }
            }
            public string Text
            {
                get
                {
                    return text;
                }
            }
            public Repriment(SqlDataReader reader)
            {
                try
                {
                    id = (int)reader["id"];
                    user_id = (int)reader["UserId"];
                    text = (string)reader["Text"];
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    id = -1;
                }
            }
            public Repriment(int id)
            {
                if (id != -1)
                {
                    SqlConnection sqlConnection = new SqlConnection(connectionstr);
                    sqlConnection.Open();
                    SqlCommand sql = new SqlCommand($"Select * from repriments where Id = " + id, sqlConnection);
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    this.id = (int)reader["Id"];
                    text = (string)reader["Text"];
                    user_id = (int)reader["UserId"];
                }
                else
                {
                    this.id = -1;
                    text = "";
                    user_id = -1;
                }
            }
            public static List<Repriment> GetRepriments()
            {
                List<Repriment> repriments = new List<Repriment>();
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select * from repriments", sqlConnection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    repriments.Add(new Repriment(reader));
                }
                return repriments;
            }
        }


        public class User
        {
            int id, reprimentQuantity;
            string fullName, addres, email, position, departament, phoneNumber, password;
            bool role, isLogged;
            float wage, hours;
            Stopwatch stopwatch = new Stopwatch();
            public bool IsLogged
            {
                get
                {
                    return isLogged;
                }
            }
            public string FullName
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
            public string Addres
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
            public string Email
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
            public string Position
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
            public string Departament
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
            public string PhoneNumber
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
            public string Password
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
            public bool Role
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
            public float Wage
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
            public float Hours
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
            public int Id
            {
                get
                {
                    return id;
                }
            }
            public int ReprimentQuantity
            {
                get
                {
                    return reprimentQuantity;
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

            public List<Repriment> GetUserRepriments()
            {
                List<Repriment> repriments = new List<Repriment>();
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select * from repriments where UserId = {id}", sqlConnection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    repriments.Add(new Repriment(reader));
                }
                return repriments;
            }

            public bool addRepriment(string text)
            {
                reprimentQuantity++;
                Save();
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($"Insert into repriments(UserId, Text) VALUES({id},'{text}')", sqlConnection);
                SqlDataAdapter sql2 = new SqlDataAdapter($@"insert into logging(UserId, Evant) values({Id}, 'got_reprim')", sqlConnection);
                DataTable dt = new DataTable();
                try
                {
                    sql.Fill(dt);
                    sql2.Fill(dt);
                }
                catch(Exception e)
                {
                    sqlConnection.Close();
                    MessageBox.Show(e.Message);
                    return false;
                }

                return true;
            }
            public User(int id)
            {
                if (id != -1)
                {
                    SqlConnection sqlConnection = new SqlConnection(connectionstr);
                    sqlConnection.Open();
                    SqlCommand sql = new SqlCommand($"Select * from users where Id = " + id, sqlConnection);
                    SqlDataReader reader = sql.ExecuteReader();
                    reader.Read();
                    this.id = (int)reader["Id"];
                    reprimentQuantity = (int)reader["ReprimantQuantity"];
                    fullName = reader["FullName"].ToString();
                    addres = reader["Addres"].ToString();
                    email = reader["Email"].ToString();
                    position = reader["Position"].ToString();
                    departament = reader["Department"].ToString();
                    phoneNumber = reader["PhoneNumber"].ToString();
                    password = reader["Password"].ToString();
                    role = (bool)reader["Role"];
                    wage = (float)((double)reader["Wage"]);
                    hours = (float)((int)reader["Hours"]);
                }
                else
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
            }
            public static int getIdByEmail(string email)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select id from users where Email = '{email}'", sqlConnection);
                SqlDataReader reader = sql.ExecuteReader();
                reader.Read();
                try { return (int)reader["Id"]; }
                catch { return -1; }
            }

            public static int getIdByFullName(string FullName)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlCommand sql = new SqlCommand($"Select id from users where FullName = '{FullName}'", sqlConnection);
                SqlDataReader reader = sql.ExecuteReader();
                reader.Read();
                try { return (int)reader["Id"]; }
                catch { return -1; }
            }

            public bool Save()
            {
                if (id == -1)
                {
                    return Users.register(fullName, role, addres, email, position, departament, phoneNumber, wage, hours, reprimentQuantity, password);
                }
                else
                {
                    SqlConnection sqlConnection = new SqlConnection(connectionstr);
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand($"UPDATE users SET FullName = '{fullName}', Role = '{role}', Addres = '{addres}', Email = '{email}', Position = '{position}', Department = '{departament}', PhoneNumber = '{phoneNumber}', Wage = {wage}, Hours = {(int)hours}, ReprimantQuantity = {reprimentQuantity}, Password = '{password}' where id = {this.id}", sqlConnection);
                    try
                    {
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        sqlConnection.Close();
                        return false;
                    }
                    return true;
                }
            }

            public bool AddTime(float time)
            {
                hours += time;
                return Save();
            }

            public static User login(string email, string password)
            {
                if (Users.login(email, password))
                {
                    User res = new User(User.getIdByEmail(email));
                    if (res.Id == -1)
                        return null;
                    else
                    {
                        SqlConnection sqlConnection = new SqlConnection(connectionstr);
                        sqlConnection.Open();
                        SqlDataAdapter sql = new SqlDataAdapter($@"insert into logging(UserId, Evant) values({res.Id}, 'login')", sqlConnection);
                        DataTable dt = new DataTable();
                        try
                        {
                            sql.Fill(dt);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                            sqlConnection.Close();
                        }
                        res.stopwatch.Start();
                        res.isLogged = true;
                        return res;
                    }
                }
                else return null;
            }
            public void giveWage()
            {
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($@"insert into logging(UserId, Evant) values({Id}, 'Wage:{calcWage()}')", sqlConnection);
                DataTable dt = new DataTable();
                try
                {
                    sql.Fill(dt);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    sqlConnection.Close();
                }
                Hours = 0;
                Save();
            }
            public bool logout()
            {
                if (!isLogged)
                    return true;
                stopwatch.Stop();
                SqlConnection sqlConnection = new SqlConnection(connectionstr);
                sqlConnection.Open();
                SqlDataAdapter sql = new SqlDataAdapter($@"insert into logging(UserId, Evant) values({id}, 'logout')", sqlConnection);
                DataTable dt = new DataTable();
                try
                {
                    sql.Fill(dt);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    sqlConnection.Close();
                    return false;
                }
                sqlConnection.Close();
                isLogged = false;
                return AddTime((float)stopwatch.Elapsed.TotalHours);
            }

            public float calcWage()
            {
                float wage = (Wage * Hours);
                float percent = wage * (reprimentQuantity * 5) / 100;
                return wage - percent;
            }

        }
    }

}