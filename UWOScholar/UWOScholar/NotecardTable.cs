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
    [Table("notecards")]
    public class NotecardTable
    {

        [PrimaryKey, AutoIncrement, Column("_Notecard")]
        public int notecardId { get; set; }
        [MaxLength(25), NotNull]
        public string term { get; set; }
        [MaxLength(100), NotNull]
        public string definition { get; set; }
        //[MaxLength(100)]
    }
}