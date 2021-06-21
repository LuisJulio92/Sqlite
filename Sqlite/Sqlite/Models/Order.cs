using Sqlite.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite.Models
{
    public class Order : TableData
    {

        public int CustomerId { get; set; }

        public DateTime OderDate { get; set; }
    }
}
