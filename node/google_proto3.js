var proto = require('./messages_proto3_pb');
var MetricSetup = proto.MetricSetup;
var Target = proto.Target;
var CalculateMetricCommand = proto.CalculateMetricCommandExtended;

module.exports = {
    serializeMetricSetup({id, metricId, entityTypes}) {
        var metricSetup = new MetricSetup();
        metricSetup.setId(id);
        metricSetup.setMetricid(metricId);
        metricSetup.setEntitytypes(entityTypes);
        return new Buffer(metricSetup.serializeBinary().buffer);
    },

    serializeCalculateMetricCommandExtended({accountId, metricSetup, targets, eventId, commandId}) {
        var targetsList = [];

        for (var i = 0; i < targets.length; i++) {
            var target = new Target();
            target.setId(targets[i].id);
            target.setEntitytype(targets[i].entityType);
            targetsList.push(target);
        }

        var mSetup = new MetricSetup();
        mSetup.setId(metricSetup.id);
        mSetup.setMetricid(metricSetup.metricId);
        mSetup.setEntitytypes(metricSetup.entityTypes);

        var command = new CalculateMetricCommand();
        command.setAccountid(accountId);
        command.setMetricsetup(mSetup);
        command.setTargetsList(targetsList);
        command.setEventid(eventId);
        command.setCommandid(commandId);
        return new Buffer(command.serializeBinary().buffer);
    },

    deserializeCalculateMetricCommandExtended(buffer) {
        return CalculateMetricCommand.deserializeBinary(new Uint8Array(buffer));
    }
};
