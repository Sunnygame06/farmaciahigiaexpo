﻿using Factura.Controlador.Facturas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura.Formularios
{
    public partial class FrmActualizarFactura : Form
    {
        public FrmActualizarFactura(int id, string Cantidad, string Codigo, string Venta)
        {
            InitializeComponent();
            ControllerActualizarFactura ObjControl = new ControllerActualizarFactura(this, id, Cantidad, Codigo, Venta);
        }
    }
}
