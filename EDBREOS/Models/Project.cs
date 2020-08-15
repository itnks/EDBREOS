using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FileHelpers;

namespace EDBREOS.Models
{
    public class Project
    {
        [Key]
        public Guid GId { get; set; }
        public int Id { get; set; }
        public string Summary { get; set; }
        public string DependsOn { get; set; }
        public string Duplicates { get; set; }
        public DateTime Modified { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public DateTime Reported { get; set; }
        public string Status { get; set; }
        public string Blocks { get; set; }
        public string Commit_ID { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Files { get; set; }
        public DateTime CreatedAt { get; set; }


        public virtual ICollection<ProjectAdditionalDetails> ProjectAdditionalDetails { get; set; }

        [ForeignKey("Projects")]
        public Guid? Project_Id { get; set; }

        public virtual Projects Projects { get; set; }

    }

    public class ProjectAdditionalDetails
    {
        [Key]
        public Guid GId { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
        
        public Guid? Project_Id { get; set; }

        public virtual Project Project { get; set; }

    }

}
