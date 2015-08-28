using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Proyecto_Hamma_Beads.Controles;
using System.Xml;
using System.Drawing.Drawing2D;
using Proyecto_Hamma_Beads.Librerias;

namespace Proyecto_Hamma_Beads.Formularios
{
    public partial class MDIPrincipal : Form
    {
        #region Constantes        
        const int EspaciadoEntreColores_Alto = 20;
        const int EspaciadoEntreTipo_Alto = 50;
        const int EspaciadoEntreColumnas_Ancho = 120;
        #endregion        

        #region Variables Aplicacion
        List<ColorHama> listaColores = new List<ColorHama>();
        Size TamanioCuadradoGenerado = new Size(Constantes.AnchoHamaGen, Constantes.AltoHamaGen);
        bool bolNuevoTipo = false;

        string rutaConfig = Application.UserAppDataPath + "\\MisHamas.xml";
        string rutaGuardado, rutaGuardadoTroceada, rutaOriginal;

        IntPtr punteroImagen = IntPtr.Zero, punteroImagenGen = IntPtr.Zero, punteroImagenTroceada = IntPtr.Zero;
        BitmapData bmpData = null, bmpDataGen = null, bmpDataTroceada = null;
        Bitmap bmpOriginal, bmpGenerado, bmpTroceada, bmpComposicion;
        String nombreOriginal, extensionOriginal, nombreGuardado, extensionGuardado;

        int step, stepGen, stepTroceada;
        public byte[] Pixeles { get; set; }
        public byte[] PixelesGen { get; set; }
        public byte[] PixelesTroceada { get; set; }
        public int profundidad, profundidadGen, profundidadTroceada;

        public Color colorBorde;
        public Color colorNumero;

        public Common.Medida Ancho, Alto;

        #endregion

        #region Otros

        CheckBox chkGenerarReporte;

        #endregion

