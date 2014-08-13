using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Hamma_Beads.Formularios
{
    public partial class Frm_RedimImage : Form
    {
        #region Properties

        private string _RutaImagen = string.Empty;
        public string RutaImagen 
        { 
            get
            {
                return _RutaImagen;
            }
            set
            {
                if (_RutaImagen != value)
                {
                    _RutaImagen = value;
                    Cargar_Datos_Imagen();
                }
            }
        }
        private Bitmap _bmpImagen;
        private int _AnchoOriginal, _AltoOriginal, _Ancho, _Alto;
        public int AnchoOriginal 
        {
            get
            {
                return _AnchoOriginal;
            }
            set
            {
                if (_AnchoOriginal != value)
                {
                    _AnchoOriginal = value;
                    txtAnchoOriginal.Text = _AnchoOriginal.ToString();
                }
            }
        }
        public int AltoOriginal 
        {
            get
            {
                return _AltoOriginal;
            }
            set
            {
                if (_AltoOriginal != value)
                {
                    _AltoOriginal = value;
                    txtAltoOriginal.Text = _AltoOriginal.ToString();
                }
            }
        }
        public int Ancho 
        {
            get
            {
                return _Ancho;
            }
            set
            {
                if (_Ancho != value)
                {
                    _Ancho = value;
                    txtAncho.Text = _Ancho.ToString();
                }
            }
        }
        public int Alto 
        {
            get
            {
                return _Alto;
            }
            set
            {
                if (_Alto != value)
                {
                    _Alto = value;
                    txtAlto.Text = _Alto.ToString();
                }
            }
        }

        #endregion

        public Frm_RedimImage()
        {
            InitializeComponent();

            this.ActiveControl = btnAceptar;            
        }

        private void Cargar_Datos_Imagen()
        {
            if (!string.IsNullOrEmpty(RutaImagen))
            {
                _bmpImagen = new Bitmap(RutaImagen);
                pbImagen.Image = _bmpImagen;
                AnchoOriginal = _bmpImagen.Width;
                AltoOriginal = _bmpImagen.Height;
                Ancho = AnchoOriginal;
                Alto = AltoOriginal;
            }
        }

        #region Events
        
        private void rdbRedimensionar_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton) sender;
            txtAlto.Enabled = rdb.Checked;
            txtAncho.Enabled = rdb.Checked;
            chkMantenerProporciones.Enabled = rdb.Checked;
        }

        private void txtAncho_Leave(object sender, EventArgs e)
        {
            double ratio = 0;
            Ancho = Convert.ToInt16(txtAncho.Text);

            if (chkMantenerProporciones.Checked)
            {
                ratio = Calcular_Ratio_Proporcion(AnchoOriginal, Ancho);

                Alto = Convert.ToInt16(Math.Round(AltoOriginal / ratio));
            }               
        }        

        private void txtAlto_Leave(object sender, EventArgs e)
        {
            double ratio = 0;
            Alto = Convert.ToInt16(txtAlto.Text);

            if (chkMantenerProporciones.Checked)
            {
                ratio = Calcular_Ratio_Proporcion(AltoOriginal, Alto);

                Ancho = Convert.ToInt16(Math.Round(AnchoOriginal / ratio));
            }
        }

        private double Calcular_Ratio_Proporcion(double MedidaOriginal, double MedidaActual)
        {
            return (MedidaOriginal / MedidaActual);
        }

        private void txtSoloNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        

        
    }
}
