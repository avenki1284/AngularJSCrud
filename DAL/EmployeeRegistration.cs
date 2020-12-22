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
       DAL.DALPROPERTIES.Employeereg prop=new DALPROPERTIES.Employeereg();
       string connection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
       public int Add(Employeereg emp)
       {
           int i;
           using (SqlConnection con = new SqlConnection(connection))
           {
               con.Open();
               SqlCommand com = new SqlCommand("SP_InsertEmp", con);
               com.CommandType = CommandType.StoredProcedure;
               com.Parameters.AddWithValue("@Ename", emp.EmpName);
               com.Parameters.AddWithValue("@Salary", emp.salary);
               com.Parameters.AddWithValue("@Gender", emp.Gender);
               com.Parameters.AddWithValue("@Hobbies", emp.hobbies);
               com.Parameters.AddWithValue("@City", emp.city);
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
                       EmpName=rdr["Ename"].ToString(),
                       salary=Convert.ToDouble(rdr["Salary"]),
                        Gender= Convert.ToBoolean(rdr["Gender"].ToString()),
                       hobbies= rdr["Hobbies"].ToString(),
                       city=rdr["City"].ToString(),
                   });               }
               return lst;
           }
       }
    }
}
