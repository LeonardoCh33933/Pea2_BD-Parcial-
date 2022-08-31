using System;
using System.Collections.Generic;
using System.Text;
using Parcial.Dominio;
using System.Data.SqlClient;

namespace Parcial.Data
{
    public class AddProd
    {
        string cadenaConexion = "server=localhost; Database=Parcial; Integrated Security = true";
        public List<Producto> Listar()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("Select IdProducto, Nombre, Marca, Precio, Stock From Producto WHERE Precio <= 2500 AND Stock > 5" , conexion))
                {

                    using (var lector = comando.ExecuteReader())
                    {

                        if(lector != null && lector.HasRows)
                        {
                            Producto producto;
                            while (lector.Read())
                            {

                                producto = new Producto();

                                producto.IdProducto = int.Parse(lector[0].ToString());
                                producto.Nombre = (lector[1].ToString());
                                producto.Marca = (lector[2].ToString());
                                producto.Precio = decimal.Parse(lector[3].ToString());
                                producto.Stock = int.Parse(lector[4].ToString());
                                
                                listado.Add(producto);

                            }


                        }

                    }

                }

            }
                
            return listado; 

        }

        public Producto BuscarPorId(int id)
        {
            var producto = new Producto();
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("SELECT * FROM Producto WHERE IdProducto = @id ", conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            producto = new Producto();

                            producto.IdProducto = int.Parse(lector[0].ToString());
                            producto.Nombre = (lector[1].ToString());
                            producto.Marca = (lector[2].ToString());
                            producto.Precio = decimal.Parse(lector[3].ToString());
                            producto.Stock = int.Parse(lector[4].ToString());


                        }
                    }

                }

            }
            return producto;

        }

        public bool Insertar(Producto producto)
        {
            int filasInsertadas = 0;
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                using(var comando = new SqlCommand("INSERT INTO Producto (Nombre, Marca, Precio, Stock) VALUES (@Nombre, @Marca, @Precio, @Stock)", conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);

                    filasInsertadas = comando.ExecuteNonQuery();
                }
            }    
            return filasInsertadas > 0;

        }

        public bool Actualizar(Producto producto)
        {
            int filasActualizadas = 0;
            using(var conexion = new SqlConnection(cadenaConexion))
            {

                conexion.Open();
                using(var comando = new SqlCommand("UPDATE Producto SET Nombre = @nombre, Marca = @marca, Precio = @precio, Stock = @stock WHERE IdProducto = @id", conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@id", producto.IdProducto);
                    filasActualizadas = comando.ExecuteNonQuery();



                }

            }
            return filasActualizadas > 0;

        }

        public bool Eliminar(int id)
        {
            int filasEliminadas = 0;
            using(var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using(var comando = new SqlCommand("DELETE  From Producto WHERE IdProducto = @id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    filasEliminadas = comando.ExecuteNonQuery();
                }

            }


            return filasEliminadas > 0;

        }



    }
}
