﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cassa.Wpf.OperationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WareLoadParams", Namespace="http://schemas.datacontract.org/2004/07/Cassa.Classes")]
    [System.SerializableAttribute()]
    public partial class WareLoadParams : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WareWcfDto", Namespace="http://schemas.datacontract.org/2004/07/Cassa.Classes")]
    [System.SerializableAttribute()]
    public partial class WareWcfDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WareIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WareNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int WareId {
            get {
                return this.WareIdField;
            }
            set {
                if ((this.WareIdField.Equals(value) != true)) {
                    this.WareIdField = value;
                    this.RaisePropertyChanged("WareId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WareName {
            get {
                return this.WareNameField;
            }
            set {
                if ((object.ReferenceEquals(this.WareNameField, value) != true)) {
                    this.WareNameField = value;
                    this.RaisePropertyChanged("WareName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CheckWcfDto", Namespace="http://schemas.datacontract.org/2004/07/Cassa.Classes")]
    [System.SerializableAttribute()]
    public partial class CheckWcfDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CashboxIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CheckIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateTMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Cassa.Wpf.OperationService.CheckDetailWcfDto[] DetailListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SummField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CashboxId {
            get {
                return this.CashboxIdField;
            }
            set {
                if ((this.CashboxIdField.Equals(value) != true)) {
                    this.CashboxIdField = value;
                    this.RaisePropertyChanged("CashboxId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CheckId {
            get {
                return this.CheckIdField;
            }
            set {
                if ((this.CheckIdField.Equals(value) != true)) {
                    this.CheckIdField = value;
                    this.RaisePropertyChanged("CheckId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateTM {
            get {
                return this.DateTMField;
            }
            set {
                if ((this.DateTMField.Equals(value) != true)) {
                    this.DateTMField = value;
                    this.RaisePropertyChanged("DateTM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Cassa.Wpf.OperationService.CheckDetailWcfDto[] DetailList {
            get {
                return this.DetailListField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailListField, value) != true)) {
                    this.DetailListField = value;
                    this.RaisePropertyChanged("DetailList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Summ {
            get {
                return this.SummField;
            }
            set {
                if ((this.SummField.Equals(value) != true)) {
                    this.SummField = value;
                    this.RaisePropertyChanged("Summ");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CheckDetailWcfDto", Namespace="http://schemas.datacontract.org/2004/07/Cassa.Classes")]
    [System.SerializableAttribute()]
    public partial class CheckDetailWcfDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CheckDetailIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CheckIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal QtyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int WareIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CheckDetailId {
            get {
                return this.CheckDetailIdField;
            }
            set {
                if ((this.CheckDetailIdField.Equals(value) != true)) {
                    this.CheckDetailIdField = value;
                    this.RaisePropertyChanged("CheckDetailId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CheckId {
            get {
                return this.CheckIdField;
            }
            set {
                if ((this.CheckIdField.Equals(value) != true)) {
                    this.CheckIdField = value;
                    this.RaisePropertyChanged("CheckId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Qty {
            get {
                return this.QtyField;
            }
            set {
                if ((this.QtyField.Equals(value) != true)) {
                    this.QtyField = value;
                    this.RaisePropertyChanged("Qty");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int WareId {
            get {
                return this.WareIdField;
            }
            set {
                if ((this.WareIdField.Equals(value) != true)) {
                    this.WareIdField = value;
                    this.RaisePropertyChanged("WareId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OperationService.IOperationService")]
    public interface IOperationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperationService/GetWareList", ReplyAction="http://tempuri.org/IOperationService/GetWareListResponse")]
        Cassa.Wpf.OperationService.WareWcfDto[] GetWareList(Cassa.Wpf.OperationService.WareLoadParams param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperationService/GetWareList", ReplyAction="http://tempuri.org/IOperationService/GetWareListResponse")]
        System.Threading.Tasks.Task<Cassa.Wpf.OperationService.WareWcfDto[]> GetWareListAsync(Cassa.Wpf.OperationService.WareLoadParams param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperationService/CloseCheck", ReplyAction="http://tempuri.org/IOperationService/CloseCheckResponse")]
        void CloseCheck(Cassa.Wpf.OperationService.CheckWcfDto Check);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOperationService/CloseCheck", ReplyAction="http://tempuri.org/IOperationService/CloseCheckResponse")]
        System.Threading.Tasks.Task CloseCheckAsync(Cassa.Wpf.OperationService.CheckWcfDto Check);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOperationServiceChannel : Cassa.Wpf.OperationService.IOperationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OperationServiceClient : System.ServiceModel.ClientBase<Cassa.Wpf.OperationService.IOperationService>, Cassa.Wpf.OperationService.IOperationService {
        
        public OperationServiceClient() {
        }
        
        public OperationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OperationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OperationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Cassa.Wpf.OperationService.WareWcfDto[] GetWareList(Cassa.Wpf.OperationService.WareLoadParams param) {
            return base.Channel.GetWareList(param);
        }
        
        public System.Threading.Tasks.Task<Cassa.Wpf.OperationService.WareWcfDto[]> GetWareListAsync(Cassa.Wpf.OperationService.WareLoadParams param) {
            return base.Channel.GetWareListAsync(param);
        }
        
        public void CloseCheck(Cassa.Wpf.OperationService.CheckWcfDto Check) {
            base.Channel.CloseCheck(Check);
        }
        
        public System.Threading.Tasks.Task CloseCheckAsync(Cassa.Wpf.OperationService.CheckWcfDto Check) {
            return base.Channel.CloseCheckAsync(Check);
        }
    }
}
