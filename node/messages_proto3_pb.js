/**
 * @fileoverview
 * @enhanceable
 * @public
 */
// GENERATED CODE -- DO NOT EDIT!

var jspb = require('google-protobuf');
var goog = jspb;
var global = Function('return this')();

var metric_setup_v3_pb = require('./metric_setup_v3_pb.js');
goog.exportSymbol('proto.CalculateMetricCommandExtended', null, global);
goog.exportSymbol('proto.Target', null, global);

/**
 * Generated by JsPbCodeGenerator.
 * @param {Array=} opt_data Optional initial data array, typically from a
 * server response, or constructed directly in Javascript. The array is used
 * in place and becomes part of the constructed object. It is not cloned.
 * If no data is provided, the constructed object will be empty, but still
 * valid.
 * @extends {jspb.Message}
 * @constructor
 */
proto.Target = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, null, null);
};
goog.inherits(proto.Target, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  proto.Target.displayName = 'proto.Target';
}


if (jspb.Message.GENERATE_TO_OBJECT) {
/**
 * Creates an object representation of this proto suitable for use in Soy templates.
 * Field names that are reserved in JavaScript and will be renamed to pb_name.
 * To access a reserved field use, foo.pb_<name>, eg, foo.pb_default.
 * For the list of reserved names please see:
 *     com.google.apps.jspb.JsClassTemplate.JS_RESERVED_WORDS.
 * @param {boolean=} opt_includeInstance Whether to include the JSPB instance
 *     for transitional soy proto support: http://goto/soy-param-migration
 * @return {!Object}
 */
proto.Target.prototype.toObject = function(opt_includeInstance) {
  return proto.Target.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Whether to include the JSPB
 *     instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.Target} msg The msg instance to transform.
 * @return {!Object}
 */
proto.Target.toObject = function(includeInstance, msg) {
  var f, obj = {
    id: msg.getId(),
    entitytype: msg.getEntitytype()
  };

  if (includeInstance) {
    obj.$jspbMessageInstance = msg;
  }
  return obj;
};
}


/**
 * Deserializes binary data (in protobuf wire format).
 * @param {jspb.ByteSource} bytes The bytes to deserialize.
 * @return {!proto.Target}
 */
proto.Target.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.Target;
  return proto.Target.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.Target} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.Target}
 */
proto.Target.deserializeBinaryFromReader = function(msg, reader) {
  while (reader.nextField()) {
    if (reader.isEndGroup()) {
      break;
    }
    var field = reader.getFieldNumber();
    switch (field) {
    case 1:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setId(value);
      break;
    case 2:
      var value = /** @type {string} */ (reader.readString());
      msg.setEntitytype(value);
      break;
    default:
      reader.skipField();
      break;
    }
  }
  return msg;
};


/**
 * Class method variant: serializes the given message to binary data
 * (in protobuf wire format), writing to the given BinaryWriter.
 * @param {!proto.Target} message
 * @param {!jspb.BinaryWriter} writer
 */
proto.Target.serializeBinaryToWriter = function(message, writer) {
  message.serializeBinaryToWriter(writer);
};


/**
 * Serializes the message to binary data (in protobuf wire format).
 * @return {!Uint8Array}
 */
