using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace travel
{
    [Activity(Label = "hesaplama")]
    public class hesaplama : Activity
    {
        
        EditText km;
        EditText litre;
        Button hesap;
        TextView textView1;
        Uri uri;
        Button map;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.hesaplama);
           
            km = FindViewById<EditText>(Resource.Id.km);
            litre = FindViewById<EditText>(Resource.Id.litre);
            hesap = FindViewById<Button>(Resource.Id.hesap);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            map = FindViewById<Button>(Resource.Id.map);
            hesap.Click += calculate;
            map.Click += click7;

            // Create your application here
        }

        private async void click7(object sender, EventArgs e)
        {
            try
            {
                uri = new Uri("https://www.opet.com.tr/guncel-akaryakit-fiyatlari");
                await Xamarin.Essentials.Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                Toast.MakeText(Android.App.Application.Context, "PLEASE ENTER A VALID URL", ToastLength.Short).Show();
            }
        }

        private void calculate(object sender, EventArgs e)
        {
            try
            {
                
                String textt = km.Text;
                String texttt = litre.Text;
                
                double fiyatt = Double.Parse(textt);
                double litree = Double.Parse(texttt);
                double total = fiyatt * litree ;
                textView1.Text = total.ToString() + "'tl değerinde benzin almanız gerekiyor";
               
            }
            catch
            {
                Toast.MakeText(Android.App.Application.Context, "boşlukları doldurunuz", ToastLength.Short).Show();
            }
            
         
        }
    }
}