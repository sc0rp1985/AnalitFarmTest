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
    /// Interaction logic for CheckDetail.xaml
    /// </summary>
    public partial class CheckDetailList : UserControl
    {
        public CheckDetailList()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool b = false;
            switch (e.Key)
            {
                case Key.Back: b = true; break;
                case Key.D0: b = true; break;
                case Key.D1: b = true; break;
                case Key.D2: b = true; break;
                case Key.D3: b = true; break;
                case Key.D4: b = true; break;
                case Key.D5: b = true; break;
                case Key.D6: b = true; break;
                case Key.D7: b = true; break;
                case Key.D8: b = true; break;
                case Key.D9: b = true; break;
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9: b = true; break;
                case Key.OemPeriod: b = true; break;
            }
            if (b == false)
            {
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }
    }
}
