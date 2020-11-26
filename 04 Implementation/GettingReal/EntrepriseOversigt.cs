using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class EntrepriseOversigt
    {
        public string ProjektNavn { get; set; }

        public string Bygherre { get; set; }

        public int ProjektNr { get; set; }

        public string Sted { get; set; }

        public int LøbeNr { get; set; }

        public string Dato { get; set; }

        public string Oprettelse { get; set; }

        private List<Aftaleseddel> aftaleseddeler = new List<Aftaleseddel>();

        private Aftaleseddel valgtAftaleseddel;

        public void OpretAftaleseddel()
        {
            valgtAftaleseddel = new Aftaleseddel(ProjektNr, Bygherre, Sted, Dato, ProjektNavn, (aftaleseddeler.Count + 1));

        }

        public List<Aftaleseddel> Vis()
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
            valgtAftaleseddel = null;
        }

        public void RedigerModtager(string modtager)
        {
            valgtAftaleseddel.Modtager = modtager;
            valgtAftaleseddel = null;
        }

        public void RedigerTidspåvirkning(string tidspåvirkning)
        {
            valgtAftaleseddel.TidsPåvirkning = tidspåvirkning;
            valgtAftaleseddel = null;
        }

        public void RedigerPrisGrundlag(string prisgrundlag)
        {
            valgtAftaleseddel.Prisgrundlag = prisgrundlag;
            valgtAftaleseddel = null;
        }

        public void RedigerArbejdsUdførelse(string arbejdsUdførelse)
        {
            valgtAftaleseddel.Arbejdsudførelse = arbejdsUdførelse;
            valgtAftaleseddel = null;
        }
       
        public bool AktiverAftaleseddel()
        {
            valgtAftaleseddel.Aktiveret = valgtAftaleseddel.Aktiveret == true ? valgtAftaleseddel.Aktiveret = false : valgtAftaleseddel.Aktiveret = true;
            return valgtAftaleseddel.Aktiveret;
        }
    }

}
