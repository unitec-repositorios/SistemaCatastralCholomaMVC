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
    public class PisoController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();
        // GET: api/
        [HttpGet]
        public HttpResponseMessage listPiso()
        {
            try
            {
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("select * from bkmilcp6nvs1hgkadyz6.piso", conn);
                reader = cmd.ExecuteReader();
                List<Piso> pisos = new List<Piso>();
                while (reader.Read())
                {
                    /*pisos.Add(new Piso((int)reader["idpiso"], (int)reader["num"],
                        (double)reader["area"], (int)reader["uso"], (String)reader["clase"],
                        (String)reader["calidad"], (double)reader["costo"], (String)reader["bueno"], (String)reader["idAvaluoEdificaciones"]));*/

                    pisos.Add(new Piso(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetInt32(3), reader.GetString(4),
                        reader.GetString(5), reader.GetDouble(6), reader.GetString(7), reader.GetString(8)));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, pisos);
                return response;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }

        [HttpGet]
        public HttpResponseMessage getPiso(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.piso where idpiso = " + id;

                SqlDataReader reader = query.ExecuteReader();


                Piso piso = new Piso();
                while (reader.Read())
                {
                    //piso = new Piso((int)reader["idpiso"], (int)reader["num"], (double)reader["area"],
                    //    (int)reader["uso"], (string)reader["clase"], (string)reader["calidad"], (double)reader["costo"], (string)reader["bueno"], (string)reader["idAvaluoEdificaciones"]);

                    piso = new Piso(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetInt32(3), reader.GetString(4),
                        reader.GetString(5), reader.GetDouble(6), reader.GetString(7), reader.GetString(8));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, piso);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage createPiso(Piso piso)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.piso VALUES (@idpiso,@num,@area,@uso,@clase,@calidad,@costo,@bueno,@idAvaluoEdificaciones);";

                query.Prepare();
                query.Parameters.AddWithValue("@idpiso", piso.idpiso);
                query.Parameters.AddWithValue("@num", piso.num);
                query.Parameters.AddWithValue("@area", piso.area);
                query.Parameters.AddWithValue("@uso", piso.uso);
                query.Parameters.AddWithValue("@clase", piso.clase);
                query.Parameters.AddWithValue("@calidad", piso.calidad);
                query.Parameters.AddWithValue("@costo", piso.costo);
                query.Parameters.AddWithValue("@bueno", piso.bueno);
                query.Parameters.AddWithValue("@idAvaluoEdificaciones", piso.idAvaluoEdificaciones);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, piso);
                return response;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        // PUT: api/Propietario/5
        [HttpPut]
        public HttpResponseMessage modifyPiso(int id, Piso piso)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.piso SET num=@num," +
                                                            "area = @area," +
                                                            "uso = @uso," +
                                                            "clase = @clase," +
                                                            "calidad = @calidad," +
                                                            "costo = @costo,"+
                                                            "bueno = @bueno,"+
                                                            "idAvaluoEdificaciones = @idAvaluoEdificaciones"+
                                                            "where idpiso = @idpiso";

                query.Prepare();
                query.Parameters.AddWithValue("@idpiso", id);
                query.Parameters.AddWithValue("@area", piso.area);
                query.Parameters.AddWithValue("@num", piso.num);
                query.Parameters.AddWithValue("@uso", piso.uso);
                query.Parameters.AddWithValue("@clase", piso.clase);
                query.Parameters.AddWithValue("@calidad", piso.calidad);
                query.Parameters.AddWithValue("@costo", piso.costo);
                query.Parameters.AddWithValue("@bueno", piso.bueno);
                query.Parameters.AddWithValue("@idAvaluoEdificaciones", piso.idAvaluoEdificaciones);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, piso);
                return response;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage deletePiso(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.piso where idpiso = @id";

                query.Prepare();
                query.Parameters.AddWithValue("@id", id);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }
    }
}