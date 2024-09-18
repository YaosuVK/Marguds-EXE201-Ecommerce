using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RequestAndResponse.Response.Transaction
{
    public class TransactionResponse
    {

        public string TmnCode { get; set; }

        public string TxnRef { get; set; }

        public long Amount { get; set; }

        public string OrderInfo { get; set; }

        public string Message { get; set; }

        public string BankTranNo { get; set; }

        public DateTime PayDate { get; set; }

        public string BankCode { get; set; }

        public string TransactionNo { get; set; }

        public string TransactionType { get; set; }

        public string TransactionStatus { get; set; }

    }
}
