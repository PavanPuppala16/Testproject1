using System.Data.SqlClient;
using System.Data;
using Testproject.Models;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net.Mime;


namespace Testproject.business_Logic
{
    public class Logic_bl
    {
        public static bool InsertData2(Employee obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_empData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                    cmd.Parameters.AddWithValue("@salary", obj.salary);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@Qualification", obj.Qualification);
                    cmd.Parameters.AddWithValue("@Manager", obj.Manager);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
        public static List<Employee> GetAllData3()
        {
            List<Employee> obj = new List<Employee>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from register", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new Employee
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            Name = dr["Name"].ToString(),
                            Designation = dr["Designation"].ToString(),
                            salary = Convert.ToInt32(dr["salary"].ToString()),
                            Email = dr["Email"].ToString(),
                            Mobile = dr["Mobile"].ToString(),
                            Qualification = dr["Qualification"].ToString(),
                            Manager = dr["Manager"].ToString(),

                        }
                        );
                }
                return obj;

            }
        }
        public static Employee GetuserByID2(int Id)
        {
            Employee obj = null;
            var dbconfig = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("sp_empbyid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    obj = new Employee();


                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    obj.Designation = ds.Tables[0].Rows[i]["Designation"].ToString();
                    obj.salary = Convert.ToInt32(ds.Tables[0].Rows[i]["salary"].ToString());
                    obj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                    obj.Qualification = ds.Tables[0].Rows[i]["Qualification"].ToString();
                    obj.Manager = ds.Tables[0].Rows[i]["Manager"].ToString();



                }
                return obj;
            }
        }

        public static bool UpdateData2(Employee obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_updateres", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                    cmd.Parameters.AddWithValue("@salary", Convert.ToInt32(obj.salary));
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                    cmd.Parameters.AddWithValue("@Qualification", obj.Qualification);
                    cmd.Parameters.AddWithValue("@Manager", obj.Manager);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(obj.Id));

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
        public static bool DeleteData2(int Id)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_deleteres", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;


            }
        }

    }
}
