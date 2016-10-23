using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.response
{
    public class Transaction
    {
        private string id;
        private string accountId;
        private string entityId;
        private string categoryId;
        private string pendingTransactionId;

        private string name;
        private string originalDescription;
        private List<string> category;
        private double amount;
        private DateTime date;
        private Dictionary<string, string> type;

        private bool pending;
    }
}
