using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using travel.helper;

namespace travel
{
    [Activity(Label = "Notlarım" )]
    public class notlar : AppCompatActivity
    {
        EditText task;
        DbHelper dbHelper;
        customadapter adapter;
        ListView lsttask;
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.men,menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Resource.Id.action_add:
                    task = new EditText(this);
                    Android.Support.V7.App.AlertDialog dialog = new Android.Support.V7.App.AlertDialog.Builder(this).
                        SetTitle("Yapılacaklar")
                        .SetMessage("Ne eklemek istersiniz?")
                        .SetView(task)
                        .SetPositiveButton("Ekle", Okaction)
                        .SetNegativeButton("İptal Et", Cancelaction)
                        .Create();
                    dialog.Show();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void Cancelaction(object sender, DialogClickEventArgs e)
        {
            
        }

        private void Okaction(object sender, DialogClickEventArgs e)
        {
            string task2 = task.Text;
            dbHelper.ınsertnewtask(task2);
            LoadTaskList();
        }

        public void LoadTaskList()
        {
            List<string> tasklist = dbHelper.gettasklist();
            adapter = new customadapter(dbHelper,this,tasklist);
            lsttask.Adapter = adapter;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.notlar);
            dbHelper = new DbHelper(this);
            lsttask = FindViewById<ListView>(Resource.Id.list);
            // Create your application here
            LoadTaskList();
        }
    }
}