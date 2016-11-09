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
using Cassa.Wpf.OperationService;
using Common;
using Microsoft.Practices.Unity;

namespace Cassa.Wpf
{
    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IUnityContainer cfg;
        WcfClient client = new WcfClient();
        private int cashBoxId = 1;

        public WareListVM WareListVm { get; set; }
        public string TestText { get; set; }
        public string AddedWareName { get; set; }

        public ICommand AddWareCMD { get; set; }
        public ICommand CloseCheckCMD { get; set; }
        public ICommand CreateCheckCMD { get; set; }

        public CheckVM Check { get; set; }

        public bool IsShowWareList { get; set; }

        [Microsoft.Practices.Unity.Dependency]
        public IWorker worker { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            client = new WcfClient();
            cfg = new UnityContainer();
            cfg.RegisterInstance(cfg)
                .RegisterType<IWorker, AsyncWorker>()
                .RegisterInstance(client);
            cfg.BuildUp(this);
            WareListVm = new WareListVM(cfg);
            WareListVm.SelectItemEven += WareSelect;
            this.DataContext = this;
            OnPropertyChanged(nameof(WareListVm));

            AddWareCMD = new CommandDelegate(AddWare, x => Check.CheckId == 0 && worker.IsFree);
            CloseCheckCMD = new CommandDelegate(CloseCheck, x=>Check.IsValidCash && Check.Summ>0 && Check.CheckId==0 && worker.IsFree);
            CreateCheckCMD = new CommandDelegate(x =>
            {
                Check = new CheckVM();
                OnPropertyChanged(nameof(Check));
            }, x=>Check.CheckId > 0 && worker.IsFree);
            IsShowWareList = false;
            Check = new CheckVM();
            //CreateTestCheck();
            OnPropertyChanged(nameof(Check));
            
        }

        void AddWare(object obj)
        {
            IsShowWareList = true;
            OnPropertyChanged(nameof(IsShowWareList));

        }

        void CloseCheck(object obj)
        {

            worker.Do(() =>
            {

                return client.CloseCheck(new CheckWcfDto
                {
                    Summ = Check.Summ,
                    CashboxId = cashBoxId,
                    DateTM = DateTime.Now,
                    DetailList = Check.Items.Select(x => new CheckDetailWcfDto
                    {
                        WareId = x.WareId,
                        Qty = x.Qty,
                        Price = x.Price,
                    }).ToArray()
                });
            },
                result =>
                {
                    Check.CheckId = result;
                },
                error =>
                {
                    MessageBox.Show($"Ошибка закрытия чека!\n{error.Message}");
                });




        }

        void WareSelect(object sender, EventArgs args)
        {
            Check.AddWare(WareListVm.SelectedItem);
            IsShowWareList = false;
            OnPropertyChanged(nameof(IsShowWareList));
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
