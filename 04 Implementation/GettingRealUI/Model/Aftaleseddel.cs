using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GettingRealUI.Model
{
    public class Aftaleseddel : INotifyPropertyChanged
    {
        public string Bygherre { get; set; } = "hej";

        public int ProjektNr { get; set; } = 1;

        public string Sted { get; set; } = "hej";

        public int LøbeNr { get; set; } = 2;

        public string Dato { get; set; } = "hej";

        public string ProjektNavn { get; set; } = "hej";

        public string Modtager { get; set; } = "hej";

        public string TidsPåvirkning { get; set; } = "hej";

        public string Arbejdsudførelse { get; set; } = "hej";

        public string Prisgrundlag { get; set; } = "hej";

        private string overskift = "hej";

        public string Overskrift
        {
            get { return overskift; }
            set 
            { 
                overskift = value;
                OnPropertyChanged("Overskrift");
            }
        }


        public string SvarSenest { get; set; } = "Imorgen";

        public string RefPlan { get; set; } = "21";

        public string Arbejdsbeskrivelse { get; set; }

        public string PrisIAlt { get; set; }

        public Aftaleseddel(int projekNr, string bygherre, string sted, string dato, int løbeNr, string projektNavn)
        {
            ProjektNr = projekNr;
            Bygherre = bygherre;
            Sted = sted;
            Dato = dato;
            LøbeNr = løbeNr;
            ProjektNavn = projektNavn;
        }

        public override string ToString()
        {
            return $"{Overskrift} {Modtager} {TidsPåvirkning} {Prisgrundlag} {Arbejdsudførelse}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
