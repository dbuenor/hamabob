using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Proyecto_Hamma_Beads
{

        //const Color Color01 = Color.FromArgb(255, 255, 255);
        //const Color Color02 = Color.FromArgb(255, 239, 189);
        //const Color Color03 = Color.FromArgb(255, 197, 0);
        //const Color Color04 = Color.FromArgb(228, 82, 20);
        //const Color Color05 = Color.FromArgb(194, 43, 42);
        //const Color Color06 = Color.FromArgb(255, 142, 164);
        //const Color Color07 = Color.FromArgb(105, 61, 159);
        //const Color Color08 = Color.FromArgb(0, 69, 132);
        //const Color Color09 = Color.FromArgb(0, 126, 190);
        //const Color Color10 = Color.FromArgb(15,138,73);
        //const Color Color11 = Color.FromArgb(92,207,151);
        //const Color Color12 = Color.FromArgb(64,36,32);
        //const Color Color13 = Color.FromArgb(224,70,76);
        //const Color Color14 = Color.FromArgb(228,192,0);
        //const Color Color15 = Color.FromArgb(0,141,201);
        //const Color Color16 = Color.FromArgb(135,221,173);
        //const Color Color17 = Color.FromArgb(142,147,151);
        //const Color Color18 = Color.FromArgb(0,0,0);
        //const Color Color19 = Color.FromArgb(229,235,244);
        //const Color Color20 = Color.FromArgb(139,57,30);
        //const Color Color21 = Color.FromArgb(192,100,46);
        //const Color Color22 = Color.FromArgb(179,27,41);
        //const Color Color23 = Color.FromArgb(118,120,121);
        //const Color Color24 = Color.FromArgb(141,109,180);
        //const Color Color25 = Color.FromArgb(157,113,78);
        //const Color Color26 = Color.FromArgb(237,182,159);
        //const Color Color27 = Color.FromArgb(239,190,146);
        //const Color Color28 = Color.FromArgb(24, 44, 29);
        //const Color Color29 = Color.FromArgb(202, 17, 70);
        //const Color Color30 = Color.FromArgb(90, 11, 21);
        //const Color Color31 = Color.FromArgb(103, 169, 191);
        //const Color Color32 = Color.FromArgb(255, 0, 144);
        //const Color Color33 = Color.FromArgb(255, 66, 0);
        //const Color Color34 = Color.FromArgb(246, 255, 0);
        //const Color Color35 = Color.FromArgb(255, 20, 0);
        //const Color Color36 = Color.FromArgb(0, 22, 238);
        //const Color Color37 = Color.FromArgb(121, 230, 51);
        //const Color Color38 = Color.FromArgb(255, 141, 49);
        //const Color Color39 = Color.FromArgb(242, 244, 95);
        //const Color Color40 = Color.FromArgb(255, 98, 36);
        //const Color Color41 = Color.FromArgb(0, 93, 163); 
        //const Color Color42 = Color.FromArgb(87, 190, 0);
        //const Color Color43 = Color.FromArgb(255, 253, 112);
        //const Color Color44 = Color.FromArgb(255, 118, 117);
        //const Color Color45 = Color.FromArgb(168, 134, 195);
        //const Color Color46 = Color.FromArgb(139, 199, 235);
        //const Color Color47 = Color.FromArgb(188, 242, 94);
        //const Color Color48 = Color.FromArgb(233, 145, 201);
        //const Color Color49 = Color.FromArgb(90, 189, 206);
        ////const Color Color50 = Color.FromArgb(255, 255, 255);
        ////const Color Color51 = Color.FromArgb(255, 255, 255);
        ////const Color Color52 = Color.FromArgb(255, 255, 255);
        ////const Color Color53 = Color.FromArgb(255, 255, 255);
        ////const Color Color54 = Color.FromArgb(255, 255, 255);
        //const Color Color55 = Color.FromArgb(230, 240, 214);
        //const Color Color56 = Color.FromArgb(243, 218, 214);
        //const Color Color57 = Color.FromArgb(212, 215, 217);
        ////const Color Color58 = Color.FromArgb(255, 255, 255);
        ////const Color Color59 = Color.FromArgb(255, 255, 255);
        //const Color Color60 = Color.FromArgb(241, 161, 37);
        //const Color Color61 = Color.FromArgb(234, 183, 50); 
        //const Color Color62 = Color.FromArgb(161, 158, 158);
        //const Color Color63 = Color.FromArgb(143, 114, 36);
        //const Color Color64 = Color.FromArgb(231, 222, 218);

        public class ColorHama
        {
            public enum eTamanioHama
            {
                MINI,
                MIDI,
                AMBOS
            }

            public enum eTipoHama
            {
                NORMAL,
                NEON,
                FLUORESCENTE,
                TRANSLUCIDO,
                FOSFORESCENTE
            }

            public eTamanioHama Tamanio { get; set; }
            public eTipoHama Tipo { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public Color Colorciko { get; set; }
            public int NumPiezas { get; set; }
            public int Numero { get; set; }

            public delegate void HabilitadoEventHandler();
            //private HabilitadoEventHandler HabilitadoCambiado;
            public event HabilitadoEventHandler HabilitadoEvent;

            private bool _Habilitado = true;
            public bool Habilitado 
            {
                get
                {
                    return _Habilitado;
                }
                set
                {
                    if (value != _Habilitado)
                    {
                        _Habilitado = value;
                        HabilitadoEvent();
                    }
                }
            }

            public ColorHama()
            {

            }

            public ColorHama(Color _color)
            {
                this.Colorciko = _color;
            }

            public ColorHama(Color _color, eTamanioHama _tamanio, eTipoHama _tipo, string _nombre, int _numero)
            {
                this.Colorciko = _color;
                this.Tamanio = _tamanio;
                this.Tipo = _tipo;
                this.Nombre = _nombre;
                this.Numero = _numero;
            }
        }   
    
}
