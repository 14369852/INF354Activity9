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
using System.Collections.Generic;

namespace ShoppingList.Resources.Model
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtDescription { get; set; }
    }
    public class ListViewAdapter : BaseAdapter
    {
       private Activity activity;
       private List<Item> itemList;
       public ListViewAdapter(Activity activity, List<Item> itemList)
       {
           this.activity = activity;
           this.itemList = itemList;
       }
       public override int Count
       {
            get { return itemList.Count; }
       }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return itemList[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
         View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
            view = activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = itemList[position].detail;
            return view;
        }
    }
}