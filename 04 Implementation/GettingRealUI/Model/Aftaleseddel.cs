using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Aftaleseddel
    {
        public string Bygherre { get; set; }

        public int ProjektNr { get; set; }

        public string  Sted { get; set; }

        public int LøbeNr { get; set; }

        public string Dato { get; set; }

        public string ProjektNavn { get; set; }

        public string Modtager { get; set; }

        public string TidsPåvirkning { get; set; }

        public string Arbejdsudførelse { get; set; }

        public string Prisgrundlag { get; set; }

        public string Overskrift { get; set; }

        public Aftaleseddel(int projekNr, string bygherre, string sted, string dato, int løbeNr, string projektNavn)
        {
            ProjektNr = projekNr;
            Bygherre = bygherre;
            Sted = sted;
            Dato = dato;
            LøbeNr = løbeNr;
            ProjektNavn = projektNavn;
        }

        public override string ToString()
        {
            return $"{Overskrift} {Modtager} {TidsPåvirkning} {Prisgrundlag} {Arbejdsudførelse}";
        }
    }
}
