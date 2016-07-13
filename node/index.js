const {measure} = require('./utils');
const proto = require('./proto');
const thrift = require('./thrift');

var buf = proto.serializeMetricSetup({
    id: 1,
    metricId: 2,
    entityTypes: 'Bug,UserStory,Feature'
});

console.log(buf, buf.length);
return;

const N = 1000;
const M = 100;
const metricSetups = [];

for (let i = 1; i <= N; i++) {
    metricSetups.push({
        id: i,
        metricId: 2 * i,
        entityTypes: Math.random() > 0.5 ? 'Bug' : 'Feature'
    });
}

var commands = [];

for (let i = 1; i <= N; i++) {
    const targets = [];

    for (let j = 1; j <= M; j++) {
        targets.push({
            id: j,
            entityType: Math.random() > 0.5 ? 'UserStory' : 'Epic'
        });
    }

    commands.push({
        accountId: i,
        metricSetup: metricSetups[i],
        targets: targets,
        eventId: (2 * i).toString(),
        commandId: (3 * i).toString()
    });
}

function measureProtoSerializeMetricSetup() {
    measure(() => {
        for (let i = 0; i < metricSetups.length; i++) {
            proto.serializeMetricSetup(metricSetups[i]);
        }

    }, 'proto.serializeMetricSetup()');
}

function measureThriftSerializeMetricSetup() {
    measure(() => {
        for (let i = 0; i < metricSetups.length; i++) {
            thrift.serializeMetricSetup(metricSetups[i]);
        }

    }, 'thrift.serializeMetricSetup()');
}

function measureProtoSerializeCalculateMetricCommandExtended() {
    measure(() => {
        for (let i = 0; i < commands.length; i++) {
            proto.serializeCalculateMetricCommandExtended(commands[i]);
        }
    }, 'proto.serializeCalculateMetricCommandExtended');
}

function measureThriftSerializeCalculateMetricCommandExtended() {
    measure(() => {
        for (let i = 0; i < commands.length; i++) {
            thrift.serializeCalculateMetricCommandExtended(commands[i]);
        }
    }, 'thrift.serializeCalculateMetricCommandExtended');
}

// measureThriftSerializeMetricSetup();
// measureProtoSerializeMetricSetup();
// measureThriftSerializeMetricSetup();
// measureProtoSerializeMetricSetup();

measureThriftSerializeCalculateMetricCommandExtended();
measureProtoSerializeCalculateMetricCommandExtended();
measureThriftSerializeCalculateMetricCommandExtended();
measureProtoSerializeCalculateMetricCommandExtended();
