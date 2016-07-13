using System;
using System.Linq;
using Proto.Messages;

namespace Proto
{
	public class Program
	{
		static void Main()
		{
			Run();
		}

		public static void Run()
		{
			Console.WriteLine("--== Google.ProtoBuffer ==--");

			var metricSetup = MetricSetup.CreateBuilder()
				.SetId(1)
				.SetMetricId(1)
				.SetEntityTypes("Bug,UserStory,Feature")
				.Build();

			var metricSetupChangedEvent = MetricSetupChangedEvent.CreateBuilder()
				.SetAccountId(1)
				.SetMetricSetup(metricSetup)
				.SetModification(Modification.UPDATED)
				.Build();

			var calculateMetricCommand = CalculateMetricCommand.CreateBuilder()
				.SetAccountId(1)
				.SetCommandId("1234567890987654321")
				.SetEventId("98765432123456789")
				.SetMetricSetup(metricSetup)
				.AddRangeTargetIds(Enumerable.Range(1, 100).ToList())
				.Build();

			var calculateMetricCommandExtended = CalculateMetricCommandExtended.CreateBuilder()
				.SetAccountId(1)
				.SetCommandId("1234567890987654321")
				.SetEventId("98765432123456789")
				.SetMetricSetup(metricSetup)
				.AddRangeTargets(
					Enumerable.Range(1, 100).Select(x => Target.CreateBuilder().SetId(x).SetEntityType("UserStory").Build()).ToList())
				.Build();

			var metricSetupData = metricSetup.ToByteArray();
			var metricSetupChangedEventData = metricSetupChangedEvent.ToByteArray();
			var calculateMetricCommandData = calculateMetricCommand.ToByteArray();
			var calculateMetricCommandExtendedData = calculateMetricCommandExtended.ToByteArray();

			Console.WriteLine($"  MetricSetup: {metricSetupData.Length} bytes");
			Console.WriteLine($"  MetricSetupChangedEvent: {metricSetupChangedEventData.Length} bytes");
			Console.WriteLine($"  CalculateMetricCommand: {calculateMetricCommandData.Length} bytes");
			Console.WriteLine($"  CalculateMetricCommandExtended: {calculateMetricCommandExtendedData.Length} bytes");
			Console.WriteLine();
		}
	}
}
