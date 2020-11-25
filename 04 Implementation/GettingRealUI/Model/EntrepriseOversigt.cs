using System;
using System.Collections.Generic;
using System.Text;

namespace GettingRealUI.Model
{
    public class EntrepriseOversigt
    {
        public string ProjektNavn { get; set; } = "heje";

        public string Bygherre { get; set; } = "Dan";

        public int ProjektNr { get; set; } = 1;

        public string Sted { get; set; } = "odense";

        public int LøbeNr { get; set; } = 1;

        public string Dato { get; set; } = "1/1";

        public string Oprettelse { get; set; } = "Dan";

        private List<Aftaleseddel> aftaleseddeler = new List<Aftaleseddel>() { new Aftaleseddel(2, "dan", "odense", "21/21", 1, "hallo"), new Aftaleseddel(2, "dan", "odense", "21/21", 2, "hallo") };
        public Aftaleseddel valgtAftaleseddel { get; private set; }

        public Aftaleseddel OpretAftaleseddel()
        {
            valgtAftaleseddel = new Aftaleseddel(ProjektNr, Bygherre, Sted, Dato, LøbeNr, ProjektNavn);
            return valgtAftaleseddel;

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
