using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class ReportAddDto
    {
        public int CarId { get; set; }
        public bool IsWorking { get; set; }
        public int ConditionScore { get; set; }
        public string DamagedParts { get; set; }
        public float EstRepairingCost { get; set; }
        public string DateCreated { get; set; }
    }
}
