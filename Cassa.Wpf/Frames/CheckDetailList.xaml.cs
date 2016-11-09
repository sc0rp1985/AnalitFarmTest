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
using Common;

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
            bool b = InputHelpers.IsValidDigitKey(e.Key);
            
            if (b == false)
            {
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }
    }
}
