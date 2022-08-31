using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Parcial.Dominio;

namespace Parcial.Data
{
    public class ProductoData
    {
        string cadenaConexion = "server=localhost; database=Parcial; Integrated Security=true";
        public List<Producto> Listar()
        {

            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("Select Nombre, Marca, Precio, Stock From Producto", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {

                        if(lector != null && lector.HasRows)
                        {
                            Producto agproducto;
                            while(lector.Read())
                            {

                                agproducto = new Producto();

                                agproducto.IdProducto = int.Parse(lector[0].ToString());
                                agproducto.Nombre = (lector[1].ToString());
                                agproducto.Marca = (lector[2].ToString());
                                agproducto.Precio = decimal.Parse(lector[3].ToString());
                                agproducto.Stock = int.Parse(lector[4].ToString());
                                
                                listado.Add(agproducto);
                            }

                        }

                    }
                }
            }
                
            return listado;

        }

        public bool Insertar()
        {

            return true;
     
        }

    }
}
