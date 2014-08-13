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

        public override void PintarImagen(int pixelInicio, Color colorFondo, int pixelesFila, List<ColorHama> coloresSeleccionados)
        {
            int posActual = pixelInicio;

            ColorHama colorParecido;

            colorParecido = Common.EncontrarColorParecido(colorFondo, coloresSeleccionados);

            PintarRecuadroHama(posActual, pixelesFila, pixelInicio, colorParecido.Colorciko);

            PintarNumero(colorParecido.Numero, posActual, pixelesFila);
        }

        public override void PintarNumero(int numero, int posActual, int pixelesFila)
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
            }
        }

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
