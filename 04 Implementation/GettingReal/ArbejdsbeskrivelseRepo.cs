using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class ArbejdsbeskrivelseRepo
    {
        //Listen over alle arbejdsbeskrivelser i hele systemet
        private List<Arbejdsbeskrivelse> _arbejdsbeskrivelser = new List<Arbejdsbeskrivelse>();

        //Det lokale field til at håndtere hvilken arbejdsbeskrivelse der i øjeblikket arbejds med
        private Arbejdsbeskrivelse valgteArbejdsbeskrivelse = null;

        //En privat metode til at finde ud af hvilket ID der ikke er taget, ud fra de allerede eksisterende arbejdsbeskrivelser
        //Hvis alle ID'er, mellem 0 til mængden af arbejdsbeskrivelser, er taget. Så returnerer den det næste frie tal.
        private int ArbejdsbeskrivelseID()
        {
            if (_arbejdsbeskrivelser.Count > 0)
            {
                int[] IDs = new int[_arbejdsbeskrivelser.Count];
                int count = 0;
                foreach (var item in _arbejdsbeskrivelser)
                {
                    IDs[count] = item.ID;
                    count++;
                }
                for (int i = 0; i < IDs.Length; i++)
                {
                    for (int j = 0; j < IDs.Length; j++)
                    {
                        if (i == IDs[j])
                        {
                            break;
                        } else if (i != IDs[j] && j == IDs.Length - 1)
                        {
                            return i;
                        }
                    }
                }
                return _arbejdsbeskrivelser.Count;
            }
            else
            {
                return 0;
            }
        }

        //Metode til at vælge hvilken arbejdsbeskrivelse der skal arbejdes med ud fra et givent ID
        public void VælgArbejdsbeskrivelse(int iD)
        {
            foreach (var item in _arbejdsbeskrivelser)
            {
                if (iD == item.ID)
                {
                    valgteArbejdsbeskrivelse = item;
                    break;
                }
            }
        }

        //Metode til at oprette en ny tom arbejdsbeskrivelse
        //Den kalder på en privat metode i denne klasse til at finde ud af hvilket ID der skal tilgives
        public void OpretArbejdsbeskrivelse()
        {
            Arbejdsbeskrivelse arbejdsbeskrivelse = new Arbejdsbeskrivelse(ArbejdsbeskrivelseID());
            _arbejdsbeskrivelser.Add(arbejdsbeskrivelse);
            valgteArbejdsbeskrivelse = arbejdsbeskrivelse;
        }

        //Metode til at ændre teksten i Arbejdsbeskrivelsen
        public void TilføjArbejdsbeskrivelse(string tekst)
        {
            valgteArbejdsbeskrivelse.Tekst = tekst;
        }

        //Metode til at slette den arbejdsbeskrivelse der i øjeblikket håndteres
        public void SletArbejdsbeskrivelse()
        {
            _arbejdsbeskrivelser.Remove(valgteArbejdsbeskrivelse);
            valgteArbejdsbeskrivelse = null;
        }

        //En metode til at finde alle de arbejdsbeskrivelser med et givent løbenummer.
        public List<Arbejdsbeskrivelse> FindArbejdsbeskrivelser(int løbeNr)
        {
            List<Arbejdsbeskrivelse> tempList = new List<Arbejdsbeskrivelse>();
            foreach (var arbejdsbeskrivelse in _arbejdsbeskrivelser)
            {
                if (arbejdsbeskrivelse.LøbeNr == løbeNr)
                {
                    tempList.Add(arbejdsbeskrivelse);
                }
            }
            return tempList;
        }
    }
}
