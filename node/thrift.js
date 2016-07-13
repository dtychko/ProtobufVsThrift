var thrift = require('thrift');
var messages = require('./gen-nodejs/messages_types');
var MetricSetup = messages.MetricSetup;
var Target = messages.Target;
var CalculateMetricCommandExtended = messages.CalculateMetricCommandExtended;

function serialize(obj) {
    var transport = new thrift.TBufferedTransport();
    var protocol = new thrift.TBinaryProtocol(transport);

    obj.write(protocol);

    return Buffer.concat(transport.outBuffers);
}

module.exports = {
    serializeMetricSetup(data) {
        var metricSetup = new MetricSetup(data);
        return serialize(metricSetup);
    },

    serializeCalculateMetricCommandExtended({accountId, metricSetup, targets, eventId, commandId}) {
        var command = new CalculateMetricCommandExtended({
            accountId,
            metricSetup: new MetricSetup(metricSetup),
            targets: targets.map(x => new Target(x)),
            eventId,
            commandId
        });
        return serialize(command);
    }
};
