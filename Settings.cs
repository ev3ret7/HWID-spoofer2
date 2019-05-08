// Decompiled with JetBrains decompiler
// Type: ApexLegends_FPS.Properties.Settings
// Assembly: ApexLegends Toolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 79BDEFFC-ACCD-4554-BF37-E76AF5FEFECE
// Assembly location: C:\Users\Owner\Downloads\apex toolkit (post to unknown).exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ApexLegends_FPS.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool box1
    {
      get
      {
        return (bool) this[nameof (box1)];
      }
      set
      {
        this[nameof (box1)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool box2
    {
      get
      {
        return (bool) this[nameof (box2)];
      }
      set
      {
        this[nameof (box2)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool box3
    {
      get
      {
        return (bool) this[nameof (box3)];
      }
      set
      {
        this[nameof (box3)] = (object) value;
      }
    }
  }
}
