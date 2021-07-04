using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
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
   public class DbHelper : SQLiteOpenHelper
    {
        private static String Db_name = "edmt";
        private static int db_ver = 1;
        private static String Db_table = "task";
        private static String Db_column = "taskname";
        public DbHelper(Context context) : base(context, Db_name, null, db_ver)
        {
               
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            string query = $"CREATE TABLE {DbHelper.Db_table} (ID INTEGER PRIMARY KEY AUTOINCREMENT,{DbHelper.Db_column} TEXT NOT NULL);";
            db.ExecSQL(query);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            string query = $"DELETE TABLE IF EXISTS {Db_table}";
            db.ExecSQL(query);
            OnCreate(db);
        }
        public void ınsertnewtask(String task)
        {
            SQLiteDatabase db = this.WritableDatabase;
            ContentValues values = new ContentValues();
            values.Put(Db_column, task);
            db.InsertWithOnConflict(Db_table, null, values, Android.Database.Sqlite.Conflict.Replace);
            db.Close();
        }
        public void deletenewtask(String task)
        {
            SQLiteDatabase db = this.WritableDatabase;
            db.Delete(Db_table, Db_column + "= ?", new String[] { task });
            db.Close();
        }
        public List<string> gettasklist()
        {
            List<string> tasklist = new List<string>();
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor cursor = db.Query(Db_table, new String[] { Db_column }, null, null, null, null, null);
            while (cursor.MoveToNext())
            {
                int index = cursor.GetColumnIndex(Db_column);
                tasklist.Add(cursor.GetString(index));
            }return tasklist;
        }
    }
}