using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HammaBob.Libraries;

namespace HammaBob.Formularios
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
        private Common.Size _AnchoOriginal, _AltoOriginal, _Ancho, _Alto;

        /// <summary>
        /// Medida del Ancho Original de la foto.        
        /// </summary>
        public Common.Size AnchoOriginal { get; set; }
        
        /// <summary>
        /// Medida del Alto Original de la foto.
        /// </summary>
        public Common.Size AltoOriginal { get; set; }
        
        public Common.Size Ancho { get; set; }        

        public Common.Size Alto { get; set; }
        
        public MeasureType TipoMedida { get; set; }

        #endregion

        public Frm_RedimImage()
        {
            InitializeComponent();

            this.ActiveControl = btnAceptar;

            Inicializar_Medidas();

            Cargar_Combo_Medidas();            
        }              

        private void Cargar_Datos_Imagen()
        {
            if (!string.IsNullOrEmpty(RutaImagen))
            {
                _bmpImagen = new Bitmap(RutaImagen);
                pbImagen.Image = _bmpImagen;
                AnchoOriginal.Pixels = _bmpImagen.Width;
                AltoOriginal.Pixels = _bmpImagen.Height;
                Ancho.Pixels = AnchoOriginal.Pixels;
                Alto.Pixels = AltoOriginal.Pixels;
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
            Ancho.SetSize(TipoMedida, txtAncho.Text);

            if (chkMantenerProporciones.Checked)
            {
                ratio = Calcular_Ratio_Proporcion(AnchoOriginal.Pixels, Ancho.Pixels);

                Alto.Pixels = Convert.ToInt16(Math.Round(AltoOriginal.Pixels / ratio));
            }               
        }        

        private void txtAlto_Leave(object sender, EventArgs e)
        {
            double ratio = 0;
            Alto.SetSize(TipoMedida, txtAlto.Text);

            if (chkMantenerProporciones.Checked)
            {
                ratio = Calcular_Ratio_Proporcion(AltoOriginal.Pixels, Alto.Pixels);

                Ancho.Pixels = Convert.ToInt16(Math.Round(AnchoOriginal.Pixels / ratio));
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
            else
            {
                ///Si es un intro, lanzo el evento de aceptar.
                if (e.KeyChar == (char)13)
                {
                    btnAceptar.Focus();
                    btnAceptar_Click(sender, null);
                }
                    
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

        #region Medidas

        private void Cargar_Combo_Medidas()
        {
            cmbTipoMedida.DataSource = Enum.GetNames(typeof(MeasureType));
            cmbTipoMedida.SelectedIndex = 0;
        }

        private void Inicializar_Medidas()
        {
            ///inicializo las variables de medida
            Ancho = new Common.Size();
            Alto = new Common.Size();
            AnchoOriginal = new Common.Size();
            AltoOriginal = new Common.Size();

            Ancho.SizeChanged += new Common.Size.SizeChangedEvent(Ancho_MedidaCambiada);
            Alto.SizeChanged += new Common.Size.SizeChangedEvent(Alto_MedidaCambiada);
            AnchoOriginal.SizeChanged += new Common.Size.SizeChangedEvent(AnchoOriginal_MedidaCambiada);
            AltoOriginal.SizeChanged += new Common.Size.SizeChangedEvent(AltoOriginal_MedidaCambiada);
        }        

        //Cambia el tipo de Medida
        private void cmbTipoMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoMedida = (MeasureType) cmbTipoMedida.SelectedIndex;

            Recargar_Datos();
        }

        private void Recargar_Datos()
        {
            AltoOriginal_MedidaCambiada();
            Alto_MedidaCambiada();
            Ancho_MedidaCambiada();
            AnchoOriginal_MedidaCambiada();            
        }

        void AltoOriginal_MedidaCambiada()
        {
            txtAltoOriginal.Text = AltoOriginal.GetSize(TipoMedida).ToString();
        }

        void AnchoOriginal_MedidaCambiada()
        {
            txtAnchoOriginal.Text = AnchoOriginal.GetSize(TipoMedida).ToString();
        }

        void Alto_MedidaCambiada()
        {
            txtAlto.Text = Alto.GetSize(TipoMedida).ToString();
        }

        void Ancho_MedidaCambiada()
        {
            txtAncho.Text = Ancho.GetSize(TipoMedida).ToString();
        }

        #endregion
    }
}
