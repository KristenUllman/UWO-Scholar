using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SQLite;
using UWOScholarAndroid;

namespace UWOScholar
{
    [Activity(Label = "FolderActivity")]
    public class FolderActivity : Activity
    {
        Toolbar toolbarTop;
        Toolbar menuBottom;
        Button btnAddFolder;
        EditText txtFolderName;
        ListView listFolders;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Folder);

            menuBottom = FindViewById<Toolbar>(Resource.Id.menu);
            toolbarTop = FindViewById<Toolbar>(Resource.Id.toolbar);
            txtFolderName = FindViewById<EditText>(Resource.Id.txtName);
            btnAddFolder = FindViewById<Button>(Resource.Id.btnAddFolder);
            listFolders = FindViewById<ListView>(Resource.Id.folderListView);

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

            //Setting the Top Toolbar and gving it the name My BackPack
            SetActionBar(toolbarTop);
            ActionBar.Title = "My Backpack";

            btnAddFolder.Click += BtnAddFolder_Click;

        }

        private void BtnAddFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<FolderTable>();
                FolderTable tbl = new FolderTable();
                tbl.FolderName = txtFolderName.ToString();

                db.Insert(tbl);
                Toast.MakeText(this, "Folder Created Successfully", ToastLength.Short).Show();

                //

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}