namespace BioField
{
    public class JournalEntries
    {
        public int JournalEntryId {get; set;}
        public int JournalId {get; set;}
        public int EntryId {get; set;}
        public Journals Journals {get; set;}
        public Entries Entries {get; set;}
    }
}