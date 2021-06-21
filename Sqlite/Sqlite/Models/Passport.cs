using Sqlite.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite.Models
{
    public class Passport : TableData
    {
        public DateTime ExpirationDate { get; set; }
    }
}
