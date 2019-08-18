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

        // GET: api/Empleado
        [HttpGet]
        public HttpResponseMessage listarEmpleados()
        {
            try
            {
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("select * from empleado", conn);
                reader = cmd.ExecuteReader();
                List<Empleado> empleados = new List<Empleado>();
                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    string pass = reader.GetString(1);
                    TIPO_EMPLEADO tip = (TIPO_EMPLEADO)reader.GetInt32(2);
                    empleados.Add(new Empleado(nombre, pass, tip));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, empleados);
                return response;
            }
            catch(SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
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
                SqlCommand cmd = new SqlCommand("select * from empleado where nombre = '" + id + "'", conn);
                reader = cmd.ExecuteReader();

                Empleado empleado = new Empleado();
                while (reader.Read())
                {
                    empleado.nombre = reader.GetString(0);
                    empleado.password = reader.GetString(1);
                    empleado.tipo = (TIPO_EMPLEADO)reader.GetInt32(2);
                }
                conn.Close();
                if (empleado.nombre==null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, empleado);
                return response;
            }
            catch(SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
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
                string query = "insert into empleado values (@nombre, @pass, @tip)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("@pass", empleado.password);
                cmd.Parameters.AddWithValue("@tip", empleado.tipo);
                cmd.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, empleado);
                return response;
            }
            catch(SqlException e)
            {

                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
            finally
            {
                conn.Close();
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
                string query = "update empleado set password = @pass where nombre = @nomb";
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
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
            finally
            {
                conn.Close();
            }
        }

        // DELETE: api/Empleado/5
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                string query = "delete from empleado where nombre = @nomb";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nomb", id);
                cmd.ExecuteNonQuery();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;


            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
