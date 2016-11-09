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

namespace Cassa.Wpf.Frames
{
    /// <summary>
    /// Interaction logic for WareList.xaml
    /// </summary>
    public partial class WareList : UserControl
    {
        public WareList()
        {
            InitializeComponent();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Presenter.ItemSelect();
            }
        }

        public WareListVM Presenter
        {
            get { return (WareListVM) DataContext; }
            set { DataContext = value; }
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Presenter.ItemSelect();
        }
    }
}
