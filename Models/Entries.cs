using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BioField.Models
{
    public class Entries
    {
        public Entries(){
            this.AllJournalEntries = new HashSet<JournalEntries>();
        }
        [Key]
        public int EntryId {get; set;}

        public string Site {get; set;}
        public int Temperature {get; set;}
        public string Weather {get; set;}
        public string Wind {get; set;}
        public string Soil {get; set;}
        public string Observation {get; set;}
        public virtual ApplicationUser User { get; set; }
        public ICollection<JournalEntries> AllJournalEntries {get; set;}
    }
}