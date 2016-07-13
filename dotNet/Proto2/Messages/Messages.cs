using ProtoBuf;

namespace Proto2.Messages
{
	[ProtoContract]
	public class MetricSetup
	{
		[ProtoMember(1, IsRequired = true)]
		public int Id { get; set; }

		[ProtoMember(2, IsRequired = true)]
		public int MetricId { get; set; }

		[ProtoMember(3, IsRequired = true)]
		public string EntityTypes { get; set; }
	}

	public enum Modification
	{
		NONE = 0,
		ADDED = 1,
		UPDATED = 2,
		DELETED = 3,
	}

	[ProtoContract]
	public class MetricSetupChangedEvent
	{
		[ProtoMember(1, IsRequired = true)]
		public MetricSetup MetricSetup { get; set; }

		[ProtoMember(2, IsRequired = true)]
		public Modification Modification { get; set; }

		[ProtoMember(3, IsRequired = true)]
		public int AccountId { get; set; }
	}

	[ProtoContract]
	public class CalculateMetricCommand
	{
		[ProtoMember(1, IsRequired = true)]
		public int AccountId { get; set; }

		[ProtoMember(2, IsRequired = true)]
		public MetricSetup MetricSetup { get; set; }

		[ProtoMember(3, IsRequired = true)]
		public int[] TargetIds { get; set; }

		[ProtoMember(4, IsRequired = true)]
		public string EventId { get; set; }

		[ProtoMember(5, IsRequired = true)]
		public string CommandId { get; set; }
	}

	[ProtoContract]
	public class Target
	{
		[ProtoMember(1, IsRequired = true)]
		public int Id { get; set; }

		[ProtoMember(2, IsRequired = true)]
		public string EntityType { get; set; }
	}

	[ProtoContract]
	public class CalculateMetricCommandExtended
	{
		[ProtoMember(1, IsRequired = true)]
		public int AccountId { get; set; }

		[ProtoMember(2, IsRequired = true)]
		public MetricSetup MetricSetup { get; set; }

		[ProtoMember(3, IsRequired = true)]
		public Target[] Targets { get; set; }

		[ProtoMember(4, IsRequired = true)]
		public string EventId { get; set; }

		[ProtoMember(5, IsRequired = true)]
		public string CommandId { get; set; }
	}
}
