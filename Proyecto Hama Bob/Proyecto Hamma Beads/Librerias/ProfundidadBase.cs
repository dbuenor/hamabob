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

        public delegate void StepDoneHandler();
        public event StepDoneHandler StepDone;

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
        public abstract void PintarImagen(int pixelInicio, System.Drawing.Color colorFondo, int pixelesFila, List<ColorHama> coloresSeleccionados);
        public abstract void PintarNumero(int numero, int posActual, int pixelesFila);
        public abstract void PintarDigito(int numero, int posActual, int pixelesFila, eDigito digito);
        public abstract void PintarRecuadroHama(int posActual, int pixelesFila, int pixelInicio, System.Drawing.Color color);
        public abstract void PintarFilaEnteraColor(int posicion, System.Drawing.Color color);
        public abstract void PintarFilaEnteraConBorde(int posicion, System.Drawing.Color color, System.Drawing.Color colorBorde);
        public abstract void PintarPixel(int posicion, System.Drawing.Color color);

        #endregion

        #region Resto Funciones

        public virtual void ProcesarImagen(List<ColorHama> coloresSeleccionados)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int y = 0; y < bmpOriginal.Height; y++)
            {
                System.Threading.Tasks.Parallel.For(0, bmpOriginal.Width, iteracion =>
                    {
                        ProcesarImagenBits(coloresSeleccionados, iteracion * step, y);
                        
                        //if (StepDone != null)
                            //StepDone();
                    });
            }
            
            //for (int y = 0; y < bmpOriginal.Height; y++)
            //{
            //    for (int x = 0; x < (bmpOriginal.Width * step); x += step)
            //    {
            //        ProcesarImagenBits(coloresSeleccionados, x, y);                    
            //    }

            //    if (StepDone != null)
            //        StepDone();                
            //}

            sw.Stop();

            Console.WriteLine("TIEMPO USADO ==> " + sw.ElapsedMilliseconds.ToString());
        }

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
