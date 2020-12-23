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
                    //var a = "Cricket";
                    emp.Hobbies = "Cricket";
                    com.Parameters.AddWithValue("@Hobbies", Convert.ToString(emp.Hobbies));
                }
                else
                {
                    var b = "Not selecteed";

                    emp.Hobbies = "Not selecteed";
                    com.Parameters.AddWithValue("@Hobbies", Convert.ToString(emp.Hobbies));
                }
                if (emp.Hobbies1 == "True")
                {

                    var c = "Songs";
                    emp.Hobbies1 = "Songs";
                    com.Parameters.AddWithValue("@Hobbies1", Convert.ToString(emp.Hobbies1));
                }
                else
                {
                    var d = "Not selecteed";
                    emp.Hobbies1 = "Not selecteed";
                    com.Parameters.AddWithValue("@Hobbies1", Convert.ToString(emp.Hobbies1));
                }
                if (emp.Hobbies2 == "True")
                {
                    var e = "Chess";
                   emp.Hobbies2 = "Chess";
                    com.Parameters.AddWithValue("@Hobbies2", Convert.ToString(emp.Hobbies2));
                }
                else
                {
                    var f = "Not selecteed";
                     emp.Hobbies2 = "Not selecteed";

                    com.Parameters.AddWithValue("@Hobbies2", Convert.ToString(emp.Hobbies2));
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
        //public int Update(Registration emp)
        //{
        //    int i;
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand com = new SqlCommand("UpdateEmployee", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Id", emp.Id);
        //        com.Parameters.AddWithValue("@Name", emp.Name);
        //        com.Parameters.AddWithValue("@Password", emp.Password);
        //        com.Parameters.AddWithValue("@DOB", emp.DOB);
        //        com.Parameters.AddWithValue("@Gender", emp.Gender);
        //        com.Parameters.AddWithValue("@Address", emp.Address);
        //        com.Parameters.AddWithValue("@City", emp.City);
        //        if (emp.Hobbies1 != "Cricket")
        //        {
        //            var b = "Not Selected";
        //            com.Parameters.AddWithValue("@Hobbies1", b);
        //        }
        //        else
        //        {
        //            com.Parameters.AddWithValue("@Hobbies1", emp.Hobbies1);
        //        }
        //        if (emp.Hobbies2 != "Songs")
        //        {
        //            var b = "Not Selected";
        //            com.Parameters.AddWithValue("@Hobbies2", b);
        //        }
        //        else
        //        {
        //            com.Parameters.AddWithValue("@Hobbies2", emp.Hobbies2);
        //        }
        //        if (emp.hobbies3 != "Chess")
        //        {
        //            var b = "Not Selected";
        //            com.Parameters.AddWithValue("@hobbies3", b);
        //        }
        //        else
        //        {
        //            com.Parameters.AddWithValue("@hobbies3", emp.hobbies3);
        //        }
        //        i = com.ExecuteNonQuery();
        //    }
        //    return i;
        //}
    }

}
