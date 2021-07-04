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

namespace travel.helper
{
    public class customadapter : BaseAdapter
    {
        private DbHelper DbHelper;
        private notlar notlar2;
        private List<String> taskList;

        public customadapter(DbHelper dbHelper, notlar notlar2, List<string> taskList)
        {
            DbHelper = dbHelper;
            this.notlar2 = notlar2;
            this.taskList = taskList;
        }

        public override int Count
        {
            get
            {
                return taskList.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater ınflater = (LayoutInflater)notlar2.GetSystemService(Context.LayoutInflaterService);
            View view = ınflater.Inflate(Resource.Layout.row, null);
            TextView txt = view.FindViewById<TextView>(Resource.Id.task);
            Button delete = view.FindViewById<Button>(Resource.Id.delete);
            txt.Text = taskList[position];
            delete.Click += delegate
            {
                string task = taskList[position];
                DbHelper.deletenewtask(task);
                notlar2.LoadTaskList();
            };
            return view;
        }
    }
}