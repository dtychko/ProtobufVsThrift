const {measure} = require('./utils');
const ProtoBuf = require('protobufjs');
const builder = measure(() => ProtoBuf.loadProtoFile('./messages.proto'), 'loadProtoFile');
const MetricSetup = measure(() => builder.build('MetricSetup'), 'build MetricSetup');
const Target = measure(() => builder.build('Target'), 'build Target');
const CalculateMetricCommandExtended = measure(() => builder.build('CalculateMetricCommandExtended'), 'build CalculateMetricCommandExtended');

module.exports = {
    serializeMetricSetup(data) {
        var metricSetup = new MetricSetup(data);
        return metricSetup.toBuffer();
    },

    serializeCalculateMetricCommandExtended({accountId, metricSetup, targets, eventId, commandId}) {
        var command = new CalculateMetricCommandExtended({
            accountId,
            metricSetup,
            targets: targets.map(x => new Target(x)),
            eventId,
            commandId
        });
    }
};
