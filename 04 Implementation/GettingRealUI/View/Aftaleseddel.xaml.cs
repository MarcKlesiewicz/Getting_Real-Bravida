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

        public Aftaleseddel(Model.Aftaleseddel aftaleseddel)
        {
            InitializeComponent();
            aftaleseddelViewModel = new AftaleseddelViewModel(aftaleseddel);
            DataContext = aftaleseddelViewModel;
        }

        private void btnDeaktiver_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAktiver_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnOpretAftaleseddel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFortryd_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnGodkendt_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
