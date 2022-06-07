using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace DataLayer
{
    public class StudentRepository : IStudentRepository
    {
        public string ConnectionString;

        public void GetConnectionString(string connString)
        {
            ConnectionString = connString;
        }

        public List<Student> GetAllStudents()
        {


            List<Student> listToReturn = new List<Student>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Students ";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Student s = new Student();
                    s.Id = dataReader.GetInt32(0);
                    s.Name = dataReader.GetString(1);
                    s.Surname = dataReader.GetString(2);
                    s.Age = dataReader.GetInt32(3);
                    s.IndexNumber = dataReader.GetString(4);

                    listToReturn.Add(s);
                }
            }

            return listToReturn;


           

        }

        
        public int InsertStudent(Student s)
        {
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Students VALUES (" +
                    "'" + s.Name + "'" + ", " +
                    "'" + s.Surname + "'" + ", " +
                    s.Age + ", " +
                    "'" + s.IndexNumber + "'" + ")";

            
                return command.ExecuteNonQuery();
            }
        }

       
        public int UpdateStudent(Student s)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Students SET" +
                    " Name = " + "'" + s.Name + "'" + "," +
                    " Surname = " + "'" + s.Surname + "'" + "," +
                    " Age = " + s.Age + "," +
                    " IndexNumber = " + "'" + s.IndexNumber + "'" +
                    " WHERE Id = " + s.Id;

                
                return command.ExecuteNonQuery();
            }
        }

     
        public int DeleteStudent(int id)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Students WHERE Id = " + id;

              
                return command.ExecuteNonQuery();
            }
        }

       
        public JsonResult Select_student_evaluate(string index_of_number)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = " Select s.Name, s.Surname, s.IndexNumber, sb.Title, m.Month_Exam, m.Mark " +
                                      " From Middle m " +
                                      " Left outer join Students s on m.Id_Student = s.Id " +
                                      " Left outer join Subject sb on m.Id_Subject = sb.Id " +
                                      " Where s.IndexNumber = '" + index_of_number + "'";

                DataTable table = new DataTable();
                SqlDataReader myReader;

                myReader = command.ExecuteReader();
                table.Load(myReader);

                return new JsonResult(table);
            }
        }


    }
}
