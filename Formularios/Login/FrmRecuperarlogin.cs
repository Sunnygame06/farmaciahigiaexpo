﻿using Login_Farmacia.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Farmacia.Formularios
{
    public partial class FrmRecuperarlogin : Form
    {
        public FrmRecuperarlogin()
        {
            InitializeComponent();
            ControllerRecuperarlogin objControl = new ControllerRecuperarlogin(this);
        }
    }
}
