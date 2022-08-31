using System;
using System.Collections.Generic;
using System.Text;
using Parcial.Dominio;
using Parcial.Data;

namespace Parical.Logic
{
    public static class ProductoBussinesLogic
    {
        public static List<Producto> Listar()
        {

            var AddProd = new AddProd();
            return AddProd.Listar();
        }

        public static Producto BuscarPorId(int id)
        {

            var addprod = new AddProd();
            return addprod.BuscarPorId(id);

        }

        public static bool Insertar(Producto producto)
        {

            var addProd = new AddProd();
            return addProd.Insertar(producto);

        }

        public static bool Actualizar(Producto producto)
        {
            var addprod = new AddProd();
            return addprod.Actualizar(producto);

        }
        
        public static bool EliminarProducto(int id)
        {

            var addprod = new AddProd();
            return addprod.Eliminar(id);

        }

    }
}
