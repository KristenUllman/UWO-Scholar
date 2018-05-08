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
using UWOScholar;

namespace UWOScholarAndroid
{
    [Activity(Label = "Home")]
    public class HomeActivity : Activity
    {
        Toolbar toolbarTop;
        Toolbar menuBottom;
        Button btnCalculator;
        Button btnNotecards;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);

            btnCalculator = FindViewById<Button>(Resource.Id.btnCalculator);
            btnNotecards = FindViewById<Button>(Resource.Id.btnNotecards);

            btnCalculator.Click += BtnCalculator_Click;
            btnNotecards.Click += BtnNotecards_Click;

            //Set the toolbar for the home screen
            menuBottom = FindViewById<Toolbar>(Resource.Id.menu);
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

            toolbarTop = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbarTop);
            ActionBar.Title = "UWO Scholar Home";
            

        
        }

        private void BtnNotecards_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NotecardActivity));
        }

        private void BtnCalculator_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ScientificCalculator));
        }

        private void MenuItemClicked(object sender, System.EventArgs e)
        {

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}