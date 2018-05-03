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
    [Activity(Label = "NotecardActivity1")]
    public class NotecardActivity : Activity
    {
        Button btnCreateCard;
        Button btnEditCard;
        EditText txtTerm;
        EditText txtDefinition;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            btnCreateCard = FindViewById<Button>(Resource.Id.btnCreateCard);
            btnEditCard = FindViewById<Button>(Resource.Id.btnEditCard);
            txtTerm = FindViewById<EditText>(Resource.Id.txtTerm);
            txtDefinition = FindViewById<EditText>(Resource.Id.txtDefinition);
            btnCreateCard.Click += btnCreateCard_Click;
            btnEditCard.Click += btnEditCard_Click;

            // Create your application here
        }

        private void btnEditCard_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCreateCard_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NotecardActivity));
        }
    }
}