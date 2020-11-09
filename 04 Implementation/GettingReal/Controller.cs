using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Controller
    {
        private EntrepriseOversigt entrepriseOversigt = new EntrepriseOversigt();

        public void OpretAftaleseddel()
        {
            entrepriseOversigt.OpretAftaleseddel();
        }

        public List<Aftaleseddel> VisEntrepriseOversigt()
        {
            return entrepriseOversigt.Vis();

        }

        public Aftaleseddel VælgAftaleseddel(string overskift)
        {
            return entrepriseOversigt.VælgAftaleseddel(overskift);
        }

        public void SletAftaleseddel(Aftaleseddel aftaleseddel)
        {
            entrepriseOversigt.SletAftaleseddel(aftaleseddel);
        }

        public void GodkendAftaleseddel()
        {
            entrepriseOversigt.GodkendAftaleseddel();
        }

        public Aftaleseddel TilføjAftaleSeddelInformation(string overskift, string modtager, string tidsPåvirkning, string prisGrundlag, string arbejdsUdførelse)
        {
            return entrepriseOversigt.TilføjAftaleSeddelInformation(overskift, modtager, tidsPåvirkning, prisGrundlag, arbejdsUdførelse);
            
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

    }
}
