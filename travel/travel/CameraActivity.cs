using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Java.IO;
using Android.Graphics;
using Android.Content.PM;
using Uri = Android.Net.Uri;
using System.Collections.Generic;
using System;

namespace travel
{
    [Activity(Label = "CameraActivity")]
    public class CameraActivity : Activity
    {
        int count = 1;
        ImageView ImageVieww;
        ImageView ImageView2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Camera);
            var btncamera = FindViewById<Button>(Resource.Id.myButton);
            ImageVieww = FindViewById<ImageView>(Resource.Id.imageView1);
            
            btncamera.Click += Btn_Click;
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            
            ImageVieww.SetImageBitmap(bitmap);
            
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Intent ıntent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(ıntent, 0);
        }
    }
}