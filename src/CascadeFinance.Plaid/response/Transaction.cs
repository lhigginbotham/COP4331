using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.Response
{
    public class Transaction
    {
        private string accountId;
        private string id;
        private string entityId;
        private string categoryId;
        private string pendingTransactionId;

        public Meta meta;

        private string name;
        private string originalDescription;
        private List<string> category;
        private double amount;
        private DateTime date;
        private Dictionary<string, string> type;

        private bool pending;

        public Transaction(string _account, string _id, double amount, DateTime date, string name, bool pending, Dictionary<string,string> type, List<string> category, string category_id)
        {
            this.accountId = _account;
            this.id = _id;
            this.amount = amount;
            this.date = date;
            this.name = name;
            this.pending = pending;
            this.type = type;
            this.category = category;
            this.categoryId = category_id;

        }
    }
}
