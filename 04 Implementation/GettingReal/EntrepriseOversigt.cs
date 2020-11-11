using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class EntrepriseOversigt
    {
        public string ProjektNavn { get; set; } = "SDU bygger, Odense";

        public string Bygherre { get; set; } = "Karl Jørgensen";

        public int ProjektNr { get; set; } = 1231371;

        public string Sted { get; set; } = "Skærbæk";

        public int LøbeNr { get; set; }

        public DateTime Dato { get; set; } = DateTime.Now;

        public string Oprettelse { get; set; }

        private List<Aftaleseddel> aftaleseddeler = new List<Aftaleseddel>();
    

        private Aftaleseddel valgtAftaleseddel;


        
        public void OpretAftaleseddel()
        {
            if (aftaleseddeler.Count <= 3 )
            {
                valgtAftaleseddel = new Aftaleseddel(ProjektNr, Bygherre, Sted, Dato, LøbeNr, ProjektNavn);
                TilføjAftaleSeddelInformation("(Hardcoded) Trykafprøvning", "Exycte", "08-11-2020",
                    "ByggeHerrens Ønske","Frostsikring");
                aftaleseddeler.Add(valgtAftaleseddel);
                
                valgtAftaleseddel = new Aftaleseddel(ProjektNr, Bygherre, Sted, Dato, LøbeNr, ProjektNavn);
                TilføjAftaleSeddelInformation("(Hardcoded) Opsætning af sprinklere", "Arla", "08-05-2010",
                    "Ekstra regning","Paragraf 17");
                aftaleseddeler.Add(valgtAftaleseddel);
            }
            LøbeNr = aftaleseddeler.Count + 1;
            

            valgtAftaleseddel = new Aftaleseddel(ProjektNr, Bygherre, Sted, Dato, LøbeNr, ProjektNavn);

            
            aftaleseddeler.Add(valgtAftaleseddel);

        }

        public List<Aftaleseddel> Vis()
        {
            if (aftaleseddeler == null)
            {
                throw new ArgumentException("Der er ikke oprettet nogen aftalesedler endnu");
            }
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
    }

}
