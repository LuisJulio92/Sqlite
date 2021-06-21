using Sqlite.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sqlite.Models
{
    [Table("Customers")]
    public class Customer : TableData
    {
        private bool isYoung;

        public string Name { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        [Ignore]
        public bool IsYoung 
        {
            get
            {
                return Age < 30 ? true : false;
            }
            
        }

        [ForeignKey(typeof(Passport))]
        public int PassporID { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeInsert |
                                      CascadeOperation.CascadeRead )] 
                                        
        public Passport Passport { get; set; }
    }
}
