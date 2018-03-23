using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace HammaBob.Libraries
{
	interface IDepth
	{
		void ProcessImage(IEnumerable<HammaColour> selectedColours, bool paintHammaNumber);
		void ProcessImageBits(IEnumerable<HammaColour> selectedColours, int x, int y);
		void DrawImage(int initialPixel, Color backgroundColour, int rowPixels, IEnumerable<HammaColour> selectedColours);
		void DrawNumber(int number, int actualPosition, int rowPixels);
		void DrawDigit(int number, int actualPosition, int rowPixels, DigitPosition digit);
		void DrawHammaSquare(int actualPosition, int rowPixels, int initialPixel, Color colour);
		void DrawFullRowColour(int position, Color colour);
		void DrawFullRowWithBorder(int position, Color colour, Color borderColour);
		void DrawPixel(int pòsition, Color colour);
	}
}
