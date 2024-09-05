using Login_Farmacia.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_Farmacia.Modelo.DAO;
using System.Data;
using Login_Farmacia.Formularios.Login;
using System.Diagnostics.Eventing.Reader;

namespace Login_Farmacia.Controlador
{
    internal class ControllerRegistrarse
    {
        FrmRegistrarse ObjRegistrarse;

        public ControllerRegistrarse(FrmRegistrarse Vista)
        {
            ObjRegistrarse = Vista;
            ObjRegistrarse.Load += new EventHandler(Iniciar);
            ObjRegistrarse.btnGuardar.Click += new EventHandler(GuardarUser);
            ObjRegistrarse.pictureCopiar.Click += new EventHandler(Copiar);
        }

        public void Iniciar(object sender, EventArgs e)
        {
            Contra();
        }
        public void Copiar(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(ObjRegistrarse.txtpass.Text, true);
                MessageBox.Show("Texto copiado al portapapeles", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al copiar texto al portapapeles: " + ex.Message, "Error al Copiar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GuardarUser(object sender, EventArgs e)
        {
            if (ObjRegistrarse.txtuser.Text == "")
            {
                MessageBox.Show("EC02-El campo 'Usuario' no se han llenado", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ObjRegistrarse.txtuser.Text == "usuario")
                {
                    MessageBox.Show("No puedes guardar tu Usuario como 'usuario'", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DAOLogin daoAdmin = new DAOLogin();
                    bool respuesta = daoAdmin.VerUsuarioAdmin();
                    if (respuesta == true)
                    {
                        DAOLogin daoInsertar = new DAOLogin();
                        daoInsertar.Username1 = ObjRegistrarse.txtuser.Text;
                        daoInsertar.Password1 = Encriptar.Encriptacion(ObjRegistrarse.txtpass.Text);
                        int retorno = daoInsertar.RegistrarseEmpleado();
                        if (retorno == 1)
                        {
                            MessageBox.Show("Datos ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ObjRegistrarse.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DAOLogin daoInsertar = new DAOLogin();
                        daoInsertar.Username1 = ObjRegistrarse.txtuser.Text;
                        daoInsertar.Password1 = Encriptar.Encriptacion(ObjRegistrarse.txtpass.Text);
                        int retorno = daoInsertar.RegistrarseAdmin();
                        if (retorno == 1)
                        {
                            MessageBox.Show("Hola Bienvenido " + ObjRegistrarse.txtuser.Text + " a Farmacia Higia, es un honor recibirte con los brazos abiertos esperamos la pases muy bien, ESPERA SOLO ESTAS TU??!, bueno es momento de encontrar amigos para tu nueva aventura", "Bienvenida a Farmacia Higia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MessageBox.Show("Datos ingresados correctamente", "Accion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ObjRegistrarse.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Hubo error al ingresar los datos", "Accion Interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            
        }
        public void Contra()
        {
            string password = GenerarContra(5);
            ObjRegistrarse.txtpass.Text += password;
        }

        public string GenerarContra(int length)
        {
            const string Validar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            StringBuilder result = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(Validar[random.Next(Validar.Length)]);
            }

            return result.ToString();
        }
    }
}
