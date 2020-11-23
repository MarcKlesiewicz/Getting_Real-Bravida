using System;
using System.Collections.Generic;
using System.Text;
using GettingRealUI.Model;

namespace GettingRealUI.ViewModel
{
    class MainViewModel
    {
        private EntrepriseOversigt entrepriseOversigt;

        public List<Aftaleseddel> Aftaleseddels { get; set; }

        public string ProjektNavn { get; set; }

        public int ProjektNr { get; set; }

        public string Sted { get; set; }

        public int LøbeNr { get; set; }

        public string Dato { get; set; }

        public string Oprettelse { get; set; }

        public MainViewModel()
        {
            entrepriseOversigt = new EntrepriseOversigt();
            ProjektNavn = entrepriseOversigt.ProjektNavn;
            ProjektNr = entrepriseOversigt.ProjektNr;
            Sted =  entrepriseOversigt.Sted;
            LøbeNr =  entrepriseOversigt.LøbeNr;
            Dato = entrepriseOversigt.Dato;
            Oprettelse = entrepriseOversigt.Oprettelse;

            Aftaleseddels =  VisEntrepriseOversigt();
        }
        public List<Aftaleseddel> VisEntrepriseOversigt()
        {
            return entrepriseOversigt.Vis();

        }

        public Aftaleseddel OpretAftaleseddel()
        {
            return entrepriseOversigt.OpretAftaleseddel();
        }
    }
}
