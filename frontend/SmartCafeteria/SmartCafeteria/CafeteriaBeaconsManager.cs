﻿using System;
using System.Collections.Generic;
using Estimotes;

namespace SmartCafeteria
{
	public class CafeteriaBeaconsManager
	{
		Dictionary<int, CafeteriaBeacon> listOfBeacons = new Dictionary<int, CafeteriaBeacon>();


		public CafeteriaBeaconsManager()
		{
			initBeacons();
		}

		private async void initBeacons()
		{
			var status = await EstimoteManager.Instance.Initialize(); // optionally pass false to authorize foreground ranging only	
			if (status != BeaconInitStatus.Success)
			{
				// nerenguju
				//connectionStatus.Text = "Not connection";
			}
			else {
				// ranguju
				//connectionStatus.Text = "Connected";
			}
			EstimoteManager.Instance.Ranged += (sender, beacons) => { };
			EstimoteManager.Instance.StartRanging(new BeaconRegion("Beacon", "9AE7B5FC-A17A-F932-EDDC-C77D41586AAB"));
			EstimoteManager.Instance.Ranged += OnBeaconsRanged;
		}

		//Odesle info o beaconech. TADY JE VOLANI NA SERVER!
		private void sendBeaconInfo(int beaconID, IBeacon beacon)
		{

		}

		async void OnBeaconsRanged(object sender, System.Collections.Generic.IEnumerable<IBeacon> e)
		{
			foreach (var beacon in e)
			{
				int beaconID = beacon.Minor;
				if (beaconID != -1)
				{
					if (shouldSendBeaconInfo(beaconID, beacon))
					{
						sendBeaconInfo(beaconID, beacon);
					}
				}
			}
		}

		// rozhoduje jestli se ma odeslat info o beaconu
		private bool shouldSendBeaconInfo(int beaconID, IBeacon beacon)
		{

			if (listOfBeacons.ContainsKey(beaconID))
			{
				var diffInSeconds = (DateTime.Now - listOfBeacons[beaconID].time).TotalSeconds;
				if (diffInSeconds < 5)
				{
					listOfBeacons[beaconID].beacon = beacon;
					listOfBeacons[beaconID].time = DateTime.Now;
					return false;
				}
				listOfBeacons[beaconID].beacon = beacon;
				listOfBeacons[beaconID].time = DateTime.Now;
				return true;
			}
			else {
				listOfBeacons.Add(beaconID, new CafeteriaBeacon(DateTime.Now, beacon));
				return true;
			}
		}
	}
}
