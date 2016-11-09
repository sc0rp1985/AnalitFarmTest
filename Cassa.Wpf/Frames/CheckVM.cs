using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cassa.Wpf.Annotations;
using Cassa.Wpf.OperationService;

namespace Cassa.Wpf.Frames
{
    public class CheckVM: INotifyPropertyChanged
    {
        private CheckDetailVM selectedDetItem;
        private decimal cash = 0;
        private int checkId = 0;
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

        public bool IsValidCash => Cash>=Summ;
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

        private string cashStr;

        public string CashStr
        {
            get { return cashStr; }
            set
            {
                cashStr = value;
                decimal c;
                char a = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                cashStr = cashStr.Replace('.', a);
                if (Decimal.TryParse(cashStr, out c))
                    Cash = c;
            }
        }

        public decimal OddMoney { get; set; }
        public int CheckWareCount => Items?.Count ?? 0;

        public int CheckId
        {
            get { return checkId; }
            set
            {
                checkId = value; 
                OnPropertyChanged(nameof(CheckIdStr));
            }

        }

        public string CheckIdStr
        {
            get { return checkId == 0 ? string.Empty : checkId.ToString(); }
        }

        

        public void AddWare(WareWcfDto ware)
        {
            var item = new CheckDetailVM
            {
                Ware = ware,
                Qty = 1,
            };
            item.EditItemEvent += OnItemEdit;
            Items.Add(item);
            UpdateGui();
            
        }

        void OnItemEdit(object sender, EventArgs args)
        {
            UpdateGui();
        }

        void UpdateGui()
        {
            OnPropertyChanged(nameof(Cash));
            OnPropertyChanged(nameof(OddMoney));
            OnPropertyChanged(nameof(CheckIdStr));
            OnPropertyChanged(nameof(Summ));
            OnPropertyChanged(nameof(IsValidCash));
            OnPropertyChanged(nameof(SelectedDetItem));
            OnPropertyChanged(nameof(CheckWareCount));
        }

        public CheckVM()
        {
            Items = new ObservableCollection<CheckDetailVM>();
        }


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
                OnEditItemEvent();
            }
        }

        public string WareName => Ware.WareName;
        public decimal Summ => Ware.Price*Qty;
        public int WareId => Ware.WareId;
        public decimal Price => Ware.Price;

        public event EventHandler EditItemEvent;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnEditItemEvent()
        {
            EditItemEvent?.Invoke(this, EventArgs.Empty);
        }
    }

}
