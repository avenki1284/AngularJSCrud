using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL.DALPROPERTIES;
namespace DAL
{
    public class EmployeeRegistration
    {
        DAL.DALPROPERTIES.Employeereg prop = new DALPROPERTIES.Employeereg();
        string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        public int Add(Employeereg emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_InsertEmp", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Ename", emp.Ename);
                com.Parameters.AddWithValue("@Salary", emp.Salary);
                com.Parameters.AddWithValue("@Gender", emp.Gender);
                if (emp.Hobbies == "True")
                {
                    var a = Convert.ToString(emp.Hobbies);
                    a = "Cricket";
                    com.Parameters.AddWithValue("@Hobbies", Convert.ToString(a));
                }
                else
                {
                    com.Parameters.AddWithValue("@Hobbies",null);
                }
                if (emp.Hobbies1 == "True")
                {
                    var a = Convert.ToString(emp.Hobbies1);
                    a = "Songs";
                    com.Parameters.AddWithValue("@Hobbies1", Convert.ToString(a));
                }
                else
                {
                    com.Parameters.AddWithValue("@Hobbies1",null);
                }
                if (emp.Hobbies2 == "True")
                {
                    var a = Convert.ToString(emp.Hobbies1);
                    a = "Chess";
                    com.Parameters.AddWithValue("@Hobbies2", Convert.ToString(a));
                }
                else
                { 
                    com.Parameters.AddWithValue("@Hobbies2", null);
                }
                com.Parameters.AddWithValue("@City", emp.City);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public List<Employeereg> ListAll()
        {
            List<Employeereg> lst = new List<Employeereg>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_Getdetails", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Employeereg
                    {
                        Eno = Convert.ToInt32(rdr["Eno"]),
                        Ename = rdr["Ename"].ToString(),
                        Salary = Convert.ToDouble(rdr["Salary"]),
                        Gender = rdr["Gender"].ToString(),
                        Hobbies = rdr["Hobbies"].ToString(),
                        Hobbies1 = rdr["Hobbies1"].ToString(),
                        Hobbies2 = rdr["Hobbies2"].ToString(),
                        City = rdr["City"].ToString(),
                    });
                }
                return lst;
            }
        }
        public int DeleteEmployee(Employeereg Emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Emp.Eno);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int Update(Employeereg Employe)
        {
            int i;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SP_UpdateEmp", con);
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.AddWithValue("@Eno", Employe.Eno);
                com.Parameters.AddWithValue("@Ename", Employe.Ename);
                
                com.Parameters.AddWithValue("@Salary",Employe.Salary);
                com.Parameters.AddWithValue("@Gender", Employe.Gender);
                if (Employe.Hobbies == "True")
                {
                    var a = Convert.ToString(Employe.Hobbies);
                    a = "Cricket";
                    com.Parameters.AddWithValue("@Hobbies", Convert.ToString(a));
                }
                else
                {

                    com.Parameters.AddWithValue("@Hobbies", DBNull.Value);
                }
                if (Employe.Hobbies1 == "True")
                {

                    var a = Convert.ToString(Employe.Hobbies1);
                    a = "Songs";
                    com.Parameters.AddWithValue("@Hobbies1", Convert.ToString(a));
                }
                else
                {

                    com.Parameters.AddWithValue("@Hobbies1", DBNull.Value);
                }
                if (Employe.Hobbies2 == "True")
                {
                    var a = Convert.ToString(Employe.Hobbies1);
                    a = "Chess";


                    com.Parameters.AddWithValue("@Hobbies2", Convert.ToString(a));
                }
                else
                {
                    // var a = Convert.ToString(emp.Hobbies2);
                    //a = "Not selecteed";
                    com.Parameters.AddWithValue("@Hobbies2", DBNull.Value);
                }
                com.Parameters.AddWithValue("@City", Employe.City);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }

}
