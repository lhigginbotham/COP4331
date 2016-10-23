using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Plaid.response
{
    public class Account
    {
        private string id;
        private string item;
        private string userId;

        private Balance balance;
        private AccountMeta accountMeta;

        private string institutionType;
        private string type;
        private string subtype;

        public Account(string _id, string _item, string _user, Balance balance, AccountMeta meta, string institution_type, string type, string subtype)
        {
            this.id = _id;
            this.item = _item;
            this.userId = _user;
            this.balance = balance;
            this.accountMeta = meta;
            this.institutionType = institution_type;
            this.type = type;
            this.subtype = subtype;
        }
    }
}
