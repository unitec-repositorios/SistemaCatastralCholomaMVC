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
    public class servicioController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[servicio]";
        [HttpGet]
        public HttpResponseMessage listManPropietarios()
        {
            List<servicio> mp = new List<servicio>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"select * from {DatabaseReference}";
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    mp.Add(new servicio(reader.GetString(0)));
                }
                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, mp);
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
        public HttpResponseMessage getMpId(string serv)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"select * from {DatabaseReference} where serv = " + serv;

                SqlDataReader reader = query.ExecuteReader();

                string tmp = reader.GetString(0);

                reader.Close();
                conn.Close();

                var response = Request.CreateResponse(HttpStatusCode.OK, tmp);
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

        [HttpPost]
        public HttpResponseMessage crearMP(servicio mp)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"insert into {DatabaseReference} values (@serv)";

                query.Prepare();
                query.Parameters.AddWithValue("@serv", mp.serv);
                query.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, mp);
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

        [HttpPut]
        public HttpResponseMessage modificarMP(string old, servicio mp)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"update {DatabaseReference} set serv = @serv where serv = " + old;

                query.Prepare();
                query.Parameters.AddWithValue("@serv", mp.serv);
                query.ExecuteNonQuery();

                conn.Close();
                var response = Request.CreateResponse(HttpStatusCode.OK, mp);
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

        [HttpDelete]
        public HttpResponseMessage deleteMP(string old)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"delete from {DatabaseReference} where serv = @serv";

                query.Prepare();
                query.Parameters.AddWithValue("@serv", old);
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
