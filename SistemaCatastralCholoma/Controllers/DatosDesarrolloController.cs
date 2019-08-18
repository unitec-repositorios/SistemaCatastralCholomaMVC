using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;
using System.Data.SqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class DatosDesarrolloController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();
        // GET: api/DatosDesarrollo
        [HttpGet]
        public HttpResponseMessage listDatosDesarrollo()
        {
            List<DatosDesarrollo> datosDesarrollo = new List<DatosDesarrollo>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from datosdesarrollo";

                SqlDataReader reader = query.ExecuteReader();
                DatosDesarrollo datosDes = new DatosDesarrollo();
                while (reader.Read())
                {
                    datosDes = new DatosDesarrollo();
                    datosDes.iddatosdesarrollo = (string)reader["iddatosdesarrollo"];
                    datosDes.area = (Double)reader["area"];
                    datosDes.servicios = (Double)reader["servicios"];
                    datosDes.topografia = (Double)reader["topografia"];
                    datosDes.configuracion = (Double)reader["configuracion"];

                    datosDesarrollo.Add(datosDes);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, datosDesarrollo);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // GET: api/DatosDesarrollo/5
        [HttpGet]
        public HttpResponseMessage getDatosDesarrollo(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from datosdesarrollo where iddatosdesarrollo = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                DatosDesarrollo datosDesarrollo = new DatosDesarrollo();
                while (reader.Read())
                {
                    datosDesarrollo = new DatosDesarrollo();
                    datosDesarrollo.iddatosdesarrollo = (string)reader["iddatosdesarrollo"];
                    datosDesarrollo.area = (Double)reader["area"];
                    datosDesarrollo.servicios = (Double)reader["servicios"];
                    datosDesarrollo.topografia = (Double)reader["topografia"];
                    datosDesarrollo.configuracion = (Double)reader["configuracion"];
                }
                conn.Close();
                if (datosDesarrollo.iddatosdesarrollo == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, datosDesarrollo);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/DatosDesarrollo
        [HttpPost]
        public HttpResponseMessage createDatosDesarrollo(DatosDesarrollo datosDesarrollo)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO datosdesarrollo VALUES (@iddatosdesarrollo,"                                                           + "@area," 
                                                                        + "@servicios," 
                                                                        + "@topografia," +
                                                                        "@configuracion)";

                query.Prepare();
                query.Parameters.AddWithValue("@iddatosdesarrollo", datosDesarrollo.iddatosdesarrollo);
                query.Parameters.AddWithValue("@area", datosDesarrollo.area);
                query.Parameters.AddWithValue("@servicios", datosDesarrollo.servicios);
                query.Parameters.AddWithValue("@topografia", datosDesarrollo.topografia);
                query.Parameters.AddWithValue("@configuracion", datosDesarrollo.configuracion);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, datosDesarrollo);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT: api/DatosDesarrollo/5
        [HttpPut]
        public HttpResponseMessage modifyDatosDesarrollo(string id, DatosDesarrollo datosDesarrollo)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE datosdesarrollo SET area = @area, servicios = @servicios, topografia = @topografia, configuracion = @configuracion " +
                                                      "where iddatosdesarrollo = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@area", datosDesarrollo.area);
                query.Parameters.AddWithValue("@servicios", datosDesarrollo.servicios);
                query.Parameters.AddWithValue("@topografia", datosDesarrollo.topografia);
                query.Parameters.AddWithValue("@configuracion", datosDesarrollo.configuracion);
                query.ExecuteNonQuery();
                datosDesarrollo.iddatosdesarrollo = id;
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, datosDesarrollo);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // DELETE: api/DatosDesarrollo/5
        [HttpDelete]
        public HttpResponseMessage deleteDatosDesarrollo(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from datosdesarrollo where iddatosdesarrollo = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }
    }
}
