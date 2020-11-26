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


        //for Units
        private List<Arbejdsbeskrivelse> Løbenmr;

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

        public ArbejdsbeskrivelseRepo()
        {
           Løbenmr = new List<Arbejdsbeskrivelse>();
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

        public void TilføjLøbenummer(int løbenr)
        {
            valgteArbejdsbeskrivelse.LøbeNr = løbenr;
        }

        //Metode til at slette den arbejdsbeskrivelse der i øjeblikket håndteres
        //public void SletArbejdsbeskrivelse()
        //{
        //    _arbejdsbeskrivelser.Remove(valgteArbejdsbeskrivelse);
        //    valgteArbejdsbeskrivelse = null;
        //}

        //En metode til at finde alle de arbejdsbeskrivelser med et givent løbenummer.

        public List<Arbejdsbeskrivelse> FindArbejdsbeskrivelser(int løbeNr)
        {
            Løbenmr.Clear();
            List<Arbejdsbeskrivelse> templist = new List<Arbejdsbeskrivelse>();
            foreach (var arbejdsbeskrivelse in _arbejdsbeskrivelser)
            {
                if (arbejdsbeskrivelse.LøbeNr == løbeNr)
                {
                    Løbenmr.Add(arbejdsbeskrivelse);
                    templist = Løbenmr;
                }
            }


            return templist;
   
        }

        public void AktiverArbejdsbeskrivelse(int ID)
        {
            _arbejdsbeskrivelser[ID].Aktiveret = _arbejdsbeskrivelser[ID].Aktiveret == true
                ? _arbejdsbeskrivelser[ID].Aktiveret = false
                : _arbejdsbeskrivelser[ID].Aktiveret = true;
        }

        public string RedigerArbejdsbeskrivelse(string tekst)
        {
            if (valgteArbejdsbeskrivelse != null)
            {
                valgteArbejdsbeskrivelse.Tekst = tekst;
                return tekst;
            }

            return null;

        }
        public double RedigerArbejdsbeskrivelse(double enhedsPris)
        {
            if (valgteArbejdsbeskrivelse != null)
            {
                valgteArbejdsbeskrivelse.EnhedsPris = enhedsPris;
                return enhedsPris;
            }

            return 0.0;
        }
        public int RedigerArbejdsbeskrivelse(int antal)
        {
            //Fjerner en nullexceptionen da der skal være valgt en arbejdsbeskrivelse
            if (valgteArbejdsbeskrivelse != null)
            {
                valgteArbejdsbeskrivelse.Antal = antal;
                return antal;
            }

            return 0;
        }
    }
}
