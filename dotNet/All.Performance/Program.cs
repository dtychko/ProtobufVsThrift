using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Google.Protobuf;
using Messages;
using ProtoBuf;
using Thrift.Transport;
using MetricSetup = Messages.MetricSetup;

namespace All.Performance
{
	internal class Program
	{
		private static void Main()
		{
			const int n = 10000;
			const int m = 100;

			var metricSetups = new List<MetricSetupData>();
			
			for (var i = 0; i < n; i++)
			{
				metricSetups.Add(new MetricSetupData
				{
					Id = i,
					MetricId = 2 * i,
					EntityTypes = "Bug"
				});
			}

			var commands = new List<CalculateMetricCommandData>();

			for (var i = 0; i < n; i++)
			{
				commands.Add(new CalculateMetricCommandData
				{
					AccountId = i,
					CommandId = (2 * i).ToString(),
					EventId = (3 * i).ToString(),
					MetricSetup = metricSetups[i],
					Targets = Enumerable.Range(1, m).Select(j => new TargetData {Id = j, EntityType = "Bug"}).ToArray()
				});
			}

			Thrift.SerializeMetricSetup(metricSetups[0]);
			Thrift.DeserializeCalculateMetricCommand(Thrift.SerializeCalculateMetricCommand(commands[0]));
			Proto.SerializeMetricSetup(metricSetups[0]);
			Proto.DeserializeCalculateMetricCommand(Proto.SerializeCalculateMetricCommand(commands[0]));
			Proto2.SerializeMetricSetup(metricSetups[0]);
			Proto2.DeserializeCalculateMetricCommand(Proto2.SerializeCalculateMetricCommand(commands[0]));
			Proto3.SerializeMetricSetup(metricSetups[0]);
			Proto3.DeserializeCalculateMetricCommand(Proto3.SerializeCalculateMetricCommand(commands[0]));

			Measure(() =>
			{
				foreach (var data in metricSetups)
				{
					Thrift.SerializeMetricSetup(data);
				}
			}, " Thrift >> MetricSetup");
			Measure(() =>
			{
				foreach (var data in metricSetups)
				{
					Proto.SerializeMetricSetup(data);
				}
			}, " Proto >> MetricSetup");
			Measure(() =>
			{
				foreach (var data in metricSetups)
				{
					Proto2.SerializeMetricSetup(data);
				}
			}, " Proto2 >> MetricSetup");
			Measure(() =>
			{
				foreach (var data in metricSetups)
				{
					Proto3.SerializeMetricSetup(data);
				}
			}, " Proto v3 >> MetricSetup");

			Measure(() =>
			{
				foreach (var data in commands)
				{
					Thrift.SerializeCalculateMetricCommand(data);
				}
			}, " Thrift >> Serialize CalculateMetricCommand");
			var dataPool = commands.Select(Thrift.SerializeCalculateMetricCommand).ToList();
			Measure(() =>
			{
				foreach (var data in dataPool)
				{
					Thrift.DeserializeCalculateMetricCommand(data);
				}
			}, " Thrift >> Deserialize CalculateMetricCommand");

			Measure(() =>
			{
				foreach (var data in commands)
				{
					Proto.SerializeCalculateMetricCommand(data);
				}
			}, " Proto >> Serialize CalculateMetricCommand");
			dataPool = commands.Select(Proto.SerializeCalculateMetricCommand).ToList();
			Measure(() =>
			{
				foreach (var data in dataPool)
				{
					Proto.DeserializeCalculateMetricCommand(data);
				}
			}, " Proto >> Deserialize CalculateMetricCommand");

			Measure(() =>
			{
				foreach (var data in commands)
				{
					Proto2.SerializeCalculateMetricCommand(data);
				}
			}, " Proto2 >> Serialize CalculateMetricCommand");
			dataPool = commands.Select(Proto2.SerializeCalculateMetricCommand).ToList();
			Measure(() =>
			{
				foreach (var data in dataPool)
				{
					Proto2.DeserializeCalculateMetricCommand(data);
				}
			}, " Proto2 >> Deserialize CalculateMetricCommand");

			Measure(() =>
			{
				foreach (var data in commands)
				{
					Proto3.SerializeCalculateMetricCommand(data);
				}
			}, " Proto v3 >> Serialize CalculateMetricCommand");
			dataPool = commands.Select(Proto3.SerializeCalculateMetricCommand).ToList();
			Measure(() =>
			{
				foreach (var data in dataPool)
				{
					Proto3.DeserializeCalculateMetricCommand(data);
				}
			}, " Proto v3 >> Deserialize CalculateMetricCommand");
		}

		private static void Measure(Action action, string message, int iterationCount = 10)
		{
			var elapsed = 0L;

			for (var i = 0; i < iterationCount; i++)
			{
				GC.Collect();
				var stopwatch = Stopwatch.StartNew();
				action();
				stopwatch.Stop();
				elapsed += stopwatch.ElapsedMilliseconds;
			}
			Console.WriteLine($"{message} {elapsed / iterationCount} ms");
		}

		private static class Thrift
		{
			public static byte[] SerializeMetricSetup(MetricSetupData data)
			{
				var metricSetup = new MetricSetup
				{
					Id = data.Id,
					MetricId = data.MetricId,
					EntityTypes = data.EntityTypes
				};

				return TMemoryBuffer.Serialize(metricSetup);
			}

