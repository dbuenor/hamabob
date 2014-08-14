using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Proyecto_Hamma_Beads.Controles
{
    public partial class PictureBoxZoom : UserControl
    {
        #region Propiedades
        
        private bool _ZoomActivado = false;
        private int _AumentoZoom = 2;
        private static ToolTip tt = new ToolTip();

        [Browsable(true)]
        public bool ZoomActivado 
        {
            get
            {
                return _ZoomActivado;
            }
            set
            {
                _ZoomActivado = value;

                if (_ZoomActivado)
                {
                    //Asumo que los anchos son en porcentajes y que tengo dos columnas
                    pbZoom.Visible = true;
                    tbarZoom.Visible = true;

                    tbPrincipal.ColumnStyles[0].Width = 80;
                    tbPrincipal.ColumnStyles[1].Width = 20;

                    btnMostrarOcultar.ImageIndex = 1;

                    pbImagen.MouseMove += new MouseEventHandler(pic_Zoom);
                    pbImagen.MouseWheel += new MouseEventHandler(pic_MouseWheel_AumentarZoom);

                    Redimensiono_PictureBox_Zoom();
                                                            
                    tt.SetToolTip(pbImagen, "Haz zoom con la rueda del ratón.");
                }
                else
                {
                    pbImagen.MouseMove -= new MouseEventHandler(pic_Zoom);
                    pbImagen.MouseWheel -= new MouseEventHandler(pic_MouseWheel_AumentarZoom);

                    //Asumo que los anchos son en porcentajes y que tengo dos columnas
                    tbPrincipal.ColumnStyles[1].Width = 0;
                    tbPrincipal.ColumnStyles[0].Width = 100;

                    btnMostrarOcultar.ImageIndex = 0;

                    pbZoom.Visible = false;
                    tbarZoom.Visible = false;

                    tt.SetToolTip(pbImagen, null);
                }                
            }
        }

        private int AumentoZoom
        {
            get
            {
                return _AumentoZoom;
            }
        }

        [Browsable(true)]
        public int Zoom 
        {
            get
            {
                return tbarZoom.Value * AumentoZoom;
            }
            set
            {
                tbarZoom.Value = value / AumentoZoom;
            }
        }
        
        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return pbImagen.SizeMode;
            }
            set
            {
                pbImagen.SizeMode = value;
            }
        }

        public Image Imagen
        {
            get
            {
                return pbImagen.Image;
            }
            set
            {
                pbImagen.Image = value;
                if (pbImagen.Image != null)
                    this.lblMedidas.Text = pbImagen.Image.Width + "x" + pbImagen.Image.Height;                
            }
        }

        public string Ruta
        {
            get
            {
                return lblRuta.Text;
            }
            set
            {                
                lblRuta.Visible = !string.IsNullOrEmpty(value);
                lblRutaTitulo.Visible = !string.IsNullOrEmpty(value);
                
                lblRuta.Text = value;
            }
        }

        public Image ImagenZoom
        {
            get
            {
                return pbZoom.Image;
            }
            set
            {
                pbZoom.Image = value;
            }
        }

        #endregion

        public PictureBoxZoom()
        {
            InitializeComponent();

            this.Size = new Size(200, 100);

            Add_ToolTips();
            
        }

        #region Funciones

        private void Add_ToolTips()
        {
            tt.AutoPopDelay = 1000;
            tt.SetToolTip(btnMostrarOcultar, "Haz clic para activar/desactivar el zoom.");            
        }


        private void AjustarImagen()
        {
            if (pbImagen.Image != null)
            {
                if (pbImagen.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    pbImagen.Dock = DockStyle.None;
                    pbImagen.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                else
                {
                    pbImagen.Dock = DockStyle.Fill;
                    pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void pic_Zoom(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            if (pic.Image != null)
            {
                double dAumento = (double)tbarZoom.Value / (double) AumentoZoom;

                int zoomAncho = Convert.ToInt16(pbZoom.Width / dAumento);
                    //(Math.Pow(AumentoZoom, 
                    //(double) (tbarZoom.Value - 1) / (double) (tbarZoom.SmallChange))));
                int zoomAlto = Convert.ToInt16(pbZoom.Height / dAumento);
                    //(Math.Pow(AumentoZoom, 
                    //(double) (tbarZoom.Value - 1) / (double) (tbarZoom.SmallChange))));

                lblZoom.Text = dAumento + "X";

                Point cursor = xy_projection(pic.Image, pic, e.X, e.Y);

                Bitmap tmpBitMap = new Bitmap(pbZoom.Width, pbZoom.Height);

                Graphics gr = Graphics.FromImage(tmpBitMap);

                gr.Clear(Color.Transparent);
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                gr.DrawImage(pic.Image,
                    new Rectangle(0, 0, pbZoom.Width, pbZoom.Height),
                    new Rectangle(
                        cursor.X - (zoomAncho / 2),
                        cursor.Y - (zoomAlto / 2),
                        zoomAncho,
                        zoomAlto),
                        GraphicsUnit.Pixel);

                pbZoom.Image = tmpBitMap;

                gr.Dispose();



                if (!pic.Focused)
                    pic.Focus();


            }
        }

        private Point xy_projection(Image bmp, PictureBox pic, int x, int y)
        {
            int heightB = bmp.Height;
            int heightP = pic.Height;
            int widthB = bmp.Width;
            int widthP = pic.Width;
            double xRatio = (double)widthB / (double)widthP;
            double yRatio = (double)heightB / (double)heightP;
            int[] xy = new int[2];
            if (pic.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                xy[0] = (int)(x * xRatio);
                xy[1] = (int)(y * yRatio);
            }
            else if (pic.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                int borderHeight = (heightP - heightB) / 2;
                int borderWidth = (widthP - widthB) / 2;
                xy[0] = x - borderWidth;
                xy[1] = y - borderHeight;
            }
            else if (pic.SizeMode == PictureBoxSizeMode.Zoom)
            {
                double ratio = xRatio;
                bool x_filled = true;
                if (ratio < yRatio)
                {
                    ratio = yRatio;
                    x_filled = false;
                }
                if (x_filled)
                {
                    heightB = (int)(heightB / ratio);
                    int borderHeight = (heightP - heightB) / 2;
                    xy[0] = (int)(x * ratio);
                    xy[1] = (int)((y - borderHeight) * ratio);
                }
                else
                {
                    widthB = (int)(widthB / ratio);
                    int borderWidth = (widthP - widthB) / 2;
                    xy[0] = (int)((x - borderWidth) * ratio);
                    xy[1] = (int)(y * ratio);
                }
            }
            else
            {
                xy[0] = x;
                xy[1] = y;
            }

            return new Point(xy[0], xy[1]);
        }
       
        private void Redimensiono_PictureBox_Zoom()
        {
            int AnchoPicZoom = pbZoom.Width;

            //Le cambio el tamaño a la fila para que el pictureBox de Zoom se adapte al tamaño, y tenga medidas exactas para ser un cuadrado. Por eso le pongo de alto de fila, el ancho del 
            // picturebox  más los margenes (izq y der) que es el tamaño total del ancho de la columna.
            tbPrincipal.RowStyles[0].Height = AnchoPicZoom + (10 * 2);
        }       

        #endregion

        #region Metodos

        public void Limpiar_Memoria()
        {
            if (pbImagen.Image != null)
                pbImagen.Image.Dispose();
            pbImagen.Image = null;
            pbImagen.SizeMode = PictureBoxSizeMode.AutoSize;
            pbImagen.Dock = DockStyle.Fill;

            if (pbZoom.Image != null)
                pbZoom.Image.Dispose();
            pbZoom.Image = null;

            this.ZoomActivado = false;
            this.Ruta = "";
        }

        #endregion

        #region Eventos

        private void btnMostrarOcultar_Click(object sender, EventArgs e)
        {
            //Cuando pulso con el boton derecho, cambia el valor del zoom para que active o desactive el efecto Zoom.
            ZoomActivado = !ZoomActivado;
        }       

        private void pb_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                AjustarImagen();                
        }
       
        private void pic_MouseWheel_AumentarZoom(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (tbarZoom.Value != tbarZoom.Maximum) tbarZoom.Value += 1;
            }
            else
            {
                if (tbarZoom.Value != tbarZoom.Minimum) tbarZoom.Value -= 1;
            }

            ((HandledMouseEventArgs)e).Handled = true;

            pic_Zoom(sender, e);
        }

        private void tbPrincipal_SizeChanged(object sender, EventArgs e)
        {
            Redimensiono_PictureBox_Zoom();
        }

        #endregion

 
        
    }
}
