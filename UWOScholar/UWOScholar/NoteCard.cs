﻿using System;
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
    public class NoteCard
    {

        [PrimaryKey, AutoIncrement, Column("_NId")]
        public int notecardId { get; set; }

        [Indexed]
        public int FolderId { get; set; }
        [MaxLength(25), NotNull]
        public string term { get; set; }
        [MaxLength(100), NotNull]
        public string definition { get; set; }


        public override string ToString()
        {
            return string.Format (term, definition);
        }
    }
}