using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cassa.Wpf.Annotations;
using Cassa.Wpf.OperationService;
using Common;
using Microsoft.Practices.Unity;

namespace Cassa.Wpf.Frames
{
    public class WareListVM : INotifyPropertyChanged
    {
        public event EventHandler SelectItemEven;

        public IUnityContainer Cfg { get; set; }
        public WcfClient client { get; set; }


        private string addedWareName;
        private ObservableCollection<WareWcfDto> WareList { get; set; }
        public ObservableCollection<WareWcfDto> Items { get; set; }
        public WareWcfDto SelectedItem { get; set; }

        [Microsoft.Practices.Unity.Dependency]
        public IWorker Worker { get; set; }

        public string AddedWareName
        {
            get { return addedWareName; }
            set
            {
                addedWareName = value;
                Items = WareList.Where(x => x.WareName.StartsWith(addedWareName)).ToObservableCollection();
                OnPropertyChanged(nameof(Items));
            }
        }

        [InjectionConstructor]
        public WareListVM(IUnityContainer cfg)
        {
            Cfg = cfg;
            Cfg.BuildUp(this);
            client = cfg.Resolve<WcfClient>();
            WareList = new ObservableCollection<WareWcfDto>();
            Items = new ObservableCollection<WareWcfDto>();
            Refresh();
        }

        void Refresh()
        {
            Items = new ObservableCollection<WareWcfDto>();
            Worker.Do(() => { return client.GetWareList(new WareLoadParams()).ToObservableCollection(); },
                result =>
                {
                    Items = result;
                    WareList = Items.ToObservableCollection();
                    OnPropertyChanged(nameof(Items));
                },
                error => { MessageBox.Show($"Ошибка загрузки списка товаров!\n{error.Message}"); });
            
        }

        public void ItemSelect()
        {
            SelectItemEven?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
