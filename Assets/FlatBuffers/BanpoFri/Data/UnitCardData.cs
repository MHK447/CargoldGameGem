// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace BanpoFri.Data
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct UnitCardData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static UnitCardData GetRootAsUnitCardData(ByteBuffer _bb) { return GetRootAsUnitCardData(_bb, new UnitCardData()); }
  public static UnitCardData GetRootAsUnitCardData(ByteBuffer _bb, UnitCardData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public UnitCardData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Unitidx { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public bool MutateUnitidx(int unitidx) { int o = __p.__offset(4); if (o != 0) { __p.bb.PutInt(o + __p.bb_pos, unitidx); return true; } else { return false; } }
  public int Level { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public bool MutateLevel(int level) { int o = __p.__offset(6); if (o != 0) { __p.bb.PutInt(o + __p.bb_pos, level); return true; } else { return false; } }
  public int Cardcount { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public bool MutateCardcount(int cardcount) { int o = __p.__offset(8); if (o != 0) { __p.bb.PutInt(o + __p.bb_pos, cardcount); return true; } else { return false; } }

  public static Offset<BanpoFri.Data.UnitCardData> CreateUnitCardData(FlatBufferBuilder builder,
      int unitidx = 0,
      int level = 0,
      int cardcount = 0) {
    builder.StartTable(3);
    UnitCardData.AddCardcount(builder, cardcount);
    UnitCardData.AddLevel(builder, level);
    UnitCardData.AddUnitidx(builder, unitidx);
    return UnitCardData.EndUnitCardData(builder);
  }

  public static void StartUnitCardData(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddUnitidx(FlatBufferBuilder builder, int unitidx) { builder.AddInt(0, unitidx, 0); }
  public static void AddLevel(FlatBufferBuilder builder, int level) { builder.AddInt(1, level, 0); }
  public static void AddCardcount(FlatBufferBuilder builder, int cardcount) { builder.AddInt(2, cardcount, 0); }
  public static Offset<BanpoFri.Data.UnitCardData> EndUnitCardData(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<BanpoFri.Data.UnitCardData>(o);
  }
};


}
