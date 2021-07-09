using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ASMXService
{
    /// <summary>
    /// Сводное описание для WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        static string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|CompanyDB.mdf;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        public ObservableCollection<Department> Deps { get; private set; }
        public ObservableCollection<Employer> Emps { get; private set; }

        [WebMethod]
        public ObservableCollection<Employer> GetEmployers()
        {
            Emps = new ObservableCollection<Employer>();
            SqlCommand selectEmps = new SqlCommand("select Id, Name, LastName, Department_Id from Employers", connection);
            connection.Open();
            SqlDataReader dr = selectEmps.ExecuteReader();
            while (dr.Read())
            {
                Emps.Add(new Employer(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetInt32(3)));
            }
            connection.Close();

            return Emps;
        }

        [WebMethod]
        public ObservableCollection<Department> GetDepartments()
        {
            Deps = new ObservableCollection<Department>();
            SqlCommand selectDeps = new SqlCommand("select Id, Name from Departments", connection);
            connection.Open();
            SqlDataReader dr = selectDeps.ExecuteReader();
            while (dr.Read())
            {
                Deps.Add(new Department(dr.GetInt32(0), dr.GetString(1)));
            }
            connection.Close();

            return Deps;
        }

        [WebMethod]
        public void UpdateEmployer(int id, string name, string lastName, int department_id)
        {
            connection.Open();
            SqlCommand updateEmp = new SqlCommand(@"update Employers set Name = @Name, LastName = @LastName, Department_Id = @Department_Id where Id = @Id", connection);
            updateEmp.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name").Value = name;
            updateEmp.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName").Value = lastName;
            updateEmp.Parameters.Add("@Department_Id", SqlDbType.Int, 0, "Department_Id").Value = department_id;
            updateEmp.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").Value = id;
            updateEmp.ExecuteNonQuery();
            connection.Close();
        }

        [WebMethod]
        public void InsertEmployer(string name, string lastName, int department_id)
        {
            connection.Open();
            SqlCommand insertEmp = new SqlCommand(@"insert into Employers (Name, LastName, Department_Id) values (@Name, @LastName, @Department_Id); set @Id = @@identity;", connection);
            insertEmp.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name").Value = name;
            insertEmp.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName").Value = lastName;
            insertEmp.Parameters.Add("@Department_Id", SqlDbType.Int, 0, "Department_Id").Value = department_id;
            insertEmp.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").Value = 1;
            insertEmp.ExecuteNonQuery();
            connection.Close();
        }

        [WebMethod]
        public void DeleteEmployer(int id)
        {
            connection.Open();
            SqlCommand deleteEmp = new SqlCommand(@"delete from Employers where Id = @Id", connection);
            deleteEmp.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").Value = id;
            deleteEmp.ExecuteNonQuery();
            connection.Close();
        }

        [WebMethod]
        public void InsertDepartment(string depName)
        {
            connection.Open();
            SqlCommand insertDep = new SqlCommand(@"insert into Departments (Name) values (@Name); set @Id = @@identity", connection);
            insertDep.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name").Value = depName;
            insertDep.Parameters.Add("@Id", SqlDbType.Int, 50, "Id").Value = 1;
            insertDep.ExecuteNonQuery();
            connection.Close();
        }
    }
    public class Employer
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Department_Id { get; set; }
        public Employer(int id, string name, string lastName, int department_Id)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Department_Id = department_Id;
        }
        public Employer()
        {

        }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Department()
        {

        }
    }

}
