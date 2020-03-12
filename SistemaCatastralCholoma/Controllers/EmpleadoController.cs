using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using SistemaCatastralCholoma.Models;
 
namespace SistemaCatastralCholoma.Controllers
{
    public class EmpleadoController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[empleado]";

        // GET: api/Empleado
        [HttpGet]
        public HttpResponseMessage listarEmpleados()
        {
            try
            {
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand($"select * from {DatabaseReference}", conn);
                reader = cmd.ExecuteReader();
                List<Empleado> empleados = new List<Empleado>();
                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    string pass = reader.GetString(1);
                    int tip = reader.GetInt16(2);
                    string usertype = reader.GetString(3);
                    empleados.Add(new Empleado(nombre, pass, tip, usertype));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, empleados);
                return response;
            }
            catch(SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }

        }

        // GET: api/Empleado/5
        [HttpGet]
        public HttpResponseMessage obtenerEmpleado(string id)
        {
            try
            {
                conn.Open();

                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand($"select * from {DatabaseReference} where nombre = '" + id + "'", conn);
                reader = cmd.ExecuteReader();

                Empleado empleado = new Empleado();
                while (reader.Read())
                {
                    empleado.nombre = reader.GetString(0);
                    empleado.password = reader.GetString(1);
                    empleado.tipo = reader.GetInt16(2);
                    empleado.usertype = reader.GetString(3);
                }
                conn.Close();
                if (empleado.nombre==null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, empleado);
                return response;
            }
            catch(SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }
        }

        // POST: api/Empleado
        [HttpPost]
        public HttpResponseMessage crearEmpleado(Empleado empleado)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                string query = $"insert into {DatabaseReference} values (@nombre, @pass, @tip, @UserType)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("@pass", empleado.password);
                cmd.Parameters.AddWithValue("@tip", empleado.tipo);
                cmd.Parameters.AddWithValue("@UserType", empleado.usertype);
                cmd.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, empleado);
                return response;
            }
            catch(SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        // PUT: api/Empleado/5
        [HttpPut]
        public HttpResponseMessage modificarEmpleado(string id,Empleado empleado)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                string query = $"update {DatabaseReference} set password = @pass where nombre = @nomb";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nomb", id);
                cmd.Parameters.AddWithValue("@pass", empleado.password);
                cmd.ExecuteNonQuery();
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, empleado);
                return response;
            }
            catch(SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        // DELETE: api/Empleado/5
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                string query = $"delete from {DatabaseReference} where nombre = @nomb";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nomb", id);
                cmd.ExecuteNonQuery();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;


            }
            catch(SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
