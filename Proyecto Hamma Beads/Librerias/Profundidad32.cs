using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

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

        public override void PintarDigito(int numero, int posActual, int pixelesFila, eDigito digito)
        {
            int pixel;

            int posInicial = 0;

            if (digito == eDigito.Izquierda)
                posInicial = 2 * stepGen;
            else if (digito == eDigito.Derecha)
                posInicial = 6 * stepGen;

            switch (numero)
            {
                #region 0
                case 0:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;
                    break;
                #endregion

                #region 1
                case 1:
                    pixel = posActual + (3 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + (1 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    break;
                #endregion

                #region 2
                case 2:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;
                    break;
                #endregion

                #region 3
                case 3:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;
                    break;
                #endregion

                #region 4
                case 4:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel + 0] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;


                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    break;
                #endregion

                #region 5
                case 5:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;
                    break;
                #endregion

                #region 6
                case 6:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;
                    break;
                #endregion

                #region 7
                case 7:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    break;
                #endregion

                #region 8
                case 8:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;
                    break;
                #endregion

                #region 9
                case 9:
                    pixel = posActual + (3 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (4 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (5 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;

                    pixel = posActual + (6 * pixelesFila) + (2 * stepGen) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;

                    pixel = posActual + (7 * pixelesFila) + posInicial;
                    PixelesGen[pixel + 3] = colorNumero.A;
                    PixelesGen[pixel + 2] = colorNumero.R;
                    PixelesGen[pixel + 1] = colorNumero.G;
                    PixelesGen[pixel] = colorNumero.B;
                    PixelesGen[pixel + 7] = colorNumero.A;
                    PixelesGen[pixel + 6] = colorNumero.R;
                    PixelesGen[pixel + 5] = colorNumero.G;
                    PixelesGen[pixel + 4] = colorNumero.B;
                    PixelesGen[pixel + 11] = colorNumero.A;
                    PixelesGen[pixel + 10] = colorNumero.R;
                    PixelesGen[pixel + 9] = colorNumero.G;
                    PixelesGen[pixel + 8] = colorNumero.B;
                    break;
                #endregion
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

        public override void PintarFilaEnteraConBorde(int posicion, Color color, Color colorBorde)
        {
            PintarPixel(posicion, colorBorde);
            posicion += step;

            for (int i = posicion; i < (posicion + step * (AnchoHamaGen - 1)); i += step)
                PintarPixel(i, color);
        }

        public override void PintarPixel(int posicion, Color color)
        {
            ///Comprobar si es por LittleEndian       
            ///
            ///Pongo el try & catch para que si es una imagen de menos de 32 bits...no pete y pase al siguiente.
            ///Funciona bien dado que aunque pinte un pixel de más...luego en la "siguiente" pasada le pongo su valor correcto, por lo que me da igual rellenar uno más
            ///
            /// AL FINAL PONGO FUNCIONES DIFERENTES PARA QUE LA CARGA DE TRABAJO SEA MENOR AL HACER OPERACIONES INNECESARIAS AUNQUE ESTETICAMENTE SEA MÁS FEO
            PixelesGen[posicion + 3] = color.A;
            PixelesGen[posicion + 2] = color.R;
            PixelesGen[posicion + 1] = color.G;
            PixelesGen[posicion] = color.B;
        }

        #endregion
        #endregion
        
    }
}
