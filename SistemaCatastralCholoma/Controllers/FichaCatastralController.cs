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
    public class FichaCatastralController : ApiController
    {

        private SqlConnection conn = WebApiConfig.conn();
        // GET: api/
        [HttpGet]
        public List<FichaCatastral> listFichaCatastral()
        {
            try
            {
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("select * from bkmilcp6nvs1hgkadyz6.FichasCatastrales", conn);
                reader = cmd.ExecuteReader();
                List<FichaCatastral> fichas = new List<FichaCatastral>();
                while (reader.Read())
                {
                    /*fichas.Add(new FichaCatastral((String)reader["cocata"], (String)reader["depto"],
                        (String)reader["municipio"], (String)reader["aldea"], (String)reader["mapa"], 
                        (String)reader["bolque"], (String)reader["predio"], (String)reader["num"], 
                        (String)reader["maq"], (String)reader["st"], (String)reader["codProp"], 
                        (String)reader["codHab"], (String)reader["noLinea"], (String)reader["noFoto"], 
                        (String)reader["poblacion"], (String)reader["identidadPropietario"],
                        (String)reader["tomo"],(String)reader["asiento"]));*/

                    fichas.Add(new FichaCatastral(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
                        reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10),
                        reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17)));
                }
                conn.Close();
                return fichas;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }

        // GET: api/FichaCatastral/5
        [HttpGet]
        public HttpResponseMessage getFichaCatastral(string cocata)
        {
            try
            {
                conn.Open();
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand("select * from bkmilcp6nvs1hgkadyz6.FichasCatastrales where cocata = '" + cocata + "'", conn);
                reader = cmd.ExecuteReader();
                FichaCatastral ficha = new FichaCatastral();

                    ficha = new FichaCatastral(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
                        reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10),
                        reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17));


                var response = Request.CreateResponse(HttpStatusCode.OK, ficha);
                conn.Close();
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;

            }
            conn.Close();
            return null;
        }
    

        // POST: api/FichaCatastral
        [HttpPost]
        public HttpResponseMessage createFichaCatastral(FichaCatastral ficha)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                string query = "insert into bkmilcp6nvs1hgkadyz6.FichasCatastrales values (@cocata, @depto,@municipio,@aldea,@mapa,@bolque,@predio,@num,@maq,@st,@codProp,@codHab," +
                    "@noLinea,@noFoto,@poblacion,@identidadPropietario,@tomo,@asiento)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@cocata", ficha.depto+ficha.municipio+ficha.aldea+ficha.mapa+ficha.bolque+ficha.predio+ficha.num);
                cmd.Parameters.AddWithValue("@depto", ficha.depto);
                cmd.Parameters.AddWithValue("@municipio", ficha.municipio);
                cmd.Parameters.AddWithValue("@aldea", ficha.aldea);
                cmd.Parameters.AddWithValue("@mapa", ficha.mapa);
                cmd.Parameters.AddWithValue("@bolque", ficha.bolque);
                cmd.Parameters.AddWithValue("@predio", ficha.predio);
                cmd.Parameters.AddWithValue("@num", ficha.num);
                cmd.Parameters.AddWithValue("@maq", ficha.maq);
                cmd.Parameters.AddWithValue("@st", ficha.st);
                cmd.Parameters.AddWithValue("@codProp", ficha.codProp);
                cmd.Parameters.AddWithValue("@codHab", ficha.codHab);
                cmd.Parameters.AddWithValue("@noLinea", ficha.noLinea);
                cmd.Parameters.AddWithValue("@noFoto", ficha.noFoto);
                cmd.Parameters.AddWithValue("@poblacion", ficha.poblacion);
                cmd.Parameters.AddWithValue("@identidadPropietario", ficha.identidadPropietario);
                cmd.Parameters.AddWithValue("@tomo", ficha.tomo);
                cmd.Parameters.AddWithValue("@asiento", ficha.asiento);
                cmd.ExecuteNonQuery();

                var response = Request.CreateResponse(HttpStatusCode.OK);
                conn.Close();

                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
            conn.Close();
        }

        // PUT: api/FichaCatastral/5
        [HttpPut]
        public HttpResponseMessage modifyFichaCatastral(string id, FichaCatastral ficha)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                string query = "UPDATE bkmilcp6nvs1hgkadyz6.FichasCatastrales SET cocata = @cocata, depto = @depto, municipio = @municipio, aldea = @aldea," +
                    "mapa = @mapa, bolque = @bolque, predio = @predio, num = @num,maq = @maq,st = @st,codProp = @codProp, codHab = @codHab," +
                    " noLinea = @noLinea, noFoto = @noFoto, poblacion = @poblacion, identidadPropietario = @identidadPropietario, tomo = @tomo," +
                    "FichasCatastrales.asiento = @asiento WHERE cocata = @cocataCode";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@cocataCode", id);
                cmd.Parameters.AddWithValue("@cocata", ficha.depto + ficha.municipio + ficha.aldea + ficha.mapa + ficha.bolque + ficha.predio + ficha.num);
                cmd.Parameters.AddWithValue("@depto", ficha.depto);
                cmd.Parameters.AddWithValue("@municipio", ficha.municipio);
                cmd.Parameters.AddWithValue("@aldea", ficha.aldea);
                cmd.Parameters.AddWithValue("@mapa", ficha.mapa);
                cmd.Parameters.AddWithValue("@bolque", ficha.bolque);
                cmd.Parameters.AddWithValue("@predio", ficha.predio);
                cmd.Parameters.AddWithValue("@num", ficha.num);
                cmd.Parameters.AddWithValue("@maq", ficha.maq);
                cmd.Parameters.AddWithValue("@st", ficha.st);
                cmd.Parameters.AddWithValue("@codProp", ficha.codProp);
                cmd.Parameters.AddWithValue("@codHab", ficha.codHab);
                cmd.Parameters.AddWithValue("@noLinea", ficha.noLinea);
                cmd.Parameters.AddWithValue("@noFoto", ficha.noFoto);
                cmd.Parameters.AddWithValue("@poblacion", ficha.poblacion);
                cmd.Parameters.AddWithValue("@identidadPropietario", ficha.identidadPropietario);
                cmd.Parameters.AddWithValue("@tomo", ficha.tomo);
                cmd.Parameters.AddWithValue("@asiento", ficha.asiento);
                cmd.ExecuteNonQuery();
                var response = Request.CreateResponse(HttpStatusCode.OK);

                conn.Close();
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                return response;
            }
            conn.Close();
            return null;
        }

        // DELETE: api/FichaCatastral/5
        [HttpDelete]
        public HttpResponseMessage deleteFichaCatastral(string cocata)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                string query = "delete from bkmilcp6nvs1hgkadyz6.FichasCatastrales where cocata = @cocata";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@cocata", cocata);
                cmd.ExecuteNonQuery();
                { }
                var response = Request.CreateResponse(HttpStatusCode.OK);

                conn.Close();
                return response;
            }
            catch (SqlException e)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest, e);
                conn.Close();
                return response;
            }
            conn.Close();
            return null;
        }
    
    }
}
