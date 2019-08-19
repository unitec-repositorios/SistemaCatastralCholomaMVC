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
    public class FactoresRuralesController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage listFactoresRurales()
        {
            List<FactoresRurales> factoresRurales = new List<FactoresRurales>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.factoresrurales";

                SqlDataReader reader = query.ExecuteReader();
                FactoresRurales factoresrurales;
                while (reader.Read())
                {
                    factoresrurales = new FactoresRurales();
<<<<<<< HEAD
                    factoresrurales.idFactoresRurales = reader.GetInt32(0);
                    factoresrurales.area = reader.GetDouble(1);
                    factoresrurales.ubicacion = reader.GetDouble(2);
                    factoresrurales.servicios = reader.GetDouble(3);
                    factoresrurales.acceso = reader.GetDouble(4);
                    factoresrurales.agua = reader.GetDouble(5);
=======
                    factoresrurales.idFactoresRurales = (string)reader["idfactoresrurales"];
                    factoresrurales.area = (double)reader["area"];
                    factoresrurales.ubicacion = (double)reader["ubicacion"];
                    factoresrurales.servicios = (double)reader["servicios"];
                    factoresrurales.acceso = (double)reader["acceso"];
                    factoresrurales.agua = (double)reader["agua"];
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f

                    factoresRurales.Add(factoresrurales);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, factoresRurales);
                return response;

            }
            catch (SqlException e)
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
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.factoresrurales where id = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                FactoresRurales factoresrurales = new FactoresRurales();
                while (reader.Read())
                {
                    factoresrurales = new FactoresRurales();
<<<<<<< HEAD
                    factoresrurales.idFactoresRurales = reader.GetInt32(0);
                    factoresrurales.area = reader.GetDouble(1);
                    factoresrurales.ubicacion = reader.GetDouble(2);
                    factoresrurales.servicios = reader.GetDouble(3);
                    factoresrurales.acceso = reader.GetDouble(4);
                    factoresrurales.agua = reader.GetDouble(5);
=======
                    factoresrurales.idFactoresRurales = (string)reader["id"];
                    factoresrurales.area = (double)reader["area"];
                    factoresrurales.ubicacion = (double)reader["ubicacion"];
                    factoresrurales.servicios = (double)reader["servicios"];
                    factoresrurales.acceso = (double)reader["acceso"];
                    factoresrurales.agua = (double)reader["agua"];
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f

                }
                conn.Close();
                if (factoresrurales.idFactoresRurales == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());

                var response = Request.CreateResponse(HttpStatusCode.OK, factoresrurales);
                return response;

            }
            catch (SqlException e)
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

                SqlCommand query = conn.CreateCommand();

<<<<<<< HEAD
                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.factoresrurales VALUES (@id,@area,@ubicacion,@servicios,@acceso,@agua);";
=======
                query.CommandText = "INSERT INTO factoresrurales VALUES (@idFactoresRurales," + "@area,"
                                                                        +"@ubicacion,"+"@servicios,"+
                                                                        "@acceso,"+"@agua);";
>>>>>>> 24f97a27102ee2e1caab9fbf83214ca4ab08f84f

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
            catch (SqlException e)
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

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.factoresrurales SET area = @area, ubicacion = @ubicacion,"
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
            catch (SqlException e)
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
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.factoresrurales where id = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }
    }
}