			public static byte[] SerializeCalculateMetricCommand(CalculateMetricCommandData data)
			{
				var command = new CalculateMetricCommandExtended
				{
					AccountId = data.AccountId,
					MetricSetup =
						new MetricSetup
						{
							Id = data.MetricSetup.Id,
							MetricId = data.MetricSetup.MetricId,
							EntityTypes = data.MetricSetup.EntityTypes
						},
					CommandId = data.CommandId,
					EventId = data.EventId,
					Targets = data.Targets.Select(t =>
						new Target
						{
							Id = t.Id,
							EntityType = t.EntityType
						}).ToList()
				};

				return TMemoryBuffer.Serialize(command);
			}

			public static CalculateMetricCommandExtended DeserializeCalculateMetricCommand(byte[] data)
			{
				return TMemoryBuffer.DeSerialize<CalculateMetricCommandExtended>(data);
			}
		}

		private static class Proto
		{
			public static byte[] SerializeMetricSetup(MetricSetupData data)
			{
				var metricSetup = global::Proto.Messages.MetricSetup.CreateBuilder()
					.SetId(data.Id)
					.SetMetricId(data.MetricId)
					.SetEntityTypes(data.EntityTypes)
					.Build();

				return metricSetup.ToByteArray();
			}

			public static byte[] SerializeCalculateMetricCommand(CalculateMetricCommandData data)
			{
				var command = global::Proto.Messages.CalculateMetricCommandExtended.CreateBuilder()
					.SetAccountId(data.AccountId)
					.SetMetricSetup(global::Proto.Messages.MetricSetup.CreateBuilder()
						.SetId(data.MetricSetup.Id)
						.SetMetricId(data.MetricSetup.MetricId)
						.SetEntityTypes(data.MetricSetup.EntityTypes)
						.Build())
					.SetCommandId(data.CommandId)
					.SetEventId(data.EventId)
					.AddRangeTargets(data.Targets.Select(t => global::Proto.Messages.Target.CreateBuilder()
						.SetId(t.Id)
						.SetEntityType(t.EntityType)
						.Build()))
					.Build();

				return command.ToByteArray();
			}

			public static global::Proto.Messages.CalculateMetricCommandExtended DeserializeCalculateMetricCommand(byte[] data)
			{
				return global::Proto.Messages.CalculateMetricCommandExtended.ParseFrom(data);
			}
		}

		private static class Proto2
		{
			public static byte[] SerializeMetricSetup(MetricSetupData data)
			{
				using (var stream = new MemoryStream())
				{
					var metricSetup = new global::Proto2.Messages.MetricSetup
					{
						Id = data.Id,
						MetricId = data.MetricId,
						EntityTypes = data.EntityTypes
					};

					Serializer.Serialize(stream, metricSetup);

					return stream.ToArray();
				}
			}

			public static byte[] SerializeCalculateMetricCommand(CalculateMetricCommandData data)
			{
				using (var stream = new MemoryStream())
				{
					var command = new global::Proto2.Messages.CalculateMetricCommandExtended
					{
						AccountId = data.AccountId,
						MetricSetup =
							new global::Proto2.Messages.MetricSetup
							{
								Id = data.MetricSetup.Id,
								MetricId = data.MetricSetup.MetricId,
								EntityTypes = data.MetricSetup.EntityTypes
							},
						CommandId = data.CommandId,
						EventId = data.EventId,
						Targets = data.Targets.Select(t =>
							new global::Proto2.Messages.Target
							{
								Id = t.Id,
								EntityType = t.EntityType
							}).ToArray()
					};

					Serializer.Serialize(stream, command);

					return stream.ToArray();
				}
			}

			public static global::Proto2.Messages.CalculateMetricCommandExtended DeserializeCalculateMetricCommand(byte[] data)
			{
				using (var stream = new MemoryStream(data))
				{
					return Serializer.Deserialize<global::Proto2.Messages.CalculateMetricCommandExtended>(stream);
				}
			}
		}

		private static class Proto3
		{
			public static byte[] SerializeMetricSetup(MetricSetupData data)
			{
				var metricSetup = new Proto_3.Messages.MetricSetup
				{
					Id = data.Id,
					MetricId = data.MetricId,
					EntityTypes = data.EntityTypes
				};

				return metricSetup.ToByteArray();
			}

			public static byte[] SerializeCalculateMetricCommand(CalculateMetricCommandData data)
			{
				var command = new Proto_3.Messages.CalculateMetricCommandExtended
				{
					AccountId = data.AccountId,
					MetricSetup =
						new Proto_3.Messages.MetricSetup
						{
							Id = data.MetricSetup.Id,
							MetricId = data.MetricSetup.MetricId,
							EntityTypes = data.MetricSetup.EntityTypes
						},
					CommandId = data.CommandId,
					EventId = data.EventId
				};

				command.Targets.Add(data.Targets.Select(t =>
					new Proto_3.Messages.Target
					{
						Id = t.Id,
						EntityType = t.EntityType
					}));

				return command.ToByteArray();
			}

			public static Proto_3.Messages.CalculateMetricCommandExtended DeserializeCalculateMetricCommand(byte[] data)
			{
				return Proto_3.Messages.CalculateMetricCommandExtended.Parser.ParseFrom(data);
			}
		}

		private class MetricSetupData
		{
			public string EntityTypes;
			public int Id;
			public int MetricId;
		}

		private class TargetData
		{
			public string EntityType;
			public int Id;
		}

		private class CalculateMetricCommandData
		{
			public int AccountId;
			public string CommandId;
			public string EventId;
			public MetricSetupData MetricSetup;
			public TargetData[] Targets;
		}
	}
}
