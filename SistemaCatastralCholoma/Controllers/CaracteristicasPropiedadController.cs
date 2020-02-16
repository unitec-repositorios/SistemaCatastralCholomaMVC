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
    public class CaracteristicasPropiedadController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[caracteristicaspropiedad]";
        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listCaracteristicasPropiedad()
        {
            List<CaracteristicasPropiedad> caracteristicaspropiedad = new List<CaracteristicasPropiedad>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"Select * from {DatabaseReference}";

                SqlDataReader reader = query.ExecuteReader();
                CaracteristicasPropiedad caracteristicas;
                while (reader.Read())
                {
                    caracteristicas = new CaracteristicasPropiedad();
                    caracteristicas.idcaracRural = reader.GetString(0);
                    caracteristicas.area = reader.GetDouble(1);
                    caracteristicas.explotacion = reader.GetString(2);
                    caracteristicas.topografia = reader.GetString(3);
                    caracteristicas.caudal = reader.GetString(4);
                    caracteristicas.pozo = reader.GetString(5);
                    caracteristicas.viasComunicacion = reader.GetString(6);

                    caracteristicaspropiedad.Add(caracteristicas);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, caracteristicaspropiedad);
                return response;

            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getcaracteristicaspropiedad(string id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"Select * from {DatabaseReference} where id = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                CaracteristicasPropiedad caracteristicas = new CaracteristicasPropiedad();
                while (reader.Read())
                {
                    caracteristicas = new CaracteristicasPropiedad();
                    caracteristicas.idcaracRural = reader.GetString(0);
                    caracteristicas.area = reader.GetDouble(1);
                    caracteristicas.explotacion = reader.GetString(2);
                    caracteristicas.topografia = reader.GetString(3);
                    caracteristicas.caudal = reader.GetString(4);
                    caracteristicas.pozo = reader.GetString(5);
                    caracteristicas.viasComunicacion = reader.GetString(6);

                }
                conn.Close();
                if (caracteristicas.idcaracRural == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, caracteristicas);
                return response;

            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
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

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"INSERT INTO {DatabaseReference} VALUES (@idcaracRural,@area,@explotacion,@topografia,@caudal,@pozo,@viasComunicacion);";

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
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadGateway, e.Message.ToString());
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

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"UPDATE {DatabaseReference} SET idcaracRura = @idcaracRura, area = @area,"
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
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
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
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"Delete from {DatabaseReference} where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@idcaracRural", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message.ToString());
                return response;
            }
        }
    }
}


