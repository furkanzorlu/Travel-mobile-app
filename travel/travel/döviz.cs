using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace travel
{
    [Activity(Label = "döviz")]
    public class döviz : Activity
    {
        EditText edt;
        Button currencyButton;
        TextView textView1;
        TextView textView2;
        TextView textView3;
        TextView textView4;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.curre);
            edt = FindViewById<EditText>(Resource.Id.msgText);
            currencyButton = FindViewById<Button>(Resource.Id.currencyBtn);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView2 = FindViewById<TextView>(Resource.Id.textView2);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView4 = FindViewById<TextView>(Resource.Id.textView4);
            currencyButton.Click += CurrencyButton_Click;

        }
    

    private void CurrencyButton_Click(object sender, EventArgs e)
    {
        CurrencyConversion(1, "TRY", "USD");
    }

        private const string urlPattern = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/usd/try.json";
        private const string urlPatternn = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/eur/try.json";
        private const string urlPattern2 = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/sar/try.json";
        private const string urlPattern3 = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/jpy/try.json";

        public string CurrencyConversion(decimal amount, string fromCurrency, string toCurrency)
    {
        string url = string.Format(urlPattern, fromCurrency, toCurrency);
            string urll = string.Format(urlPatternn, fromCurrency, toCurrency);
            string urlll = string.Format(urlPattern2, fromCurrency, toCurrency);
            string urllll = string.Format(urlPattern3, fromCurrency, toCurrency);
            using (var wc = new WebClient())
        {
            var json = wc.DownloadString(url);
               var json2 = wc.DownloadString(urll);
                var json3 = wc.DownloadString(urlll);
                var json4 = wc.DownloadString(urllll);
                Newtonsoft.Json.Linq.JToken token = Newtonsoft.Json.Linq.JObject.Parse(json);
                Newtonsoft.Json.Linq.JToken token2 = Newtonsoft.Json.Linq.JObject.Parse(json2);
                Newtonsoft.Json.Linq.JToken token3 = Newtonsoft.Json.Linq.JObject.Parse(json3);
                Newtonsoft.Json.Linq.JToken token4 = Newtonsoft.Json.Linq.JObject.Parse(json4);
                double exchangeRate = (double)token.SelectToken("try");
                double exchangeRatee = (double)token2.SelectToken("try");
                double exchangeRateee = (double)token3.SelectToken("try");
                double exchangeRateeee = (double)token4.SelectToken("try");
                String text = edt.Text;
                double kmm = Double.Parse(text);
                double Output = kmm / exchangeRate;
                double Output2 = kmm / exchangeRatee;
                double Output3 = kmm / exchangeRateee;
                double Output4 = kmm / exchangeRateeee;
                // edt.Text = "1 TRY = " + Output + " USD";
                textView1.Text = edt.Text+"tl="+Output.ToString()+" usd";
                textView2.Text = edt.Text + "tl=" + Output2.ToString() + " euro";
                textView3.Text = edt.Text + "tl=" + Output3.ToString() + " riyal";
                textView4.Text = edt.Text + "tl=" + Output4.ToString() + " japon yeni";
                return edt.Text;
        }
    }
}}
    