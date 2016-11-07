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

namespace Cassa.Wpf.Frames
{
    public class CheckVM: INotifyPropertyChanged
    {
        private CheckDetailVM selectedDetItem;
        public ObservableCollection<CheckDetailVM> Items { get; set; }

        public CheckDetailVM SelectedDetItem
        {
            get { return selectedDetItem; }
            set
            {
                selectedDetItem = value;
                OnPropertyChanged(nameof(SelectedDetItem));
            }
        }

        public decimal Summ { get; set; }
        public decimal Cash { get; set; }
        public decimal OddMoney { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    };

    public class CheckDetailVM : INotifyPropertyChanged
    {
        private decimal qty;

        public WareWcfDto Ware { get; set; }

        public decimal Qty
        {
            get { return qty; }
            set
            {
                qty = value; 
                OnPropertyChanged(nameof(Summ));
            }
        }

        public string WareName => Ware.WareName;
        public decimal Summ => Ware.Price*Qty;
        public int WareId => Ware.WareId;
        public decimal Price => Ware.Price;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
