var ProtoBuf = require('protobufjs');
var builder = ProtoBuf.loadProtoFile('./messages_proto3.proto');
var MetricSetup = builder.build('MetricSetup');
var Target = builder.build('Target');
var CalculateMetricCommand = builder.build('CalculateMetricCommandExtended');

var metricSetup = new MetricSetup({
    id: 1,
    metricId: 2,
    entityTypes: 'Bug,UserStory,Feature'
});

var buffer = metricSetup.toBuffer();

console.log(buffer, buffer.length);

var command = new CalculateMetricCommand({
    accountId: 1,
    metricSetup: metricSetup,
    targets: [
        new Target({id: 1, entityType: 'Bug'}),
        new Target({id: 2, entityType: 'Bug'})
    ],
    eventId: '1234567890',
    commandId: '0987654321'
});

buffer = command.toBuffer();

console.log(buffer, buffer.length);
