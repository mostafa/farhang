using System;
using SQLite;

namespace Farhang2
{
    public class DBHeadword
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String Lemma { get; set; }
        [Indexed]
        public String Word { get; set; }

        public String Pronunciation { get; set; }

        public String Description { get; set; }

        public Int32 Priority { get; set; }
        public Boolean Incomplete { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }

        public DBHeadword(String lemma, String word, String pronunciation, String description, int priority, bool incomplete, DateTime creation, DateTime modification)
        {
            Lemma = lemma;
            Word = word;
            Pronunciation = String.IsNullOrWhiteSpace(pronunciation) ? null : pronunciation;
            Description = String.IsNullOrWhiteSpace(description) ? null : description;
            Priority = priority;
            Incomplete = incomplete;
            CreationDateTime = creation;
            ModificationDateTime = modification;
        }

        public DBHeadword(DBHeadword hw)
        {
            Lemma = hw.Lemma;
            Word = hw.Word;
            Pronunciation = String.IsNullOrWhiteSpace(hw.Pronunciation) ? null : hw.Pronunciation;
            Description = String.IsNullOrWhiteSpace(hw.Description) ? null : hw.Description;
            Priority = hw.Priority;
            Incomplete = hw.Incomplete;
            CreationDateTime = hw.CreationDateTime;
            ModificationDateTime = hw.ModificationDateTime;
        }

        public static int InsertHeadword(SQLiteConnection db, DBHeadword headword)
        {
            var hw = new DBHeadword(headword);

            db.Insert(headword);

            return hw.Id;
        }
    }

    public class DBEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int pid { get; set; }

        public String EntryType { get; set; }
        public String Number { get; set; }
        public String SourceLanguage { get; set; }

        public String SourceText { get; set; }

        public String TranslationLanguage { get; set; }

        public String Translation { get; set; }

        public DBEntry(int parent_id, String type, String number, String srcLang, String srcText, String transLang, String transText)
        {
            pid = parent_id;
            EntryType = type;
            Number = number;
            SourceLanguage = srcLang;
            SourceText = srcText;
            TranslationLanguage = transLang;
            Translation = transText;
        }
    }
}
