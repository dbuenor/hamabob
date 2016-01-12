using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyecto_Hamma_Beads.Controles
{
    public partial class colorCheckBox : UserControl
    {
        public string NombreColor
        {
            get
            {
                return this.chkColor.Text;
            }
            set
            {
                this.chkColor.Text = value;
            }            
        }

        private int? _numPiezas;
        public int? NumPiezas
        {
            get
            {
                return _numPiezas;
            }
            set
            {
                _numPiezas = value;

                if (_numPiezas.HasValue)
                    lblNumPiezas.Text = String.Format("({0})", NumPiezas.Value);
                else
                    lblNumPiezas.Text = "";
            }
        }

        public ColorHama.eTipoHama Tipo
        {
            get
            {
                return _color.Tipo;
            }            
        }

        private eLadoCuadrado _lado = eLadoCuadrado.Izquierda;
        private ColorHama _color;

        #region Propiedades Publicas        
        public eLadoCuadrado LadoCuadrado
        {
            get
            {
                return _lado;
            }
            set
            {                
                if (_lado != value)
                {
                    switch (value)
                    {
                        case eLadoCuadrado.Derecha:
                            tableLayoutPanel1.SetColumn(chkColor, 0);
                            tableLayoutPanel1.SetColumn(pnlRecuadroColor, 1);
                            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.AutoSize;
                            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Absolute;
                            tableLayoutPanel1.ColumnStyles[1].Width = 20;
                            break;
                        case eLadoCuadrado.Izquierda:
                            tableLayoutPanel1.SetColumn(chkColor, 1);
                            tableLayoutPanel1.SetColumn(pnlRecuadroColor, 0);
                            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Absolute;
                            tableLayoutPanel1.ColumnStyles[0].Width = 20;
                            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.AutoSize;                            
                            break;
                    }

                    _lado = value;
                }
            }
        }
        //public Color Color { get; set; }
        public int AnchoCuadrado { get; set; }
        public int AltoCuadrado { get; set; }
        public int Alto
        {
            get
            {
                return this.Height;
            }
        }
        public int Ancho
        {
            get
            {
                return this.Width;
            }
        }
        public ColorHama Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color == null)
                {
                    _color = value;
                    Color.HabilitadoEvent += new ColorHama.HabilitadoEventHandler(Color_HabilitadoEvent);
                }
                else
                {
                    _color = value;
                }

                
            }

        }

        public CheckBox Chk
        {
            get
            {
                return chkColor;
            }
        }
        #endregion

        const int _anchoDefecto = 12;
        const int _altoDefecto = 12;        

        public enum eLadoCuadrado
        {
            Derecha,
            Izquierda
        }

        public colorCheckBox()
        {
            InitializeComponent();

            chkColor.CheckedChanged += new EventHandler(chkColor_CheckedChanged);

            ///Esto lo pongo para que salte el evento al control padre que contiene todos los demás controles, sino no salta.
            ///Es decir, hago un "bubbling" de forma manual.
            chkColor.MouseHover += new EventHandler(controlHijo_MouseHover);
            pnlRecuadroColor.MouseHover += new EventHandler(controlHijo_MouseHover);
            lblNumPiezas.MouseHover += new EventHandler(controlHijo_MouseHover);
            tableLayoutPanel1.MouseHover += new EventHandler(controlHijo_MouseHover);
            

            AltoCuadrado = _altoDefecto;
            AnchoCuadrado = _anchoDefecto;
        }

        void controlHijo_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
        }        

        void Color_HabilitadoEvent(object sender, EventArgs e)
        {
            chkColor.Checked = Color.Habilitado;
        }

        void chkColor_CheckedChanged(object sender, EventArgs e)
        {
            Color.Habilitado = chkColor.Checked;
        }

        private void pnlRecuadroColor_Paint(object sender, PaintEventArgs e)
        {
            if (!Color.Colorciko.IsEmpty)
            {                
                SolidBrush relleno = new SolidBrush(Color.Colorciko);
                Rectangle rect = new Rectangle(0, 1, AnchoCuadrado, AltoCuadrado);
                System.Drawing.Graphics graficos = e.Graphics;
                Pen borde = new Pen(Brushes.Black, 1);
                borde.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                graficos.FillRectangle(relleno, rect);
                graficos.DrawRectangle(borde, rect);
            }
        }
    }
}
