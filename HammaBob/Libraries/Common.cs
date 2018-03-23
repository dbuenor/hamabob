using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HammaBob.Libraries
{
	public enum DigitPosition
	{
		Left,
		Right
	}

	public class Constants
	{
		#region Constants
		public const int WidthGeneratedHamma = 10;
		public const int HeightGeneratedHamma = 10;
		public const int WidthSheetPixels = 57;
		public const int HeightSheetPixels = 57;
		public const int WidthSheetCentimeters = 15;
		public const int HeightSheetCentimeters = 15;
		#endregion
	}

	public enum MeasureType
	{
		Pixel,
		Centimeter
	}

	public class Common
	{
		public static HammaColour FindNearestColour(Color originalColour, IEnumerable<HammaColour> selectedColours)
		{
			HammaColour nearestColour = null;

			/////Primero busco en la caché
			////colorSimilar = RevisarColoresYaEncontrados(colorOriginal);

			/////Si no está en la caché...entonces busco su color parecido y lo añado a la caché de colores ya encontrados.
			if (nearestColour == null)
			{

				double dbl_input_red = Convert.ToDouble(originalColour.R);
				double dbl_input_green = Convert.ToDouble(originalColour.G);
				double dbl_input_blue = Convert.ToDouble(originalColour.B);

				double dbl_test_red, dbl_test_green, dbl_test_blue, temp;
				double distance = double.MaxValue;


				foreach (HammaColour hammaColour in selectedColours)
				{
					// compute the Euclidean distance between the two colors
					// note, that the alpha-component is not used in this example
					dbl_test_red = Math.Pow(Convert.ToDouble((hammaColour.Colour).R) - dbl_input_red, 2.0);
					dbl_test_green = Math.Pow(Convert.ToDouble
						((hammaColour.Colour).G) - dbl_input_green, 2.0);
					dbl_test_blue = Math.Pow(Convert.ToDouble
						((hammaColour.Colour).B) - dbl_input_blue, 2.0);
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
						nearestColour = hammaColour;
						break;
					}
					else if (temp < distance)
					{
						distance = temp;
						nearestColour = hammaColour;
					}
				}

				//if (colorSimilar != null)
				//    lock (bloqueo)
				//    {
				//        coloresYaEncontrados.Add(new cColoresEncontrados() { ColorBuscado = colorOriginal, ColorParecido = colorSimilar });
				//    }
			}

			if (nearestColour != null)
				nearestColour.PiecesCount++;

			return nearestColour;
		}

		#region Measurement

		private static int ConvertSize(int value, MeasureType measureType)
		{
			switch (measureType)
			{
				case MeasureType.Centimeter:
					return ((value * Constants.WidthSheetPixels) / Constants.WidthSheetCentimeters);
				case MeasureType.Pixel:
					return ((value * Constants.WidthSheetCentimeters) / Constants.WidthSheetPixels);
				default:
					throw new NotImplementedException($"Not a valid {measureType}");
			}
		}

		public static int ConvertSizeToCentimeters(int value)
		{
			return ConvertSize(value, MeasureType.Pixel);
		}

		public static int ConvertSizeToPixels(int value)
		{
			return ConvertSize(value, MeasureType.Centimeter);
		}

		public class Size
		{
			private int _pixels, _centimeters;
			public delegate void SizeChangedEvent();
			public event SizeChangedEvent SizeChanged;

			public int Pixels
			{
				get
				{
					return _pixels;
				}
				set
				{
					if (value != _pixels)
					{
						_pixels = value;
						_centimeters = ConvertSizeToCentimeters(value);
						if (SizeChanged != null)
							SizeChanged();
					}
				}
			}
			public int Centimeters
			{
				get
				{
					return _centimeters;
				}
				set
				{
					if (value != _centimeters)
					{
						_centimeters = value;
						_pixels = ConvertSizeToPixels(value);
					}
				}
			}

			public void SetSize(MeasureType measureType, string value)
			{
				if (measureType == MeasureType.Centimeter)
					Centimeters = Convert.ToInt16(value);
				else if (measureType == MeasureType.Pixel)
					Pixels = Convert.ToInt16(value);
				else
					throw new NotImplementedException($"Can't set value for Measure Type {measureType}");
			}

			public int GetSize(MeasureType measureType)
			{
				if (measureType == MeasureType.Centimeter)
					return this.Centimeters;
				else if (measureType == MeasureType.Pixel)
					return this.Pixels;
				else
					throw new NotImplementedException($"Can't obtain value for Measure Type {measureType}");

			}
		}

		#endregion
	}
}
