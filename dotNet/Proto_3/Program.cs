using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Proto_3.Messages;

namespace Proto_3
{
	class Program
	{
		static void Main(string[] args)
		{
			var metricSetup = new MetricSetup
			{
				Id = 1,
				MetricId = 2,
				EntityTypes = "Bug,UserStory"
			};

			var bytes = metricSetup.ToByteArray();

			var parsedMetricSetup = MetricSetup.Parser.ParseFrom(bytes);
		}
	}
}
