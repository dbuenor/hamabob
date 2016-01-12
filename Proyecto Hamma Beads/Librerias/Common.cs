using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Proyecto_Hamma_Beads.Librerias
{
    public enum eDigito
    {
        Izquierda,
        Derecha
    }

    public class Constantes
    {
        #region Constantes
        public const int AnchoHamaGen = 10;
        public const int AltoHamaGen = 10;
        public const int AnchoPlacaPx = 57;
        public const int AltoPlacaPx = 57;
        public const int AnchoPlacaCm = 15;
        public const int AltoPlacaCm = 15;
        #endregion   
    }    
    
    public enum eTipoMedida
    {
        Pixeles,
        Centimetros
    }    

    public class Common
    {
        public static ColorHama EncontrarColorParecido(Color colorOriginal, List<ColorHama> coloresSeleccionados)
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
        
        #region Medidas
        
        private static int Transformar_Medida(int valor, eTipoMedida tipoValor)
        {
            switch (tipoValor)
            {
                case eTipoMedida.Centimetros:
                    return ((valor * Constantes.AnchoPlacaPx) / Constantes.AnchoPlacaCm);
                case eTipoMedida.Pixeles:
                    return ((valor * Constantes.AnchoPlacaCm) / Constantes.AnchoPlacaPx);
                default:
                    return -1;
            }
        }

        public static int Transformar_Pixeles_A_CM(int valor)
        {
            return Transformar_Medida(valor, eTipoMedida.Pixeles);
        }

        public static int Transformar_CM_A_Pixeles(int valor)
        {
            return Transformar_Medida(valor, eTipoMedida.Centimetros);
        }

        public class Medida
        {
            private int _px, _cm;
            public delegate void MedidaCambiadaEvent(object sender, EventArgs e);
            public event MedidaCambiadaEvent MedidaCambiada;

            public int Px
            {
                get
                {
                    return _px;
                }
                set
                {
                    if (value != _px)
                    {
                        _px = value;
                        _cm = Transformar_Pixeles_A_CM(value);
                        if (MedidaCambiada != null)
                            MedidaCambiada(this, null);
                    }
                }
            }
            public int Cm
            {
                get
                {
                    return _cm;
                }
                set
                {
                    if (value != _cm)
                    {
                        _cm = value;
                        _px = Transformar_CM_A_Pixeles(value);
                    }
                }
            }

            public void Establecer_Valor(eTipoMedida tipo, string texto)
            {
                if (tipo == eTipoMedida.Centimetros)
                    Cm = Convert.ToInt16(texto);
                else
                    Px = Convert.ToInt16(texto);
            }

            public int Devolver_Medida(eTipoMedida tipo)
            {
                if (tipo == eTipoMedida.Centimetros)
                    return this.Cm;
                else
                    return this.Px;
            }
        }

        #endregion
    }
}
