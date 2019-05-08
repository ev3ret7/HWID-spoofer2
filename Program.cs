// Decompiled with JetBrains decompiler
// Type: ApexLegends_FPS.Program
// Assembly: ApexLegends Toolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 79BDEFFC-ACCD-4554-BF37-E76AF5FEFECE
// Assembly location: C:\Users\Owner\Downloads\apex toolkit (post to unknown).exe

using System;
using System.Windows.Forms;

namespace ApexLegends_FPS
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
