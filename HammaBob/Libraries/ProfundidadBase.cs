using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace HammaBob.Libraries
{
	public abstract class BaseDepth : IDepth
	{
		#region Constants

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
		public event StepDoneHandler StepDoneEvent;

		#endregion

		#region Constructor

		public BaseDepth(Bitmap _bmpOriginal, byte[] _pixeles, byte[] _pixelesGen,
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

		public abstract void ProcessImageBits(IEnumerable<HammaColour> coloresSeleccionados, int x, int y);
		public abstract void ProcesarImagenBitsSOLOColor(IEnumerable<HammaColour> coloresSeleccionados, int x, int y);
		//public abstract void ProcesarImagenBitsSOLONumero(int x, int y);                

		public abstract void DrawDigit(int numero, int posActual, int pixelesFila, DigitPosition digito);
		public abstract void DrawHammaSquare(int posActual, int pixelesFila, int pixelInicio, System.Drawing.Color color);
		public abstract void DrawFullRowColour(int posicion, System.Drawing.Color color);
		public abstract void DrawFullRowWithBorder(int posicion, System.Drawing.Color color, System.Drawing.Color colorBorde);
		public abstract void DrawPixel(int posicion, System.Drawing.Color color);



		#endregion

		#region Resto Funciones

		public virtual void PintarImagenSOLOColor(int pixelInicio, Color colorFondo, IEnumerable<HammaColour> coloresSeleccionados)
		{
			int posActual = pixelInicio;

			HammaColour colorParecido;

			colorParecido = Common.FindNearestColour(colorFondo, coloresSeleccionados);

			DrawPixel(pixelInicio, colorParecido.Colour);
		}

		public virtual void DrawImage(int pixelInicio, Color colorFondo, int pixelesFila, IEnumerable<HammaColour> coloresSeleccionados)
		{
			int posActual = pixelInicio;

			HammaColour colorParecido;

			colorParecido = Common.FindNearestColour(colorFondo, coloresSeleccionados);

			DrawHammaSquare(posActual, pixelesFila, pixelInicio, colorParecido.Colour);

			DrawNumber(colorParecido.Number, posActual, pixelesFila);
		}

		public virtual void DrawNumber(int numero, int posActual, int pixelesFila)
		{
			switch (numero)
			{
				case 1:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 2:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 3:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 4:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 5:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 6:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 7:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 8:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 9:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					break;

				case 10:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 11:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 12:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 13:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 14:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 15:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 16:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 17:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 18:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 19:
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 20:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 21:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 22:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 23:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 24:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 25:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 26:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 27:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 28:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 29:
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 30:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 31:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 32:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 33:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 34:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 35:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 36:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 37:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 38:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 39:
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 40:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 41:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 42:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 43:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 44:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 45:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 46:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 47:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 48:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 49:
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;
				case 50:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 51:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 52:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 53:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 54:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 55:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 56:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 57:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 58:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 59:
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 60:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 61:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 62:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 63:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 64:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 65:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 66:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 67:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 68:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 69:
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;
				case 70:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 71:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 72:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 73:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 74:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 75:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 76:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 77:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 78:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 79:
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;
				case 80:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 81:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 82:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 83:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 84:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 85:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 86:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 87:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 88:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 89:
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;
				case 90:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(0, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 91:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(1, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 92:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(2, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 93:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(3, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 94:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(4, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 95:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(5, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 96:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(6, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 97:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(7, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 98:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(8, posActual, pixelesFila, DigitPosition.Right);
					break;

				case 99:
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Left);
					DrawDigit(9, posActual, pixelesFila, DigitPosition.Right);
					break;
			}
		}

		/// <summary>
		/// Funcion que nos procesa una imagen para encontrar qué colores parecidos de los seleccionados, se parecen a los de la imagen original.
		/// Es opcional si queremos que se pinten los numeros o no
		/// </summary>
		/// <param name="coloresSeleccionados">Colores Seleccionados a comparar con los originales</param>
		/// <param name="pintarNumHama">Parametro booleano que indica si queremos pintar o no los numeros correspondientes al color Parecido</param>
		public virtual void ProcessImage(IEnumerable<HammaColour> coloresSeleccionados, bool pintarNumHama)
		{
			Stopwatch sw = new Stopwatch();

			sw.Start();

			if (pintarNumHama)
			{
				for (int y = 0; y < bmpOriginal.Height; y++)
				{
					System.Threading.Tasks.Parallel.For(0, bmpOriginal.Width, iteracion =>
					{
						ProcessImageBits(coloresSeleccionados, iteracion * step, y);
					});

					if (StepDoneEvent != null)
						StepDoneEvent();
				}
			}
			else
			{
				for (int y = 0; y < bmpOriginal.Height; y++)
				{
					System.Threading.Tasks.Parallel.For(0, bmpOriginal.Width, iteracion =>
					{
						ProcesarImagenBitsSOLOColor(coloresSeleccionados, iteracion * step, y);
					});

					if (StepDoneEvent != null)
						StepDoneEvent();
				}
			}

			sw.Stop();

			Console.WriteLine("TIEMPO USADO ==> " + sw.ElapsedMilliseconds.ToString());
		}

		#endregion
		#endregion





	}
}
