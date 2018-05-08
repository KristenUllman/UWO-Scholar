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
using UWOScholarAndroid;

namespace UWOScholar
{
    [Activity(Label = "Study Feature")]
    public class StudyFeatureActivity : Activity
    {
        Button btnHome;
        Button btnLogout;
        Button btnNextCard;
        Button btnShowDefinition;
        EditText txtTerm;
        EditText txtDefinition;
        Toolbar menuBottom;
        Toolbar toolbarTop;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.StudyFeature);
            txtTerm = FindViewById<EditText>(Resource.Id.txtTerm);
            txtDefinition = FindViewById<EditText>(Resource.Id.txtDefinition);
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnLogout = FindViewById<Button>(Resource.Id.btnLogout);
            btnNextCard = FindViewById<Button>(Resource.Id.btnNextCard);
            btnShowDefinition = FindViewById<Button>(Resource.Id.btnShowDefinition);

            btnLogout.Click += BtnLogout_Click;
            btnHome.Click += BtnHome_Click;
            btnNextCard.Click += BtnNextCard_Click;
            btnShowDefinition.Click += BtnShowDefinition_Click;
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            menuBottom = FindViewById<Toolbar>(Resource.Id.menu);
            toolbarTop = FindViewById<Toolbar>(Resource.Id.toolbar);
            menuBottom.Title = "Study";
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
            SetActionBar(toolbarTop);
            ActionBar.Title = "Study";
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Intent backActivity = new Intent(this, typeof(MainActivity));
            StartActivity(backActivity);
        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            Intent backActivity = new Intent(this, typeof(HomeActivity));
            StartActivity(backActivity);
        }
        private void BtnNextCard_Click(object sender, EventArgs e)
        {
            txtTerm.Text = "Data Type";
           
        }
        private void BtnShowDefinition_Click(object sender, EventArgs e)
        {
            txtDefinition.Text = "a particular kind of data item, as defined by the values it can take, the programming language used, or the operations that can be performed on it.";
        }
    }
}