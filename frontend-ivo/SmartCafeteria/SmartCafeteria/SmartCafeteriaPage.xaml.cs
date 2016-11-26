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
		//string resultBody = "nic";

		public SmartCafeteriaPage()
		{
			InitializeComponent();

			ahoj.Text = "Xamathon je super!!!";
			//Task task = GetResponseString(handler);

			ServerRequest request = new ServerRequest("http://mendelu.cz", "", Method.GET);
			request.run(handler);

		}
		/*
		async void ProcessRequest()
		{
			Task<string> task = GetResponseString();
			string result = task.Result;
			ahoj.Text = result;
		}*/
		/*
		async Task GetResponseString(Action<string> callback)
		{
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync("http://pisarovic.cz");
			var contents = await response.Content.ReadAsStringAsync();

			callback(contents);

			//return contents;
		}
		*/
		void handler(string content)
		{
			ahoj.Text = content;
		}
	}
}
