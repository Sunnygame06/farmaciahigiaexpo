using Factura.Formularios;
using Factura.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura.Controlador.Facturas
{
    internal class ControllerActualizarFactura
    {
        FrmActualizarFactura ObjActualizar;
        private int Id;

        public ControllerActualizarFactura(FrmActualizarFactura Vista, int id, string Cantidad, string Codigo, string Venta)
        {
            ObjActualizar = Vista;
            this.Id = id;
            ChargeValues(Cantidad, Codigo, Venta);
            ObjActualizar.Load += new EventHandler(Iniciar);
            ObjActualizar.btnActualizar.Click += new EventHandler(Actualizar);
        }

        public void Iniciar(object sendr, EventArgs e)
        {
            DAOFactura daoCombo = new DAOFactura();
            DataSet ds = daoCombo.VerRoles();

            ObjActualizar.cmbVenta.DataSource = ds.Tables["VerEmpleados"];
            ObjActualizar.cmbVenta.DisplayMember = "Nombre";
            ObjActualizar.cmbVenta.ValueMember = "idEmpleados";
        }

        public void Actualizar(object sender, EventArgs e)
        {
            if (ObjActualizar.txtCantidad.Text == "" || ObjActualizar.txtCodigoProducto.Text == "" || ObjActualizar.cmbVenta.Text == "")
            {
                MessageBox.Show("Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DAOFactura daoActualizar = new DAOFactura();
                    daoActualizar.Cantidad = int.Parse(ObjActualizar.txtCantidad.Text.Trim());
                    daoActualizar.CodigoProducto = int.Parse(ObjActualizar.txtCodigoProducto.Text.Trim());
                    daoActualizar.Venta = int.Parse(ObjActualizar.cmbVenta.SelectedValue.ToString());
                    daoActualizar.IdDetalleVenta = Id;
                    int retorno = daoActualizar.ActualizarPro();
                    if (retorno == 1)
                    {
                        MessageBox.Show("Los datos se actualizado correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ObjActualizar.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hubo error al actualizar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        public void ChargeValues(string Cantidad, string Codigo, string Venta)
        {
            ObjActualizar.txtCantidad.Text = Cantidad;
            ObjActualizar.txtCodigoProducto.Text = Codigo;
            ObjActualizar.cmbVenta.SelectedValue = Venta;
        }
    }
}
