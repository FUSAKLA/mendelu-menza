using System;
using Newtonsoft.Json;

namespace SmartCafeteria
{
	public class Sync
	{
		const string baseURL = "http://mendelu-menza.azurewebsites.net/";
		public int userId;

		private Action<string, int[]> testCallback;
		private Action<IntervalObject[]> predictionCallback;
		private Action<HistoryObject[]> historyCallback;

		public Sync(int userId)
		{
			this.userId = userId;
		}

		/* --- TEST --- */
		public void SendTest(Action<string, int[]> callback)
		{
			testCallback = callback;
			ServerRequest request = new ServerRequest("https://raw.githubusercontent.com/FUSAKLA/mendelu-menza/master/test.json", "", Method.GET);
			request.Run(HandleTestResult);
		}

		public void HandleTestResult(string result)
		{
			TestObject obj = JsonConvert.DeserializeObject<TestObject>(result);
			testCallback(obj.status, obj.data);
		}

		/* --- SEND RECORD --- */
		public void SendIBeaconRecord(string UUID, string hitTime)
		{
			BeaconHitObject obj = new BeaconHitObject();
			obj.beacon_id = UUID;
			obj.user_id = userId;
			obj.hit_time = hitTime;
			var json = JsonConvert.SerializeObject(obj);
			ServerRequest request = new ServerRequest(baseURL + "beacon_hit", json, Method.PUT);
			request.Run(null);
		}

		/* --- CURRENT STATISTICS --- */
		public void GetPrediction(Action<IntervalObject[]> callback)
		{
			predictionCallback = callback;
			ServerRequest request = new ServerRequest(baseURL + "level/today", "", Method.GET);
			request.Run(HandlePredictionResult);
		}

		public void HandlePredictionResult(string result)
		{
			IntervalObjects obj = JsonConvert.DeserializeObject<IntervalObjects>(result);
			predictionCallback(obj.intervals);
		}

		/* --- HISTORY STATISTICS --- */
		public void GetHistory(string forTime, Action<HistoryObject[]> callback)
		{
			historyCallback = callback;
			ServerRequest request = new ServerRequest(baseURL + "level/history/"+forTime, "", Method.GET);
			request.Run(HandleHistoryResult);
		}

		public void HandleHistoryResult(string result)
		{
			HistoryObjects obj = JsonConvert.DeserializeObject<HistoryObjects>(result);
			historyCallback(obj.history);
		}

	}
}
