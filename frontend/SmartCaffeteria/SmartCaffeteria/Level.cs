using System;
using Xamarin.Forms;

namespace SmartCaffeteria
{
	public class Level
	{
		private Level()
		{
		}

		/// <summary>
		/// Generates color that describes the waiting time in the caffeteria queue
		/// </summary>
		/// <returns>The color for given waiting time.</returns>
		/// <param name="level">Level that describes the waiting time</param>
		public static Color getColorForLevel(int level)
		{
			switch (level)
			{
				case 1:
					return Color.Green;
				case 2:
					return Color.Yellow;
				case 3:
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
		public static String getDescriptionForLevel(int level)
		{
			switch (level)
			{
				case 1:
					return "Go there!";
				case 2:
					return "It's bearable...";
				case 3:
					return "Stay hungry.";
				default:
					return "What the heck?";
			}
		}
	}
}
