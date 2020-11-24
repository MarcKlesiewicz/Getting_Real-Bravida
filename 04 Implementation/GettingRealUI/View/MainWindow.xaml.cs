﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GettingRealUI.ViewModel;

namespace GettingRealUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mvm;
        public MainWindow()
        {

            InitializeComponent();
            mvm = new MainViewModel();
            DataContext = mvm;
        }




        private void Opret_knap_Click(object sender, RoutedEventArgs e)
        {
            Aftaleseddel aftaleseddelWindow = new Aftaleseddel(mvm.OpretAftaleseddel());
            aftaleseddelWindow.Show();
        }

        private void VisAftaleSeddel_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAftaleSeddel.SelectedItem is Model.Aftaleseddel)
            {
                Model.Aftaleseddel temp = (Model.Aftaleseddel)ListBoxAftaleSeddel.SelectedItem;
                Aftaleseddel aftaleseddelWindow = new Aftaleseddel(temp);
                if (aftaleseddelWindow.ShowDialog().Value)
                {
                    mvm.sætaftaleseddel(temp);
                    if (temp.Overskrift != aftaleseddelWindow.aftaleseddelViewModel.Overskrift)
                    {
                        mvm.RedigerAftaleseddel("Overskrift", aftaleseddelWindow.aftaleseddelViewModel.Overskrift);
                    }
                }


            }
        }
    }
}