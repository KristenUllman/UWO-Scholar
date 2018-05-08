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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.StudyFeature);
            txtTerm = FindViewById<EditText>(Resource.Id.txtTerm);
            txtDefinition = FindViewById<EditText>(Resource.Id.txtDefinition);
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnLogout = FindViewById<Button>(Resource.Id.btnLogOut);
            btnNextCard = FindViewById<Button>(Resource.Id.btnNextCard);
            btnShowDefinition = FindViewById<Button>(Resource.Id.btnShowDefinition);

            btnLogout.Click += BtnLogout_Click;
            btnHome.Click += BtnHome_Click;
            btnNextCard.Click += BtnNextCard_Click;
            btnShowDefinition.Click += BtnShowDefinition_Click;
        }
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Intent backActivity = new Intent(this, typeof(UWOScholarAndroid.MainActivity));
            StartActivity(backActivity);
        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            Intent backActivity = new Intent(this, typeof(UWOScholarAndroid.HomeActivity));
            StartActivity(backActivity);
        }
        private void BtnNextCard_Click(object sender, EventArgs e)
        {
            txtTerm.Text = "Data Type";
            txtTerm.Text = "Big Data";
           
        }
        private void BtnShowDefinition_Click(object sender, EventArgs e)
        {
            txtDefinition.Text = "a particular kind of data item, as defined by the values it can take, the programming language used, or the operations that can be performed on it.";
            txtDefinition.Text = "extremely large data sets that may be analyzed computationally to reveal patterns, trends, and associations, especially relating to human behavior and interactions.";

    }
}