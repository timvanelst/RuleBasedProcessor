using System;
using Domain;

namespace Domain
{
    public class Item
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public ItemType? Type { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public CostCenter CostCenter { get; set; }
    }
}