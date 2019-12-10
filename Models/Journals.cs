using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BioField.Models
    {
        public class Journals
        {
            public Journals()
            {
                this.Entries = new HashSet<JournalEntry>();
            }

            [Key]
            public int JournalId {get; set;}
            
            public string Name {get; set;}
            public virtual ApplicationUser User {get; set;}
            public virtual ICollection<JournalEntry> Entries {get; set;}
        }
    }