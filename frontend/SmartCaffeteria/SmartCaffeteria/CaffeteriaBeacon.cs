using System;
using Estimotes;

namespace SmartCaffeteria
{
	public class CaffeteriaBeacon
	{
		public DateTime time;
		public IBeacon beacon;

		public CaffeteriaBeacon(DateTime time, IBeacon beacon)
		{
			this.time = time;
			this.beacon = beacon;
		}
	}
}
