﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using UWOScholarAndroid;

namespace UWOScholar
{
    [Activity(Label = "Notecards")]
    public class NotecardActivity : Activity
    {
        Button btnCreateCard;
        Button btnEditCard;
        EditText txtTerm;
        EditText txtDefinition;
        Toolbar menuBottom;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Notecard);

            btnCreateCard = FindViewById<Button>(Resource.Id.btnCreateCard);
            btnEditCard = FindViewById<Button>(Resource.Id.btnEditCard);
            txtTerm = FindViewById<EditText>(Resource.Id.txtTerm1);
            txtDefinition = FindViewById<EditText>(Resource.Id.txtDefinition1);
            btnCreateCard.Click += btnCreateCard_Click;
            btnEditCard.Click += btnEditCard_Click;
            CreateDB();
            DisplayMenu();
            // Create your application here
        }
        private void DisplayMenu()
        {
            //Bottom Menu Bar setting and giving it functionality
            //Probably should make a class that does this so we can call it on each page.
            menuBottom.Title = "Menu";
            menuBottom.InflateMenu(Resource.Menu.pageMenu);
            menuBottom.MenuItemClick += (sender, e) =>
            {
                var menuClicked = e.Item.TitleFormatted;
                if (menuClicked.ToString() == "Folder")
                {
                    Intent folderActivity = new Intent(this, typeof(FolderActivity));
                    StartActivity(folderActivity);
                }
                else if (menuClicked.ToString() == "Home")
                {
                    Intent homeActivity = new Intent(this, typeof(HomeActivity));
                    StartActivity(homeActivity);
                }
            };
        }
        public string CreateDB()
        {
            var output = "";
            output += "Creating Databse if it doesnt exists";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";
            return output;
        }

        private void btnEditCard_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCreateCard_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<NoteCard>();
                NoteCard tbl = new NoteCard();
                tbl.term = txtTerm.Text;
                tbl.definition = txtDefinition.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}