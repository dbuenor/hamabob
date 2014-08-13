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
    }
}
