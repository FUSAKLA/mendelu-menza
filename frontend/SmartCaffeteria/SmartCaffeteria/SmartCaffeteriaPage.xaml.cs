using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SmartCaffeteria
{
	public partial class SmartCaffeteriaPage : ContentPage
	{

		public SmartCaffeteriaPage()
		{
			InitializeComponent();
			Sync syncInterface = new Sync(1);
			syncInterface.GetPrediction(CreateHourModel);
			CaffeteriaBeaconsManager manager = new CaffeteriaBeaconsManager();
		}

		/// <summary>
		/// Created rectangles that describes approx. waiting times in the queue
		/// </summary>
		private void CreateHourModel(IntervalObject[] result)
		{
			/// Get the key value pairs with predicted times
			             
			IntervalObject[] queueTimes = result;

			/// If there are any objects in the container, remove them.
			hours.Children.Clear();

			/// For each pair generate time label and the square with appropriate color
			foreach (var time in queueTimes)
			{

				/// Create row with time and description of the waiting
				var horizontalRow = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.FillAndExpand
				};

				var timelLabel = new Label()
				{
					Text = time.start_time,
					FontSize = 14,
					HorizontalOptions = LayoutOptions.Start,
					FontAttributes = FontAttributes.Bold
				};

				var descriptionLabel = new Label()
				{
					Text = Level.getDescriptionForLevel(time.level),
					FontSize = 14,
					HorizontalOptions = LayoutOptions.EndAndExpand
				};

				horizontalRow.Children.Add(timelLabel);
				horizontalRow.Children.Add(descriptionLabel);

				hours.Children.Add(horizontalRow);

				/// Then create button that represents the waiting color
				var button = new Button()
				{
					BackgroundColor = Level.getColorForLevel(time.level),
					BorderRadius = 0,
					HeightRequest = 70,
					WidthRequest = 300
				};

				button.Clicked += (sender, e) => { Navigation.PushAsync(new StatisticsDetail(time.start_time.Replace(":","-"))); };

				hours.Children.Add(button);
			}

			/// Set padding of the prediction rectangles
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
		}
	}
}
