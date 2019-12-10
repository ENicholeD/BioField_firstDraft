using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BioField.Models
{
    public class Entries
    {
        [Key]
        public int EntryId {get; set;}

        public string Site {get; set;}
        public int Temperature {get; set;}
        public string Weather {get; set;}
        public string Wind {get; set;}
        public string Soil {get; set;}
        public string Observation {get; set;}
        public int JournalId {get; set;}
        public virtual ApplicationUser User { get; set; }
        public virtual Journals Journal {get; set;}
    }
}