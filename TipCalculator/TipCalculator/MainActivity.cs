using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipCalculator
{
	[Activity (Label = "TipCalculator")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MainLayout);

			var button = FindViewById<Button> (Resource.Id.myButton);
			var billAmount = FindViewById<EditText> (Resource.Id.editText1);
			var numberOfGuests = FindViewById<EditText> (Resource.Id.editText1);
			var sliderBar = FindViewById<SeekBar> (Resource.Id.seekBar1);
			var tipAmount = FindViewById<TextView> (Resource.Id.TipAmount);

			button.Click += (sender, e) =>
			{
				double tipCost = (Convert.ToDouble(billAmount.Text)  * sliderBar.Progress)/Convert.ToDouble(numberOfGuests.Text);
				tipAmount.Text = "$ " + Math.Round(tipCost, 2); 
			};
		}
	}
}


