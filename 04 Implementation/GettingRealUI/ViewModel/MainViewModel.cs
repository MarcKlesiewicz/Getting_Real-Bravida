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

        public Aftaleseddel VælgAftaleseddel(string overskift)
        {
            return entrepriseOversigt.VælgAftaleseddel(overskift);
        }

        public void RedigerAftaleseddel(string parameter, string redigerTil)
        {
            switch (parameter)
            {
                case "Overskrift":
                    entrepriseOversigt.RedigerOverskift(redigerTil);
                    break;
                case "Modtager":
                    entrepriseOversigt.RedigerModtager(redigerTil);
                    break;
                case "Tidspåvirkning":
                    entrepriseOversigt.RedigerTidspåvirkning(redigerTil);
                    break;
                case "PrisGrundlag":
                    entrepriseOversigt.RedigerPrisGrundlag(redigerTil);
                    break;
                case "ArbejdsUdførelse":
                    entrepriseOversigt.RedigerArbejdsUdførelse(redigerTil);
                    break;
                default:
                    break;
            }

        }
        public void sætaftaleseddel(Aftaleseddel aftaleseddel)
        {
            entrepriseOversigt.sætaftaleseddel(aftaleseddel);
        }
    }
}
