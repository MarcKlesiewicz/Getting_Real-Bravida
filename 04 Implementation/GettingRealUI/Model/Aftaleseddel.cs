using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GettingRealUI.Model
{
    public class Aftaleseddel : INotifyPropertyChanged
    {
        public string Bygherre { get; set; }

        public int ProjektNr { get; set; } 

        public string Sted { get; set; }

        public int LøbeNr { get; set; }

        public string Dato { get; set; }

        public string ProjektNavn { get; set; }

        private string modtager;

        public string Modtager
        {
            get { return modtager; }
            set 
            {
                modtager = value;
                OnPropertyChanged("Modtager");
            }
        }

        private string tidsPårvirkning;

        public string TidsPåvirkning
        {
            get { return tidsPårvirkning; }
            set 
            { 
                tidsPårvirkning = value;
                OnPropertyChanged("TidsPåvirkning");
            }
        }

        private string arbejdsudførelse;

        public string Arbejdsudførelse
        {
            get { return arbejdsudførelse; }
            set 
            { 
                arbejdsudførelse = value;
                OnPropertyChanged("Arbejdsudførelse");
            }
        }

        private string prisgrundlag;

        public string Prisgrundlag
        {
            get { return prisgrundlag; }
            set 
            {
                prisgrundlag = value;
                OnPropertyChanged("Prisgrundlag");
            }
        }

        private string overskift;

        public string Overskrift
        {
            get { return overskift; }
            set 
            { 
                overskift = value;
                OnPropertyChanged("Overskrift");
            }
        }

        private string svarSenest;

        public string SvarSenest
        {
            get { return svarSenest; }
            set 
            { 
                svarSenest = value;
                OnPropertyChanged("SvarSenest");
            }
        }

        private string refPlan;

        public string RefPlan
        {
            get { return refPlan; }
            set 
            { 
                refPlan = value;
                OnPropertyChanged("RefPlan");
            }
        }

        private string arbejdsbeskrivelse;

        public string Arbejdsbeskrivelse
        {
            get { return arbejdsbeskrivelse; }
            set
            { 
                arbejdsbeskrivelse = value;
                OnPropertyChanged("Arbejdsbeskrivelse");
            }
        }

        private bool aktiv = true;

        public bool Aktiv
        {
            get { return aktiv; }
            set
            { 
                aktiv = value;
                OnPropertyChanged("Aktiv");
            }
        }

        private double prisIAlt;

        public double PrisIAlt
        {
            get { return prisIAlt; }
            set 
            { 
                prisIAlt = value;
                OnPropertyChanged("PrisIAlt");
            }
        }

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
