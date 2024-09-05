using Factura.Controlador.Facturas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
            ControllerFactura objControl = new ControllerFactura(this);
        }
    }
}
