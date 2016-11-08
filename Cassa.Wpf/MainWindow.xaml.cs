using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Cassa.Wpf.Annotations;
using Cassa.Wpf.Frames;
using Microsoft.Practices.Unity;

namespace Cassa.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IUnityContainer cfg;

        public WareListVM WareListVm { get; set; }
        public string TestText { get; set; }
        public string AddedWareName { get; set; }

        public ICommand AddWareCMD { get; set; }

        public CheckVM Check { get; set; }

        public bool IsShowWareList { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var client = new WcfClient();
            cfg = new UnityContainer();
            cfg.RegisterInstance(cfg)
                .RegisterInstance(client);

            WareListVm = new WareListVM(cfg);
            WareListVm.OnSelectItemEven += OnWareSelect;
            this.DataContext = this;
            OnPropertyChanged(nameof(WareListVm));

            AddWareCMD = new CommandDelegate(AddWare,x=>true);
            IsShowWareList = false;
            CreateTestCheck();
            OnPropertyChanged(nameof(Check));
            
        }

        void AddWare(object obj)
        {
            IsShowWareList = true;
            OnPropertyChanged(nameof(IsShowWareList));
        }

        void OnWareSelect(object sender, EventArgs args)
        {
            Check.AddWare(WareListVm.SelectedItem);
            IsShowWareList = false;
            OnPropertyChanged(nameof(IsShowWareList));
        }

        void Click(object obj)
        {

            TestText = "j rfr ";
            OnPropertyChanged(nameof(TestText));
            OnPropertyChanged(nameof(WareListVm));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestText = "j rfr ";
            OnPropertyChanged(nameof(TestText));
            OnPropertyChanged(nameof(WareListVm));
        }

        void CreateTestCheck()
        {
            Check = new CheckVM
            {
                Items = new ObservableCollection<CheckDetailVM>
                {
                    new CheckDetailVM
                    {
                        Ware = WareListVm.Items.FirstOrDefault(x=>x.WareId==1),
                        Qty = 2,
                    },
                    new CheckDetailVM
                    {
                        Ware = WareListVm.Items.FirstOrDefault(x=>x.WareId==2),
                        Qty = 1,
                    },
                    new CheckDetailVM
                    {
                        Ware = WareListVm.Items.FirstOrDefault(x=>x.WareId==3),
                        Qty = 3,
                    },
                },
                Cash = 200,
            };
            OnPropertyChanged(nameof(Check));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
