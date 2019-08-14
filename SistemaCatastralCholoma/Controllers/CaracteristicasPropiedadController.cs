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
    public class CaracteristicasPropiedadController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listCaracteristicasPropiedad()
        {
            List<CaracteristicasPropiedad> caracteristicaspropiedad = new List<CaracteristicasPropiedad>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from caracteristicaspropiedad";

                MySqlDataReader reader = query.ExecuteReader();
                CaracteristicasPropiedad caracteristicas;
                while (reader.Read())
                {
                    caracteristicas = new CaracteristicasPropiedad();
                    caracteristicas.idcaracRural = (string)reader["idcaracRural"];
                    caracteristicas.area = (double)reader["area"];
                    caracteristicas.explotacion = (string)reader["explotacion"];
                    caracteristicas.topografia = (string)reader["topografia"];
                    caracteristicas.caudal = (string)reader["caudal"];
                    caracteristicas.pozo = (string)reader["pozo"];
                    caracteristicas.viasComunicacion = (string)reader["viasComunicacion"];

                    caracteristicaspropiedad.Add(caracteristicas);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, caracteristicaspropiedad);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getcaracteristicaspropiedad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from caracteristicaspropiedad where idcaracRural = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                CaracteristicasPropiedad caracteristicas = new CaracteristicasPropiedad();
                while (reader.Read())
                {
                    caracteristicas = new CaracteristicasPropiedad();
                    caracteristicas.idcaracRural = (string)reader["idcaracRural"];
                    caracteristicas.area = (double)reader["area"];
                    caracteristicas.explotacion = (string)reader["explotacion"];
                    caracteristicas.topografia = (string)reader["topografia"];
                    caracteristicas.caudal = (string)reader["caudal"];
                    caracteristicas.pozo = (string)reader["pozo"];
                    caracteristicas.viasComunicacion = (string)reader["viasComunicacion"];

                }
                conn.Close();
                if (caracteristicas.idcaracRural == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, caracteristicas);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage crearcaracteristicaspropiedad(CaracteristicasPropiedad p)
        {   
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO caracteristicaspropiedad VALUES (@idcaracRural,@area,@explotacion,@topografia,@caudal,@pozo,@viasComunicacion);";

                query.Prepare();
                query.Parameters.AddWithValue("@idcaracRural", p.idcaracRural);
                query.Parameters.AddWithValue("@area", p.area);
                query.Parameters.AddWithValue("@explotacion", p.explotacion);
                query.Parameters.AddWithValue("@topografia", p.topografia);
                query.Parameters.AddWithValue("@caudal", p.caudal);
                query.Parameters.AddWithValue("@pozo", p.pozo);
                query.Parameters.AddWithValue("@viasComunicacion", p.viasComunicacion);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadGateway, p);
                return response;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage modificarcaracteristicaspropiedad(string id, CaracteristicasPropiedad p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE caracteristicaspropiedad SET idcaracRural = @idcaracRural, area = @area,"
                                                    + "explotacion = @explotacion, topografia = @topografia, caudal = @caudal,"
                                                    + "pozo = @pozo, viasComunicacion= @viasComunicacion";

                p.idcaracRural = id;

                query.Prepare();
                query.Parameters.AddWithValue("@idcaracRural", p.idcaracRural);
                query.Parameters.AddWithValue("@area", p.area);
                query.Parameters.AddWithValue("@explotacion", p.explotacion);
                query.Parameters.AddWithValue("@topografia", p.topografia);
                query.Parameters.AddWithValue("@caudal", p.caudal);
                query.Parameters.AddWithValue("@pozo", p.pozo);
                query.Parameters.AddWithValue("@viasComunicacion", p.viasComunicacion); ;
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage eliminarcaracteristicaspropiedad(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from caracteristicaspropiedad where idcaracRural = @idcaracRural";

                query.Prepare();
                query.Parameters.AddWithValue("@idcaracRural", id);
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


