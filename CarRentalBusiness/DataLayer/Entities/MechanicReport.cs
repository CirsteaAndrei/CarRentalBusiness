using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class MechanicReport : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool IsWorking { get; set; } 
        public int ConditionScore { get; set; }
        public string DamagedParts { get; set; }
        public float EstRepairingCost { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
