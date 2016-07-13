using System;
using System.IO;
using System.Linq;
using Proto2.Messages;
using ProtoBuf;

namespace Proto2
{
	public class Program
	{
		private static void Main()
		{
			Run();
		}

		public static void Run()
		{
			Console.WriteLine("--== protobuf-net ==--");

			var metricSetup = new MetricSetup
			{
				Id = 1,
				MetricId = 2,
				EntityTypes = "Bug,UserStory,Feature"
			};

			var metricSetupChangedEvent = new MetricSetupChangedEvent
			{
				AccountId = 1,
				MetricSetup = metricSetup,
				Modification = Modification.UPDATED
			};

			var calculateMetricCommand = new CalculateMetricCommand
			{
				AccountId = 1,
				CommandId = "1234567890987654321",
				EventId = "98765432123456789",
				MetricSetup = metricSetup,
				TargetIds = Enumerable.Range(1, 100).ToArray()
			};

			var calculateMetricCommandExtended = new CalculateMetricCommandExtended
			{
				AccountId = 1,
				CommandId = "1234567890987654321",
				EventId = "98765432123456789",
				MetricSetup = metricSetup,
				Targets = Enumerable.Range(1, 100).Select(x => new Target { Id = x, EntityType = "UserStory" }).ToArray()
			};

			var metricSetupData = Serialize(metricSetup);
			var metricSetupChangedEventData = Serialize(metricSetupChangedEvent);
			var calculateMetricCommandData = Serialize(calculateMetricCommand);
			var calculateMetricCommandExtendedData = Serialize(calculateMetricCommandExtended);

			Console.WriteLine($"  MetricSetup: {metricSetupData.Length} bytes");
			Console.WriteLine($"  MetricSetupChangedEvent: {metricSetupChangedEventData.Length} bytes");
			Console.WriteLine($"  CalculateMetricCommand: {calculateMetricCommandData.Length} bytes");
			Console.WriteLine($"  CalculateMetricCommandExtended: {calculateMetricCommandExtendedData.Length} bytes");
			Console.WriteLine();
		}

		private static byte[] Serialize(object message)
		{
			using (var stream = new MemoryStream())
			{
				Serializer.Serialize(stream, message);
				return stream.ToArray();
			}
		}
	}
}
