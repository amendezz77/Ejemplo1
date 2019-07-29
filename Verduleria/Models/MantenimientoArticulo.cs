using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Verduleria.Models
{
    public class MantenimientoArticulo
    {
        private SqlConnection con;

        private void Conectar()
        {
            string cadConection = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(cadConection);
        }

        public void Alta(Articulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into articulos (codigo,descripcion,precio) values (@codigo,@descripcion,@precio)",con);

            comando.Parameters.Add("@codigo",SqlDbType.Int);
            comando.Parameters.Add("@descripcion",SqlDbType.VarChar );
            comando.Parameters.Add("@precio",SqlDbType.Float );

            comando.Parameters["@codigo"].Value = art.Codigo;
            comando.Parameters["@descripcion"].Value = art.Descripcion;
            comando.Parameters["@precio"].Value = art.Precio;

            con.Open();

            int i = comando.ExecuteNonQuery();

            if (i==0) Console.WriteLine("Alta dio  {i}");

            con.Close();


        }

        public void Modificar(Articulo art)
        {
            Conectar();

            SqlCommand comando = new SqlCommand(" update articulos set " +
                                                        "codigo=@codigo," +
                                                        "descripcion=@descripcion," +
                                                        "precio=@precio " +
                                                  "where codigo=@codigo", con);

            comando.Parameters.Add("@codigo",SqlDbType.Int);
            comando.Parameters["@codigo"].Value = art.Codigo;

            comando.Parameters.Add("@descripcion",SqlDbType.VarChar);
            comando.Parameters["@descripcion"].Value = art.Descripcion;

            comando.Parameters.Add("@precio",SqlDbType.Float);
            comando.Parameters["@precio"].Value = art.Precio;

            con.Open();

            int i = comando.ExecuteNonQuery();

            Console.WriteLine("Modificación i: {i}");


            con.Close();

            
        }

        public List<Articulo> RecuperarTodos()
        {
            Conectar();

            List<Articulo> articulos = new List<Articulo>();

            SqlCommand comando = new SqlCommand("select * from articulos", con);

            con.Open();

            SqlDataReader registros = comando.ExecuteReader();

            while (registros.Read())
            {
                Articulo art = new Articulo
                {
                    Codigo = int.Parse(registros["codigo"].ToString()),
                    Descripcion = registros["descripcion"].ToString(),
                    Precio = float.Parse(registros["precio"].ToString())
                };
                articulos.Add(art);
            }

            con.Close();

            return articulos;
            }

        public Articulo Recuperar(int codigo)
        {
            Conectar();

            SqlCommand com = new SqlCommand("select * from articulos where codigo=@codigo", con);

            com.Parameters.Add("@codigo", SqlDbType.Int);
            com.Parameters["@codigo"].Value = codigo;

            con.Open();

            SqlDataReader registros = com.ExecuteReader();

            Articulo art = new Articulo();

            if (registros.Read())
            {
                art.Codigo = int.Parse(registros["codigo"].ToString());
                art.Descripcion = registros["descripcion"].ToString();
                art.Precio = float.Parse(registros["precio"].ToString());
            }

            con.Close();

            return art;
        }

        public int Borrar(int codigo)
        {
            Conectar();

            SqlCommand comando = new SqlCommand("delete articulos where codigo = @codigo", con);

            comando.Parameters.Add("@codigo",SqlDbType.Int);
            comando.Parameters["@codigo"].Value = codigo;

            con.Open();

            int i = comando.ExecuteNonQuery();

            con.Close();

            return i;
        }
        }
    }
