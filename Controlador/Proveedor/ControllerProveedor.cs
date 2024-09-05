﻿using Login_Farmacia.Formularios;
using Login_Farmacia.Formularios.Proveedor;
using Login_Farmacia.Modelo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Controlador.Proveedor
{
    internal class ControllerProveedor
    {
        FrmProveedor ObjProveedor;

        public ControllerProveedor(FrmProveedor Vista)
        {
            ObjProveedor = Vista;
            ObjProveedor.Load += new EventHandler(Refrescar);
            ObjProveedor.btnCerrarSesion.Click += new EventHandler(Cerrar);
            ObjProveedor.btnLogo.Click += new EventHandler(Logo);
            ObjProveedor.txtBuscar.KeyPress += new KeyPressEventHandler(Buscar);
            ObjProveedor.btnAgregar.Click += new EventHandler(Agregar);
            ObjProveedor.btnActualizar.Click += new EventHandler(Actualizar);
            ObjProveedor.btnEliminar.Click += new EventHandler(Eliminar);
        }

        public void Refrescar(object sender, EventArgs e)
        {
            MostrarProveedores();
        }

        public void MostrarProveedores()
        {
            DAOProveedores ObjAdmin = new DAOProveedores();
            DataSet ds = ObjAdmin.VerProveedores();
            ObjProveedor.ListaProveedores.DataSource = ds.Tables["Proveedor"];
        }

        public void Agregar(object sender, EventArgs e)
        {
            if (ObjProveedor.txtNombreEmpresa.Text == "" || ObjProveedor.txtEmail.Text == "" || ObjProveedor.txtDireccion.Text == "" || ObjProveedor.txtContacto.Text == "")
            {
                MessageBox.Show("EC02-Algunos campos no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DAOProveedores daoInsertar = new DAOProveedores();
                daoInsertar.NombreE = ObjProveedor.txtNombreEmpresa.Text;
                daoInsertar.Contacto = ObjProveedor.txtContacto.Text;
                daoInsertar.Direccion = ObjProveedor.txtDireccion.Text;
                daoInsertar.Email = ObjProveedor.txtEmail.Text;
                int retorno = daoInsertar.IngresarProveedor();
                if (retorno == 1)
                {
                    MessageBox.Show("Datos ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarProveedores();
                    Refrescar();
                }
                else
                {
                    MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Actualizar(object sender, EventArgs e)
        {
            int pos = ObjProveedor.ListaProveedores.CurrentRow.Index;
            int id;
            string NombreE, Contacto, Direccion, Email;

            id = int.Parse(ObjProveedor.ListaProveedores[0, pos].Value.ToString());
            NombreE = ObjProveedor.ListaProveedores[1, pos].Value.ToString();
            Contacto = ObjProveedor.ListaProveedores[2, pos].Value.ToString();
            Direccion = ObjProveedor.ListaProveedores[3, pos].Value.ToString();
            Email = ObjProveedor.ListaProveedores[4, pos].Value.ToString();

            FrmActualizarPro open = new FrmActualizarPro(id, NombreE, Contacto, Direccion, Email);
            open.ShowDialog();
            MostrarProveedores();
        }

        public void Eliminar(object sender, EventArgs e)
        {
            int pos = ObjProveedor.ListaProveedores.CurrentRow.Index;
            if (MessageBox.Show($"Esta seguro de eliminar estos datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOProveedores daoEliminar = new DAOProveedores();
                daoEliminar.IdProvedor = int.Parse(ObjProveedor.ListaProveedores[0, pos].Value.ToString());
                int retorno = daoEliminar.EliminarProveedor();
                if (retorno == 1)
                {
                    MessageBox.Show("Los datos se han eliminado exitosamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarProveedores();
                }
                else
                {
                    MessageBox.Show("Ha surgido un error al eliminar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Cerrar(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Estas seguro de cerrar sesion temporalmente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Frmlogin Login = new Frmlogin();
                Login.Show();
                ObjProveedor.Hide();
            }
        }

        public void Logo(object sender, EventArgs e)
        {
            Frmusers open = new Frmusers();
            open.Show();
            ObjProveedor.Hide();
        }

        public void Buscar(object sender, EventArgs e)
        {
            DAOProveedores ObjBuscar = new DAOProveedores();
            DataSet ds = ObjBuscar.BuscarProveedores(ObjProveedor.txtBuscar.Text.Trim());
            ObjProveedor.ListaProveedores.DataSource = ds.Tables["Proveedor"];
        }

        public void Refrescar()
        {
            ObjProveedor.txtNombreEmpresa.Text = "";
            ObjProveedor.txtEmail.Text = "";
            ObjProveedor.txtDireccion.Text = "";
            ObjProveedor.txtContacto.Text = "";
        }
    }
}
