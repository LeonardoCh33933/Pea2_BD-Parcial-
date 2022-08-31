using Parcial.Dominio;
using Parical.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial.AppWin
{
    public partial class frmProducto : Form
    {
        Producto producto;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ProductoBussinesLogic.Listar();
            dgvDatos.Rows.Clear();
            foreach (var producto in listado)
            {
                dgvDatos.Rows.Add(producto.IdProducto, producto.Nombre, producto.Marca, producto.Precio, producto.Stock);
            }

        }

        private void NuevoRegistro(object sender, EventArgs e)
        {
            var nuevoProducto = new Producto();
            var frm = new frmProductoEdit(nuevoProducto);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var producto = new Producto();

                var exito = ProductoBussinesLogic.Insertar(nuevoProducto);

                if (producto.Precio >= 2500 && producto.Stock < 5)
                {
                    MessageBox.Show("Cantidades no requeridas", "Parcial");


                }


                else if (exito)
                {

                    MessageBox.Show("Producto registrado con exito", "Parcial", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    cargarDatos();


                }
                else
                {

                    MessageBox.Show("No se ha podido registrar el producto", "Parcial", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
                }

            }

        private void EditarRegistro(object sender, EventArgs e)
        {
            if(dgvDatos.Rows.Count > 0)
            {

                int filaActual = dgvDatos.CurrentRow.Index;
                var idProducto = int.Parse(dgvDatos.Rows[filaActual].Cells[0].Value.ToString());
                var productoEditar = ProductoBussinesLogic.BuscarPorId(idProducto);
                var frm = new frmProductoEdit(productoEditar);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ProductoBussinesLogic.Actualizar(productoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El cliente ha sido actualizado", "Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();

                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la operacion de actualizacion", "Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private void EliminarRegistro(object sender, EventArgs e)
        {
            if(dgvDatos.Rows.Count > 0)
            {
                int filaActual = dgvDatos.CurrentRow.Index;
                var idprod = int.Parse(dgvDatos.Rows[filaActual].Cells[0].Value.ToString());
                var nameprod = dgvDatos.Rows[filaActual].Cells[1].Value.ToString();

                var rpta = MessageBox.Show("Desea eliminar este producto? D:", "Parcial", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {

                    var exito = ProductoBussinesLogic.EliminarProducto(idprod);
                    if (exito)  
                    {

                        MessageBox.Show("Producto eliminado", "Parcial",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();

                    }
                    else
                    {

                        MessageBox.Show("No se pudo completar la eliminacion", "Parcial", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

            }
        }
    }
    
}
