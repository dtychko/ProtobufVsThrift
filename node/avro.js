var avro = require('avsc');

var type = avro.parse({
    name: 'MetricSetup',
    type: 'record',
    fields: [
        {name: 'id', type: 'int'},
        {name: 'metricId', type: 'int'},
        {name: 'entityTypes', type: 'string'}
    ]
});

var metricSetup = {
    id: 1,
    metricId: 2,
    entityTypes: 'Bug,UserStory,Feature'
};

var buf = type.toBuffer(metricSetup);

console.log(buf, buf.length);
