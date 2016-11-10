using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Cassa.Classes
{
    [ServiceContract]
    public interface IOperationService
    {
        [OperationContract]
        List<WareWcfDto> GetWareList(WareLoadParams param);
        [OperationContract]
        int CloseCheck(CheckWcfDto Check);
    }

    [DataContract]
    public class WareLoadParams
    {
        [DataMember]
        public string WareName { get; set; }
        [DataMember]
        public int LoadLimit { get; set; }
    }


    [DataContract]
    public class WareWcfDto
    {
        [DataMember]
        public int WareId { get; set; }
        [DataMember]
        public string WareName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }

    [DataContract]
    public class CheckWcfDto
    {
        [DataMember]
        public int CheckId { get; set; }
        [DataMember]
        public int CashboxId { get; set; }
        [DataMember]
        public DateTime? DateTM { get; set; }
        [DataMember]
        public decimal Summ { get; set; }
        [DataMember]
        public List<CheckDetailWcfDto> DetailList { get; set; }
    }

    [DataContract]
    public class CheckDetailWcfDto
    {
        [DataMember]
        public int CheckDetailId { get; set; }
        [DataMember]
        public int CheckId { get; set; }
        [DataMember]
        public int WareId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal Qty { get; set; }
    }


}
