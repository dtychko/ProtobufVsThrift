const {measure} = require('./utils');
const proto = require('./proto');
const thrift = require('./thrift');
const proto3 = require('./google_proto3');

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
        metricSetup: metricSetups[i - 1],
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
    }, 'proto >> serialize CalculateMetricCommandExtended');
}

function measureProtoDeserializeCalculateMetricCommandExtended() {
    var buffers = commands.map(x => proto.serializeCalculateMetricCommandExtended(x));

    measure(() => {
        for (let i = 0; i < buffers.length; i++) {
            proto.deserializeCalculateMetricCommandExtended(buffers[i]);
        }
    }, 'proto >> deserialize CalculateMetricCommandExtended');
}

function measureThriftSerializeCalculateMetricCommandExtended() {
    measure(() => {
        for (let i = 0; i < commands.length; i++) {
            thrift.serializeCalculateMetricCommandExtended(commands[i]);
        }
    }, 'thrift >> serialize CalculateMetricCommandExtended');
}

function measureThriftDeserializeCalculateMetricCommandExtended() {
    var buffers = commands.map(x => thrift.serializeCalculateMetricCommandExtended(x));

    measure(() => {
        for (let i = 0; i < buffers.length; i++) {
            thrift.deserializeCalculateMetricCommandExtended(buffers[i]);
        }
    }, 'thrift >> deserialize CalculateMetricCommandExtended');
}

function measureProtoV3SerializeCalculateMetricCommandExtended() {
    var buffers = [];

    measure(() => {
        for (let i = 0; i < commands.length; i++) {
            buffers.push(proto3.serializeCalculateMetricCommandExtended(commands[i]));
        }
    }, 'proto3 >> serialize CalculateMetricCommandExtended');

    console.log(buffers.length);
}

function measureProtoV3DeserializeCalculateMetricCommandExtended() {
    var buffers = commands.map(x => proto3.serializeCalculateMetricCommandExtended(x));

    measure(() => {
        for (let i = 0; i < buffers.length; i++) {
            proto3.deserializeCalculateMetricCommandExtended(buffers[i]);
        }
    }, 'proto3 >> deserialize CalculateMetricCommandExtended');
}

function measureJSONSerializeCalculateMetricCommandExtended() {
    var buffers = [];

    measure(() => {
        for (let i = 0; i < commands.length; i++) {
            var command = commands[i];
            buffers.push(new Buffer(JSON.stringify({
                accountId: command.accountId,
                eventId: command.eventId,
                commandId: command.commandId,
                metricSetup: command.metricSetup,
                targets: command.targets.map(x => ({id: x.id, entityType: x.entityType}))
            })));
        }
    }, 'JSON >> serialize CalculateMetricCommandExtended')

    console.log(buffers.length);
}

function measureJSONDeserializeCalculateMetricCommandExtended() {
    var strings = commands.map(x => new Buffer(JSON.stringify(x)));

    measure(() => {
        for (let i = 0; i < strings.length; i++) {
            JSON.parse(strings[i].toString());
        }
    }, 'JSON >> deserialize CalculateMetricCommandExtended');
}

// measureThriftSerializeMetricSetup();
// measureProtoSerializeMetricSetup();
// measureThriftSerializeMetricSetup();
// measureProtoSerializeMetricSetup();

//measureThriftSerializeCalculateMetricCommandExtended();
//measureProtoSerializeCalculateMetricCommandExtended();
measureProtoV3SerializeCalculateMetricCommandExtended();
measureJSONSerializeCalculateMetricCommandExtended();
//measureThriftSerializeCalculateMetricCommandExtended();
//measureProtoSerializeCalculateMetricCommandExtended();
measureProtoV3SerializeCalculateMetricCommandExtended();
measureJSONSerializeCalculateMetricCommandExtended();

//measureThriftDeserializeCalculateMetricCommandExtended();
//measureProtoDeserializeCalculateMetricCommandExtended();
//measureProtoV3DeserializeCalculateMetricCommandExtended();
//measureThriftDeserializeCalculateMetricCommandExtended();
//measureProtoDeserializeCalculateMetricCommandExtended();
//measureProtoV3DeserializeCalculateMetricCommandExtended();
//measureJSONDeserializeCalculateMetricCommandExtended();
