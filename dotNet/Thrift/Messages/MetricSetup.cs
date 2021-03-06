/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Messages
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MetricSetup : TBase
  {
    private int _Id;
    private int _metricId;
    private string _entityTypes;

    public int Id
    {
      get
      {
        return _Id;
      }
      set
      {
        __isset.Id = true;
        this._Id = value;
      }
    }

    public int MetricId
    {
      get
      {
        return _metricId;
      }
      set
      {
        __isset.metricId = true;
        this._metricId = value;
      }
    }

    public string EntityTypes
    {
      get
      {
        return _entityTypes;
      }
      set
      {
        __isset.entityTypes = true;
        this._entityTypes = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Id;
      public bool metricId;
      public bool entityTypes;
    }

    public MetricSetup() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I32) {
              Id = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              MetricId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              EntityTypes = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("MetricSetup");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.Id) {
        field.Name = "Id";
        field.Type = TType.I32;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Id);
        oprot.WriteFieldEnd();
      }
      if (__isset.metricId) {
        field.Name = "metricId";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MetricId);
        oprot.WriteFieldEnd();
      }
      if (EntityTypes != null && __isset.entityTypes) {
        field.Name = "entityTypes";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(EntityTypes);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MetricSetup(");
      sb.Append("Id: ");
      sb.Append(Id);
      sb.Append(",MetricId: ");
      sb.Append(MetricId);
      sb.Append(",EntityTypes: ");
      sb.Append(EntityTypes);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