        private void Inicializar_Colores()
        {
            #region Colores
            listaColores.Add(new ColorHama(Color.FromArgb(255, 255, 255), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H01", 01));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 239, 189), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H02", 02));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 197, 0), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H03", 03));
            listaColores.Add(new ColorHama(Color.FromArgb(228, 82, 20), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H04", 04));
            listaColores.Add(new ColorHama(Color.FromArgb(194, 43, 42), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H05", 05));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 142, 164), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H06", 06));
            listaColores.Add(new ColorHama(Color.FromArgb(105, 61, 159), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H07", 07));
            listaColores.Add(new ColorHama(Color.FromArgb(0, 69, 132), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H08", 08));
            listaColores.Add(new ColorHama(Color.FromArgb(0, 126, 190), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H09", 09));
            listaColores.Add(new ColorHama(Color.FromArgb(15, 138, 73), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H10", 10));
            listaColores.Add(new ColorHama(Color.FromArgb(92, 207, 151), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H11", 11));
            listaColores.Add(new ColorHama(Color.FromArgb(64, 36, 32), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H12", 12));
            listaColores.Add(new ColorHama(Color.FromArgb(224, 70, 76), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H13", 13));
            listaColores.Add(new ColorHama(Color.FromArgb(228, 192, 0), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H14", 14));
            listaColores.Add(new ColorHama(Color.FromArgb(0, 141, 201), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H15", 15));
            listaColores.Add(new ColorHama(Color.FromArgb(135, 221, 173), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H16", 16));
            listaColores.Add(new ColorHama(Color.FromArgb(142, 147, 151), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H17", 17));
            listaColores.Add(new ColorHama(Color.FromArgb(0, 0, 0), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H18", 18));
            listaColores.Add(new ColorHama(Color.FromArgb(229, 235, 244), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H19", 19));
            listaColores.Add(new ColorHama(Color.FromArgb(139, 57, 30), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H20", 20));
            listaColores.Add(new ColorHama(Color.FromArgb(192, 100, 46), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H21", 21));
            listaColores.Add(new ColorHama(Color.FromArgb(179, 27, 41), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H22", 22));
            listaColores.Add(new ColorHama(Color.FromArgb(118, 120, 121), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H23", 23));
            listaColores.Add(new ColorHama(Color.FromArgb(141, 109, 180), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H24", 24));
            listaColores.Add(new ColorHama(Color.FromArgb(157, 113, 78), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.TRANSLUCIDO, "H25", 25));
            listaColores.Add(new ColorHama(Color.FromArgb(237, 182, 159), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H26", 26));
            listaColores.Add(new ColorHama(Color.FromArgb(239, 190, 146), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H27", 27));
            listaColores.Add(new ColorHama(Color.FromArgb(24, 44, 29), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H28", 28));
            listaColores.Add(new ColorHama(Color.FromArgb(202, 17, 70), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H29", 29));
            listaColores.Add(new ColorHama(Color.FromArgb(90, 11, 21), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H30", 30));
            listaColores.Add(new ColorHama(Color.FromArgb(103, 169, 191), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H31", 31));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 0, 144), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NEON, "H32", 32));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 66, 0), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.FLUORESCENTE, "H33", 33));
            listaColores.Add(new ColorHama(Color.FromArgb(246, 255, 0), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NEON, "H34", 34));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 20, 0), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NEON, "H35", 35));
            listaColores.Add(new ColorHama(Color.FromArgb(0, 22, 238), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NEON, "H36", 36));
            listaColores.Add(new ColorHama(Color.FromArgb(121, 230, 51), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NEON, "H37", 37));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 141, 49), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NEON, "H38", 38));
            listaColores.Add(new ColorHama(Color.FromArgb(242, 244, 95), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.FLUORESCENTE, "H39", 39));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 98, 36), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.FLUORESCENTE, "H40", 40));
            listaColores.Add(new ColorHama(Color.FromArgb(0, 93, 163), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.FLUORESCENTE, "H41", 41));
            listaColores.Add(new ColorHama(Color.FromArgb(87, 190, 0), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.FLUORESCENTE, "H42", 42));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 253, 112), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H43", 43));
            listaColores.Add(new ColorHama(Color.FromArgb(255, 118, 117), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H44", 44));
            listaColores.Add(new ColorHama(Color.FromArgb(168, 134, 195), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H45", 45));
            listaColores.Add(new ColorHama(Color.FromArgb(139, 199, 235), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H46", 46));
            listaColores.Add(new ColorHama(Color.FromArgb(188, 242, 94), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H47", 47));
            listaColores.Add(new ColorHama(Color.FromArgb(233, 145, 201), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H48", 48));
            listaColores.Add(new ColorHama(Color.FromArgb(90, 189, 206), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H49", 49));
            listaColores.Add(new ColorHama(Color.FromArgb(230, 240, 214), ColorHama.eTamanioHama.MIDI, ColorHama.eTipoHama.FOSFORESCENTE, "H55", 55));
            listaColores.Add(new ColorHama(Color.FromArgb(243, 218, 214), ColorHama.eTamanioHama.MIDI, ColorHama.eTipoHama.FOSFORESCENTE, "H56", 56));
            listaColores.Add(new ColorHama(Color.FromArgb(212, 215, 217), ColorHama.eTamanioHama.MIDI, ColorHama.eTipoHama.FOSFORESCENTE, "H57", 57));
            listaColores.Add(new ColorHama(Color.FromArgb(241, 161, 37), ColorHama.eTamanioHama.MIDI, ColorHama.eTipoHama.NORMAL, "H60", 60));
            listaColores.Add(new ColorHama(Color.FromArgb(234, 183, 50), ColorHama.eTamanioHama.AMBOS, ColorHama.eTipoHama.NORMAL, "H61", 61));
            listaColores.Add(new ColorHama(Color.FromArgb(161, 158, 158), ColorHama.eTamanioHama.MIDI, ColorHama.eTipoHama.NORMAL, "H62", 62));
            listaColores.Add(new ColorHama(Color.FromArgb(143, 114, 36), ColorHama.eTamanioHama.MIDI, ColorHama.eTipoHama.NORMAL, "H63", 63));
            listaColores.Add(new ColorHama(Color.FromArgb(231, 222, 218), ColorHama.eTamanioHama.MIDI, ColorHama.eTipoHama.NORMAL, "H64", 64));
            #endregion
        }

        private void Limpiar(object sender, EventArgs e)
        {
            if (bmpOriginal != null)
            {
                bmpOriginal.Dispose();
                bmpOriginal = null;
            }

            if (bmpGenerado != null)
            {
                bmpGenerado.Dispose();
                bmpGenerado = null;
            }

            if (bmpComposicion != null)
            {
                bmpComposicion.Dispose();
                bmpComposicion = null;
            }

            if (bmpTroceada != null)
            {
                bmpTroceada.Dispose();
                bmpTroceada = null;
            }

            pbZoomOriginal.Limpiar_Memoria();
            pbZoomGenerada.Limpiar_Memoria();

            Desactivar_Botones();
        }

        private void Desactivar_Botones()
        {
            tsbtnGenerarImagen.Enabled = false;
            tsbtnGuardarImagen.Enabled = false;
            tsbtnTrocearImagen.Enabled = false;
            generarImagenToolStripMenuItem.Enabled = false;
            trocearImagenToolStripMenuItem.Enabled = false;
            guardarToolStripMenuItem.Enabled = false;
        }

        private void Habilitar_Botones_Tras_Generar_Imagen()
        {
            tsbtnGuardarImagen.Enabled = true;
            tsbtnTrocearImagen.Enabled = true;
            trocearImagenToolStripMenuItem.Enabled = true;
            guardarToolStripMenuItem.Enabled = true;
        }

        private void Habilitar_Botones_Tras_Abrir_Imagen()
        {
            tsbtnGenerarImagen.Enabled = true;
            generarImagenToolStripMenuItem.Enabled = true;
        }

        #region AutoGenerado

        //private int childFormNumber = 0;
        //bool modoLupa = false;

        public MDIPrincipal()
        {
            InitializeComponent();

            ///Añado un checkbox a la barra de titulo para poder generar el informe por defecto o no.
            Aniadir_CheckBox_ToolTip();

            rdbBordeNegro.Checked = true;

            Inicializar_Colores();

            Inicializar_Controles_Colores();

            Cargar_Configuracion();

            Cargar_Combo_Medidas();
        }

        private void Cargar_Combo_Medidas()
        {
            cmbTipoMedida.ComboBox.DataSource = Enum.GetNames(typeof(eTipoMedida));
            cmbTipoMedida.SelectedIndex = 0;
        }

        private void Aniadir_CheckBox_ToolTip()
        {
            chkGenerarReporte = new CheckBox();
            chkGenerarReporte.BackColor = Color.Transparent;
            chkGenerarReporte.Checked = true;
            chkGenerarReporte.Text = "Generar Reporte";
            ToolStripControlHost host = new ToolStripControlHost(chkGenerarReporte);
            toolStrip.Items.Add(host);
        }

        #region Botones
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion
        #endregion

        /// <summary>
        /// Funcion que carga los controles iniciales en el grid con todos los colores que tengamos disponibles
        /// </summary>
        private void Inicializar_Controles_Colores()
        {
            tbColores.RowStyles.Clear();
            tbColores.MouseWheel += new MouseEventHandler(tbColores_MouseWheel);

            foreach (ColorHama.eTipoHama _tipo in Enum.GetValues(typeof(ColorHama.eTipoHama)))
            {
                tbColores.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                
                GroupBox grTipo = new GroupBox() { Text = _tipo.ToString(), Name = "gb" + _tipo.ToString()};
                grTipo.Dock = DockStyle.Fill;
                grTipo.AutoSize = true;
                tbColores.Controls.Add(grTipo, 0, tbColores.RowStyles.Count - 1);
                
                TableLayoutPanel tbTipo = new TableLayoutPanel();
                tbTipo.Dock = DockStyle.Fill;
                tbTipo.AutoSize = true;
                grTipo.Controls.Add(tbTipo);          
                
                List<ColorHama> ColoresTipo = listaColores.Where(x => x.Tipo == _tipo).ToList();                
                int columna = 0;
                int numColumnas = 2;

                for (int i = 0; i < numColumnas; i++)
                    tbTipo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));

                foreach (ColorHama _color in ColoresTipo)
                {
                    if (columna == 0)
                        tbTipo.RowStyles.Add(new RowStyle(SizeType.Absolute,30));
                    
                    colorCheckBox chkColor = new colorCheckBox()
                    {
                        NombreColor = _color.Nombre,
                        Name = "chk" + _color.Nombre,
                        //Size = new Size(100, 22),
                        Color = _color
                    };

                    chkColor.Chk.Checked = _color.Habilitado;                    
                    chkColor.MouseWheel += new MouseEventHandler(chkColor_MouseWheel);
                    chkColor.MouseHover += new EventHandler(chkColor_MouseHover);

                    tbTipo.Controls.Add(chkColor, columna, tbTipo.RowStyles.Count - 1);

                    columna++;

                    ///Si ya he llegado a la ultima columna, vuelvo a la columna inicial. Los voy colocando de izquierda a derecha, y de arriba a abajo.
                    if (columna == numColumnas)
                        columna = 0;
                }                                         
            }
        }

        #region Scroll TB COLORES
        /// <summary>
        /// Todo esto lo pongo para que al hacer scroll sobre los objetos colorCheckBox, me haga scroll en el control padre que sí que tiene scroll,
        /// es decir, la tbColores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tbColores_MouseWheel(object sender, MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        void chkColor_MouseHover(object sender, EventArgs e)
        {
            (sender as Control).Focus();
        }       

        void chkColor_MouseWheel(object sender, MouseEventArgs e)
        {
            tbColores_MouseWheel(sender, e);
        }
        #endregion        

        private void Calcular_Siguiente_Posicion(ref int X, ref int Y, int AnchoLienzo, int AltoLienzo, int EspaciadoX, int EspaciadoY, int AltoControl)
        {
            if (Y + EspaciadoY + AltoControl > AltoLienzo)
            {
                Y = (bolNuevoTipo ? EspaciadoY * 2 : EspaciadoY);
                X += EspaciadoX;
            }
            else
            {
                Y += EspaciadoY;
            }
        }

        private void Cargar_Imagen(string rutaImagen)
        {
            try
            {
                bmpOriginal = new Bitmap(rutaImagen);
                pbZoomOriginal.SizeMode = PictureBoxSizeMode.Zoom;
                pbZoomOriginal.Ruta = rutaImagen;
                pbZoomOriginal.Imagen = bmpOriginal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Abrir Imagen: " + ex.Message, "ERROR");
            }
        }

        private void Cargar_Imagen(string rutaImagen, int AnchoDeseado, int AltoDeseado)
        {
            try
            {
                using (Image imagenOriginal = Image.FromFile(rutaImagen))
                {
                    bmpOriginal = new Bitmap(AnchoDeseado, AltoDeseado);

                    using (Graphics gr = Graphics.FromImage(bmpOriginal))
                    {
                        gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        gr.SmoothingMode = SmoothingMode.HighQuality;
                        gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        gr.CompositingQuality = CompositingQuality.HighQuality;

                        gr.DrawImage(imagenOriginal,
                            new Rectangle(0, 0, bmpOriginal.Width, bmpOriginal.Height),
                            new Rectangle(0, 0, imagenOriginal.Width, imagenOriginal.Height),
                            GraphicsUnit.Pixel);
                    }
                }

                pbZoomOriginal.SizeMode = PictureBoxSizeMode.Zoom;
                pbZoomOriginal.Ruta = rutaImagen;
                pbZoomOriginal.Imagen = bmpOriginal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Abrir Imagen: " + ex.Message, "ERROR");
            }
        }

        //#region 32 BITS

        //private void ProcesarImagen32Bits(List<ColorHama> coloresSeleccionados)
        //{
        //    for (int y = 0; y < bmpOriginal.Height; y++)
        //    {
        //        for (int x = 0; x < (bmpOriginal.Width * step); x += step)
        //        {
        //            PintarImagen32((x * AnchoHamaGen) + (bmpDataGen.Stride * AltoHamaGen * y)
        //                , Color.FromArgb(
        //                    Pixeles[x + (bmpData.Stride * y) + 3],
        //                    Pixeles[x + (bmpData.Stride * y) + 2],
        //                    Pixeles[x + (bmpData.Stride * y) + 1],
        //                    Pixeles[x + (bmpData.Stride * y)]
        //                    )
        //                , bmpDataGen.Stride, coloresSeleccionados);

        //        }

        //        barraProgreso.PerformStep();
        //    }        
        //}

        //private void PintarImagen32(int pixelInicio, Color colorFondo, int pixelesFila, List<ColorHama> coloresSeleccionados)
        //{
        //    int posActual = pixelInicio;

        //    ColorHama colorParecido;

        //    colorParecido = EncontrarColorParecido(colorFondo, coloresSeleccionados);

        //    PintarRecuadroHama32(posActual, pixelesFila, pixelInicio, colorParecido.Colorciko);

        //    PintarNumero32(colorParecido.Numero, posActual, pixelesFila);            
        //}

        //private void PintarNumero32(int numero, int posActual, int pixelesFila)
        //{
        //    switch (numero)
        //    {
        //        case 1:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 2:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 3:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 4:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 5:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 6:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 7:
        //            PintarDigito32(7, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 8:
        //            PintarDigito32(8, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 9:
        //            PintarDigito32(9, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 10:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 11:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 12:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 13:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 14:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 15:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 16:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 17:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 18:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 19:
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 20:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 21:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 22:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 23:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 24:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 25:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 26:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 27:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 28:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 29:
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 30:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 31:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 32:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 33:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;              

        //        case 34:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 35:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 36:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 37:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 38:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 39:
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 40:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 41:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 42:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 43:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 44:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 45:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 46:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 47:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 48:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 49:
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;
        //        case 50:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 51:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 52:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 53:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 54:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 55:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 56:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 57:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 58:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 59:
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 60:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 61:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 62:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 63:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 64:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 65:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 66:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 67:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 68:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 69:
        //            PintarDigito32(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito32(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;
        //    }
        //}

        //private void PintarDigito32(int numero, int posActual, int pixelesFila, eDigito digito)
        //{
        //    int pixel;

        //    int posInicial = 0;

        //    if (digito == eDigito.Izquierda)
        //        posInicial = 2 * stepGen;
        //    else if (digito == eDigito.Derecha)
        //        posInicial = 6 * stepGen;

        //    switch (numero)
        //    {
        //        #region 0
        //        case 0:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 1
        //        case 1:
        //            pixel = posActual + (3 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (1 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 2
        //        case 2:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 3
        //        case 3:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) +  posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 4
        //        case 4:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel + 0] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;


        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 5
        //        case 5:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 6
        //        case 6:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 7
        //        case 7:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 8
        //        case 8:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 9
        //        case 9:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 3] = colorNumero.A;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 7] = colorNumero.A;
        //            PixelesGen[pixel + 6] = colorNumero.R;
        //            PixelesGen[pixel + 5] = colorNumero.G;
        //            PixelesGen[pixel + 4] = colorNumero.B;
        //            PixelesGen[pixel + 11] = colorNumero.A;
        //            PixelesGen[pixel + 10] = colorNumero.R;
        //            PixelesGen[pixel + 9] = colorNumero.G;
        //            PixelesGen[pixel + 8] = colorNumero.B;
        //            break;
        //        #endregion
        //    }
        //}

        //private void PintarRecuadroHama32(int posActual, int pixelesFila, int pixelInicio, Color color)
        //{
        //    //Dibujo la linea superior de negro, es decir, pinto el borde
        //    pintarFilaEnteraColor32(posActual, colorBorde);

        //    //Pinto todas las filas de en medio del color que necesito, para luego pintar los numeros encima.
        //    for (int i = 1; i < (AltoHamaGen); i++)
        //    {
        //        posActual = pixelInicio + pixelesFila * i;
        //        pintarFilaEnteraConBorde32(posActual, color, colorBorde);
        //    }

        //    //posActual = pixelInicio + pixelesFila * (AltoHamaGen - 1);

        //    ////Dibujo la linea inferior de negro, es decir, pinto el borde
        //    //pintarFilaEnteraColor32(posActual, Color.Black);
        //}

        //private void pintarFilaEnteraColor32(int posicion, Color color)
        //{
        //    for (int i = posicion; i < (posicion + step * AnchoHamaGen); i += step)
        //    {
        //        pintarPixel32(i, color);
        //    }
        //}

        //private void pintarFilaEnteraConBorde32(int posicion, Color color, Color colorBorde)
        //{
        //    pintarPixel32(posicion, colorBorde);
        //    posicion += step;

        //    for (int i = posicion; i < (posicion + step * (AnchoHamaGen - 1)); i += step)
        //        pintarPixel32(i, color);

        //    //posicion += (step * (AnchoHamaGen - 2));

        //    //pintarPixel32(posicion, colorBorde);
        //}

        //private void pintarPixel32(int posicion, Color color)
        //{
        //    ///Comprobar si es por LittleEndian       
        //    ///
        //    ///Pongo el try & catch para que si es una imagen de menos de 32 bits...no pete y pase al siguiente.
        //    ///Funciona bien dado que aunque pinte un pixel de más...luego en la "siguiente" pasada le pongo su valor correcto, por lo que me da igual rellenar uno más
        //    ///
        //    /// AL FINAL PONGO FUNCIONES DIFERENTES PARA QUE LA CARGA DE TRABAJO SEA MENOR AL HACER OPERACIONES INNECESARIAS AUNQUE ESTETICAMENTE SEA MÁS FEO
        //    PixelesGen[posicion + 3] = color.A;
        //    PixelesGen[posicion + 2] = color.R;
        //    PixelesGen[posicion + 1] = color.G;
        //    PixelesGen[posicion] = color.B;
        //}

        //#endregion

        //#region 24 BITS

        //private void ProcesarImagen24Bits(List<ColorHama> coloresSeleccionados)
        //{
        //    for (int y = 0; y < bmpOriginal.Height; y++)
        //    {
        //        for (int x = 0; x < (bmpOriginal.Width * step); x += step)
        //        {
        //            PintarImagen24((x * AnchoHamaGen) + (bmpDataGen.Stride * AltoHamaGen * y)
        //                , Color.FromArgb(Pixeles[x + (bmpData.Stride * y) + 2],
        //                    Pixeles[x + (bmpData.Stride * y) + 1],
        //                    Pixeles[x + (bmpData.Stride * y)]
        //                    )
        //                , bmpDataGen.Stride, coloresSeleccionados);
        //        }

        //        barraProgreso.PerformStep();
        //    }
        //}

        //private void PintarImagen24(int pixelInicio, Color colorFondo, int pixelesFila, List<ColorHama> coloresSeleccionados)
        //{
        //    int posActual = pixelInicio;

        //    ColorHama colorParecido;

        //    colorParecido = EncontrarColorParecido(colorFondo, coloresSeleccionados);

        //    PintarRecuadroHama24(posActual, pixelesFila, pixelInicio, colorParecido.Colorciko);

        //    PintarNumero24(colorParecido.Numero, posActual, pixelesFila);
        //}

        //private void PintarNumero24(int numero, int posActual, int pixelesFila)
        //{
        //    switch (numero)
        //    {
        //        case 1:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 2:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 3:
        //            PintarDigito24(3,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 4:
        //            PintarDigito24(4,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 5:
        //            PintarDigito24(5,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 6:
        //            PintarDigito24(6,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 7:
        //            PintarDigito24(7,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 8:
        //            PintarDigito24(8, posActual, pixelesFila, eDigito.Izquierda);
        //            break;

        //        case 9:
        //            PintarDigito24(9,posActual,pixelesFila,eDigito.Izquierda);
        //            break;

        //        case 10:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(0,posActual,pixelesFila,eDigito.Derecha);
        //            break;

        //        case 11:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 12:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 13:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 14:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 15:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 16:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 17:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 18:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 19:
        //            PintarDigito24(1,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 20:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 21:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 22:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 23:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 24:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 25:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 26:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 27:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 28:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 29:
        //            PintarDigito24(2,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 30:
        //            PintarDigito24(3,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 31:
        //            PintarDigito24(3,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 32:
        //            PintarDigito24(3,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 33:
        //            PintarDigito24(3,posActual,pixelesFila,eDigito.Izquierda);
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 34:
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 35:
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 36:
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 37:
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 38:
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 39:
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 40:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 41:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 42:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 43:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 44:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 45:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 46:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 47:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 48:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 49:
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;
        //        case 50:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 51:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 52:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 53:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 54:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 55:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 56:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 57:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 58:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 59:
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 60:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(0, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 61:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(1, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 62:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(2, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 63:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(3, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 64:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(4, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 65:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(5, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 66:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 67:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(7, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 68:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(8, posActual, pixelesFila, eDigito.Derecha);
        //            break;

        //        case 69:
        //            PintarDigito24(6, posActual, pixelesFila, eDigito.Izquierda);
        //            PintarDigito24(9, posActual, pixelesFila, eDigito.Derecha);
        //            break;
        //    }
        //}

        //private void PintarDigito24(int numero, int posActual, int pixelesFila, eDigito digito)
        //{
        //    int pixel;
        //    //Color _colorNumero = colorNumero;

        //    int posInicial = 0;

        //    if (digito == eDigito.Izquierda)
        //        posInicial = 2 * stepGen;
        //    else if (digito == eDigito.Derecha)
        //        posInicial = 6 * stepGen;

        //    switch (numero)
        //    {
        //        #region 0
        //        case 0:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;                    
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 1
        //        case 1:
        //            pixel = posActual + (3 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (1 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 2
        //        case 2:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 3
        //        case 3:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 4
        //        case 4:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;


        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 5
        //        case 5:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 6
        //        case 6:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 7
        //        case 7:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 8
        //        case 8:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;
        //            break;
        //        #endregion

        //        #region 9
        //        case 9:
        //            pixel = posActual + (3 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (4 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (5 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;

        //            pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;

        //            pixel = posActual + (7 * pixelesFila) + posInicial;
        //            PixelesGen[pixel + 2] = colorNumero.R;
        //            PixelesGen[pixel + 1] = colorNumero.G;
        //            PixelesGen[pixel] = colorNumero.B;
        //            PixelesGen[pixel + 5] = colorNumero.R;
        //            PixelesGen[pixel + 4] = colorNumero.G;
        //            PixelesGen[pixel + 3] = colorNumero.B;
        //            PixelesGen[pixel + 8] = colorNumero.R;
        //            PixelesGen[pixel + 7] = colorNumero.G;
        //            PixelesGen[pixel + 6] = colorNumero.B;
        //            break;
        //        #endregion
        //    }
        //}

        //private void PintarRecuadroHama24(int posActual, int pixelesFila, int pixelInicio, Color color)
        //{
        //    //Dibujo la linea superior de negro, es decir, pinto el borde
        //    pintarFilaEnteraColor24(posActual, colorBorde);

        //    //Pinto todas las filas de en medio del color que necesito, para luego pintar los numeros encima.
        //    for (int i = 1; i < (AltoHamaGen); i++)
        //    {
        //        posActual = pixelInicio + pixelesFila * i;
        //        pintarFilaEnteraConBorde24(posActual, color, colorBorde);
        //    }

        //    //posActual = pixelInicio + pixelesFila * (AltoHamaGen - 1);

        //    ////Dibujo la linea inferior de negro, es decir, pinto el borde
        //    //pintarFilaEnteraColor24(posActual, Color.Black);
        //}

        ////private void PintarRecuadroHamaFinalDeColumna24(int posActual, int pixelesFila, int pixelInicio, Color color)
        ////{
        ////    //Dibujo la linea superior de negro, es decir, pinto el borde
        ////    pintarFilaEnteraColor24(posActual, colorBorde);

        ////    //Pinto todas las filas de en medio del color que necesito, para luego pintar los numeros encima.
        ////    for (int i = 1; i < (AltoHamaGen - 1); i++)
        ////    {
        ////        posActual = pixelInicio + pixelesFila * i;
        ////        pintarFilaEnteraConBorde24(posActual, color, colorBorde);
        ////    }

        ////    posActual = pixelInicio + pixelesFila * (AltoHamaGen - 1);

        ////    ////Dibujo la linea inferior de negro, es decir, pinto el borde
        ////    pintarFilaEnteraColor24(posActual, colorBorde);
        ////}

        //private void pintarFilaEnteraColor24(int posicion, Color color)
        //{
        //    for (int i = posicion; i < (posicion + step * AnchoHamaGen); i += step)
        //    {
        //        pintarPixel24(i, color);
        //    }
        //}

        //private void pintarFilaEnteraConBorde24(int posicion, Color color, Color colorBorde)
        //{
        //    pintarPixel24(posicion, colorBorde);
        //    posicion += step;

        //    for (int i = posicion; i < (posicion + step * (AnchoHamaGen - 1)); i += step)
        //        pintarPixel24(i, color);

        //    //posicion += (step * (AnchoHamaGen - 2));

        //    //pintarPixel24(posicion, colorBorde);
        //}

        //private void pintarPixel24(int posicion, Color color)
        //{
        //    ///Comprobar si es por LittleEndian                   
        //    PixelesGen[posicion + 2] = color.R;
        //    PixelesGen[posicion + 1] = color.G;
        //    PixelesGen[posicion] = color.B;
        //}

        //#endregion


        public void UnlockBits(byte[] _pixeles, ref IntPtr _puntero, ref Bitmap _bmp, ref BitmapData _bmpData)
        {
            try
            {
                // Copy data from byte array to pointer
                Marshal.Copy(_pixeles, 0, _puntero, _pixeles.Length);

                // Unlock bitmap data
                _bmp.UnlockBits(_bmpData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] LockBits(ref Bitmap bmp, ref int _profundidad, ref int _step, ref IntPtr _puntero, ref BitmapData _bmpData)
        {
            _profundidad = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat);
            _step = _profundidad / 8;

            _bmpData = bmp.LockBits(new Rectangle(new Point(0, 0), bmp.Size)
                , System.Drawing.Imaging.ImageLockMode.ReadWrite
                , bmp.PixelFormat);

            int numPixeles = bmp.Height * _bmpData.Stride;

            byte[] Pixeles = new byte[numPixeles];

            _puntero = _bmpData.Scan0;
            Marshal.Copy(_puntero, Pixeles, 0, numPixeles);

            return Pixeles;
        }

        private void ResetearContadoresHama()
        {
            foreach (ColorHama color in listaColores.Where(x => x.NumPiezas > 0))
                color.NumPiezas = 0;
        }

        private void ActualizarEtiquetasConNumeroDePiezasHama()
        {
            foreach (ColorHama color in listaColores.Where(x => x.NumPiezas > 0))
            {
                try
                {
                    colorCheckBox chk = (colorCheckBox)tbColores.Controls.Find("chk" + color.Nombre, true)[0];
                    chk.NumPiezas = color.NumPiezas;
                    //chk.NombreColor = color.Nombre + " (" + color.NumPiezas + ")";
                }
                catch { }
            }
        }

        private void ActualizarEstadisticas()
        {
            gbEstadisticas.Controls.Clear();

            int numPiezas = int.MaxValue;
            ColorHama aux = null;

            do
            {
                aux = listaColores
                    .Where(x => x.NumPiezas.Equals
                        (listaColores
                        .Where(y => y.NumPiezas < numPiezas)
                        .Max(y => y.NumPiezas)
                        ))
                        .First();

                numPiezas = aux.NumPiezas;

                gbEstadisticas.Controls.Add(new Label() { Text = aux.Nombre + "- " + aux.NumPiezas });
            }
            while (numPiezas > 0);
        }

        //private ColorHama EncontrarColorParecido(Color colorOriginal, List<ColorHama> coloresSeleccionados)
        //{            
        //    double dbl_input_red = Convert.ToDouble(colorOriginal.R);
        //    double dbl_input_green = Convert.ToDouble(colorOriginal.G);
        //    double dbl_input_blue = Convert.ToDouble(colorOriginal.B);

        //    double dbl_test_red, dbl_test_green, dbl_test_blue, temp;
        //    double distance = double.MaxValue;

        //    ColorHama colorSimilar = null;

        //    foreach (ColorHama _colorHama in coloresSeleccionados)
        //    {
        //        // compute the Euclidean distance between the two colors
        //        // note, that the alpha-component is not used in this example
        //        dbl_test_red = Math.Pow(Convert.ToDouble((_colorHama.Colorciko).R) - dbl_input_red, 2.0);
        //        dbl_test_green = Math.Pow(Convert.ToDouble
        //            ((_colorHama.Colorciko).G) - dbl_input_green, 2.0);
        //        dbl_test_blue = Math.Pow(Convert.ToDouble
        //            ((_colorHama.Colorciko).B) - dbl_input_blue, 2.0);
        //        // it is not necessary to compute the square root
        //        // it should be sufficient to use:
        //        // temp = dbl_test_blue + dbl_test_green + dbl_test_red;
        //        // if you plan to do so, the distance should be initialized by 250000.0
        //        temp = Math.Sqrt(dbl_test_blue + dbl_test_green + dbl_test_red);
        //        // explore the result and store the nearest color
        //        if (temp == 0.0)
        //        {
        //            // the lowest possible distance is - of course - zero
        //            // so I can break the loop (thanks to Willie Deutschmann)
        //            // here I could return the input_color itself
        //            // but in this example I am using a list with named colors
        //            // and I want to return the Name-property too
        //            colorSimilar = _colorHama;
        //            break;
        //        }
        //        else if (temp < distance)
        //        {
        //            distance = temp;
        //            colorSimilar = _colorHama;
        //        }
        //    }

        //    if (colorSimilar != null)
        //    {
        //        colorSimilar.NumPiezas++;
        //        //nearest_color = colorSimilar.Colorciko;
        //    }

        //    return colorSimilar;
        //}

        //private void statusStrip1_Resize(object sender, EventArgs e)
        //{
        //    StatusStrip estado = (StatusStrip) sender;
        //    barraProgreso.Size = new Size(estado.Width - 14, barraProgreso.Height);
        //}

        #region Radio Button Tipos Colores Seleccionados
        private void rdbSeleccionarTodosColores_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
                Chequear_Colores(true);
        }

        private void rdbNingunColor_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
                Chequear_Colores(false);
        }

        private void rdbBorde_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                colorBorde = Color.Black;
                colorNumero = Color.White;
            }
            else
            {
                colorBorde = Color.White;
                colorNumero = Color.Black;
            }

        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkTipo = (CheckBox)sender;

            ColorHama.eTipoHama tipo = (ColorHama.eTipoHama)Convert.ToInt16(chkTipo.Tag);

            IEnumerable<colorCheckBox> coloresChk = Obtener_ColorCheckBox();

            if (coloresChk != null)
                foreach (colorCheckBox chk in coloresChk.Where(x => x.Tipo.Equals(tipo)))
                    chk.Chk.Checked = chkTipo.Checked;          
            
            chkTipo = null;
        }

        private IEnumerable<colorCheckBox> Obtener_ColorCheckBox()
        {        
            List<colorCheckBox> oRetorno = new List<colorCheckBox>();

            foreach (GroupBox gb in tbColores.Controls.OfType<GroupBox>())
            {
                ///Doy por hecho que dentro de los groupbox va a haber un tablelayoutpanel con los controles dentro
                ///MAS INFO ==> Inicializar_Controles_Colores()
                TableLayoutPanel tb = gb.Controls[0] as TableLayoutPanel;
                oRetorno.AddRange(tb.Controls.OfType<colorCheckBox>());
            }

            return oRetorno;
        }

        private void Chequear_Colores(bool Valor)
        {
            foreach (colorCheckBox chk in Obtener_ColorCheckBox())
                chk.Chk.Checked = Valor;
            
            ///Deberia valer solo con esta segunda linea, pero como no controlo que solo se chequee cuando esten todos chequeados...no me vale.
            ///Ya que si ya está chequeado, no implica que estén todos chequedados de ese tipo, y si ya está chequeado, no salta el evento para que los chequee
            ///ya que el la propiedad CHECKED tiene el mismo valor en todo momento.
            foreach (CheckBox chk in gbTipos.Controls.OfType<CheckBox>())
                chk.Checked = Valor;
        }

        private void rdbMisHamas_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if (rdb.Checked)
                Cargar_Configuracion_Hamas();

        }
        #endregion

        #region Abrir Imagen

        private void tsbtnCargarImagen_Click(object sender, EventArgs e)
        {
            AbrirImagen();
        }

        private void cargarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirImagen();
        }

        private void AbrirImagen()
        {
            tsbtnGenerarImagen.Enabled = false;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Cualquier Imagen(*.bmp, *.png, *.jpg, *.jpeg)|*.bmp;*.png;*.jpg;*.jpeg|Imagen BMP (*.bmp)|*.bmp|Imagen PNG (*.png)|*.png|Imagen JPG, JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|Todos los Archivos (*.*)|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.Multiselect = false;
            DialogResult resultado = openFileDialog.ShowDialog();

            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                rutaOriginal = openFileDialog.FileNames[0];
                nombreOriginal = openFileDialog.SafeFileNames[0];
                extensionOriginal = nombreOriginal.Substring(nombreOriginal.IndexOf(".") + 1);

                //Common.Medida Ancho, Alto;

                using (Frm_RedimImage frm = new Frm_RedimImage())
                {
                    frm.RutaImagen = rutaOriginal;
                    if (frm.ShowDialog() == DialogResult.Cancel)
                        return;
                    Ancho = frm.Ancho;
                    Alto = frm.Alto;
                }

                Cargar_Imagen(openFileDialog.FileNames[0], Ancho.Px, Alto.Px);

                Habilitar_Botones_Tras_Abrir_Imagen();

                generarImagenToolStripMenuItem.Enabled = true;
            }
        }

        #endregion

        #region Generar

        private void tsbtnGenerarImagen_Click(object sender, EventArgs e)
        {
            Procesar_Imagen();
        }

        private void generarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procesar_Imagen();
        }

        private void Procesar_Imagen()
        {
            try
            {                
                try
                {
                    bmpGenerado = new Bitmap(bmpOriginal.Width, bmpOriginal.Height, bmpOriginal.PixelFormat);
                }
                catch (System.Exception ex)
                {
                    throw new cExcepcionControlada("Error al crear la imagen generada. Se ha excedido el tamaño maximo. (Tamaño Actual: "
                        + (bmpOriginal.Width * Constantes.AnchoHamaGen).ToString() + "x"
                        + (bmpOriginal.Height * Constantes.AltoHamaGen).ToString() + ").", ex);
                }

                Pixeles = LockBits(ref bmpOriginal, ref profundidad, ref step, ref punteroImagen, ref bmpData);
                PixelesGen = LockBits(ref bmpGenerado, ref profundidadGen, ref stepGen, ref punteroImagenGen, ref bmpDataGen);

                Ocultar_Mensaje_Estado();

                barraProgreso.Step = 1;
                barraProgreso.Value = 0;
                barraProgreso.Maximum = bmpOriginal.Height;

                ResetearContadoresHama();

                List<ColorHama> coloresSeleccionados = listaColores.Where(x => x.Habilitado).ToList();
                ProfundidadBase procesador = null;

                switch (bmpOriginal.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        procesador = new Profundidad24(bmpOriginal, Pixeles, PixelesGen, bmpData, bmpDataGen, step, stepGen);
                        break;
                    case PixelFormat.Format32bppArgb:
                        procesador = new Profundidad32(bmpOriginal, Pixeles, PixelesGen, bmpData, bmpDataGen, step, stepGen);
                        break;
                }

                procesador.barraProgreso = this.barraProgreso;                
                procesador.StepDoneEvent += new ProfundidadBase.StepDoneHandler(procesador_StepDone);

                this.Cursor = Cursors.WaitCursor;

                procesador.ProcesarImagen(coloresSeleccionados, false);

                this.Cursor = Cursors.Default;

                //if (BitConverter.IsLittleEndian)
                //{
                //    //Array.Reverse(Pixeles);
                //    //Array.Reverse(PixelesGen);
                //}

                UnlockBits(Pixeles, ref punteroImagen, ref bmpOriginal, ref bmpData);
                UnlockBits(PixelesGen, ref punteroImagenGen, ref bmpGenerado, ref bmpDataGen);

                pbZoomGenerada.SizeMode = PictureBoxSizeMode.Zoom;
                pbZoomGenerada.Imagen = bmpGenerado;

                ActualizarEtiquetasConNumeroDePiezasHama();
                ActualizarEstadisticas();

                Habilitar_Botones_Tras_Generar_Imagen();

                Mostrar_Mensaje_Estado("Imagen Generada Correctamente.");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message + System.Environment.NewLine + "Mas Info: "
                    + System.Environment.NewLine + System.Environment.NewLine
                    + (ex.InnerException != null ? ex.InnerException.Message : ""),
                    "ERROR GENERANDO IMAGEN", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex is cExcepcionControlada)
                    UnlockBits(Pixeles, ref punteroImagen, ref bmpOriginal, ref bmpData);
            }
        }

        //private void Procesar_Imagen()
        //{
        //    try
        //    {
        //        Pixeles = LockBits(ref bmpOriginal, ref profundidad, ref step, ref punteroImagen, ref bmpData);

        //        try
        //        {
        //            bmpGenerado = new Bitmap(bmpOriginal.Width * AnchoHamaGen, bmpOriginal.Height * AltoHamaGen, bmpOriginal.PixelFormat);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw new cExcepcionControlada("Error al crear la imagen generada. Se ha excedido el tamaño maximo. (Tamaño Actual: "
        //                + (bmpOriginal.Width * AnchoHamaGen).ToString() + "x"
        //                + (bmpOriginal.Height * AltoHamaGen).ToString() + ").", ex);
        //        }

        //        PixelesGen = LockBits(ref bmpGenerado, ref profundidadGen, ref stepGen, ref punteroImagenGen, ref bmpDataGen);

        //        Ocultar_Mensaje_Estado();

        //        barraProgreso.Step = 1;
        //        barraProgreso.Value = 0;
        //        barraProgreso.Maximum = bmpOriginal.Height;

        //        ResetearContadoresHama();

        //        List<ColorHama> coloresSeleccionados = listaColores.Where(x => x.Habilitado).ToList();
        //        ProfundidadBase procesador = null;

        //        switch (bmpOriginal.PixelFormat)
        //        {
        //            case PixelFormat.Format24bppRgb:
        //                procesador = new Profundidad24(bmpOriginal, Pixeles, PixelesGen, bmpData, bmpDataGen, step, stepGen);                        
        //                break;
        //            case PixelFormat.Format32bppArgb:
        //                procesador = new Profundidad32(bmpOriginal, Pixeles, PixelesGen, bmpData, bmpDataGen, step, stepGen);
        //                break;
        //        }

        //        procesador.barraProgreso = this.barraProgreso;
        //        procesador.StepDone += new ProfundidadBase.StepDoneHandler(procesador_StepDone);
        //        procesador.ProcesarImagen(coloresSeleccionados);

        //        //if (BitConverter.IsLittleEndian)
        //        //{
        //        //    //Array.Reverse(Pixeles);
        //        //    //Array.Reverse(PixelesGen);
        //        //}

        //        UnlockBits(Pixeles, ref punteroImagen, ref bmpOriginal, ref bmpData);
        //        UnlockBits(PixelesGen, ref punteroImagenGen, ref bmpGenerado, ref bmpDataGen);

        //        pbZoomGenerada.SizeMode = PictureBoxSizeMode.Zoom;
        //        pbZoomGenerada.Imagen = bmpGenerado;

        //        ActualizarEtiquetasConNumeroDePiezasHama();
        //        ActualizarEstadisticas();

        //        Habilitar_Botones_Tras_Generar_Imagen();

        //        Mostrar_Mensaje_Estado("Imagen Generada Correctamente.");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + System.Environment.NewLine + "Mas Info: "
        //            + System.Environment.NewLine + System.Environment.NewLine
        //            + (ex.InnerException != null ? ex.InnerException.Message : ""),
        //            "ERROR GENERANDO IMAGEN", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        if (ex is cExcepcionControlada)
        //            UnlockBits(Pixeles, ref punteroImagen, ref bmpOriginal, ref bmpData);
        //    }
        //}

        #region Barra Estado
        private void Mostrar_Mensaje_Estado(string Mensaje, bool AddHora = true)
        {
            tslblEstado.Text = Mensaje;
            tslblEstado.Visible = true;

            tslblEnlace.Visible = true;
            tslblEnlace.Text = "";

            if (AddHora)
            {
                tslblHora.Text = DateTime.Now.ToString();
                tslblHora.Visible = true;
            }
            else
            {
                tslblHora.Visible = false;
                tslblHora.Text = "";
            }
        }

        private void Mostrar_Mensaje_Estado(string Mensaje, string linkTexto, string linkValor, bool AddHora = true)
        {
            tslblEstado.Text = Mensaje;
            tslblEnlace.Text = linkTexto;
            tslblEnlace.Tag = linkValor;
            tslblEstado.Visible = true;
            tslblEnlace.Visible = true;

            if (AddHora)
            {
                tslblHora.Text = DateTime.Now.ToString();
                tslblHora.Visible = true;
            }
            else
            {
                tslblHora.Visible = false;
                tslblHora.Text = "";
            }
        }

        private void Ocultar_Mensaje_Estado()
        {
            tslblEstado.Text = "";
            tslblEstado.Width = 0;
            tslblEstado.Visible = false;
        }

        private void tslblEnlace_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe",
                (((ToolStripLabel)sender).Tag).ToString());
        }
        #endregion

        void procesador_StepDone(object sender, EventArgs e)
        {
            if (barraProgreso.InvokeRequired)
            {

                barraProgreso.BeginInvoke((ProfundidadBase.StepDoneHandler)delegate
                {
                    barraProgreso.PerformStep();
                });
            }
            else
            {
                barraProgreso.PerformStep();
            }
            
        }

        #endregion

        #region Guardar
        private void tsbtnGuardarImagen_Click(object sender, EventArgs e)
        {
            GuardarImagen();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarImagen();
        }

        private void GuardarImagen()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = rutaOriginal.Substring(0, rutaOriginal.LastIndexOf("\\"));
            saveFileDialog.FileName = nombreOriginal.Substring(0, nombreOriginal.IndexOf(".")) + "_Generada." + extensionOriginal;
            saveFileDialog.Filter = "Cualquier Imagen(*.bmp, *.png, *.jpg, *.jpeg)|*.bmp;*.png;*.jpg;*.jpeg|Imagen BMP (*.bmp)|*.bmp|Imagen PNG (*.png)|*.png|Imagen JPG, JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|Todos los Archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                rutaGuardado = saveFileDialog.FileName;
                nombreGuardado = rutaGuardado.Substring(rutaGuardado.LastIndexOf("\\") + 1);
                extensionGuardado = nombreGuardado.Substring(nombreGuardado.IndexOf(".") + 1);
                bmpGenerado.Save(rutaGuardado);
                pbZoomGenerada.Ruta = rutaGuardado;
                Mostrar_Mensaje_Estado("Imagen guardada correctamente en: ", rutaGuardado
                    , rutaGuardado.Substring(0, rutaGuardado.LastIndexOf("\\")));
            }
        }
        #endregion        

        #region XML CONFIG

        private void Guardar_Configuracion()
        {
            try
            {
                if (System.IO.File.Exists(rutaConfig))
                    Updatear_XML();
                else
                    Crear_XML();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar configuración. ## Mas Info:" + System.Environment.NewLine
                    + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Crear_XML()
        {
            XmlDocument doc = new XmlDocument();

            XmlElement el;

            XmlElement elementoPrincipal = (XmlElement)doc.AppendChild(doc.CreateElement("CONFIGURACION"));

            Guardar_Configuracion_Hamas(doc, elementoPrincipal);

            //Guardo la configuracion de qué de colores hay seleccionados
            el = (XmlElement)elementoPrincipal.AppendChild(doc.CreateElement("SeleccionColor"));
            foreach (RadioButton rdb in gbColoresSeleccionados.Controls.OfType<RadioButton>())
            {
                XmlElement hijo = (XmlElement)el.AppendChild(doc.CreateElement(rdb.Name));
                hijo.SetAttribute("Valor", rdb.Checked.ToString());
            }

            //Guardo la configuracion de qué tipo de colores hay seleccionados
            el = (XmlElement)elementoPrincipal.AppendChild(doc.CreateElement("TipoColores"));
            foreach (CheckBox chk in gbTipos.Controls.OfType<CheckBox>())
            {
                XmlElement hijo = (XmlElement)el.AppendChild(doc.CreateElement(chk.Name));
                hijo.SetAttribute("Valor", chk.Checked.ToString());
            }

            //Guardo la configuracion de qué tipo de borde hay seleccionados
            el = (XmlElement)elementoPrincipal.AppendChild(doc.CreateElement("Borde"));
            foreach (RadioButton rdb in gbBorde.Controls.OfType<RadioButton>())
            {
                XmlElement hijo = (XmlElement)el.AppendChild(doc.CreateElement(rdb.Name));
                hijo.SetAttribute("Valor", rdb.Checked.ToString());
            }

            doc.Save(rutaConfig);
        }

        private void Updatear_XML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaConfig);

            XmlElement elementoPrincipal = doc.DocumentElement;
            XmlElement el, elHijo;

            Guardar_Configuracion_Hamas(doc, elementoPrincipal);

            el = (XmlElement)elementoPrincipal.GetElementsByTagName("SeleccionColor")[0];
            foreach (RadioButton rdb in gbColoresSeleccionados.Controls.OfType<RadioButton>())
            {
                elHijo = (XmlElement)el.GetElementsByTagName(rdb.Name)[0];
                elHijo.SetAttribute("Valor", rdb.Checked.ToString());
            }

            el = (XmlElement)elementoPrincipal.GetElementsByTagName("TipoColores")[0];
            foreach (CheckBox chk in gbTipos.Controls.OfType<CheckBox>())
            {
                elHijo = (XmlElement)el.GetElementsByTagName(chk.Name)[0];
                elHijo.SetAttribute("Valor", chk.Checked.ToString());
            }

            el = (XmlElement)elementoPrincipal.GetElementsByTagName("Borde")[0];
            foreach (RadioButton rdb in gbBorde.Controls.OfType<RadioButton>())
            {
                elHijo = (XmlElement)el.GetElementsByTagName(rdb.Name)[0];
                elHijo.SetAttribute("Valor", rdb.Checked.ToString());
            }

            doc.Save(rutaConfig);

        }

        private void Cargar_Configuracion()
        {
            if (System.IO.File.Exists(rutaConfig))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaConfig);
                XmlElement elementoPrincipal = doc.DocumentElement;
                XmlElement el, elHijo;

                el = (XmlElement)elementoPrincipal.GetElementsByTagName("SeleccionColor")[0];
                foreach (RadioButton rdb in gbColoresSeleccionados.Controls.OfType<RadioButton>())
                {
                    elHijo = (XmlElement)el.GetElementsByTagName(rdb.Name)[0];
                    rdb.Checked = Convert.ToBoolean(elHijo.GetAttribute("Valor"));
                }

                el = (XmlElement)elementoPrincipal.GetElementsByTagName("TipoColores")[0];
                foreach (CheckBox chk in gbTipos.Controls.OfType<CheckBox>())
                {
                    elHijo = (XmlElement)el.GetElementsByTagName(chk.Name)[0];
                    chk.Checked = Convert.ToBoolean(elHijo.GetAttribute("Valor"));
                }

                el = (XmlElement)elementoPrincipal.GetElementsByTagName("Borde")[0];
                foreach (RadioButton rdb in gbBorde.Controls.OfType<RadioButton>())
                {
                    elHijo = (XmlElement)el.GetElementsByTagName(rdb.Name)[0];
                    rdb.Checked = Convert.ToBoolean(elHijo.GetAttribute("Valor"));
                }

                //foreach (ColorHama color in listaColores)
                //{
                //    XmlElement nodo = doc.GetElementById(color.Colorciko.ToArgb().ToString());
                //    color.Habilitado = Convert.ToBoolean(nodo.GetAttribute("Habilitado"));
                //}
            }
        }

        private void Guardar_Configuracion_Hamas(XmlDocument doc, XmlElement elementoPrincipal)
        {
            XmlElement el;

            //Guardo la configuracion de colores
            if (rdbMisHamas.Checked)
            {
                el = (XmlElement)elementoPrincipal.GetElementsByTagName("Colores")[0];

                if (el == null)
                {
                    el = (XmlElement)elementoPrincipal.AppendChild(doc.CreateElement("Colores"));

                    foreach (ColorHama color in listaColores)
                    {
                        XmlElement elColor = (XmlElement)el.AppendChild(doc.CreateElement(color.Colorciko.Name));
                        elColor.SetAttribute("Nombre", color.Nombre);
                        elColor.SetAttribute("RGB", color.Colorciko.ToArgb().ToString());
                        elColor.SetAttribute("Habilitado", color.Habilitado.ToString());
                    }
                }
                else
                {
                    foreach (ColorHama color in listaColores)
                    {
                        XmlElement elColor = (XmlElement)el.GetElementsByTagName(color.Colorciko.Name)[0];
                        elColor.SetAttribute("Habilitado", color.Habilitado.ToString());
                    }
                }
            }
        }

        private void Cargar_Configuracion_Hamas()
        {
            if (System.IO.File.Exists(rutaConfig))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaConfig);
                XmlElement elementoPrincipal = doc.DocumentElement;
                XmlElement el;

                el = (XmlElement)elementoPrincipal.GetElementsByTagName("Colores")[0];

                if (el != null)
                {
                    foreach (ColorHama color in listaColores)
                    {
                        XmlElement nodo = (XmlElement)el.GetElementsByTagName(color.Colorciko.Name)[0];
                        color.Habilitado = Convert.ToBoolean(nodo.GetAttribute("Habilitado"));
                    }
                }
            }
        }

        #endregion

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Guardar_Configuracion();
        }

        private void tsbtnTrocearImagen_Click(object sender, EventArgs e)
        {
            Trocear_Imagen_Entera();
        }

        private void trocearImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trocear_Imagen_Entera();
        }

        private void Trocear_Imagen_Entera()
        {
            bmpComposicion = new Bitmap(bmpGenerado);
            Graphics grComposicion = Graphics.FromImage(bmpComposicion);
            
            ///Le pongo esto para que el texto se vea bien, y no borroso.
            grComposicion.SmoothingMode = SmoothingMode.HighQuality;
            
            GraphicsPath path = new GraphicsPath();

            int Indice_FILA = 0;
            int Indice_COLUMNA = 0;
            string Texto;
            string nombreFich = nombreOriginal.Substring(0, nombreOriginal.LastIndexOf("."));

            float TamanioFuente = 12;
            Font fuente = new Font(FontFamily.GenericSansSerif, TamanioFuente);

            if (string.IsNullOrEmpty(rutaGuardado))
                GuardarImagen();

            if (!string.IsNullOrEmpty(rutaGuardado))
            {
                rutaGuardadoTroceada = rutaGuardado.Substring(0, rutaGuardado.LastIndexOf("\\")) + "\\Troceada\\" + nombreFich + "\\";

                if (!System.IO.Directory.Exists(rutaGuardadoTroceada))
                    System.IO.Directory.CreateDirectory(rutaGuardadoTroceada);

                ///Inicializo la barra de progreso
                barraProgreso.Step = 1;
                barraProgreso.Value = 0;
                barraProgreso.Maximum = (int)Math.Round((double)bmpGenerado.Height / Constantes.AltoPlacaPx);

                for (int y = 0; y <= bmpOriginal.Height; y += Constantes.AltoPlacaPx)
                {
                    for (int x = 0; x <= bmpOriginal.Width; x += Constantes.AnchoPlacaPx)
                    {
                        Texto = Indice_FILA.ToString("D2") + "_" + Indice_COLUMNA.ToString("D2");

                        Trocear_Imagen_Placa(x, y, Texto);

                        ///Aqui pinto en una copia de la imagen generada la situacion de las distintas imagenes de cada placa
                        path.AddString(Texto, fuente.FontFamily
                            , (int)FontStyle.Bold, TamanioFuente, new Point((x + Constantes.AnchoPlacaPx / 4), (y + Constantes.AltoPlacaPx / 4)),
                            new StringFormat(StringFormat.GenericTypographic));

                        grComposicion.DrawPath(Pens.Black, path);
                        grComposicion.FillPath(Brushes.White, path);

                        path.Reset();

                        Indice_COLUMNA++;
                    }

                    Indice_FILA++;
                    Indice_COLUMNA = 0;

                    barraProgreso.PerformStep();
                }

                bmpComposicion.Save(rutaGuardadoTroceada + nombreFich + "_composicion." + extensionGuardado);

                if (chkGenerarReporte.Checked)
                    Generar_Reporte_Fichas(rutaGuardadoTroceada + nombreFich + ".txt");

                Mostrar_Mensaje_Estado("Imagen troceada correctamente en: ", rutaGuardadoTroceada, rutaGuardadoTroceada);
            }

            bmpComposicion.Dispose();
            bmpComposicion = null;
        }

        private void Trocear_Imagen_Placa(int x, int y, string Texto)
        {
            Bitmap bmpAux = new Bitmap(Constantes.AnchoPlacaPx, Constantes.AltoPlacaPx, bmpGenerado.PixelFormat);
            Byte[] PixelesAux = null;
            int profundidadAux=0, stepAux=0;
            IntPtr punteroImagenAux = IntPtr.Zero;
            BitmapData bmpDataAux = null;

            try
            {                
                try
                {
                    Graphics.FromImage(bmpAux).DrawImage(bmpGenerado, new Rectangle(0, 0, Constantes.AnchoPlacaPx, Constantes.AltoPlacaPx),
                        new Rectangle(x, y, Constantes.AnchoPlacaPx, Constantes.AltoPlacaPx), GraphicsUnit.Pixel);
                    bmpTroceada = new Bitmap(bmpAux.Width * Constantes.AnchoHamaGen, bmpAux.Height * Constantes.AltoHamaGen, bmpAux.PixelFormat);
                }
                catch (System.Exception ex)
                {
                    throw new cExcepcionControlada("Error al crear la imagen generada. Se ha excedido el tamaño maximo. (Tamaño Actual: "
                        + (bmpGenerado.Width * Constantes.AnchoHamaGen).ToString() + "x"
                        + (bmpGenerado.Height * Constantes.AltoHamaGen).ToString() + ").", ex);
                }

                PixelesAux = LockBits(ref bmpAux, ref profundidadAux, ref stepAux, ref punteroImagenAux, ref bmpDataAux);
                PixelesTroceada = LockBits(ref bmpTroceada, ref profundidadTroceada, ref stepTroceada, ref punteroImagenTroceada, ref bmpDataTroceada);

                Ocultar_Mensaje_Estado();
                
                List<ColorHama> coloresSeleccionados = listaColores.Where(i => i.Habilitado).ToList();
                ProfundidadBase procesador = null;

                switch (bmpAux.PixelFormat)
                {
                    case PixelFormat.Format24bppRgb:
                        procesador = new Profundidad24(bmpAux, PixelesAux, PixelesTroceada, bmpDataAux, bmpDataTroceada, stepAux, stepTroceada);
                        break;
                    case PixelFormat.Format32bppArgb:
                        procesador = new Profundidad32(bmpAux, PixelesAux, PixelesTroceada, bmpDataAux, bmpDataTroceada, stepAux, stepTroceada);
                        break;
                }

                this.Cursor = Cursors.WaitCursor;

                procesador.ProcesarImagen(coloresSeleccionados, true);

                this.Cursor = Cursors.Default;
                
                UnlockBits(PixelesAux, ref punteroImagenAux, ref bmpAux, ref bmpDataAux);
                UnlockBits(PixelesTroceada, ref punteroImagenTroceada, ref bmpTroceada, ref bmpDataTroceada);

                bmpTroceada.Save(rutaGuardadoTroceada + Texto + "." + extensionGuardado);               

                bmpTroceada.Dispose();
                bmpTroceada = null;
                bmpAux.Dispose();
                bmpAux = null;

                punteroImagenAux = IntPtr.Zero;
                PixelesAux = null;
                bmpDataAux = null;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message + System.Environment.NewLine + "Mas Info: "
                    + System.Environment.NewLine + System.Environment.NewLine
                    + (ex.InnerException != null ? ex.InnerException.Message : ""),
                    "ERROR GENERANDO IMAGEN", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (ex is cExcepcionControlada)
                    UnlockBits(PixelesAux, ref punteroImagenAux, ref bmpAux, ref bmpDataAux);
            }            
        }        

        private void btnGuardarConfig_Click(object sender, EventArgs e)
        {
            Guardar_Configuracion();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_AcercaDe acerca = new Frm_AcercaDe();
            acerca.Show();
        }

        private void Generar_Reporte_Fichas(string ruta)
        {
            if (string.IsNullOrEmpty(ruta))
            {
                //OpenFileDialog ofd = new OpenFileDialog();
                //if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //ofd.FileName
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(ruta))
            {
                file.WriteLine("#####################################################");
                file.WriteLine("#######               INFORME                 #######");
                file.WriteLine("#####################################################");
                file.WriteLine();
                file.WriteLine();

                foreach (colorCheckBox color in Obtener_ColorCheckBox()
                    .Where(x => x.NumPiezas != null)
                    .OrderByDescending(x => x.NumPiezas))
                {
                    file.WriteLine("COLOR " + color.NombreColor + " ==> " + color.NumPiezas);
                }
            }
        }

        private void cmbTipoMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pbZoomOriginal.TipoMedida = (eTipoMedida)cmbTipoMedida.SelectedIndex;
            this.pbZoomGenerada.TipoMedida = (eTipoMedida)cmbTipoMedida.SelectedIndex;
        }
    }
}
