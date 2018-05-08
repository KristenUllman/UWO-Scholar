using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SQLite;
using UWOScholar.Folders;
using UWOScholarAndroid;
using Path = System.IO.Path;

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
        Database _db;
        private List<string> FolderNames;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Folder);

            Initialize();
            ViewsFromTheSix();
            DisplayMenu();
            ListFolders();

            btnAddFolder.Click += BtnAddFolder_Click;
        }

        private void DisplayMenu()
        {
            //Bottom Menu Bar setting and giving it functionality
            //Probably should make a class that does this so we can call it on each page.
            menuBottom.Title = "Folders";
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
                else if (menuClicked.ToString() == "Study")
                {
                    Intent studyActivity = new Intent(this, typeof(StudyFeatureActivity));
                    StartActivity(studyActivity);
                }
            };

            //Setting the Top Toolbar and gving it the name My BackPack
            SetActionBar(toolbarTop);
            ActionBar.Title = "My Backpack";
        }

        private void ViewsFromTheSix()
        {
            menuBottom = FindViewById<Toolbar>(Resource.Id.menu);
            toolbarTop = FindViewById<Toolbar>(Resource.Id.toolbar);
            txtFolderName = FindViewById<EditText>(Resource.Id.txtName);
            btnAddFolder = FindViewById<Button>(Resource.Id.btnAddFolder);
            listFolders = FindViewById<ListView>(Resource.Id.folderListView);
        }

        void Initialize()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Folders.db");
            _db = new Database(dbPath);
        }

        void ListFolders ()
        {
            FolderNames = new List<string>();

            foreach (Folder folder in _db.QueryAllFolders())
            {
                FolderNames.Add(folder.Name);
                Toast.MakeText(this, FolderNames.ToString(), ToastLength.Short).Show();
            }
            
            MyListViewAdapter adapter = new MyListViewAdapter(this, FolderNames);
            listFolders.Adapter = adapter;
        }
        private void BtnAddFolder_Click(object sender, EventArgs e)
        { 
            
            try
            {
                var newFolder = new Folder();
                newFolder.Name = txtFolderName.Text;
                _db.Insert(newFolder);
                ListFolders();
                Toast.MakeText(this, "Added " + txtFolderName.ToString() + " Folder to the Database", ToastLength.Short).Show();
            }
            catch (Exception )
            {
                Toast.MakeText(this,"Error adding " + txtFolderName.ToString() + " Folder to the Database", ToastLength.Short).Show();
            }
        }
    }
}