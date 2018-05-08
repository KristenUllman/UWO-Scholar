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
    [Activity(Label = "Scientific Calculator")]
    public class ScientificCalculator : Activity
    {
        EditText txtValue1;
        EditText txtValue2;
        Button btnAdd;
        Button btnSubtract;
        Button btnMultiply;
        Button btnDivide;
        Button btnBack;
        Button btnLogOut;
        Toolbar menuBottom;
        Toolbar toolbarTop;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ScientificCalculator);

            txtValue1 = FindViewById<EditText>(Resource.Id.txtValue1);
            txtValue2 = FindViewById<EditText>(Resource.Id.txtValue2);
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnSubtract = FindViewById<Button>(Resource.Id.btnSubtract);
            btnMultiply = FindViewById<Button>(Resource.Id.btnMultiply);
            btnDivide = FindViewById<Button>(Resource.Id.btnDivide);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnLogOut = FindViewById<Button>(Resource.Id.btnLogOut);




            btnAdd.Click += BtnAdd_Click;
            btnSubtract.Click += BtnSubtract_Click;
            btnMultiply.Click += BtnMultiply_Click;
            btnDivide.Click += BtnDivide_Click;
            btnBack.Click += BtnBack_Click;
            btnLogOut.Click += BtnLogOut_Click;
            DisplayMenu();

        }

        private void DisplayMenu()
        {
            menuBottom = FindViewById<Toolbar>(Resource.Id.pageMenu);
            toolbarTop = FindViewById<Toolbar>(Resource.Id.toolbar);
            menuBottom.Title = "Calculator";
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
            ActionBar.Title = "Calculator";
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HomeActivity));
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                double Value1 = double.Parse(txtValue1.Text);
                double Value2 = double.Parse(txtValue2.Text);
                txtValue1.Text = (Value1 + Value2).ToString();
                txtValue2.Text = "";

            }
            catch
            {

            }
        }

        private void BtnSubtract_Click(object sender, System.EventArgs e)
        {
            try
            {
                double Value1 = double.Parse(txtValue1.Text);
                double Value2 = double.Parse(txtValue2.Text);
                txtValue1.Text = (Value1 - Value2).ToString();
                txtValue2.Text = "";

            }
            catch
            {

            }
        }
        private void BtnMultiply_Click(object sender, System.EventArgs e)
        {
            try
            {
                double Value1 = double.Parse(txtValue1.Text);
                double Value2 = double.Parse(txtValue2.Text);
                txtValue1.Text = (Value1 * Value2).ToString();
                txtValue2.Text = "";

            }
            catch
            {

            }
        }

        private void BtnDivide_Click(object sender, System.EventArgs e)
        {
            try
            {
                double Value1 = double.Parse(txtValue1.Text);
                double Value2 = double.Parse(txtValue2.Text);
                txtValue1.Text = (Value1 / Value2).ToString();
                txtValue2.Text = "";

            }
            catch
            {

            }
        }

    }
}