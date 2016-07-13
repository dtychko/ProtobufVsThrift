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
  public partial class MetricSetupChangedEvent : TBase
  {
    private MetricSetup _MetricSetup;
    private Modification _Modification;
    private int _AccountId;

    public MetricSetup MetricSetup
    {
      get
      {
        return _MetricSetup;
      }
      set
      {
        __isset.MetricSetup = true;
        this._MetricSetup = value;
      }
    }

    /// <summary>
    /// 
    /// <seealso cref="Modification"/>
    /// </summary>
    public Modification Modification
    {
      get
      {
        return _Modification;
      }
      set
      {
        __isset.Modification = true;
        this._Modification = value;
      }
    }

    public int AccountId
    {
      get
      {
        return _AccountId;
      }
      set
      {
        __isset.AccountId = true;
        this._AccountId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool MetricSetup;
      public bool Modification;
      public bool AccountId;
    }

    public MetricSetupChangedEvent() {
      this._Modification = Modification.NONE;
      this.__isset.Modification = true;
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
            if (field.Type == TType.Struct) {
              MetricSetup = new MetricSetup();
              MetricSetup.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              Modification = (Modification)iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I32) {
              AccountId = iprot.ReadI32();
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
      TStruct struc = new TStruct("MetricSetupChangedEvent");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (MetricSetup != null && __isset.MetricSetup) {
        field.Name = "MetricSetup";
        field.Type = TType.Struct;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        MetricSetup.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (__isset.Modification) {
        field.Name = "Modification";
        field.Type = TType.I32;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32((int)Modification);
        oprot.WriteFieldEnd();
      }
      if (__isset.AccountId) {
        field.Name = "AccountId";
        field.Type = TType.I32;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(AccountId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MetricSetupChangedEvent(");
      sb.Append("MetricSetup: ");
      sb.Append(MetricSetup== null ? "<null>" : MetricSetup.ToString());
      sb.Append(",Modification: ");
      sb.Append(Modification);
      sb.Append(",AccountId: ");
      sb.Append(AccountId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
