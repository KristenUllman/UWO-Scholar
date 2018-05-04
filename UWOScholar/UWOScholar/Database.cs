using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace UWOScholar
{
    class Database : SQLiteConnection
    {
        public Database (string path) : base(path)
        {
            CreateTable<Folder> ();
            CreateTable<NoteCard>();
        }
        public IEnumerable<NoteCard> QueryNoteCard (Folder folder)
        {
            return Table<NoteCard>().Where(x => x.FolderId == folder.Id);
        }
        /*
        public Folder QueryLatestFolder(Folder folder)
        {
            return Table<Folder>().Where(x => x.Id == folder.Id).Take(1).FirstOrDefault();
        }
        */
        public IEnumerable<Folder> QueryAllFolders()
        {
            return from f in Table<Folder>()
                   orderby f.Name
                   select f;
        }
        public IEnumerable<NoteCard> QueryAllNoteCards()
        {
            return from n in Table<NoteCard>()
                   orderby n.term
                   select n;
        }
    }
}