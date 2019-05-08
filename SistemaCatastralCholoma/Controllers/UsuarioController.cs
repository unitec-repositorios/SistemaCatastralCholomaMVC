using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace SistemaCatastralCholoma.Controllers
{
    public class UsuarioController : ApiController
    {
        private string connectionString = "server=bkmilcp6nvs1hgkadyz6-mysql.services.clever-cloud.com;uid=uedhxkzl6doratlh;pwd=xDdW8Ro6Rg01GUnJsjLW;database=bkmilcp6nvs1hgkadyz6";

        // GET: api/Usuario
        public List<Usuario> Get()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from usuario", conn);
                reader = cmd.ExecuteReader();
                List<Usuario> users = new List<Usuario>();
                while (reader.Read())
                {
                    string nombre = reader.GetString(0);
                    string pass = reader.GetString(1);
                    users.Add(new Usuario(nombre, pass));
                }
                conn.Close();
                return users;
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }

        // GET: api/Usuario/5
        public Usuario Get(string nombre)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();

                string username = "";
                string pass = "";

                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand("select * from usuario where nombre = " + username, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    username = reader.GetString(0);
                    pass = reader.GetString(1);
                }
                Usuario nuevoUsuario = new Usuario(username, pass);
                conn.Close();
                return nuevoUsuario;
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
            return null;
        }

        // POST: api/Usuario
        public void Post(Usuario n)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "insert into usuario values (@nombre, @pass)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nombre", n.nombre);
                cmd.Parameters.AddWithValue("@pass", n.password);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }


        // PUT: api/Usuario/5
        public void Put(Usuario n)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "update usuario set password = @pass where nombre = @nomb";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nomb", n.nombre);
                cmd.Parameters.AddWithValue("@pass", n.password);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }

        // DELETE: api/Usuario/5
        public void Delete(string nomb)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "delete from usuario where nombre = @nomb";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@nomb", nomb);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            conn.Close();
        }
    }
}
