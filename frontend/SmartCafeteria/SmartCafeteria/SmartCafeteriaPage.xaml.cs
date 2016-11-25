using System.Collections.Generic;
using System.Diagnostics;
using Estimotes;
using Xamarin.Forms;

namespace SmartCafeteria
{
	public partial class SmartCafeteriaPage : ContentPage
	{

		private static int counter = 0;

		public static IList<BeaconRegion> Regions { get; } = new List<BeaconRegion> {
			new BeaconRegion("whites",  "05ba452866ec2fb22ebd41936cbdd108"),
			new BeaconRegion("bewhere", "9AE7B5FC-A17A-F932-EDDC-C77D41586AAB")
		};

		private static string b1 = "05ba452866ec2fb22ebd41936cbdd108";
		//private static string b2 = "9AE7B5FC-A17A-F932-EDDC-C77D41586AAB";

		public SmartCafeteriaPage()
		{
			InitializeComponent();

			test.Text = "Ahoj";

			initBeacons();
		}

		private async void initBeacons()
		{
			var status = await EstimoteManager.Instance.Initialize(); // optionally pass false to authorize foreground ranging only	
			if (status != BeaconInitStatus.Success)
			{
				// problem 
				test.Text = "Problem";
			}
			else {
				test.Text = "No problem";
			}
			EstimoteManager.Instance.Ranged += (sender, beacons) => { };
			//EstimoteManager.Instance.RegionStatusChanged += (sender, region) => { };

			//EstimoteManager.Instance.StartMonitoring(new BeaconRegion("Beacon Identifier", "9AE7B5FC-A17A-F932-EDDC-C77D41586AAB"));
			EstimoteManager.Instance.StartRanging(new BeaconRegion("Beacon", "9AE7B5FC-A17A-F932-EDDC-C77D41586AAB"));

			EstimoteManager.Instance.Ranged += OnBeaconsRanged;
		}


		async void OnBeaconsRanged(object sender, System.Collections.Generic.IEnumerable<IBeacon> e)
		{
			counter++;
			test.Text = counter + "";
			foreach (var beacon in e)
			{
				test.Text += "BeakonsAAA " + beacon.Major.ToString() + " " + beacon.Minor.ToString() + "|";

			}
		
		}

		async void OnBeaconRegionStatusChanged(object sender, BeaconRegionStatusChangedEventArgs args)
		{
			//Do your stuff when entered or removed
			//test.Text = "Beakon " + args.Region.Uuid;
			//args.Region.Identifier
		}	


	}
}
