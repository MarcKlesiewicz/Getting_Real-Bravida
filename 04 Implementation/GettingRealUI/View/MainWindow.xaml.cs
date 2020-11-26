using System;
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
            Model.Aftaleseddel temp = mvm.OpretAftaleseddel();
            Aftaleseddel aftaleseddelWindow = new Aftaleseddel(temp, mvm.ArbejdsbeskrivelseRepo);
            if (aftaleseddelWindow.ShowDialog().Value)
            {
                redigere(temp, aftaleseddelWindow);
                mvm.GodkendAftaleseddel();
                ListBoxAftaleSeddel.ItemsSource = mvm.VisEntrepriseOversigt();
            }
        }

        private void VisAftaleSeddel_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxAftaleSeddel.SelectedItem is Model.Aftaleseddel)
            {
                Model.Aftaleseddel temp = (Model.Aftaleseddel)ListBoxAftaleSeddel.SelectedItem;
                Aftaleseddel aftaleseddelWindow = new Aftaleseddel(temp, mvm.ArbejdsbeskrivelseRepo);
                if (aftaleseddelWindow.ShowDialog().Value)
                {
                    mvm.Sætaftaleseddel(temp);
                    redigere(temp, aftaleseddelWindow);
                    mvm.Sætaftaleseddel(null);
                }
            }
        }
        private void redigere(Model.Aftaleseddel temp, Aftaleseddel aftaleseddelWindow)
        {
            if (temp.Overskrift != aftaleseddelWindow.aftaleseddelViewModel.Overskrift)
            {
                mvm.RedigerAftaleseddel("Overskrift", aftaleseddelWindow.aftaleseddelViewModel.Overskrift);
            }
            if (temp.Modtager != aftaleseddelWindow.aftaleseddelViewModel.Modtager)
            {
                mvm.RedigerAftaleseddel("Modtager", aftaleseddelWindow.aftaleseddelViewModel.Modtager);
            }
            if (temp.TidsPåvirkning != aftaleseddelWindow.aftaleseddelViewModel.TidsPåvirkning)
            {
                mvm.RedigerAftaleseddel("TidsPåvirkning", aftaleseddelWindow.aftaleseddelViewModel.TidsPåvirkning);
            }
            if (temp.SvarSenest != aftaleseddelWindow.aftaleseddelViewModel.SvarSenest)
            {
                mvm.RedigerAftaleseddel("SvarSenest", aftaleseddelWindow.aftaleseddelViewModel.SvarSenest);
            }
            if (temp.RefPlan != aftaleseddelWindow.aftaleseddelViewModel.RefPlan)
            {
                mvm.RedigerAftaleseddel("RefPlan", aftaleseddelWindow.aftaleseddelViewModel.RefPlan);
            }
            if (temp.Arbejdsbeskrivelse != aftaleseddelWindow.aftaleseddelViewModel.Arbejdsbeskrivelse)
            {
                mvm.RedigerAftaleseddel("Arbejdsbeskrivelse", aftaleseddelWindow.aftaleseddelViewModel.Arbejdsbeskrivelse);
            }
            
        }

        private void Deaktiver_Knap_Click(object sender, RoutedEventArgs e)
        {
            mvm.Sætaftaleseddel((Model.Aftaleseddel)ListBoxAftaleSeddel.SelectedItem);
            mvm.SætAktivTilFalse();
        }

        private void Aktiver_Knap_Click(object sender, RoutedEventArgs e)
        {
            mvm.Sætaftaleseddel((Model.Aftaleseddel)ListBoxAftaleSeddel.SelectedItem);
            mvm.SætAktivTilTrue();
        }
    }
}
