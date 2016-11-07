using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using TestWpf.Annotations;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ICommand TestCMD { get; set; }
        public string TestText { get; set; }
        private int i = 0;

        public MainWindow()
        {
            InitializeComponent();
            TestText = "Жмакни меня";
            this.DataContext = this;
            TestCMD = new RoutedCommand("Click",typeof(MainWindow));
            TestCMD = new RoutedUICommand();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestText = i.ToString();
            OnPropertyChanged(nameof(TestText));
        }

        private void Click()
        {
            TestText = i.ToString();
            OnPropertyChanged(nameof(TestText));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
