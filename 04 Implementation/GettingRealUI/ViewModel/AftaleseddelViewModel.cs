using System;
using System.Collections.Generic;
using System.Text;
using GettingRealUI.Model;

namespace GettingRealUI.ViewModel
{
    class AftaleseddelViewModel
    {
        private Model.Aftaleseddel aftaleseddel;
        public string Bygherre { get; set; }

        public int ProjektNr { get; set; }

        public string Sted { get; set; }

        public int LøbeNr { get; set; }

        public string Dato { get; set; }

        public string ProjektNavn { get; set; }

        public string Modtager { get; set; }

        public string TidsPåvirkning { get; set; }

        public string Arbejdsudførelse { get; set; }

        public string Prisgrundlag { get; set; }

        public string Overskrift { get; set; }

        public AftaleseddelViewModel(Model.Aftaleseddel aftaleseddel)
        {
            this.aftaleseddel = aftaleseddel;
            Bygherre = aftaleseddel.Bygherre;
            ProjektNr = aftaleseddel.ProjektNr;
            Sted = aftaleseddel.Sted;
            LøbeNr = aftaleseddel.LøbeNr;
            Dato = aftaleseddel.Dato;
            ProjektNavn = aftaleseddel.ProjektNavn;
            Modtager = aftaleseddel.Modtager;
            TidsPåvirkning = aftaleseddel.TidsPåvirkning;
            Prisgrundlag = aftaleseddel.Prisgrundlag;
            Overskrift = aftaleseddel.Overskrift;
           
        }
    }

}
