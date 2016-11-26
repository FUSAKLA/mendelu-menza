﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SmartCaffeteria
{
	public partial class StatisticsDetail : ContentPage
	{
		public StatisticsDetail()
		{
			InitializeComponent();
			Sync syncInterface = new Sync(1);
			syncInterface.GetHistory("12_11_10",CreateHistoryModel);
		}

		/// <summary>
		/// Created rectangles that describes approx. waiting times in the queue
		/// </summary>
		private void CreateHistoryModel(HistoryObject[] result)
		{
			/// Get the key value pairs with predicted times
			HistoryObject[] historyWeeks = result;

			/// If there are any objects in the container, remove them.
			weeksInHistory.Children.Clear();

			/// For each pair generate time label and the square with appropriate color
			foreach (var week in historyWeeks)
			{
				/// Create row with time and description of the waiting
				var horizontalRow = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Start
				};

				var weekLabel = new Label()
				{
					Text = week.week_id.ToString() + " weeks back ",
					FontSize = 14,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand,
				};

				var colorBox = new StackLayout()
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					BackgroundColor = Level.getColorForLevel(week.level),
					WidthRequest = 60,
					HeightRequest = 60
				};

				var timeLabel = new Label()
				{
					Text = week.queue_time.ToString(),
					FontSize = 24,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					FontAttributes = FontAttributes.Bold
				};

				colorBox.Children.Add(timeLabel);

				horizontalRow.Children.Add(weekLabel);
				horizontalRow.Children.Add(colorBox);

				weeksInHistory.Children.Add(horizontalRow);

			}

			/// Set padding of the prediction rectangles
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
		}
	}
}