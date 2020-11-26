using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using GettingRealUI.Model;
using System.ComponentModel;

namespace GettingRealUI.ViewModel
{
    public class AftaleseddelViewModel : INotifyPropertyChanged
    {
        private Model.Aftaleseddel aftaleseddel;
        public string Bygherre { get; set; }

        public int ProjektNr { get; set; }

        public string Sted { get; set; }

        public int LøbeNr { get; set; }

        public string Dato { get; set; }

        public string ProjektNavn { get; set; }

        public string Modtager { get; set; }

        public string TidsPåvirkning { get; set; }

        public string Arbejdsudførelse { get; set; }

        public string Prisgrundlag { get; set; }

        public string Overskrift { get; set; }

        public string SvarSenest { get; set; }

        public string RefPlan { get; set; }

        public string Arbejdsbeskrivelse { get; set; }

        private double prisIAlt;

        public double PrisIAlt
        {
            get { return prisIAlt; }
            set
            {
                prisIAlt = value;
                aftaleseddel.PrisIAlt = prisIAlt;
                OnPropertyChanged("PrisIAlt");
            }
        }


        public AftaleseddelViewModel(Model.Aftaleseddel aftaleseddel)
        {
            this.aftaleseddel = aftaleseddel;
            Bygherre = aftaleseddel.Bygherre;
            ProjektNr = aftaleseddel.ProjektNr;
            Sted = aftaleseddel.Sted;
            LøbeNr = aftaleseddel.LøbeNr;
            Dato = aftaleseddel.Dato;
            ProjektNavn = aftaleseddel.ProjektNavn;
            Modtager = aftaleseddel.Modtager;
            TidsPåvirkning = aftaleseddel.TidsPåvirkning;
            Prisgrundlag = aftaleseddel.Prisgrundlag;
            Overskrift = aftaleseddel.Overskrift;
            SvarSenest = aftaleseddel.SvarSenest;
            RefPlan = aftaleseddel.RefPlan;
            Arbejdsbeskrivelse = aftaleseddel.Arbejdsbeskrivelse;
            prisIAlt = aftaleseddel.PrisIAlt;
        }

        public void FindPrisIAlt(ObservableCollection<Arbejdsbeskrivelse> arbejdsbeskrivelses)
        {
            double sum = 0;
            foreach (var item in arbejdsbeskrivelses)
            {
                sum += item.Sum;
            }
            PrisIAlt = sum;
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
