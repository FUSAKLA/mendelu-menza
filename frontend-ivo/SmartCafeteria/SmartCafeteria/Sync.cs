using System;
using Newtonsoft.Json;

namespace SmartCafeteria
{
	public class Sync
	{
		const string baseURL = "http://pisarovic.cz/";
		public int userId;

		private Action<string, int[]> testCallback;

		public Sync(int userId)
		{
			this.userId = userId;
		}

		public void sendTest(Action<string, int[]> callback)
		{
			testCallback = callback;
			ServerRequest request = new ServerRequest("https://raw.githubusercontent.com/FUSAKLA/mendelu-menza/master/test.json", "", Method.GET);
			request.Run(HandleTestRequest);
		}

		public void HandleTestRequest(string result)
		{
			TestObject obj = JsonConvert.DeserializeObject<TestObject>(result);
			testCallback(obj.status, obj.data);
		}

		public void sendIBeaconRecord(string UUID, Action<string> calllback)
		{
			ServerRequest request = new ServerRequest(baseURL, "", Method.GET);
			request.Run(calllback);
		}
	}
}
