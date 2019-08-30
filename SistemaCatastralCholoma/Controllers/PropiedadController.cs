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
    public class PropiedadController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();

        // GET: api/Propietario
        [HttpGet]
        public HttpResponseMessage listPropiedades()
        {
            List<Propiedad> propiedades = new List<Propiedad>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.propiedad";

                SqlDataReader reader = query.ExecuteReader();

                Propiedad propiedad;
                while (reader.Read())
                {
                    /*string claveCatastral = (string)reader["claveCatastral"];

                    propiedad = new Propiedad();
                    propiedad.claveCatastral = claveCatastral;
                    propiedad.mapa = (string)reader["mapa"];
                    propiedad.bloque = (string)reader["bloque"];
                    propiedad.predio = (string)reader["predio"];
                    propiedad.propietarioPrincipal = (string)reader["propietarioPrincipal"];
                    propiedad.tipo = (string)reader["tipo"];
                    propiedad.estadoPredio = (string)reader["estadoPredio"];*/

                    string claveCatastral = reader.GetString(0);

                    propiedad = new Propiedad();
                    propiedad.claveCatastral = claveCatastral;
                    propiedad.mapa = reader.GetString(1);
                    propiedad.bloque = reader.GetString(2);
                    propiedad.predio = reader.GetString(3);
                    propiedad.propietarioPrincipal = reader.GetString(4);
                    propiedad.tipo = reader.GetString(6);
                    propiedad.estadoPredio = reader.GetString(7);

                    propiedades.Add(propiedad);
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedades);
                return response;

            }
            catch (SqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
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
                SqlCommand query = conn.CreateCommand();

                query.CommandText = "Select * from bkmilcp6nvs1hgkadyz6.propiedad where claveCatastral = '" + id + "'";

                SqlDataReader reader = query.ExecuteReader();


                Propiedad propiedad = new Propiedad();
                while (reader.Read())
                {
                    /*string claveCatastral = (string)reader["claveCatastral"];

                    propiedad = new Propiedad();
                    propiedad.claveCatastral = claveCatastral;
                    propiedad.mapa = (string)reader["mapa"];
                    propiedad.bloque = (string)reader["bloque"];
                    propiedad.predio = (string)reader["predio"];
                    propiedad.propietarioPrincipal = (string)reader["propietarioPrincipal"];
                    propiedad.tipo = (string)reader["tipo"];
                    propiedad.estadoPredio = (string)reader["estadoPredio"];*/

                    string claveCatastral = reader.GetString(0);

                    propiedad = new Propiedad();
                    propiedad.claveCatastral = claveCatastral;
                    propiedad.mapa = reader.GetString(1);
                    propiedad.bloque = reader.GetString(2);
                    propiedad.predio = reader.GetString(3);
                    propiedad.propietarioPrincipal = reader.GetString(4);
                    propiedad.tipo = reader.GetString(5);
                    propiedad.estadoPredio = reader.GetString(6);
                }
                if (propiedad.claveCatastral == null)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, new ArgumentNullException());
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (SqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
        }

        // POST: api/Propietario
        [HttpPost]
        public HttpResponseMessage createPropiedad(Propiedad propiedad)
        {
            try
            {
                conn.Open();
                SqlCommand my = conn.CreateCommand();
                my.CommandText = "SELECT count(predio) from bkmilcp6nvs1hgkadyz6.propiedad where mapa = '" + propiedad.mapa + "' AND bloque = '" + propiedad.bloque + "';";


                int cant = Convert.ToInt32(my.ExecuteScalar());
                string str1 = "000";//1 digito
                string str2 = "00";//2 digitos
                string str3 = "0";// 3 digitos
                string strca = "";// variable final

                string scant = cant.ToString();
                if (cant < 10)
                {
                    strca = string.Concat(str1,scant);
                }
                else if (cant < 100)
                {
                    strca = string.Concat(str2, scant);
                }
                else if (cant < 1000)
                {
                    strca = string.Concat(str3, scant);
                }

                string claveC = propiedad.claveCatastral + strca;

                SqlCommand query = conn.CreateCommand();
                query.CommandText = "SELECT numeroPredio FROM bkmilcp6nvs1hgkadyz6.predio WHERE mapa = '" + propiedad.mapa+"' AND bloque = '"+propiedad.bloque+"' ORDER BY numeroPredio DESC LIMIT 1;";

                query.CommandText = "INSERT INTO propiedad VALUES (@claveCatastral,"
                                                                + "@mapa,"
                                                                + "@bloque,"
                                                                + "@predio,"
                                                                + "@propietarioPrincipal,"
                                                                + "@propietarios,"
                                                                + "@tipo,"
                                                                + "@estadoPredio);";
                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", claveC);
                query.Parameters.AddWithValue("@mapa", propiedad.mapa);
                query.Parameters.AddWithValue("@bloque", propiedad.bloque);
                query.Parameters.AddWithValue("@predio", strca);
                query.Parameters.AddWithValue("@propietarioPrincipal", propiedad.propietarioPrincipal);
                query.Parameters.AddWithValue("@propietarios", null);
                query.Parameters.AddWithValue("@tipo", propiedad.tipo);
                query.Parameters.AddWithValue("@estadoPredio", propiedad.estadoPredio);
                query.ExecuteNonQuery();
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (SqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
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

                propiedad.claveCatastral = id;

                SqlCommand query = conn.CreateCommand();

                query.CommandText = "UPDATE bkmilcp6nvs1hgkadyz6.propiedad SET propietarioPrincipal = @propietarioPrincipal,"
                                                        + "propietarios = @propietarios,"
                                                        + "tipo = @tipo,"
                                                        + "estadoPredio = @estadoPredio "
                                                        +"WHERE claveCatastral = @claveCatastral";

                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", id);
                query.Parameters.AddWithValue("@propietarioPrincipal", propiedad.propietarioPrincipal);
                query.Parameters.AddWithValue("@propietarios", null);
                query.Parameters.AddWithValue("@tipo", propiedad.tipo);
                query.Parameters.AddWithValue("@estadoPredio", propiedad.estadoPredio);
                query.ExecuteNonQuery();

                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, propiedad);
                return response;

            }
            catch (SqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
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
                SqlCommand query = conn.CreateCommand();
                query.CommandText = "Delete from bkmilcp6nvs1hgkadyz6.propiedad where claveCatastral = @claveCatastral";

                query.Prepare();
                query.Parameters.AddWithValue("@claveCatastral", id);
                query.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.NoContent);
                return response;

            }
            catch (SqlException e)
            {
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.BadRequest,e.Message);
                return response;
            }

        }
    }
}
