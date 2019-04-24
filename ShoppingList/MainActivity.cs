using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using ShoppingList.Resources.Helper;
using ShoppingList.Resources.Model;
using System.Collections.Generic;
using Java.Lang;

namespace ShoppingList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView lstViewData;
        List<Item> listSource = new List<Item>();
        string[] items;
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            db = new Database();
            db.CreateDatabase();
            LoadData();
            Button button = FindViewById<Button>(Resource.Id.btnAddItem);
            lstViewData = FindViewById<ListView>(Resource.Id.listView1);
            button.Click += delegate {
                LayoutInflater layoutInflater = LayoutInflater.From(this);
                View view = layoutInflater.Inflate(Resource.Layout.InputItem, null);
                Android.Support.V7.App.AlertDialog.Builder alertbuilder = new Android.Support.V7.App.AlertDialog.Builder(this);
                alertbuilder.SetView(view);
                var txtAddItem = view.FindViewById<EditText>(Resource.Id.txtNewItem);
                alertbuilder.SetCancelable(false)
                .SetPositiveButton("Submit", delegate
                {
                    Item itm = new Item()
                    {
                        detail = txtAddItem.Text
                    };
                    db.insertIntoTable(itm);
                    LoadData();
                    Toast.MakeText(this, "Item added: " + txtAddItem.Text, ToastLength.Short).Show();
                })
                .SetNegativeButton("Cancel", delegate
                {
                    alertbuilder.Dispose();
                });
                Android.Support.V7.App.AlertDialog dialog = alertbuilder.Create();
                dialog.Show();
            };


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void LoadData()
        {
            try
            {
                listSource = db.selectTable();
                var adapter = new ListViewAdapter(this, listSource);
                lstViewData.Adapter = adapter;
            }
            catch
            {
                
            }
        }
    }
}