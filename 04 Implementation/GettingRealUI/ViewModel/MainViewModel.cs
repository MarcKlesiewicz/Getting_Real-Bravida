using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using GettingRealUI.Model;

namespace GettingRealUI.ViewModel
{
    class MainViewModel
    {
        private EntrepriseOversigt entrepriseOversigt;

        public ArbejdsbeskrivelseRepo ArbejdsbeskrivelseRepo = new ArbejdsbeskrivelseRepo();

        public ObservableCollection<Aftaleseddel> Aftaleseddels { get; set; }

        private string projektNavn;

        public string ProjektNavn
        {
            get { return projektNavn; }
            set 
            {
                projektNavn = value;
                entrepriseOversigt.ProjektNavn = value;
            }
        }

        private int projektNr;

        public int ProjektNr
        {
            get { return projektNr; }
            set
            {
                projektNr = value;
                entrepriseOversigt.ProjektNr = value;
            }
        }

        private string sted;

        public string Sted
        {
            get { return sted; }
            set
            {
                sted = value;
                entrepriseOversigt.Sted = value;
            }
        }

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
        public ObservableCollection<Aftaleseddel> VisEntrepriseOversigt()
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
                case "SvarSenest":
                    entrepriseOversigt.RedigerSvarSenest(redigerTil);
                    break;
                case "RefPlan":
                    entrepriseOversigt.RedigerRefPlan(redigerTil);
                    break;
                case "Arbejdsbeskrivelse":
                    entrepriseOversigt.RedigerArbejdsbeskrivelse(redigerTil);
                    break;
                default:
                    break;
            }

        }
        public void Sætaftaleseddel(Aftaleseddel aftaleseddel)
        {
            entrepriseOversigt.sætaftaleseddel(aftaleseddel);
        }

        public void GodkendAftaleseddel()
        {
            entrepriseOversigt.GodkendAftaleseddel();
        }

        public void SætProjektnavn(string navn)
        {
            entrepriseOversigt.ProjektNavn = navn;
        }
        public void SætAktivTilTrue()
        {
            entrepriseOversigt.SætAktivTilTrue();
        }

        public void SætAktivTilFalse()
        {
            entrepriseOversigt.SætAktivTilFalse();
        }
    }
}
