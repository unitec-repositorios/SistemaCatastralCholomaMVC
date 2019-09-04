﻿using System;
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
                SqlCommand cmd = new SqlCommand("select * from bkmilcp6nvs1hgkadyz6.empleado", conn);
                reader = cmd.ExecuteReader();
                List<Empleado> empleados = new List<Empleado>();
                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    string pass = reader.GetString(1);
                    string tip = reader.GetString(2);
                    empleados.Add(new Empleado(nombre, pass, tip));
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
                SqlCommand cmd = new SqlCommand("select * from bkmilcp6nvs1hgkadyz6.empleado where nombre = '" + id + "'", conn);
                reader = cmd.ExecuteReader();

                Empleado empleado = new Empleado();
                while (reader.Read())
                {
                    empleado.nombre = reader.GetString(0);
                    empleado.password = reader.GetString(1);
                    empleado.tipo = reader.GetString(2);
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
                string query = "insert into bkmilcp6nvs1hgkadyz6.empleado values (@nombre, @pass, @tip)";
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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
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
                string query = "update bkmilcp6nvs1hgkadyz6.empleado set password = @pass where nombre = @nomb";
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
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
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
                string query = "delete from bkmilcp6nvs1hgkadyz6.empleado where nombre = @nomb";
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
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
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
