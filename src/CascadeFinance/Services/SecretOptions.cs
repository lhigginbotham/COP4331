using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CascadeFinance.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SecretOptions
    {
        public string PlaidSecret { get; set; }
    }
}
