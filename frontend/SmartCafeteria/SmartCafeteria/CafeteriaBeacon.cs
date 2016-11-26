using System;
using Estimotes;

namespace SmartCafeteria
{
	public class CafeteriaBeacon
	{
		public DateTime time;
		public IBeacon beacon;

		public CafeteriaBeacon(DateTime time, IBeacon beacon)
		{
			this.time = time;
			this.beacon = beacon;
		}
	}
}
