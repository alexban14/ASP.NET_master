using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClubM.Models.DBObjects
{
    public partial class Announcement
    {
        public Guid Idannouncement { get; set; }

        [DisplayFormat(DataFormatString = "{0:/MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:/MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ValidTo { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:/MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? EventDateTime { get; set; }
        public string? Tags { get; set; }
    }
}
