using System;
using System.Collections.Generic;
using System.Text;
using GettingRealUI.Model;
using System.Collections.ObjectModel;

namespace GettingRealUI.ViewModel
{
    class ArbejdsbeskrivelseViewModel
    {
        public ObservableCollection<Arbejdsbeskrivelse> Arbejdsbeskrivelses { get; set; }
        private ArbejdsbeskrivelseRepo arbejdsbeskrivelseRepo;

        public ArbejdsbeskrivelseViewModel(ArbejdsbeskrivelseRepo arbejdsbeskrivelseRepo)
        {
            this.arbejdsbeskrivelseRepo = arbejdsbeskrivelseRepo;
        }

        public void FindArbejsbeskrivleser(int løbeNr)
        {
            Arbejdsbeskrivelses = arbejdsbeskrivelseRepo.FindArbejdsbeskrivelser(løbeNr);
        }

        public void OpretArbejdsbeskrivelse(int løbeNr)
        {
            var temp = arbejdsbeskrivelseRepo.OpretArbejdsbeskrivelse();
            arbejdsbeskrivelseRepo.TilføjLøbenummer(løbeNr);
            Arbejdsbeskrivelses.Add(temp);
        }

        public void AktiverArbejdsbeskrivelse()
        {
            arbejdsbeskrivelseRepo.AktiveretArbejdsbeskrivelse();
        }
        public void DeaktiveretArbejdsbeskrivelse()
        {
            arbejdsbeskrivelseRepo.DeaktiveretArbejdsbeskrivelse();
        }
        public void SætArbejdesbeskrivelse(Arbejdsbeskrivelse arbejdsbeskrivelse)
        {
            arbejdsbeskrivelseRepo.SætArbejdesbeskrivelse(arbejdsbeskrivelse);
        }
    }
}
