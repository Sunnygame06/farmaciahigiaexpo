﻿using Factura.Formularios;
using Factura.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura.Controlador.Facturas
{
    internal class ControllerAgregarFactura
    {
        FrmAgregarFactura ObjAgregar;

        public ControllerAgregarFactura(FrmAgregarFactura Vista)
        {
            ObjAgregar = Vista;
            ObjAgregar.Load += new EventHandler(Iniciar);
            ObjAgregar.btnAgregar.Click += new EventHandler(Agregar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            DAOFactura daoCombo = new DAOFactura();
            DataSet ds = daoCombo.VerRoles();

            ObjAgregar.cmbVenta.DataSource = ds.Tables["VerEmpleados"];
            ObjAgregar.cmbVenta.DisplayMember = "Nombre";
            ObjAgregar.cmbVenta.ValueMember = "idEmpleados";
        }

        public void Agregar(object sender, EventArgs e)
        {
            if (ObjAgregar.txtCantidad.Text == "" || ObjAgregar.txtCodigoProducto.Text == "")
            {
                MessageBox.Show("Al gunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DAOFactura daoinsertar = new DAOFactura();
                    daoinsertar.CodigoProducto = int.Parse(ObjAgregar.txtCodigoProducto.Text);
                    bool retorno = daoinsertar.VerCodigo();
                    if (retorno == true)
                    {
                        daoinsertar.Cantidad = int.Parse(ObjAgregar.txtCantidad.Text);
                        daoinsertar.CodigoProducto = int.Parse(ObjAgregar.txtCodigoProducto.Text);
                        daoinsertar.Venta = int.Parse(ObjAgregar.cmbVenta.SelectedValue.ToString());
                        int respuesta = daoinsertar.IngresarPro();
                        if (respuesta == 1)
                        {
                            MessageBox.Show("Los datos han sido ingresados exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ObjAgregar.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Producto es inexistente", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }
    }
}
