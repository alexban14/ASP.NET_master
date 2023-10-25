using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingClubM.Models.DBObjects
{
    public partial class CodeSnippet
    {
        public CodeSnippet()
        {
            InverseIdsnippetPreviousVersionNavigation = new HashSet<CodeSnippet>();
        }

        public Guid IdcodeSnippet { get; set; }
        public string Title { get; set; } = null!;
        public string ContentCode { get; set; } = null!;
        public Guid Idmember { get; set; }
        public int Revision { get; set; }
        public Guid? IdsnippetPreviousVersion { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:/MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateTimeAdded { get; set; }
        public bool IsPublished { get; set; }

        public virtual Member IdmemberNavigation { get; set; } = null!;
        public virtual CodeSnippet? IdsnippetPreviousVersionNavigation { get; set; }
        public virtual ICollection<CodeSnippet> InverseIdsnippetPreviousVersionNavigation { get; set; }
    }
}
