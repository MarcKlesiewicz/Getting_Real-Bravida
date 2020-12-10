using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GettingRealUI.Model
{
    public class EntrepriseOversigt
    {
        private string projektNavn;

        public string ProjektNavn
        {
            get { return projektNavn; }
            set
            { 
                projektNavn = value;
                foreach (var item in aftaleseddeler)
                {
                    item.ProjektNavn = value;
                }
            }
        }

        private string bygherre;

        public string Bygherre
        {
            get { return bygherre; }
            set
            {
                bygherre = value;
                foreach (var item in aftaleseddeler)
                {
                    item.Bygherre = value;
                }
            }
        }

        private int projektNr;

        public int ProjektNr
        {
            get { return projektNr; }
            set
            {
                projektNr = value;
                foreach (var item in aftaleseddeler)
                {
                    item.ProjektNr = value;
                }
            }
        }

        private string sted;

        public string Sted
        {
            get { return sted; }
            set
            {
                sted = value;
                foreach (var item in aftaleseddeler)
                {
                    item.Sted = value;
                }
            }
        }

        public int LøbeNr { get; set; } = 1;

        public string Dato { get; set; }

        public string Oprettelse { get; set; }

        private ObservableCollection<Aftaleseddel> aftaleseddeler = new ObservableCollection<Aftaleseddel>();

        public Aftaleseddel valgtAftaleseddel { get; private set; }

        public Aftaleseddel OpretAftaleseddel()
        {
            valgtAftaleseddel = new Aftaleseddel(ProjektNr, Bygherre, Sted, Dato, (aftaleseddeler.Count + 1), ProjektNavn);
            return valgtAftaleseddel;

        }

        public ObservableCollection<Aftaleseddel> Vis()
        {
            return aftaleseddeler;

        }

        public Aftaleseddel VælgAftaleseddel(string overskrift)
        {
            foreach (var item in aftaleseddeler)
            {
                if (overskrift == item.Overskrift)
                {
                    valgtAftaleseddel = item;
                    return valgtAftaleseddel;
                }
            }
            return null;
        }

        public void SletAftaleseddel(Aftaleseddel aftaleseddel)
        {
            aftaleseddeler.Remove(aftaleseddel);
        }

        public void GodkendAftaleseddel()
        {
            aftaleseddeler.Add(valgtAftaleseddel);
            valgtAftaleseddel = null;
        }

        public Aftaleseddel TilføjAftaleSeddelInformation(string overskift, string modtager, string tidsPåvirkning, string prisGrundlag, string arbejdsUdførelse)
        {
            valgtAftaleseddel.Overskrift = overskift;
            valgtAftaleseddel.Modtager = modtager;
            valgtAftaleseddel.TidsPåvirkning = tidsPåvirkning;
            valgtAftaleseddel.Prisgrundlag = prisGrundlag;
            valgtAftaleseddel.Arbejdsudførelse = arbejdsUdførelse;

            return valgtAftaleseddel;
        }

        public void RedigerOverskift(string overskift)
        {
            valgtAftaleseddel.Overskrift = overskift;
        }

        public void RedigerModtager(string modtager)
        {
            valgtAftaleseddel.Modtager = modtager;
        }

        public void RedigerTidspåvirkning(string tidspåvirkning)
        {
            valgtAftaleseddel.TidsPåvirkning = tidspåvirkning;
        }

        public void RedigerPrisGrundlag(string prisgrundlag)
        {
            valgtAftaleseddel.Prisgrundlag = prisgrundlag;
        }

        public void RedigerArbejdsUdførelse(string arbejdsUdførelse)
        {
            valgtAftaleseddel.Arbejdsudførelse = arbejdsUdførelse;
        }
        public void RedigerSvarSenest(string svarSenest)
        {
            valgtAftaleseddel.SvarSenest = svarSenest;
        }
        public void RedigerRefPlan(string refPlan)
        {
            valgtAftaleseddel.RefPlan = refPlan;
        }

        public void RedigerArbejdsbeskrivelse(string arbejdsbeskrivelse)
        {
            valgtAftaleseddel.Arbejdsbeskrivelse = arbejdsbeskrivelse;
        }

        public void SætAktivTilTrue()
        {
            valgtAftaleseddel.Aktiv = true;
        }

        public void SætAktivTilFalse()
        {
            valgtAftaleseddel.Aktiv = false;
        }

        public void sætaftaleseddel(Aftaleseddel aftaleseddel)
        {
            foreach (var item in aftaleseddeler)
            {
                if(aftaleseddel == item)
                {
                    valgtAftaleseddel = item;
                }
            }
        }
    }

}
