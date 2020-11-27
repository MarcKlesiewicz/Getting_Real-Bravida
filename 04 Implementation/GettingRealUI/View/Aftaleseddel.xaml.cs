using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GettingRealUI.ViewModel;
using GettingRealUI.Model;

namespace GettingRealUI.View
{
    /// <summary>
    /// Interaction logic for Aftaleseddel.xaml
    /// </summary>
    public partial class Aftaleseddel : Window
    {
        public readonly AftaleseddelViewModel aftaleseddelViewModel;
        private ArbejdsbeskrivelseViewModel arbejdsbeskrivelseViewModel;

        public Aftaleseddel(Model.Aftaleseddel aftaleseddel, Model.ArbejdsbeskrivelseRepo arbejdsbeskrivelseRepo)
        {
            InitializeComponent();
            aftaleseddelViewModel = new AftaleseddelViewModel(aftaleseddel);
            arbejdsbeskrivelseViewModel = new ArbejdsbeskrivelseViewModel(arbejdsbeskrivelseRepo);
            DataContext = new
            {
                asvm = aftaleseddelViewModel,
                abvm = arbejdsbeskrivelseViewModel
            };
            arbejdsbeskrivelseViewModel.FindArbejsbeskrivleser(aftaleseddelViewModel.LøbeNr);
            sætCheckBox(aftaleseddelViewModel.Prisgrundlag, aftaleseddelViewModel.Arbejdsudførelse);
        }

        private void btnDeaktiver_Click(object sender, RoutedEventArgs e)
        {
            arbejdsbeskrivelseViewModel.SætArbejdesbeskrivelse((Model.Arbejdsbeskrivelse)ListBoxArbejdsBeskrivelser.SelectedItem);
            arbejdsbeskrivelseViewModel.DeaktiveretArbejdsbeskrivelse();
            aftaleseddelViewModel.FindPrisIAlt(arbejdsbeskrivelseViewModel.Arbejdsbeskrivelses);
        }

        private void btnAktiver_Click(object sender, RoutedEventArgs e)
        {
            arbejdsbeskrivelseViewModel.SætArbejdesbeskrivelse((Model.Arbejdsbeskrivelse)ListBoxArbejdsBeskrivelser.SelectedItem);
            arbejdsbeskrivelseViewModel.AktiverArbejdsbeskrivelse();
            aftaleseddelViewModel.FindPrisIAlt(arbejdsbeskrivelseViewModel.Arbejdsbeskrivelses);
        }

        private void btnOpretAftaleseddel_Click(object sender, RoutedEventArgs e)
        {
            arbejdsbeskrivelseViewModel.OpretArbejdsbeskrivelse(aftaleseddelViewModel.LøbeNr);
        }

        private void btnFortryd_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnGodkendt_Click(object sender, RoutedEventArgs e)
        {
            if (Overskrift.Text == "")
            {
                MessageBox.Show("Du mangler at sætte overskiften", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void BygHerreØnske_Checked(object sender, RoutedEventArgs e)
        {
            PrisGrundlagCheck(BygHerreØnske);
        }


        private void ProjektÆndring_Checked(object sender, RoutedEventArgs e)
        {
            PrisGrundlagCheck(ProjektÆndring);
        }

        private void EfterRegning_Checked(object sender, RoutedEventArgs e)
        {
            PrisGrundlagCheck(EfterRegning);
        }

        private void TillægsPris_Checked(object sender, RoutedEventArgs e)
        {
            PrisGrundlagCheck(TillægsPris);
        }

        private void AB92_Checked(object sender, RoutedEventArgs e)
        {
            IHenholdTilCheck(AB92);
        }

        private void StandardForbehold_Checked(object sender, RoutedEventArgs e)
        {
            IHenholdTilCheck(StandardForbehold);
        }

        private void Andet_Checked(object sender, RoutedEventArgs e)
        {
            IHenholdTilCheck(Andet);
        }


        private void PrisGrundlagCheck(CheckBox checkbox)
        {
            if (checkbox == BygHerreØnske)
            {
                aftaleseddelViewModel.Prisgrundlag = "Bygherre";
                EfterRegning.IsChecked = false;
                TillægsPris.IsChecked = false;
                ProjektÆndring.IsChecked = false;
            }
            else if (checkbox == EfterRegning)
            {
                aftaleseddelViewModel.Prisgrundlag = "Efter";
                BygHerreØnske.IsChecked = false;
                TillægsPris.IsChecked = false;
                ProjektÆndring.IsChecked = false;
            }
            else if (checkbox == TillægsPris)
            {
                aftaleseddelViewModel.Prisgrundlag = "Tillæg";
                EfterRegning.IsChecked = false;
                BygHerreØnske.IsChecked = false;
                ProjektÆndring.IsChecked = false;
            }
            else if (checkbox == ProjektÆndring)
            {
                aftaleseddelViewModel.Prisgrundlag = "Projekt";
                EfterRegning.IsChecked = false;
                TillægsPris.IsChecked = false;
                BygHerreØnske.IsChecked = false;
            }

        }

        private void sætCheckBox(string prisgrundlag,string iHenholdTil)
        {
            
            if (prisgrundlag == "Bygherre")
            {
                BygHerreØnske.IsChecked = true;
            }
            else if (prisgrundlag == "Efter")
            {
                EfterRegning.IsChecked = true;
            }
            else if (prisgrundlag == "Tilæg")
            {
                TillægsPris.IsChecked = true;
            }
            else if (prisgrundlag == "Projekt")
            {
                ProjektÆndring.IsChecked = true;
            }

            if (iHenholdTil == "AB")
            {
                AB92.IsChecked = true;
            }
            else if (iHenholdTil == "Standard")
            {
                StandardForbehold.IsChecked = true;
            }
            else if (iHenholdTil != null)
            {
                Andet.IsChecked = true;
                AndetTextBox.Text = iHenholdTil;
            }
        }

        private void IHenholdTilCheck(CheckBox checkbox)
        {
            if (checkbox == AB92)
            {
                aftaleseddelViewModel.Arbejdsudførelse = "AB";
                Andet.IsChecked = false;
                StandardForbehold.IsChecked = false;

            }
            else if (checkbox == Andet)
            {
                aftaleseddelViewModel.Arbejdsudførelse = AndetTextBox.Text;
                AB92.IsChecked = false;
                StandardForbehold.IsChecked = false;
            }
            else if (checkbox == StandardForbehold)
            {
                aftaleseddelViewModel.Arbejdsudførelse = "Standard";
                Andet.IsChecked = false;
                AB92.IsChecked = false;
            }
        }

        private void Sum_TextChanged(object sender, TextChangedEventArgs e)
        {
            aftaleseddelViewModel.FindPrisIAlt(arbejdsbeskrivelseViewModel.Arbejdsbeskrivelses);
        }
    }
}
