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
    public class FichaCatastralController : ApiController
    {

        private MySqlConnection conn = WebApiConfig.conn();
        // GET: api/
        public List<FichaCatastral> GetAllFichaCatastral()
        {
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from FichasCatastrales", conn);
                reader = cmd.ExecuteReader();
                List<FichaCatastral> fichas = new List<FichaCatastral>();
                while (reader.Read())
                {
                    fichas.Add(new FichaCatastral((String)reader["cocata"], (String)reader["depto"],
                        (String)reader["municipio"], (String)reader["aldea"], (String)reader["mapa"], 
                        (String)reader["bolque"], (String)reader["predio"], (String)reader["num"], 
                        (String)reader["maq"], (String)reader["st"], (String)reader["codProp"], 
                        (String)reader["codHab"], (String)reader["noLinea"], (String)reader["noFoto"], 
                        (String)reader["poblacion"], (String)reader["identidadPropietario"],
                        (String)reader["tomo"],(String)reader["asiento"]));
                }
                conn.Close();
                return fichas;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }

        // GET: api/FichaCatastral/5
        public FichaCatastral Get(string cocata)
        {
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from FichasCatastrales where cocata = '" + cocata + "'", conn);
                reader = cmd.ExecuteReader();
                FichaCatastral ficha = new FichaCatastral();
                while (reader.Read())
                {
                    ficha = new FichaCatastral((String)reader["cocata"], (String)reader["depto"],
                        (String)reader["municipio"], (String)reader["aldea"], (String)reader["mapa"],
                        (String)reader["bolque"], (String)reader["predio"], (String)reader["num"],
                        (String)reader["maq"], (String)reader["st"], (String)reader["codProp"],
                        (String)reader["codHab"], (String)reader["noLinea"], (String)reader["noFoto"],
                        (String)reader["poblacion"], (String)reader["identidadPropietario"],
                        (String)reader["tomo"],(String)reader["asiento"]);
                }
                conn.Close();
                return ficha;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }
    

        // POST: api/FichaCatastral
        public void Post(FichaCatastral ficha)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "insert into FichasCatastrales values (@cocata, @depto,@municipio,@aldea,@mapa,@bolque,@predio,@num,@maq,@st,@codProp,@codHab," +
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
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }

        // PUT: api/FichaCatastral/5
        public void Put(FichaCatastral ficha)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "UPDATE FichasCatastrales SET cocata = @cocata, depto = @depto, municipio = @municipio, aldea = @aldea," +
                    "mapa = @mapa, bolque = @bolque, predio = @predio, num = @num,maq = @maq,st = @st,codProp = @codProp, codHab = @codHab," +
                    " noLinea = @noLinea, noFoto = @noFoto, poblacion = @poblacion, identidadPropietario = @identidadPropietario, tomo = @tomo," +
                    "FichasCatastrales.asiento = @asiento WHERE cocata = @cocataCode";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@cocataCode", ficha.cocata);
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
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }

        // DELETE: api/FichaCatastral/5
        public void Delete(string cocata)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "delete from FichasCatastrales where cocata = @cocata";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@cocata", cocata);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }
    
    }
}
