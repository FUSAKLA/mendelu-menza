using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using ModernHttpClient;
using System.Collections.Generic;

namespace SmartCafeteria
{
	public partial class SmartCafeteriaPage : ContentPage
	{
		public SmartCafeteriaPage()
		{
			InitializeComponent();

			ahoj.Text = "Xamathon je super!!!";

			Sync sync = new Sync(1);
			sync.sendTest((string obj, int[] data) => {
				ahoj.Text = obj;
				for (int i = 0; i < data.Length; i++)
				{
					ahoj.Text += data[i];
				}
			});
		}
	}
}
