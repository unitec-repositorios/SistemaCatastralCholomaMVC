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
    public class PropiedadController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET: api/Propietario
        [HttpGet]
        public HttpResponseMessage listPropiedades()
        {
            List<Propiedad> propiedades = new List<Propiedad>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propiedad";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    propiedades.Add(new Propiedad((string)reader["claveCatastral"],(string)reader["propietario"], (string)reader["tipoPropiedad"]));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedades);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e);
                return response;
            }
        }

        // GET: api/Propietario/5
        [HttpGet]
        public HttpResponseMessage getPropiedad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from propiedad where claveCatastral = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                Propiedad propiedad = new Propiedad();
                while (reader.Read())
                {
                    propiedad = new Propiedad((string)reader["claveCatastral"], (string)reader["propietario"], (string)reader["tipoPropiedad"]);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e);
                return response;
            }
        }

        // POST: api/Propietario
        [HttpPost]
        public HttpResponseMessage crearPropiedad(Propiedad propiedad)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO propiedad VALUES (@claveCatastral,@propietario,@tipoPropiedad);";

                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", propiedad.claveCatastral);
                query.Parameters.AddWithValue("@propietario", propiedad.propietario);
                query.Parameters.AddWithValue("@tipoPropiedad", propiedad.tipoPropiedad);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // PUT: api/Propietario/5
        [HttpPut]
        public HttpResponseMessage modificarPropiedad(string id, Propiedad propiedad)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE propiedad SET propietario = @propietario, tipoPropiedad = @tipoPropiedad where claveCatastral = @claveCatastral";

                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", id);
                query.Parameters.AddWithValue("@propietario", propiedad.propietario);
                query.Parameters.AddWithValue("@tipoPropiedad", propiedad.tipoPropiedad);
                query.ExecuteNonQuery();

                conn.Close();
                propiedad.claveCatastral = id;
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // DELETE: api/Propietario/5
        [HttpDelete]
        public HttpResponseMessage eliminarPropiedad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from propiedad where claveCatastral = @claveCatastral";

                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }
    }
}
