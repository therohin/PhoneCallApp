﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace PhoneCallApp
{
    [Activity(Label = "PhoneCallApp", MainLauncher = true, Icon ="@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText phoneNumberInput;
        Button callButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            phoneNumberInput = FindViewById<EditText>(Resource.Id.PhoneNumber);
            callButton = FindViewById<Button>(Resource.Id.CallButton);
                

            callButton.Click += CallButton_Click;
        }
        
        private void CallButton_Click(object sender, System.EventArgs e)
        {
            var phoneNumber = phoneNumberInput.Text;
            if(!string.IsNullOrWhiteSpace(phoneNumber))
            {
                var callDialog = new AlertDialog.Builder(this);
                callDialog.SetMessage("Do you want to call " + phoneNumber + "?");
                //Set Call and Cancel Button for the call dialog
                callDialog.SetNeutralButton("Call", delegate {
                    // Create intent to dial phone
                    var callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumber));
                    StartActivity(callIntent);
                });
                callDialog.SetNegativeButton("Cancel", delegate { });
                //Show dialog box
                callDialog.Show();

            }
            else
            {
                var toast = Toast.MakeText(this, "Please provide number", new ToastLength());
                toast.Show();
            }
           
        }
    }
}

