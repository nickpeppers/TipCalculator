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
        TextView seekBarText;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.MainLayout);

			var button = FindViewById<Button> (Resource.Id.myButton);
			var billAmount = FindViewById<EditText> (Resource.Id.editText1);
			var numberOfGuests = FindViewById<EditText> (Resource.Id.editText2);
			var sliderBar = FindViewById<SeekBar> (Resource.Id.seekBar1);
			var tipAmount = FindViewById<TextView> (Resource.Id.TipAmount);
            var guestAmount = FindViewById<TextView>(Resource.Id.guestTotalText);
            seekBarText = FindViewById<TextView>(Resource.Id.SeekBarText);

            sliderBar.ProgressChanged += OnSeekBarChanged;

			button.Click += (sender, e) =>
			{
				double tipCost = (Convert.ToDouble(billAmount.Text) * ((double)sliderBar.Progress/100));
                tipAmount.Text = string.Format("{0:C2}", Math.Round(tipCost, 2)); 
                guestAmount.Text = string.Format("{0:C2}",(tipCost + Convert.ToDouble(billAmount.Text))/Convert.ToDouble(numberOfGuests.Text));
			};
		}

        protected void OnSeekBarChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            seekBarText.Text = e.Progress.ToString();
        }
	}
}


