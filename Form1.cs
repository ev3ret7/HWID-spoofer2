// Decompiled with JetBrains decompiler
// Type: ApexLegends_FPS.Form1
// Assembly: ApexLegends Toolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 79BDEFFC-ACCD-4554-BF37-E76AF5FEFECE
// Assembly location: C:\Users\Owner\Downloads\apex toolkit (post to unknown).exe

using ApexLegends_FPS.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace ApexLegends_FPS
{
  public class Form1 : Form
  {
    private static string videoConfig = Path.Combine(Environment.GetEnvironmentVariable("USERPROFILE"), "saved games") + "\\Respawn\\Apex\\local\\videoconfig.txt";
    private static string[] videoConfigContentArray;
    private IContainer components;
    private Button button1;
    private Button button2;
    private Button button3;
    private Label label1;
    private Label label2;
    private Label label3;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private Label label4;
    private Button button4;
    private Button button5;

    private static bool IsAdministrator()
    {
      return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }

    public Form1()
    {
      this.EndProcessByName("r5apex");
      this.EndProcessByName("EasyAntiCheat");
      this.InitializeComponent();
      try
      {
        foreach (Process process in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName))
        {
          if (process.Id != Process.GetCurrentProcess().Id)
            process.Kill();
        }
      }
      catch
      {
      }
      if (File.Exists(Form1.videoConfig))
      {
        Form1.videoConfigContentArray = File.ReadAllLines(Form1.videoConfig);
      }
      else
      {
        int num = (int) MessageBox.Show("Can not find files..", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Process.GetCurrentProcess().Kill();
      }
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (Process.GetProcessesByName("r5apex").Length != 0)
      {
        int num1 = (int) MessageBox.Show("Close Apex Legends first.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        string contents = "";
        foreach (string videoConfigContent in Form1.videoConfigContentArray)
          contents = (!videoConfigContent.Contains("setting.csm_enabled") ? (!videoConfigContent.Contains("setting.r_lod_switch_scale") ? contents + videoConfigContent : contents + "\t\"setting.r_lod_switch_scale\"\t\t\"0\"") : contents + "\t\"setting.csm_enabled\"\t\t\"0\"") + "\n";
        File.WriteAllText(Form1.videoConfig, contents);
        int num2 = (int) MessageBox.Show("Success! FPS Config loaded.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      if (Process.GetProcessesByName("r5apex").Length != 0)
      {
        int num1 = (int) MessageBox.Show("Close Apex Legends first.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        string contents = "";
        foreach (string videoConfigContent in Form1.videoConfigContentArray)
          contents = (!videoConfigContent.Contains("setting.csm_enabled") ? (!videoConfigContent.Contains("setting.r_lod_switch_scale") ? contents + videoConfigContent : contents + "\t\"setting.r_lod_switch_scale\"\t\t\"0.6\"") : contents + "\t\"setting.csm_enabled\"\t\t\"1\"") + "\n";
        File.WriteAllText(Form1.videoConfig, contents);
        int num2 = (int) MessageBox.Show("Success! Default Config loaded.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void EndProcessByName(string pname)
    {
      try
      {
        foreach (Process process in Process.GetProcessesByName(pname))
          process.Kill();
      }
      catch
      {
      }
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      if (File.Exists("r5apex.exe"))
      {
        this.button1.Enabled = false;
        this.button2.Enabled = false;
        this.button3.Enabled = false;
        this.EndProcessByName("r5apex");
        this.EndProcessByName("EasyAntiCheat");
        Process process = new Process();
        string str = "-novid -nomenuvid ";
        if (this.checkBox1.Checked)
          str += "-dxlevel 95 ";
        if (this.checkBox2.Checked)
          str += "-forcenovsync ";
        if (this.checkBox3.Checked)
          str += "+m_rawimput 1 ";
        process.StartInfo.Arguments = str;
        process.StartInfo.FileName = "r5apex.exe";
        process.Start();
        Process.GetCurrentProcess().Kill();
      }
      else
      {
        int num = (int) MessageBox.Show("Place this .exe inside your \"Origin Games\\Apex\" folder", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Process.GetCurrentProcess().Kill();
      }
    }

    private void Label2_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.unknowncheats.me/forum/members/1615403.html");
    }

    private void Label1_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.unknowncheats.me/forum/2373813-post1.html");
    }

    private void Label3_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.unknowncheats.me/forum/apex-legends/323740-hwid-anti-ban.html");
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      Settings.Default.box1 = this.checkBox1.Checked;
      Settings.Default.Save();
    }

    private void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
      Settings.Default.box2 = this.checkBox2.Checked;
      Settings.Default.Save();
    }

    private void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
      Settings.Default.box3 = this.checkBox3.Checked;
      Settings.Default.Save();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.checkBox1.Checked = Settings.Default.box1;
      this.checkBox2.Checked = Settings.Default.box2;
      this.checkBox3.Checked = Settings.Default.box3;
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      if (!Form1.IsAdministrator())
      {
        int num1 = (int) MessageBox.Show("You need to start the Program as Administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        object obj = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", "HwProfileGuid", (object) "ERROR");
        if (!File.Exists("hwid.backup"))
          File.WriteAllText("hwid.backup", obj.ToString());
        if (obj.ToString() == "ERROR")
        {
          int num2 = (int) MessageBox.Show("Could not find HWID", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          int int16 = (int) Convert.ToInt16(obj.ToString().Substring(obj.ToString().Length - 5, 4));
          int num3 = int16 <= 5000 ? int16 - 1 : int16 + 1;
          string str = obj.ToString().Substring(0, obj.ToString().Length - 5) + num3.ToString() + "}";
          Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", "HwProfileGuid", (object) str, RegistryValueKind.String);
          int num4 = (int) MessageBox.Show(string.Format("Success! Changed your HWID from\n{0}\nto\n{1}", obj, (object) str), "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
    }

    private void Button5_Click(object sender, EventArgs e)
    {
      if (!Form1.IsAdministrator())
      {
        int num1 = (int) MessageBox.Show("You need to start the Program as Administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", "HwProfileGuid", (object) "ERROR");
        if (!File.Exists("hwid.backup"))
        {
          int num2 = (int) MessageBox.Show("Can not find hwid.backup file- looks like you delted it..", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          Registry.SetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", "HwProfileGuid", (object) File.ReadAllText("hwid.backup"), RegistryValueKind.String);
          int num3 = (int) MessageBox.Show("Success! Changed your HWID back to\n" + File.ReadAllText("hwid.backup") + "\n(your default value)", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.checkBox1 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.label4 = new Label();
      this.button4 = new Button();
      this.button5 = new Button();
      this.SuspendLayout();
      this.button1.BackColor = System.Drawing.Color.DarkSlateBlue;
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.button1.Location = new Point(14, 12);
      this.button1.Name = "button1";
      this.button1.Size = new Size(210, 24);
      this.button1.TabIndex = 34;
      this.button1.Text = "FPS CONFIG SETTINGS";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new EventHandler(this.Button1_Click);
      this.button2.BackColor = System.Drawing.Color.DarkSlateBlue;
      this.button2.FlatStyle = FlatStyle.Flat;
      this.button2.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button2.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.button2.Location = new Point(242, 12);
      this.button2.Name = "button2";
      this.button2.Size = new Size(210, 24);
      this.button2.TabIndex = 35;
      this.button2.Text = "DEFAULT CONFIG SETTINGS";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new EventHandler(this.Button2_Click);
      this.button3.BackColor = System.Drawing.Color.DarkSlateBlue;
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button3.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.button3.Location = new Point(584, 386);
      this.button3.Name = "button3";
      this.button3.Size = new Size(145, 24);
      this.button3.TabIndex = 36;
      this.button3.Text = "START GAME";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new EventHandler(this.Button3_Click);
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.label1.Location = new Point(12, 39);
      this.label1.Name = "label1";
      this.label1.Size = new Size(138, 15);
      this.label1.TabIndex = 37;
      this.label1.Text = "credits to: corcik2009";
      this.label1.Click += new EventHandler(this.Label1_Click);
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label2.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.label2.Location = new Point(595, 414);
      this.label2.Name = "label2";
      this.label2.Size = new Size((int) sbyte.MaxValue, 15);
      this.label2.TabIndex = 38;
      this.label2.Text = "made by newguy148";
      this.label2.Click += new EventHandler(this.Label2_Click);
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Transparent;
      this.label3.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.label3.Location = new Point(12, 169);
      this.label3.Name = "label3";
      this.label3.Size = new Size(115, 15);
      this.label3.TabIndex = 39;
      this.label3.Text = "credits to: BlakeS";
      this.label3.Click += new EventHandler(this.Label3_Click);
      this.checkBox1.AutoSize = true;
      this.checkBox1.BackColor = System.Drawing.Color.Transparent;
      this.checkBox1.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.checkBox1.Location = new Point(584, 315);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(138, 19);
      this.checkBox1.TabIndex = 40;
      this.checkBox1.Text = "minecraft graphics";
      this.checkBox1.UseVisualStyleBackColor = false;
      this.checkBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
      this.checkBox2.AutoSize = true;
      this.checkBox2.BackColor = System.Drawing.Color.Transparent;
      this.checkBox2.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.checkBox2.Location = new Point(584, 338);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new Size(128, 19);
      this.checkBox2.TabIndex = 41;
      this.checkBox2.Text = "no vsync (forced)";
      this.checkBox2.UseVisualStyleBackColor = false;
      this.checkBox2.CheckedChanged += new EventHandler(this.CheckBox2_CheckedChanged);
      this.checkBox3.AutoSize = true;
      this.checkBox3.BackColor = System.Drawing.Color.Transparent;
      this.checkBox3.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.checkBox3.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.checkBox3.Location = new Point(584, 361);
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.Size = new Size(125, 19);
      this.checkBox3.TabIndex = 42;
      this.checkBox3.Text = "raw mouse input";
      this.checkBox3.UseVisualStyleBackColor = false;
      this.checkBox3.CheckedChanged += new EventHandler(this.CheckBox3_CheckedChanged);
      this.label4.BackColor = System.Drawing.Color.Transparent;
      this.label4.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label4.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.label4.Location = new Point(12, 90);
      this.label4.Name = "label4";
      this.label4.Size = new Size(651, 49);
      this.label4.TabIndex = 44;
      this.label4.Text = componentResourceManager.GetString("label4.Text");
      this.button4.BackColor = System.Drawing.Color.DarkSlateBlue;
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button4.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.button4.Location = new Point(14, 142);
      this.button4.Name = "button4";
      this.button4.Size = new Size(145, 24);
      this.button4.TabIndex = 45;
      this.button4.Text = "CHANGE HWID";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new EventHandler(this.Button4_Click);
      this.button5.BackColor = System.Drawing.Color.DarkSlateBlue;
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.Font = new Font("Arial Black", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button5.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.button5.Location = new Point(242, 142);
      this.button5.Name = "button5";
      this.button5.Size = new Size(210, 24);
      this.button5.TabIndex = 46;
      this.button5.Text = "RESTORE DEFAULT HWID";
      this.button5.UseVisualStyleBackColor = false;
      this.button5.Click += new EventHandler(this.Button5_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new Size(734, 438);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.Font = new Font("Consolas", 8.25f, FontStyle.Bold);
      this.ForeColor = System.Drawing.Color.FromArgb(215, 215, 215);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "ApexLegends Toolkit";
      this.Load += new EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
