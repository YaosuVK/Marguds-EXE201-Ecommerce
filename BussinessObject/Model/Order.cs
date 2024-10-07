using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
        public double Total { get; set; }

        public int? ReportID { get; set; }
        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }

        public string? transactionID { get; set; }
        public int? ShippingInforID { get; set; }

        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; }
        //
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Transaction? Transaction { get; set; }
        public ShippingInfo ShippingInfo { get; set; } = null!;

        public Report? Report { get; set; }

        
        public int VoucherDetailID { get; set; }

        public VoucherDetail VoucherDetail { get; set; }

    }

    public enum PaymentMethod
    {
        Cod = 0,
        VnPay = 1
    }

    public enum OrderStatus
    {
        ToPay = 0,
        ToConfirm = 1,
        ToShip = 2,
        ToReceive = 3,
        Completed = 4,
        Cancelled = 5,
        ReturnRefund = 6,
        RequestReturn = 7
    }
}

