using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GettingRealUI.Model
{
    public class Arbejdsbeskrivelse : INotifyPropertyChanged
    {
        //Hver arbejdsbeskrivelse bliver nødt til at have hver sit ID for at kunne differentiere mellem dem. Ligesom at Aftalesedler har forskellige overskrifter
        private int _iD;

        //Field for løbenummeret til hver arbejdsbeskrivelse. Arbejdsbeskrivelse objekter KAN GODT have det samme løbenummer.
        private int _løbeNr = 1;

        //Field for teksten i arbejdsbeskrivelsens indhold
        private string _tekst;

        //Field for antal i arbejdsbeskrivelsens indhold
        private int _antal;

        //Field for enhedsprisen i arbejdsbeskrivelsens indhold
        private double _enhedsPris = 4;

        //Field for summen af alle enhedspriserne i arbejdsbeskrivelsens indhold
        private double _sum;

        //Field for om arbejdsbeskrivelsen er aktiveret eller ej
        private bool _aktiveret = true;

        public int ID
        {
            get { return _iD; }
        }

        public bool Aktiveret
        {
            get { return _aktiveret; }
            set { _aktiveret = value; }
        }

        public double Sum
        {
            get { return _sum; }
            set
            {
                _sum = value;
                OnPropertyChanged("Sum");
            }
        }

        public double EnhedsPris
        {
            get { return _enhedsPris; }
            set
            {
                _enhedsPris = value;
                Sum = EnhedsPris * Antal;
            }
        }

        public int Antal
        {
            get { return _antal; }
            set
            {
                _antal = value;
                Sum = EnhedsPris * Antal;
            }
        }

        public string Tekst
        {
            get { return _tekst; }
            set { _tekst = value; }
        }

        public int LøbeNr
        {
            get { return _løbeNr; }
            set { _løbeNr = value; }
        }

        public Arbejdsbeskrivelse(int iD)
        {
            _iD = iD;
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
