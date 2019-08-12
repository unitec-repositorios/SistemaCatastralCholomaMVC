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
    public class FactoresRuralesController : ApiController
    {
        private MySqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listFactoresRurales()
        {
            List<FactoresRurales> factoresRurales = new List<FactoresRurales>();
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from factoresrurales";

                MySqlDataReader reader = query.ExecuteReader();
                FactoresRurales factoresrurales;
                while (reader.Read())
                {
                    factoresrurales = new FactoresRurales();
                    factoresrurales.idFactoresRurales = (string)reader["idfactoresrurales"];
                    factoresrurales.area = (double)reader["area"];
                    factoresrurales.ubicacion = (double)reader["ubicacion"];
                    factoresrurales.servicios = (double)reader["servicios"];
                    factoresrurales.acceso = (double)reader["acceso"];
                    factoresrurales.agua = (double)reader["agua"];

                    factoresRurales.Add(factoresrurales);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, factoresRurales);
                return response;

            }
            catch (MySqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage getfactoresrurales(int id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from factoresrurales where id = '" + id + "'";

                MySqlDataReader reader = query.ExecuteReader();


                FactoresRurales factoresrurales = new FactoresRurales();
                while (reader.Read())
                {
                    factoresrurales = new FactoresRurales();
                    factoresrurales.idFactoresRurales = (string)reader["id"];
                    factoresrurales.area = (double)reader["area"];
                    factoresrurales.ubicacion = (double)reader["ubicacion"];
                    factoresrurales.servicios = (double)reader["servicios"];
                    factoresrurales.acceso = (double)reader["acceso"];
                    factoresrurales.agua = (double)reader["agua"];

                }
                conn.Close();
                if (factoresrurales.idFactoresRurales == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, factoresrurales);
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
        public HttpResponseMessage crearfactoresrurales(FactoresRurales p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO factoresrurales VALUES (@idFactoresRurales," + "@area,"
                                                                        +"@ubicacion,"+"@servicios,"+
                                                                        "@acceso,"+"@agua);";

                query.Prepare();
                query.Parameters.AddWithValue("@idFactoresRurales", p.idFactoresRurales);
                query.Parameters.AddWithValue("@area", p.area);
                query.Parameters.AddWithValue("@ubicacion", p.ubicacion);
                query.Parameters.AddWithValue("@servicios", p.servicios);
                query.Parameters.AddWithValue("@acceso", p.acceso);
                query.Parameters.AddWithValue("@agua", p.agua);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, p);
                return response;

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage modificarfactoresrurales(string id, FactoresRurales p)
        {
            try
            {
                conn.Open();

                MySqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE factoresrurales SET area = @area, ubicacion = @ubicacion,"
                                                    + "servicios = @servicios, acceso = @acceso, agua = @agua";

                p.idFactoresRurales = id;

                query.Prepare();
                query.Parameters.AddWithValue("@id", p.idFactoresRurales);
                query.Parameters.AddWithValue("@area", p.area);
                query.Parameters.AddWithValue("@ubicacion", p.ubicacion);
                query.Parameters.AddWithValue("@servicios", p.servicios);
                query.Parameters.AddWithValue("@acceso", p.acceso);
                query.Parameters.AddWithValue("@agua", p.agua);
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
        public HttpResponseMessage eliminarfactoresrurales(string id)
        {
            try
            {
                conn.Open();
                MySqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from factoresrurales where idFactoresRurales = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
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