proto.Target.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  this.serializeBinaryToWriter(writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the message to binary data (in protobuf wire format),
 * writing to the given BinaryWriter.
 * @param {!jspb.BinaryWriter} writer
 */
proto.Target.prototype.serializeBinaryToWriter = function (writer) {
  var f = undefined;
  f = this.getId();
  if (f !== 0) {
    writer.writeInt32(
      1,
      f
    );
  }
  f = this.getEntitytype();
  if (f.length > 0) {
    writer.writeString(
      2,
      f
    );
  }
};


/**
 * Creates a deep clone of this proto. No data is shared with the original.
 * @return {!proto.Target} The clone.
 */
proto.Target.prototype.cloneMessage = function() {
  return /** @type {!proto.Target} */ (jspb.Message.cloneMessage(this));
};


/**
 * optional int32 id = 1;
 * @return {number}
 */
proto.Target.prototype.getId = function() {
  return /** @type {number} */ (jspb.Message.getFieldProto3(this, 1, 0));
};


/** @param {number} value  */
proto.Target.prototype.setId = function(value) {
  jspb.Message.setField(this, 1, value);
};


/**
 * optional string entityType = 2;
 * @return {string}
 */
proto.Target.prototype.getEntitytype = function() {
  return /** @type {string} */ (jspb.Message.getFieldProto3(this, 2, ""));
};


/** @param {string} value  */
proto.Target.prototype.setEntitytype = function(value) {
  jspb.Message.setField(this, 2, value);
};



/**
 * Generated by JsPbCodeGenerator.
 * @param {Array=} opt_data Optional initial data array, typically from a
 * server response, or constructed directly in Javascript. The array is used
 * in place and becomes part of the constructed object. It is not cloned.
 * If no data is provided, the constructed object will be empty, but still
 * valid.
 * @extends {jspb.Message}
 * @constructor
 */
proto.CalculateMetricCommandExtended = function(opt_data) {
  jspb.Message.initialize(this, opt_data, 0, -1, proto.CalculateMetricCommandExtended.repeatedFields_, null);
};
goog.inherits(proto.CalculateMetricCommandExtended, jspb.Message);
if (goog.DEBUG && !COMPILED) {
  proto.CalculateMetricCommandExtended.displayName = 'proto.CalculateMetricCommandExtended';
}
/**
 * List of repeated fields within this message type.
 * @private {!Array<number>}
 * @const
 */
proto.CalculateMetricCommandExtended.repeatedFields_ = [3];



if (jspb.Message.GENERATE_TO_OBJECT) {
/**
 * Creates an object representation of this proto suitable for use in Soy templates.
 * Field names that are reserved in JavaScript and will be renamed to pb_name.
 * To access a reserved field use, foo.pb_<name>, eg, foo.pb_default.
 * For the list of reserved names please see:
 *     com.google.apps.jspb.JsClassTemplate.JS_RESERVED_WORDS.
 * @param {boolean=} opt_includeInstance Whether to include the JSPB instance
 *     for transitional soy proto support: http://goto/soy-param-migration
 * @return {!Object}
 */
proto.CalculateMetricCommandExtended.prototype.toObject = function(opt_includeInstance) {
  return proto.CalculateMetricCommandExtended.toObject(opt_includeInstance, this);
};


/**
 * Static version of the {@see toObject} method.
 * @param {boolean|undefined} includeInstance Whether to include the JSPB
 *     instance for transitional soy proto support:
 *     http://goto/soy-param-migration
 * @param {!proto.CalculateMetricCommandExtended} msg The msg instance to transform.
 * @return {!Object}
 */
proto.CalculateMetricCommandExtended.toObject = function(includeInstance, msg) {
  var f, obj = {
    accountid: msg.getAccountid(),
    metricsetup: (f = msg.getMetricsetup()) && metric_setup_v3_pb.MetricSetup.toObject(includeInstance, f),
    targetsList: jspb.Message.toObjectList(msg.getTargetsList(),
    proto.Target.toObject, includeInstance),
    eventid: msg.getEventid(),
    commandid: msg.getCommandid()
  };

  if (includeInstance) {
    obj.$jspbMessageInstance = msg;
  }
  return obj;
};
}


/**
 * Deserializes binary data (in protobuf wire format).
 * @param {jspb.ByteSource} bytes The bytes to deserialize.
 * @return {!proto.CalculateMetricCommandExtended}
 */
proto.CalculateMetricCommandExtended.deserializeBinary = function(bytes) {
  var reader = new jspb.BinaryReader(bytes);
  var msg = new proto.CalculateMetricCommandExtended;
  return proto.CalculateMetricCommandExtended.deserializeBinaryFromReader(msg, reader);
};


/**
 * Deserializes binary data (in protobuf wire format) from the
 * given reader into the given message object.
 * @param {!proto.CalculateMetricCommandExtended} msg The message object to deserialize into.
 * @param {!jspb.BinaryReader} reader The BinaryReader to use.
 * @return {!proto.CalculateMetricCommandExtended}
 */
proto.CalculateMetricCommandExtended.deserializeBinaryFromReader = function(msg, reader) {
  while (reader.nextField()) {
    if (reader.isEndGroup()) {
      break;
    }
    var field = reader.getFieldNumber();
    switch (field) {
    case 1:
      var value = /** @type {number} */ (reader.readInt32());
      msg.setAccountid(value);
      break;
    case 2:
      var value = new metric_setup_v3_pb.MetricSetup;
      reader.readMessage(value,metric_setup_v3_pb.MetricSetup.deserializeBinaryFromReader);
      msg.setMetricsetup(value);
      break;
    case 3:
      var value = new proto.Target;
      reader.readMessage(value,proto.Target.deserializeBinaryFromReader);
      msg.getTargetsList().push(value);
      msg.setTargetsList(msg.getTargetsList());
      break;
    case 4:
      var value = /** @type {string} */ (reader.readString());
      msg.setEventid(value);
      break;
    case 5:
      var value = /** @type {string} */ (reader.readString());
      msg.setCommandid(value);
      break;
    default:
      reader.skipField();
      break;
    }
  }
  return msg;
};


/**
 * Class method variant: serializes the given message to binary data
 * (in protobuf wire format), writing to the given BinaryWriter.
 * @param {!proto.CalculateMetricCommandExtended} message
 * @param {!jspb.BinaryWriter} writer
 */
proto.CalculateMetricCommandExtended.serializeBinaryToWriter = function(message, writer) {
  message.serializeBinaryToWriter(writer);
};


/**
 * Serializes the message to binary data (in protobuf wire format).
 * @return {!Uint8Array}
 */
proto.CalculateMetricCommandExtended.prototype.serializeBinary = function() {
  var writer = new jspb.BinaryWriter();
  this.serializeBinaryToWriter(writer);
  return writer.getResultBuffer();
};


/**
 * Serializes the message to binary data (in protobuf wire format),
 * writing to the given BinaryWriter.
 * @param {!jspb.BinaryWriter} writer
 */
proto.CalculateMetricCommandExtended.prototype.serializeBinaryToWriter = function (writer) {
  var f = undefined;
  f = this.getAccountid();
  if (f !== 0) {
    writer.writeInt32(
      1,
      f
    );
  }
  f = this.getMetricsetup();
  if (f != null) {
    writer.writeMessage(
      2,
      f,
      metric_setup_v3_pb.MetricSetup.serializeBinaryToWriter
    );
  }
  f = this.getTargetsList();
  if (f.length > 0) {
    writer.writeRepeatedMessage(
      3,
      f,
      proto.Target.serializeBinaryToWriter
    );
  }
  f = this.getEventid();
  if (f.length > 0) {
    writer.writeString(
      4,
      f
    );
  }
  f = this.getCommandid();
  if (f.length > 0) {
    writer.writeString(
      5,
      f
    );
  }
};


/**
 * Creates a deep clone of this proto. No data is shared with the original.
 * @return {!proto.CalculateMetricCommandExtended} The clone.
 */
proto.CalculateMetricCommandExtended.prototype.cloneMessage = function() {
  return /** @type {!proto.CalculateMetricCommandExtended} */ (jspb.Message.cloneMessage(this));
};


/**
 * optional int32 accountId = 1;
 * @return {number}
 */
proto.CalculateMetricCommandExtended.prototype.getAccountid = function() {
  return /** @type {number} */ (jspb.Message.getFieldProto3(this, 1, 0));
};


/** @param {number} value  */
proto.CalculateMetricCommandExtended.prototype.setAccountid = function(value) {
  jspb.Message.setField(this, 1, value);
};


/**
 * optional MetricSetup metricSetup = 2;
 * @return {proto.MetricSetup}
 */
proto.CalculateMetricCommandExtended.prototype.getMetricsetup = function() {
  return /** @type{proto.MetricSetup} */ (
    jspb.Message.getWrapperField(this, metric_setup_v3_pb.MetricSetup, 2));
};


/** @param {proto.MetricSetup|undefined} value  */
proto.CalculateMetricCommandExtended.prototype.setMetricsetup = function(value) {
  jspb.Message.setWrapperField(this, 2, value);
};


proto.CalculateMetricCommandExtended.prototype.clearMetricsetup = function() {
  this.setMetricsetup(undefined);
};


/**
 * repeated Target targets = 3;
 * If you change this array by adding, removing or replacing elements, or if you
 * replace the array itself, then you must call the setter to update it.
 * @return {!Array.<!proto.Target>}
 */
proto.CalculateMetricCommandExtended.prototype.getTargetsList = function() {
  return /** @type{!Array.<!proto.Target>} */ (
    jspb.Message.getRepeatedWrapperField(this, proto.Target, 3));
};


/** @param {Array.<!proto.Target>|undefined} value  */
proto.CalculateMetricCommandExtended.prototype.setTargetsList = function(value) {
  jspb.Message.setRepeatedWrapperField(this, 3, value);
};


proto.CalculateMetricCommandExtended.prototype.clearTargetsList = function() {
  this.setTargetsList([]);
};


/**
 * optional string eventId = 4;
 * @return {string}
 */
proto.CalculateMetricCommandExtended.prototype.getEventid = function() {
  return /** @type {string} */ (jspb.Message.getFieldProto3(this, 4, ""));
};


/** @param {string} value  */
proto.CalculateMetricCommandExtended.prototype.setEventid = function(value) {
  jspb.Message.setField(this, 4, value);
};


/**
 * optional string commandId = 5;
 * @return {string}
 */
proto.CalculateMetricCommandExtended.prototype.getCommandid = function() {
  return /** @type {string} */ (jspb.Message.getFieldProto3(this, 5, ""));
};


/** @param {string} value  */
proto.CalculateMetricCommandExtended.prototype.setCommandid = function(value) {
  jspb.Message.setField(this, 5, value);
};


goog.object.extend(exports, proto);
