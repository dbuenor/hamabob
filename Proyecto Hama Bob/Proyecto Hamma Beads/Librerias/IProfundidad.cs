using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Proyecto_Hamma_Beads.Librerias
{
    interface IProfundidad
    {        
        void ProcesarImagen(List<ColorHama> coloresSeleccionados, bool pintarNumHama);
        void ProcesarImagenBits(List<ColorHama> coloresSeleccionados, int x, int y);
        void PintarImagen(int pixelInicio, Color colorFondo, int pixelesFila, List<ColorHama> coloresSeleccionados);
        void PintarNumero(int numero, int posActual, int pixelesFila);
        void PintarDigito(int numero, int posActual, int pixelesFila, eDigito digito);
        void PintarRecuadroHama(int posActual, int pixelesFila, int pixelInicio, Color color);
        void PintarFilaEnteraColor(int posicion, Color color);
        void PintarFilaEnteraConBorde(int posicion, Color color, Color colorBorde);
        void PintarPixel(int posicion, Color color);
    }
}
