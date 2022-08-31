using Parcial.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Parcial.AppWin
{
    public partial class frmProductoEdit : Form
    {
        Producto producto;
        public frmProductoEdit(Producto producto) // producto = parametro
        {
            InitializeComponent();
            this.producto = producto;


        }

        private void IniciarFormulario(object sender, EventArgs e)
        {
           if(producto.IdProducto > 0)
            {

                asignarControles();

            }
        }

        private void asignarObjeto()
        {

            this.producto.Nombre = txtNombre.Text;
            this.producto.Marca = txtMarca.Text;
            this.producto.Precio = decimal.Parse(txtPrecio.Text);
            this.producto.Stock = int.Parse(txtStock.Text);
        }

        private void asignarControles()
        {
            txtNombre.Text = producto.Nombre;
            txtMarca.Text = producto.Marca;
            decimal.Parse(txtPrecio.Text = producto.Precio.ToString());
            int.Parse(txtStock.Text = producto.Stock.ToString());
            

        }


        private void GrabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }
    }
}
