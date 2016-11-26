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
			CreateHourModel();
		}

		private void OnButtonClicked(object sender, EventArgs args)
		{
			
		}

		/// <summary>
		/// Generates color that describes the waiting time in the caffeteria queue
		/// </summary>
		/// <returns>The color for given waiting time.</returns>
		/// <param name="level">Level that describes the waiting time</param>
		private Color getColorForLevel(int level)
		{
			switch (level)
			{
				case 0:
					return Color.Green;
				case 1:
					return Color.Yellow;
				case 2:
					return Color.Red;
				default:
					return Color.Gray;
			}

		}

		/// <summary>
		/// Generates text description of the waiting time in the caffeteria queue
		/// </summary>
		/// <returns>The text description for given waiting time.</returns>
		/// <param name="level">Level that describes the waiting time</param>
		private String getDescriptionForLevel(int level)
		{
			switch (level)
			{
				case 0:
					return "Go there!";
				case 1:
					return "It's bearable...";
				case 2:
					return "Stay hungry.";
				default:
					return "What the heck?";
			}
		}

		/// <summary>
		/// Created rectangles that describes approx. waiting times in the queue
		/// </summary>
		private void CreateHourModel()
		{
			/// Get the key value pairs with predicted times
			Dictionary<String, int> queueTimes = new Dictionary<String, int>();
			queueTimes.Add("12 a.m.", 0);
			queueTimes.Add("13 a.m.", 1);
			queueTimes.Add("14 a.m.", 2);

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
					Text = time.Key,
					FontSize = 14,
					HorizontalOptions = LayoutOptions.Start,
					FontAttributes = FontAttributes.Bold
				};

				var descriptionLabel = new Label()
				{
					Text = getDescriptionForLevel(time.Value),
					FontSize = 14,
					HorizontalOptions = LayoutOptions.EndAndExpand
				};

				horizontalRow.Children.Add(timelLabel);
				horizontalRow.Children.Add(descriptionLabel);

				hours.Children.Add(horizontalRow);

				/// Then create button that represents the waiting color
				var button = new Button()
				{
					BackgroundColor = getColorForLevel(time.Value),
					BorderRadius = 0,
					HeightRequest = 70,
					WidthRequest = 300
				};

				button.Clicked += (sender, e) => { Navigation.PushAsync(new Detail()); };

				hours.Children.Add(button);
			}

			/// Set padding of the prediction rectangles
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
		}
	}
}
