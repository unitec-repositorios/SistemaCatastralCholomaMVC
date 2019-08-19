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
    public class FraccionController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();
        // GET: api/
        [HttpGet]
        public HttpResponseMessage listFraccion()
        {
            try
            {
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("select * from bkmilcp6nvs1hgkadyz6.fraccion", conn);
                reader = cmd.ExecuteReader();
                List<Fraccion> f = new List<Fraccion>();
                while (reader.Read())
                {
                    /*f.Add(new Fraccion((int)reader["idfraccion"], (double)reader["Valor"], (double)reader["Area"],
                        (double)reader["parcelaTipica"], (double)reader["factorModificado"], (double)reader["Frente"],
                        (int)reader["idAvaluoUrbano"]));*/

                    f.Add(new Fraccion(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), 
                        reader.GetDouble(4), reader.GetDouble(5), reader.GetInt32(6)));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, f);
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
                return response;
            }
            conn.Close();
            return null;
        }

        [HttpGet]
        public HttpResponseMessage getFraccion(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from fraccion where bkmilcp6nvs1hgkadyz6.idfraccion = " + id;

                SqlDataReader reader = query.ExecuteReader();


                Fraccion f = new Fraccion();
                while (reader.Read())
                {
                    f = new Fraccion(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3),
                        reader.GetDouble(4), reader.GetDouble(5), reader.GetInt32(6));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, f);
                return response;

            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage createFraccion(Fraccion f)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "INSERT INTO bkmilcp6nvs1hgkadyz6.fraccion VALUES (@idfraccion,@Valor,@Area,@parcelaTipica,@factorModificado,@Frente,@idAvaluoUrbano);";

                query.Prepare();
                query.Parameters.AddWithValue("@idfraccion", f.idfraccion );
                query.Parameters.AddWithValue("@Valor", f.Valor);
                query.Parameters.AddWithValue("@Area", f.Area);
                query.Parameters.AddWithValue("@parcelaTipica", f.parcelaTipica);
                query.Parameters.AddWithValue("@factorModificado", f.factorModificado);
                query.Parameters.AddWithValue("@Frente", f.Frente);
                query.Parameters.AddWithValue("@idAvaluoUrbano", f.idAvaluoUrbano);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, f);
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
        public HttpResponseMessage modifyFraccion(int id,Fraccion f)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.fraccion SET Valor=@Valor," +
                                                            "Area = @Area," +
                                                            "parcelaTipica = @parcelaTipica," +
                                                            "factorModificado = @factorModificado," +
                                                            "Frente = @Frente," +
                                                            "idAvaluoUrbano = @idAvaluoUrbano " +
                                                            "where idfraccion = @idfraccion";

                query.Prepare();
                query.Parameters.AddWithValue("@idfraccion", id);
                query.Parameters.AddWithValue("@Valor", f.Valor);
                query.Parameters.AddWithValue("@Area", f.Area);
                query.Parameters.AddWithValue("@parcelaTipica", f.parcelaTipica);
                query.Parameters.AddWithValue("@factorModificado", f.factorModificado);
                query.Parameters.AddWithValue("@Frente", f.Frente);
                query.Parameters.AddWithValue("@idAvaluoUrbano", f.idAvaluoUrbano);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, f);
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
        public HttpResponseMessage deleteFraccion(int id)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.fraccion where idfraccion = @id";

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