using System;
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


namespace UWOScholarAndroid
{
    [Activity(Label = "Register")]
    public class RegisterActivity : Activity
    {
        EditText txtEmail;
        EditText txtUsername;
        EditText txtPassword;
        EditText txtConfirmPassword;
        Button btnCreateAcc;
        Button btnAlreadyUser;
        Toolbar hometoolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            btnCreateAcc = FindViewById<Button>(Resource.Id.btnCreateAcc);
            btnAlreadyUser = FindViewById<Button>(Resource.Id.btnAlreadyUser);
            hometoolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetActionBar(hometoolbar);
            ActionBar.Title = "Register";

            btnCreateAcc.Click += BtnCreateAcc_Click;
            btnAlreadyUser.Click += BtnAlreadyUser_Click;
        }

        private void BtnCreateAcc_Click(object sender, System.EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<LoginTable>();
                LoginTable tbl = new LoginTable();
                tbl.email = txtEmail.Text;
                tbl.username = txtUsername.Text;
                tbl.password = txtPassword.Text;
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    db.Insert(tbl);
                    Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
                    Intent nextActivity = new Intent(this, typeof(HomeActivity));
                    StartActivity(nextActivity);
                }
                else
                {
                    Toast.MakeText(this, "Passwords do not match", ToastLength.Short).Show();
                }
                
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
            
        }
        private void BtnAlreadyUser_Click(object sender, System.EventArgs e)
        {
            Intent backActivity = new Intent(this, typeof(MainActivity));
            StartActivity(backActivity);
        }
    }
}