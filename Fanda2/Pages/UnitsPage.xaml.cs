using Fanda2.ViewModels;

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

namespace Fanda2.Pages
{
    /// <summary>
    /// Interaction logic for UnitsPage.xaml
    /// </summary>
    public partial class UnitsPage : Page
    {
        public UnitsPage()
        {
            UnitsViewModel units = new UnitsViewModel { Code = "EACH", Name = "Each", Description = "Each unit", IsEnabled = true };
            units.PropertyChanged += Units_PropertyChanged;
            DataContext = units;

            InitializeComponent();
        }

        private void Units_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}