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
    public class tipoEmpresaController : ApiController
    {
        private SqlConnection conn = WebApiConfig.conn();
        String DatabaseReference = WebApiConfig.DatabaseName() + ".[tipoEmpresa]";

        [HttpGet]
        public HttpResponseMessage listManPropietarios()
        {
            List<tipoEmpresa> mp = new List<tipoEmpresa>();
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"select * from {DatabaseReference}";
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    mp.Add(new tipoEmpresa(reader.GetString(0)));
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
        public HttpResponseMessage getMpId(string empresa)
        {
            try
            {
                conn.Open();

                SqlCommand query = conn.CreateCommand();

                query.CommandText = $"select * from {DatabaseReference} where empresa = " + empresa;

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
        public HttpResponseMessage crearMP(tipoEmpresa mp)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"insert into {DatabaseReference} values (@empresa)";

                query.Prepare();
                query.Parameters.AddWithValue("@empresa", mp.empresa);
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
        public HttpResponseMessage modificarMP(string old, tipoEmpresa mp)
        {
            try
            {
                conn.Open();
                SqlCommand query = conn.CreateCommand();
                query.CommandText = $"update {DatabaseReference} set empresa = @empresa where empresa = " + old;

                query.Prepare();
                query.Parameters.AddWithValue("@empresa", mp.empresa);
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
                query.CommandText = $"delete from {DatabaseReference} where empresa = @empresa";

                query.Prepare();
                query.Parameters.AddWithValue("@empresa", old);
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
