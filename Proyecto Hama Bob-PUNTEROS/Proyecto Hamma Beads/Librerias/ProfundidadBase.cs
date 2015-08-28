using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Proyecto_Hamma_Beads.Librerias
{
    public abstract class ProfundidadBase : IProfundidad
    {        
        #region Constantes

        protected const int AnchoHamaGen = 10;
        protected const int AltoHamaGen = 10;
        protected const int AnchoPlaca = 57;
        protected const int AltoPlaca = 57;

        #endregion
        #region Propiedades

        public Bitmap bmpOriginal { get; set; }
        
        public int step { get; set; }
        public int stepGen { get; set; }
        public int profundidad { get; set; }
        public int profundidadGen { get; set; }

        public byte[] Pixeles { get; set; }
        public byte[] PixelesGen { get; set; }

        public Color colorBorde { get; set; }
        public Color colorNumero { get; set; }

        public BitmapData bmpData { get; set; }
        public BitmapData bmpDataGen { get; set; }

        public System.Windows.Forms.ProgressBar barraProgreso { get; set; }

        #endregion

        #region Eventos

        public delegate void StepDoneHandler(object sender, EventArgs e);
        public event StepDoneHandler StepDoneEvent;

        #endregion

        #region Constructor

        public ProfundidadBase(Bitmap _bmpOriginal, byte[] _pixeles, byte[] _pixelesGen,
            BitmapData _bmpData, BitmapData _bmpDataGen, int _step, int _stepGen)
        {
            bmpOriginal = _bmpOriginal;
            Pixeles = _pixeles;
            PixelesGen = _pixelesGen;
            bmpData = _bmpData;
            bmpDataGen = _bmpDataGen;
            step = _step;
            stepGen = _stepGen;
        }

        #endregion

        #region Funciones
        #region Funciones Abstractas

        public abstract void ProcesarImagenBits(List<ColorHama> coloresSeleccionados, int x, int y);
        public abstract void ProcesarImagenBitsSOLOColor(List<ColorHama> coloresSeleccionados, int x, int y);
        //public abstract void ProcesarImagenBitsSOLONumero(int x, int y);                
        
        public abstract void PintarDigito(int numero, int posActual, int pixelesFila, eDigito digito);
        public abstract void PintarRecuadroHama(int posActual, int pixelesFila, int pixelInicio, System.Drawing.Color color);
        public abstract void PintarFilaEnteraColor(int posicion, System.Drawing.Color color);
        public abstract void PintarFilaEnteraConBorde(int posicion, System.Drawing.Color color, System.Drawing.Color colorBorde);
        public abstract void PintarPixel(int posicion, System.Drawing.Color color);

        

        #endregion

        #region Resto Funciones

        //public virtual void PintarImagenSOLONumero(int pixelInicio, Color colorFondo, int pixelesFila)
        //{
        //    int posActual = pixelInicio;
            
        //    ColorHama col = new ColorHama(colorFondo);

        //    PintarRecuadroHama(posActual, pixelesFila, pixelInicio, colorFondo);

        //    PintarNumero(0, posActual, pixelesFila);
        //}

        public virtual void PintarImagenSOLOColor(int pixelInicio, Color colorFondo, List<ColorHama> coloresSeleccionados)
        {
            int posActual = pixelInicio;

            ColorHama colorParecido;

            colorParecido = Common.EncontrarColorParecido(colorFondo, coloresSeleccionados);

            PintarPixel(pixelInicio, colorParecido.Colorciko);
        }    

        public virtual void PintarImagen(int pixelInicio, Color colorFondo, int pixelesFila, List<ColorHama> coloresSeleccionados)
        {
            int posActual = pixelInicio;

            ColorHama colorParecido;

            colorParecido = Common.EncontrarColorParecido(colorFondo, coloresSeleccionados);

            PintarRecuadroHama(posActual, pixelesFila, pixelInicio, colorParecido.Colorciko);

            //PintarNumero(colorParecido.Numero, posActual, pixelesFila);
        }  

        public virtual void PintarNumero(int numero, int posActual, int pixelesFila)
        {
            switch (numero)
            {
                case 1:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 2:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 3:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 4:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 5:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 6:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 7:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 8:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 9:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    break;

                case 10:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 11:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 12:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 13:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 14:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 15:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 16:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 17:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 18:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 19:
                    PintarDigito(1, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 20:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 21:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 22:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 23:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 24:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 25:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 26:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 27:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 28:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 29:
                    PintarDigito(2, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 30:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 31:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 32:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 33:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 34:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 35:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 36:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 37:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 38:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 39:
                    PintarDigito(3, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 40:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 41:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 42:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 43:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 44:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 45:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 46:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 47:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 48:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 49:
                    PintarDigito(4, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;
                case 50:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 51:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 52:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 53:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 54:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 55:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 56:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 57:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 58:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 59:
                    PintarDigito(5, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 60:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 61:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 62:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 63:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 64:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 65:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 66:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 67:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 68:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 69:
                    PintarDigito(6, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;
                case 70:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 71:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 72:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 73:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 74:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 75:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 76:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 77:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 78:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 79:
                    PintarDigito(7, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;
                case 80:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 81:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 82:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 83:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 84:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 85:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 86:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 87:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 88:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 89:
                    PintarDigito(8, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;
                case 90:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(0, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 91:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(1, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 92:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(2, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 93:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(3, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 94:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(4, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 95:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(5, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 96:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(6, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 97:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(7, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 98:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(8, posActual, pixelesFila, eDigito.Derecha);
                    break;

                case 99:
                    PintarDigito(9, posActual, pixelesFila, eDigito.Izquierda);
                    PintarDigito(9, posActual, pixelesFila, eDigito.Derecha);
                    break;
            }
        }

        /// <summary>
        /// Funcion que nos procesa una imagen para encontrar qué colores parecidos de los seleccionados, se parecen a los de la imagen original.
        /// Es opcional si queremos que se pinten los numeros o no
        /// </summary>
        /// <param name="coloresSeleccionados">Colores Seleccionados a comparar con los originales</param>
        /// <param name="pintarNumHama">Parametro booleano que indica si queremos pintar o no los numeros correspondientes al color Parecido</param>
        public virtual void ProcesarImagen(List<ColorHama> coloresSeleccionados, bool pintarNumHama)
        {            
            Stopwatch sw = new Stopwatch();

            sw.Start();

            if (pintarNumHama)
            {
                for (int y = 0; y < bmpOriginal.Height; y++)
                {
                    System.Threading.Tasks.Parallel.For(0, bmpOriginal.Width, iteracion =>
                    {
                        ProcesarImagenBits(coloresSeleccionados, iteracion * step, y);                            
                    });

                    if (StepDoneEvent != null)
                        StepDoneEvent(this, null);
                }
            }
            else
            {                
                for (int y = 0; y < bmpOriginal.Height; y++)
                {
                    System.Threading.Tasks.Parallel.For(0, bmpOriginal.Width, iteracion =>
                    {
                        ProcesarImagenBitsSOLOColor(coloresSeleccionados, iteracion * step, y);                        
                    });

                    if (StepDoneEvent != null)
                        StepDoneEvent(this, null);
                }
            }

            sw.Stop();

            Console.WriteLine("TIEMPO USADO ==> " + sw.ElapsedMilliseconds.ToString());
        }

        ///// <summary>
        ///// Funcion que nos procesa una imagen, y nos pinta los numeros de cada color Hama.
        ///// </summary>
        ///// <param name="pintarNumHama">Parametro booleano que indica si queremos pintar o no los numeros correspondientes al color Parecido</param>
        //public virtual void ProcesarImagen()
        //{
        //    Stopwatch sw = new Stopwatch();

        //    sw.Start();

        //    for (int y = 0; y < bmpOriginal.Height; y++)
        //    {
        //        System.Threading.Tasks.Parallel.For(0, bmpOriginal.Width, iteracion =>
        //        {
        //            ProcesarImagenBitsSOLONumero(iteracion * step, y);
        //        });
        //    }
           
        //    sw.Stop();

        //    Console.WriteLine("TIEMPO USADO ==> " + sw.ElapsedMilliseconds.ToString());
        //}

        protected ColorHama EncontrarColorParecido(Color colorOriginal, List<ColorHama> coloresSeleccionados)
        {
            double dbl_input_red = Convert.ToDouble(colorOriginal.R);
            double dbl_input_green = Convert.ToDouble(colorOriginal.G);
            double dbl_input_blue = Convert.ToDouble(colorOriginal.B);

            double dbl_test_red, dbl_test_green, dbl_test_blue, temp;
            double distance = double.MaxValue;

            ColorHama colorSimilar = null;

            foreach (ColorHama _colorHama in coloresSeleccionados)
            {
                // compute the Euclidean distance between the two colors
                // note, that the alpha-component is not used in this example
                dbl_test_red = Math.Pow(Convert.ToDouble((_colorHama.Colorciko).R) - dbl_input_red, 2.0);
                dbl_test_green = Math.Pow(Convert.ToDouble
                    ((_colorHama.Colorciko).G) - dbl_input_green, 2.0);
                dbl_test_blue = Math.Pow(Convert.ToDouble
                    ((_colorHama.Colorciko).B) - dbl_input_blue, 2.0);
                // it is not necessary to compute the square root
                // it should be sufficient to use:
                // temp = dbl_test_blue + dbl_test_green + dbl_test_red;
                // if you plan to do so, the distance should be initialized by 250000.0
                temp = Math.Sqrt(dbl_test_blue + dbl_test_green + dbl_test_red);
                // explore the result and store the nearest color
                if (temp == 0.0)
                {
                    // the lowest possible distance is - of course - zero
                    // so I can break the loop (thanks to Willie Deutschmann)
                    // here I could return the input_color itself
                    // but in this example I am using a list with named colors
                    // and I want to return the Name-property too
                    colorSimilar = _colorHama;
                    break;
                }
                else if (temp < distance)
                {
                    distance = temp;
                    colorSimilar = _colorHama;
                }
            }

            if (colorSimilar != null)
            {
                colorSimilar.NumPiezas++;
                //nearest_color = colorSimilar.Colorciko;
            }

            return colorSimilar;
        }

        #endregion
        #endregion


        


    }
}
