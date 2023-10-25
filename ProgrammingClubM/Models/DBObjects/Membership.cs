using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClubM.Models.DBObjects
{
    public partial class Membership
    {
        public Guid Idmembership { get; set; }
        public Guid Idmember { get; set; }
        public Guid IdmembershipType { get; set; }

        [DisplayFormat(DataFormatString = "{0:/MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:/MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int Level { get; set; }

        public virtual Member IdmemberNavigation { get; set; } = null!;
        public virtual MembershipType IdmembershipTypeNavigation { get; set; } = null!;
    }
}
