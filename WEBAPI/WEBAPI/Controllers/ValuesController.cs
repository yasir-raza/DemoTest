using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("Demo")]
    public class ValuesController : ApiController
    {
        public static string GetConnection() { return ConfigurationManager.ConnectionStrings["test"].ConnectionString; }
        [HttpGet Route("testUser")]
        public string testUser(string Name, string Password)
        {
            using (SqlConnection con = new SqlConnection(GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Test", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return "test User";
        }
        [HttpGet Route("test")]
        public string test()
        {
            return "test";
        }
        [HttpGet Route("GetUser")]
        public IHttpActionResult GetUser()
        {
            return Ok("Get");
        }
        [HttpGet Route("GetUser")]
        public IHttpActionResult GetUser(string Username, string Password)
        {
            DataTable dt = GetDataTable(GetConnection(), 0, "sp_Test", new string[] { "@Type", "@Name", "@Password" }, 2, Username, Password);
            if (dt.Rows.Count > 0)
                return Ok();
            else
                return Content(HttpStatusCode.BadRequest, "User Not Found");
        }
        [HttpPost Route("InsertUser")]
        public IHttpActionResult InsertUser([FromBody] object obj)
        {
            return Ok(obj);
        }
        [HttpPost Route("Insert")]
        public IHttpActionResult Insert([FromBody] object obj)
        {
            return Ok(obj);
        }
        [HttpDelete Route("DeleteUser")]
        public IHttpActionResult DeleteUser(object obj)
        {
            return Ok(obj);
        }
        //GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
        DataTable GetDataTable(string ConnectionString, int CommandTimeOut, string SpName, string[] parameters, params object[] values)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand objSQLCommand = new SqlCommand();
                    objSQLCommand.Parameters.Clear();
                    objSQLCommand.Connection = con;
                    objSQLCommand.CommandType = CommandType.StoredProcedure;
                    objSQLCommand.CommandTimeout = CommandTimeOut;
                    objSQLCommand.CommandText = SpName;
                    int i = 0;
                    foreach (string p in parameters)
                    {
                        objSQLCommand.Parameters.Add(new SqlParameter(p, values[i]));
                        i++;
                    }
                    SqlDataAdapter DBDataAtapter02 = new SqlDataAdapter(objSQLCommand);
                    DataTable dt = new DataTable();
                    con.Open();
                    DBDataAtapter02.Fill(dt);
                    if (dt != null)
                    {
                        DBDataAtapter02.Dispose();
                        DBDataAtapter02 = null;
                        return dt;
                    }
                    else
                    {
                        DBDataAtapter02 = new SqlDataAdapter(objSQLCommand);
                        dt = new DataTable();
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        DBDataAtapter02.Fill(dt);
                        DBDataAtapter02.Dispose();
                        DBDataAtapter02 = null;
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }

        public bool InsertRecord(string ConnectionString, string SpName, string[] parameters, params object[] values)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand objSQLCommand = new SqlCommand();
                    objSQLCommand.Parameters.Clear();
                    objSQLCommand.CommandType = CommandType.StoredProcedure;
                    objSQLCommand.CommandText = SpName;
                    objSQLCommand.CommandTimeout = 0;
                    int i = 0;
                    foreach (string p in parameters)
                    {
                        objSQLCommand.Parameters.Add(new SqlParameter(p, values[i]));
                        i++;
                    }
                    con.Open();
                    objSQLCommand.Connection = con;
                    objSQLCommand.ExecuteNonQuery();
                    con.Close();
                    return true; ;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
        }
    }
}
