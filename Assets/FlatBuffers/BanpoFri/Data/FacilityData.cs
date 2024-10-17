// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace BanpoFri.Data
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct FacilityData : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_2_0_0(); }
  public static FacilityData GetRootAsFacilityData(ByteBuffer _bb) { return GetRootAsFacilityData(_bb, new FacilityData()); }
  public static FacilityData GetRootAsFacilityData(ByteBuffer _bb, FacilityData obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FacilityData __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Groundidx { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public bool MutateGroundidx(int groundidx) { int o = __p.__offset(4); if (o != 0) { __p.bb.PutInt(o + __p.bb_pos, groundidx); return true; } else { return false; } }
  public int Facilitygrade { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public bool MutateFacilitygrade(int facilitygrade) { int o = __p.__offset(6); if (o != 0) { __p.bb.PutInt(o + __p.bb_pos, facilitygrade); return true; } else { return false; } }
  public int Landstatuseventidx { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public bool MutateLandstatuseventidx(int landstatuseventidx) { int o = __p.__offset(8); if (o != 0) { __p.bb.PutInt(o + __p.bb_pos, landstatuseventidx); return true; } else { return false; } }
  public long Landbenefittime { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetLong(o + __p.bb_pos) : (long)0; } }
  public bool MutateLandbenefittime(long landbenefittime) { int o = __p.__offset(10); if (o != 0) { __p.bb.PutLong(o + __p.bb_pos, landbenefittime); return true; } else { return false; } }
  public bool Iseventground { get { int o = __p.__offset(12); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool MutateIseventground(bool iseventground) { int o = __p.__offset(12); if (o != 0) { __p.bb.Put(o + __p.bb_pos, (byte)(iseventground ? 1 : 0)); return true; } else { return false; } }
  public bool Isbenefit { get { int o = __p.__offset(14); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  public bool MutateIsbenefit(bool isbenefit) { int o = __p.__offset(14); if (o != 0) { __p.bb.Put(o + __p.bb_pos, (byte)(isbenefit ? 1 : 0)); return true; } else { return false; } }

  public static Offset<BanpoFri.Data.FacilityData> CreateFacilityData(FlatBufferBuilder builder,
      int groundidx = 0,
      int facilitygrade = 0,
      int landstatuseventidx = 0,
      long landbenefittime = 0,
      bool iseventground = false,
      bool isbenefit = false) {
    builder.StartTable(6);
    FacilityData.AddLandbenefittime(builder, landbenefittime);
    FacilityData.AddLandstatuseventidx(builder, landstatuseventidx);
    FacilityData.AddFacilitygrade(builder, facilitygrade);
    FacilityData.AddGroundidx(builder, groundidx);
    FacilityData.AddIsbenefit(builder, isbenefit);
    FacilityData.AddIseventground(builder, iseventground);
    return FacilityData.EndFacilityData(builder);
  }

  public static void StartFacilityData(FlatBufferBuilder builder) { builder.StartTable(6); }
  public static void AddGroundidx(FlatBufferBuilder builder, int groundidx) { builder.AddInt(0, groundidx, 0); }
  public static void AddFacilitygrade(FlatBufferBuilder builder, int facilitygrade) { builder.AddInt(1, facilitygrade, 0); }
  public static void AddLandstatuseventidx(FlatBufferBuilder builder, int landstatuseventidx) { builder.AddInt(2, landstatuseventidx, 0); }
  public static void AddLandbenefittime(FlatBufferBuilder builder, long landbenefittime) { builder.AddLong(3, landbenefittime, 0); }
  public static void AddIseventground(FlatBufferBuilder builder, bool iseventground) { builder.AddBool(4, iseventground, false); }
  public static void AddIsbenefit(FlatBufferBuilder builder, bool isbenefit) { builder.AddBool(5, isbenefit, false); }
  public static Offset<BanpoFri.Data.FacilityData> EndFacilityData(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<BanpoFri.Data.FacilityData>(o);
  }
};


}
