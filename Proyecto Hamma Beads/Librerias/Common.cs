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

    //public class cColoresEncontrados
    //{
    //    public Color ColorBuscado { get; set; }
    //    public ColorHama ColorParecido { get; set; }
    //}

    public class Common
    {

        //private static List<cColoresEncontrados> coloresYaEncontrados = new List<cColoresEncontrados>();
        //private static object bloqueo = new object();

        ///// <summary>
        ///// Función que busca en la caché de colores ya encontrados para ver si es un color que ya se haya buscado anteriormente, para no tener que volver a buscar su color parecido.
        ///// </summary>
        ///// <param name="colorOriginal"></param>
        ///// <returns></returns>
        //private static ColorHama RevisarColoresYaEncontrados(Color colorOriginal)
        //{            
        //    for (int i = 0; i < coloresYaEncontrados.Count(); i++)
        //    {
        //        cColoresEncontrados aux = coloresYaEncontrados[i];

        //        Color clr = aux.ColorBuscado;
        //        if (clr.R == colorOriginal.R)
        //            if (clr.G == colorOriginal.G)
        //                if (clr.B == colorOriginal.B)
        //                    return aux.ColorParecido;
        //    }

        //    return null;
        //}

        public static ColorHama EncontrarColorParecido(Color colorOriginal, List<ColorHama> coloresSeleccionados)
        {
            ColorHama colorSimilar = null;

            /////Primero busco en la caché
            ////colorSimilar = RevisarColoresYaEncontrados(colorOriginal);

            /////Si no está en la caché...entonces busco su color parecido y lo añado a la caché de colores ya encontrados.
            if (colorSimilar == null)
            {

                double dbl_input_red = Convert.ToDouble(colorOriginal.R);
                double dbl_input_green = Convert.ToDouble(colorOriginal.G);
                double dbl_input_blue = Convert.ToDouble(colorOriginal.B);

                double dbl_test_red, dbl_test_green, dbl_test_blue, temp;
                double distance = double.MaxValue;


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

                //if (colorSimilar != null)
                //    lock (bloqueo)
                //    {
                //        coloresYaEncontrados.Add(new cColoresEncontrados() { ColorBuscado = colorOriginal, ColorParecido = colorSimilar });
                //    }
            }

            if (colorSimilar != null)
            {
                colorSimilar.NumPiezas++;
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
            public delegate void MedidaCambiadaEvent();
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
                            MedidaCambiada();
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
