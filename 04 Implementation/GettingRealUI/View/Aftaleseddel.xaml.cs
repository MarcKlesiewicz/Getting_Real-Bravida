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
        private AftaleseddelViewModel aftaleseddelViewModel;

        public Aftaleseddel(Model.Aftaleseddel aftaleseddel)
        {
            InitializeComponent();
            aftaleseddelViewModel = new AftaleseddelViewModel(aftaleseddel);
            DataContext = aftaleseddelViewModel;
        }
    }
}
