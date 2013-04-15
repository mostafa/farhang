using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Farhang2
{
    class Headword
    {
        [BsonId]
        public BsonObjectId _id { get; set; }

        public String Lemma { get; set; }
        public String Word { get; set; }

        [BsonIgnoreIfNull]
        public String Pronunciation { get; set; }

        [BsonIgnoreIfNull]
        public String Description { get; set; }

        public Int32 Priority { get; set; }
        public Boolean Incomplete { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModificationDateTime { get; set; }

        [BsonIgnoreIfNull]
        public List<Entry> Entries { get; set; }

        [BsonIgnoreIfNull]
        public Attachment Attachment { get; set; }

        public Headword(String lemma, String word, String pronunciation, String description, int priority, bool incomplete, DateTime creation, DateTime modification)
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

        public void AddEntry(String type, String number, String sourcelang, String source, String translang, String translation)
        {
            if (Entries == null)
            {
                Entries = new List<Entry>();
            }

            Entry entry = new Entry(type, number, sourcelang, source, translang, translation);
            Entries.Add(entry);
        }

        public void AddEntry(Entry ent)
        {
            if (Entries == null)
            {
                Entries = new List<Entry>();
            }
            Entries.Add(ent);
        }

        public void AddAttachment(BsonObjectId _id, String fileName)
        {
            if (Attachment == null)
            {
                Attachment = new Attachment(_id, fileName);
            }
        }
    }

    class Entry
    {
        public String EntryType { get; set; }
        public String Number { get; set; }
        public String SourceLanguage { get; set; }

        [BsonIgnoreIfNull]
        public String SourceText { get; set; }

        [BsonIgnoreIfNull]
        public String TranslationLanguage { get; set; }

        [BsonIgnoreIfNull]
        public String Translation { get; set; }

        //public List<Entry> Subentries { get; set; }

        public Entry(String type, String number, String sourcelang, String source, String translang, String translation)
        {
            EntryType = type;
            Number = number;
            SourceLanguage = sourcelang;
            SourceText = String.IsNullOrWhiteSpace(source) ? null : source;
            TranslationLanguage = String.IsNullOrWhiteSpace(translang) ? null : translang;
            Translation = String.IsNullOrWhiteSpace(translation) ? null : translation;
        }

        //public void AddSubentry(_EntryType type, String number, _Language sourcelang, String source, _Language translang, String translation)
        //{
        //    if (Subentries == null)
        //    {
        //        Subentries = new List<Entry>();
        //    }

        //    Entry subentry = new Entry(type, number, sourcelang, source, translang, translation);
        //    Subentries.Add(subentry);
        //}
    }

    class Attachment
    {
        public BsonObjectId _AttachmentId;
        public String FileName;

        public Attachment(BsonObjectId _id, String fileName)
        {
            _AttachmentId = _id;
            FileName = fileName;
        }
    }
}
