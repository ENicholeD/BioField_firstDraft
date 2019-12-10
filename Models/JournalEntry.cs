namespace BioField.Models
{
    public class JournalEntry
    {
        public int JournalEntryId {get; set;}
        public int JournalId {get; set;}
        public int EntryId {get; set;}
        public Entries Entries {get; set;}
        public Journals Journals {get; set;}
    }
}