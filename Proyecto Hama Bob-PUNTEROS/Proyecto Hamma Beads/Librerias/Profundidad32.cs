using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Proyecto_Hamma_Beads.Librerias
{
    public class Profundidad32 : ProfundidadBase
    {

        #region Constructor

        public Profundidad32(Bitmap _bmpOriginal, byte[] _pixeles, byte[] _pixelesGen,
            BitmapData _bmpData, BitmapData _bmpDataGen, int _step, int _stepGen) : base(_bmpOriginal,_pixeles,_pixelesGen,_bmpData,_bmpDataGen, _step, _stepGen)
        {

        }

        #endregion

        #region Funciones
        #region OverRide

        /// <summary>
        /// Procesa la imagen para generar una procesada en funcion de los colores seleccionados, y pinta qué numero de Hama debemos colocar en cada pixel
        /// </summary>
        /// <param name="coloresSeleccionados"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void ProcesarImagenBits(List<ColorHama> coloresSeleccionados, int x, int y)
        {
            PintarImagen((x * AnchoHamaGen) + (bmpDataGen.Stride * AltoHamaGen * y)
                , Color.FromArgb(
                    Pixeles[x + (bmpData.Stride * y) + 3],
                    Pixeles[x + (bmpData.Stride * y) + 2],
                    Pixeles[x + (bmpData.Stride * y) + 1],
                    Pixeles[x + (bmpData.Stride * y)]
                    )
                , bmpDataGen.Stride, coloresSeleccionados);               
        }

        /// <summary>
        /// Proceso la imagen para generar una procesada en funcion de los colores seleccionados. NO pinta los números, solo pinta el color más aproximado.
        /// </summary>
        /// <param name="coloresSeleccionados"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void ProcesarImagenBitsSOLOColor(List<ColorHama> coloresSeleccionados, int x, int y)
        {
            PintarImagenSOLOColor((x) + (bmpDataGen.Stride * y)
                , Color.FromArgb(
                    Pixeles[x + (bmpData.Stride * y) + 3],
                    Pixeles[x + (bmpData.Stride * y) + 2],
                    Pixeles[x + (bmpData.Stride * y) + 1],
                    Pixeles[x + (bmpData.Stride * y)]
                    )
                , coloresSeleccionados);
        }

        ///// <summary>
        ///// Proceso la imagen para generar una procesada en funcion de los colores seleccionados. NO pinta los números, solo pinta el color más aproximado.
        ///// </summary>
        ///// <param name="coloresSeleccionados"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public override void ProcesarImagenBitsSOLONumero(int x, int y)
        //{
        //    PintarImagenSOLONumero((x * AnchoHamaGen) + (bmpDataGen.Stride * AltoHamaGen * y)
        //        , Color.FromArgb(
        //            Pixeles[x + (bmpData.Stride * y) + 3],
        //            Pixeles[x + (bmpData.Stride * y) + 2],
        //            Pixeles[x + (bmpData.Stride * y) + 1],
        //            Pixeles[x + (bmpData.Stride * y)]
        //            )
        //        , bmpDataGen.Stride); 
        //}                               

        unsafe public override void PintarDigito(int numero, int posActual, int pixelesFila, eDigito digito)
        {
            int pixel;

            int posInicial = 0;

            if (digito == eDigito.Izquierda)
                posInicial = 2 * stepGen;
            else if (digito == eDigito.Derecha)
                posInicial = 6 * stepGen;

            fixed (byte* pTarget = PixelesGen)
            {
                ///Lo empiezo desde el final, y voy hacia atrás porque en mi array de bytes de la imagen
                /// primero meto el B,luego el G, luego el R, y por ultimo el alpha.                
                byte* pt;


                ///Aqui se dibujan los pixeles correspondientes a cada número
                /// en el recuadro. En función del número deberan pintarse unas posiciones u otras.
                switch (numero)
                {
                    #region 0
                    case 0:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;                        
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (4 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///Pinto 1, salto un espacio, y pinto 1
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt += 4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        
                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///Pinto 1, salto un espacio, y pinto 1
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt += 4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///Pinto 1, salto un espacio, y pinto 1
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt += 4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (7 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 1
                    case 1:
                        pixel = posActual + (3 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (4 * pixelesFila) + (1 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 2 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);


                        pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        
                        pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        
                        break;
                    #endregion

                    #region 2
                    case 2:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        
                        pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        

                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        
                        pixel = posActual + (6 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);                        

                        pixel = posActual + (7 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 3
                    case 3:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        
                        pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);                        

                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);                        

                        pixel = posActual + (7 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 4
                    case 4:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 2 puntos y me salto uno
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt+=4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        
                        pixel = posActual + (4 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 2 puntos y me salto uno
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt+=4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 5
                    case 5:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (4 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (7 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 6
                    case 6:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (4 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);                        

                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 2 puntos y me salto 1
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt += 4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (7 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 7
                    case 7:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);                        

                        pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 8
                    case 8:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (4 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 2 puntos y me salto 1
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt += 4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 2 puntos y me salto 1
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt += 4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (7 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                    #endregion

                    #region 9
                    case 9:
                        pixel = posActual + (3 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (4 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 2 puntos y me salgo 1
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        pt += 4;
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (5 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 1 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);

                        pixel = posActual + (7 * pixelesFila) + posInicial;
                        pt = pTarget + pixel;
                        ///pinto 3 puntos
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        Rellenar_Puntero_con_Color(pt, colorNumero);
                        break;
                        #endregion
                }
            }
        }

        

        public override void PintarRecuadroHama(int posActual, int pixelesFila, int pixelInicio, Color color)
        {
            //Dibujo la linea superior de negro, es decir, pinto el borde
            PintarFilaEnteraColor(posActual, colorBorde);

            //Pinto todas las filas de en medio del color que necesito, para luego pintar los numeros encima.
            for (int i = 1; i < (AltoHamaGen); i++)
            {
                posActual = pixelInicio + pixelesFila * i;
                PintarFilaEnteraConBorde(posActual, color, colorBorde);
            }
        }

        public override void PintarFilaEnteraColor(int posicion, Color color)
        {
            for (int i = posicion; i < (posicion + step * AnchoHamaGen); i += step)
            {
                PintarPixel(i, color);
            }
        }

        public override void PintarFilaEnteraConBorde(int posicion, Color color, Color ColorBorde)
        {
            PintarPixel(posicion, color);
            posicion += step;

            for (int i = posicion; i < (posicion + step * (AnchoHamaGen - 1)); i += step)
                PintarPixel(i, ColorBorde);
        }

        unsafe public override void PintarPixel(int posicion, Color color)
        {
            ///Comprobar si es por LittleEndian       
            ///
            ///Pongo el try & catch para que si es una imagen de menos de 32 bits...no pete y pase al siguiente.
            ///Funciona bien dado que aunque pinte un pixel de más...luego en la "siguiente" pasada le pongo su valor correcto, por lo que me da igual rellenar uno más
            ///
            /// AL FINAL PONGO FUNCIONES DIFERENTES PARA QUE LA CARGA DE TRABAJO SEA MENOR AL HACER OPERACIONES INNECESARIAS AUNQUE ESTETICAMENTE SEA MÁS FEO            

            fixed (byte* pTarget = PixelesGen)
            {                
                byte* pt = pTarget + posicion;

                Rellenar_Puntero_con_Color(pt, color);                
            }
        }

        unsafe private void Rellenar_Puntero_con_Color(byte* pt, Color color)
        {
            *pt = color.B;
            pt++;
            *pt = color.G;
            pt++;
            *pt = color.R;
            pt++;
            *pt = color.A;
            pt++;
        }


        static unsafe void PintarPixel(Color color, byte[] target, int targetOffset)
        {
            byte[] source = new byte[] { color.B, color.G, color.R, color.A };

            fixed(byte* pSource = source, pTarget = target)
            {
                byte* ps = pSource;
                byte* pt = pTarget + targetOffset;

                for (int i = 0; i < 4; i++)
                {
                    *pt = *ps;
                    pt++;
                    ps++;
                }
            }            
        }
        #endregion
        #endregion
        
    }
}
