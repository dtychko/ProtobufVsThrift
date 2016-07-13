namespace * Messages

struct MetricSetup
{
	1: i32 id,
	2: i32 metricId,
	3: string entityTypes
}

enum Modification
{
	NONE = 0,
	ADDED = 1,
	UPDATED = 2,
	DELETED = 3
}

struct MetricSetupChangedEvent
{
	1: MetricSetup MetricSetup,
	2: Modification Modification = Modification.NONE,
	3: i32 AccountId
}

struct CalculateMetricCommand
{
	1: i32 AccountId,
	2: MetricSetup MetricSetup,
	3: string EventId,
	4: string CommandId,
	5: list<i32> TargetIds
}

struct Target
{
	1: i32 id,
	2: string entityType
}

struct CalculateMetricCommandExtended
{
	1: i32 accountId,
	2: MetricSetup metricSetup,
	3: string eventId,
	4: string commandId,
	5: list<Target> targets
}
