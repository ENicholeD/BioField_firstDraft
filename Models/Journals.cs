using System.Collections.Generic;

namespace BioField.Models
    {
        public class Journals
        {
            public Journals()
            {
                this.AllJournalEntries = new HashSet<JournalEntries>();
            }

            public int JournalId {get; set;}
            public string Name {get; set;}
            public virtual ApplicationUser User {get; set;}
            public virtual ICollection<JournalEntries> AllJournalEntries {get; set;}
        }
    }