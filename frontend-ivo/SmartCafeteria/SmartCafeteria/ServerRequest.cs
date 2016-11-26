using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartCafeteria
{
	public class ServerRequest
	{
		private HttpClient httpClient;
		private string URL;
		private string body;
		private Method method;

		public ServerRequest(string URL, string body, Method method)
		{
			this.URL = URL;
			this.body = body;
			this.method = method;
		}

		public void Run(Action<string> callback)
		{
			GetResponseString(callback);
		}

		async Task GetResponseString(Action<string> callback)
		{
			httpClient = new HttpClient();

			var response = await SendRequest();
			var contents = await response.Content.ReadAsStringAsync();

			callback(contents);
		}

		private Task<HttpResponseMessage> SendRequest()
		{
			switch (method)
			{
				case Method.GET:
					return httpClient.GetAsync(URL);
				case Method.POST:
					var content = new StringContent(body, Encoding.UTF8, "application/json");
					return httpClient.PostAsync(URL, content);
				case Method.PUT:
					var content2 = new StringContent(body, Encoding.UTF8, "application/json");
					return httpClient.PutAsync(URL, content2);
				case Method.DELETE:
					return httpClient.DeleteAsync(URL);
			}
			return null;
		}
	}
}
