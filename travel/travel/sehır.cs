using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travel
{
    [Activity(Label = "sehir")]
    public class sehır : Activity
    {
        private ListView lv;
        private CustomAdapter adapter;
        private JavaList<Spacecraft> spacecrafts;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.sehrow);

            lv = FindViewById<ListView>(Resource.Id.lv);

            //BIND ADAPTER
            adapter = new CustomAdapter(this, GetSpacecrafts());

            lv.Adapter = adapter;

            lv.ItemClick += lv_ItemClick;

        }

        /*
         * LISTVIEW ITEM CLICK
         */
        void lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, spacecrafts[e.Position].Name, ToastLength.Short).Show();
        }

        /*
         * DATA SOURCE
         */
        private JavaList<Spacecraft> GetSpacecrafts()
        {
            spacecrafts = new JavaList<Spacecraft>();

            Spacecraft s;

            s = new Spacecraft("Düden Şelalesi", Resource.Drawable.dud);
            spacecrafts.Add(s);

            s = new Spacecraft("Anıtkabir", Resource.Drawable.an);
            spacecrafts.Add(s);

            s = new Spacecraft("Ayasofya Camii", Resource.Drawable.aya);
            spacecrafts.Add(s);

            s = new Spacecraft("Efes Antik Kenti", Resource.Drawable.efes);
            spacecrafts.Add(s);

            s = new Spacecraft("Peri Bacaları", Resource.Drawable.peri);
            spacecrafts.Add(s);

            s = new Spacecraft("Mevlana Müzesi", Resource.Drawable.mevla);
            spacecrafts.Add(s);

            s = new Spacecraft("Yerebatan Sarnıcı", Resource.Drawable.yere);
            spacecrafts.Add(s);

            s = new Spacecraft("Uzungöl", Resource.Drawable.uzun);
            spacecrafts.Add(s);

            s = new Spacecraft("Uludağ", Resource.Drawable.ulu);
            spacecrafts.Add(s);

            s = new Spacecraft("Manavgat Şelalesi", Resource.Drawable.mana);
            spacecrafts.Add(s);

            s = new Spacecraft("Pamukkale", Resource.Drawable.Pam);
            spacecrafts.Add(s);

            return spacecrafts;

        }
    }
}