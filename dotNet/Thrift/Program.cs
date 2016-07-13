using System;
using System.Diagnostics;
using System.Linq;
using Messages;
using Thrift.Protocol;
using Thrift.Transport;

namespace TryThrift
{
	public class Program
	{
		private static void Main()
		{
			Run();
		}

		#region Size

		public static void Run()
		{
			Console.WriteLine("--== Thrift ==--");

			Run(nameof(TBinaryProtocol), Serialize(transport => new TBinaryProtocol(transport)));
			Run(nameof(TCompactProtocol), Serialize(transport => new TCompactProtocol(transport)));
			Run(nameof(TJSONProtocol), Serialize(transport => new TJSONProtocol(transport)));
		}

		private static void Run(string caption, Func<TAbstractBase, byte[]> serialize)
		{
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
				TargetIds = Enumerable.Range(1, 100).ToList()
			};

			var calculateMetricCommandExtended = new CalculateMetricCommandExtended
			{
				AccountId = 1,
				CommandId = "1234567890987654321",
				EventId = "98765432123456789",
				MetricSetup = metricSetup,
				Targets = Enumerable.Range(1, 100).Select(x => new Target { Id = x, EntityType = "UserStory" }).ToList()
			};

			var metricSetupData = serialize(metricSetup);
			var metricSetupChangedEventData = serialize(metricSetupChangedEvent);
			var calculateMetricCommandData = serialize(calculateMetricCommand);
			var calculateMetricCommandExtendedData = serialize(calculateMetricCommandExtended);

			Console.WriteLine(caption);
			Console.WriteLine($"  MetricSetup: {metricSetupData.Length} bytes");
			Console.WriteLine($"  MetricSetupChangedEvent: {metricSetupChangedEventData.Length} bytes");
			Console.WriteLine($"  CalculateMetricCommand: {calculateMetricCommandData.Length} bytes");
			Console.WriteLine($"  CalculateMetricCommandExtended: {calculateMetricCommandExtendedData.Length} bytes");
			Console.WriteLine();
		}

		private static Func<TAbstractBase, byte[]> Serialize(Func<TTransport, TProtocol> protocol)
		{
			return obj =>
			{
				var buffer = new TMemoryBuffer();
				obj.Write(protocol(buffer));
				return buffer.GetBuffer();
			};
		}

		#endregion
	}
}
