﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Estimotes;
using Xamarin.Forms;

namespace SmartCafeteria
{
	public partial class SmartCafeteriaPage : ContentPage
	{


		Dictionary<int, CafeteriaBeacon> listOfBeacons = new Dictionary<int, CafeteriaBeacon>();

		private int counter = 0;

		private int rangedCounter = 0;

		CafeteriaBeaconsManager manager;

		public SmartCafeteriaPage()
		{
			InitializeComponent();
			manager = new CafeteriaBeaconsManager();

			//initBeacons();

		}

		/*
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

			if (beaconID == 1)
			{
				beacon1.Text = "(" + counter + ")" + "Beacon 1 Send";
				counter++;
			}

			if (beaconID == 2)
			{
				beacon2.Text = "(" + counter + ")" + "Beacon 2 Send";
				counter++;
			}

		
		}

		async void OnBeaconsRanged(object sender, System.Collections.Generic.IEnumerable<IBeacon> e)
		{
			connectionStatus.Text = rangedCounter + " ranged";
			rangedCounter++;

			bool beaconOneFound = false;
			bool beaconTwoFound = false;

			foreach (var beacon in e)
			{
				int beaconID = beacon.Minor;
				//int beaconID = beaconFound(beacon);
				if (beaconID != -1)
				{
					if (shouldSendBeaconInfo(beaconID, beacon))
					{
						sendBeaconInfo(beaconID, beacon);
					}
					if (beaconID == 1)
					{
						beaconOneFound = true;
					}

					if (beaconID == 2)
					{
						beaconTwoFound = true;
					}

				}
				//beaconFound(beacon);
			}
			if (!beaconOneFound)
			{
				beacon1.Text = "Not detected";
			}
			if (!beaconTwoFound)
			{
				beacon2.Text = "Not detected";
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
		*/
	}
}
