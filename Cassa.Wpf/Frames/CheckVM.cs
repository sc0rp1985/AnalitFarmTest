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
        private decimal cash = 0;
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

        public bool IsValidCash { get { return OddMoney < 0; } }

        public decimal Summ { get { return Items?.Count > 0 ? Items.Sum(x => x.Summ) : 0; }}

        public decimal Cash
        {
            get { return cash; }
            set
            {
                cash = value;
                OddMoney = cash - Summ;
                OnPropertyChanged(nameof(Cash));
                OnPropertyChanged(nameof(OddMoney));
                OnPropertyChanged(nameof(IsValidCash));
            }
        }

        public decimal OddMoney { get; set; }
        public int CheckWareCount { get { return Items.Count; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddWare(WareWcfDto ware)
        {
            Items.Add(new CheckDetailVM
            {
                Ware = ware,
                Qty = 1,
            });
        }

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
