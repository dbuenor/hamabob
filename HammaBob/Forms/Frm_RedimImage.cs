using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proyecto_Hamma_Beads.Librerias;

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
        private Common.Medida _AnchoOriginal, _AltoOriginal, _Ancho, _Alto;

        /// <summary>
        /// Medida del Ancho Original de la foto.        
        /// </summary>
        public Common.Medida AnchoOriginal { get; set; }
        
        /// <summary>
        /// Medida del Alto Original de la foto.
        /// </summary>
        public Common.Medida AltoOriginal { get; set; }
        
        public Common.Medida Ancho { get; set; }        

        public Common.Medida Alto { get; set; }
        
        public eTipoMedida TipoMedida { get; set; }

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
                AnchoOriginal.Px = _bmpImagen.Width;
                AltoOriginal.Px = _bmpImagen.Height;
                Ancho.Px = AnchoOriginal.Px;
                Alto.Px = AltoOriginal.Px;
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
            Ancho.Establecer_Valor(TipoMedida, txtAncho.Text);

            if (chkMantenerProporciones.Checked)
            {
                ratio = Calcular_Ratio_Proporcion(AnchoOriginal.Px, Ancho.Px);

                Alto.Px = Convert.ToInt16(Math.Round(AltoOriginal.Px / ratio));
            }               
        }        

        private void txtAlto_Leave(object sender, EventArgs e)
        {
            double ratio = 0;
            Alto.Establecer_Valor(TipoMedida, txtAlto.Text);

            if (chkMantenerProporciones.Checked)
            {
                ratio = Calcular_Ratio_Proporcion(AltoOriginal.Px, Alto.Px);

                Ancho.Px = Convert.ToInt16(Math.Round(AnchoOriginal.Px / ratio));
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
            cmbTipoMedida.DataSource = Enum.GetNames(typeof(eTipoMedida));
            cmbTipoMedida.SelectedIndex = 0;
        }

        private void Inicializar_Medidas()
        {
            ///inicializo las variables de medida
            Ancho = new Common.Medida();
            Alto = new Common.Medida();
            AnchoOriginal = new Common.Medida();
            AltoOriginal = new Common.Medida();

            Ancho.MedidaCambiada += new Common.Medida.MedidaCambiadaEvent(Ancho_MedidaCambiada);
            Alto.MedidaCambiada += new Common.Medida.MedidaCambiadaEvent(Alto_MedidaCambiada);
            AnchoOriginal.MedidaCambiada += new Common.Medida.MedidaCambiadaEvent(AnchoOriginal_MedidaCambiada);
            AltoOriginal.MedidaCambiada += new Common.Medida.MedidaCambiadaEvent(AltoOriginal_MedidaCambiada);
        }        

        //Cambia el tipo de Medida
        private void cmbTipoMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoMedida = (eTipoMedida) cmbTipoMedida.SelectedIndex;

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
            txtAltoOriginal.Text = AltoOriginal.Devolver_Medida(TipoMedida).ToString();
        }

        void AnchoOriginal_MedidaCambiada()
        {
            txtAnchoOriginal.Text = AnchoOriginal.Devolver_Medida(TipoMedida).ToString();
        }

        void Alto_MedidaCambiada()
        {
            txtAlto.Text = Alto.Devolver_Medida(TipoMedida).ToString();
        }

        void Ancho_MedidaCambiada()
        {
            txtAncho.Text = Ancho.Devolver_Medida(TipoMedida).ToString();
        }

        #endregion
    }
}
