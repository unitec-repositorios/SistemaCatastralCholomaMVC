using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SistemaCatastralCholoma.Models;
using MySql.Data.MySqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class DatosDesarrolloController : ApiController
    {

        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/DatosDesarrollo
        [HttpGet]
        public HttpResponseMessage listDatosDesarrollo()
        {
            List<DatosDesarrollo> datosDesarrollo = new List<DatosDesarrollo>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from datosdesarrollo";

                MySqlDataReader reader = query.ExecuteReader();
                DatosDesarrollo datosDes;
                while (reader.Read())
                {
                    datosDes = new DatosDesarrollo();
                    datosDes.iddatosdesarrollo = (string)reader["iddatosdesarrollo"];
                    datosDes.area = (Double)reader["area"];
                    datosDes.servicios = (Double)reader["servicios"];
                    datosDes.topografia = (Double)reader["topografia"];
                    datosDes.configuracion = (Double)reader["configuracion"];

                    datosDes.Add(datosDes);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, datosDesarrollo);
                return response;

            }
            catch (MySqlException e)
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
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from datosdesarrollo where iddatosdesarrollo = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                DatosDesarrollo datosDesarrollo = new DatosDesarrollo();
                while (reader.Read())
                {
                    datosDes = new DatosDesarrollo();
                    datosDes.iddatosdesarrollo = (string)reader["iddatosdesarrollo"];
                    datosDes.area = (Double)reader["area"];
                    datosDes.servicios = (Double)reader["servicios"];
                    datosDes.topografia = (Double)reader["topografia"];
                    datosDes.configuracion = (Double)reader["configuracion"];
                }
                conn.Close();
                if (datosDesarrollo.iddatosdesarrollo == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, datosDesarrollo);
                return response;

            }
            catch (MySqlException e)
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO datosdesarrollo VALUES (@iddatosdesarrollo,"                                                           + "@area," 
                                                                        + "@servicios," 
                                                                        + "@topografia," +
                                                                        "@configuracion)";

                query.Prepare();
                query.Parameters.AddWithValue("@iddatosdesarrollo", datosDesarrollo.iddatosdesarrollo);
                query.Parameters.AddWithValue("@area", datosDesarrollo.area);
                query.Parameters.AddWithValue("@servicios", datosDesarrollo.servicios);
                query.Parameters.AddWithValue("@topografia", datosDesarrollo.topografia);
                query.Parameters.AddWithValue("@configuracion", configuracion);

                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, datosDesarrollo);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
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

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE datosdesarrollo SET area = @area, servicios = @servicios, topografia = @topografia, configuracion = @configuracion" +
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
            catch (MySql.Data.MySqlClient.MySqlException e)
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
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from datosdesarrollo where iddatosdesarrollo = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }
    }
}
