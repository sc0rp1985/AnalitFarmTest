using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Cassa.Wpf.Annotations;
using Cassa.Wpf.OperationService;
using Common;
using Microsoft.Practices.Unity;

namespace Cassa.Wpf.Frames
{
    public class WareListVM : INotifyPropertyChanged
    {
        public IUnityContainer Cfg { get; set; }

        
        public WcfClient client { get; set; }

        public ObservableCollection<WareWcfDto> Items { get; set; }

        [InjectionConstructor]
        public WareListVM(IUnityContainer cfg)
        {
            Cfg = cfg;
            client = cfg.Resolve<WcfClient>();
            Items = new ObservableCollection<WareWcfDto>();
            Refresh();
        }

        void Refresh()
        {
            Items = new ObservableCollection<WareWcfDto>();
            Items = client.GetWareList(new WareLoadParams()).ToObservableCollection();
            OnPropertyChanged(nameof(Items));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
