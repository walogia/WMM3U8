/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2019/1/30 星期三
 * 时间: 21:29
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WMM3U8
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "M3U8文件|*.m3u8|所有文件|*.*";
			ofd.ShowDialog();
			string path = ofd.FileName;
			if (path == ""){return;}
			using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
			{
			byte[] buffer = new byte[1024 * 1024 * 5];
			int r = fsRead.Read(buffer, 0, buffer.Length);
			textBox1.Text = Encoding.Default.GetString(buffer, 0, r);
			}
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			try {
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "M3U8文件|*.m3u8|所有文件|*.*";
				sfd.FileName= DateTime.Now.ToString("yyyy-MM-dd"); 
				sfd.ShowDialog();
				string path = sfd.FileName;
				if (path == ""){return;}
				using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
				{
					byte[] buffer = Encoding.Default.GetBytes(textBox1.Text);
					fsWrite.Write(buffer, 0, buffer.Length);
				}
			} catch (Exception) {
			}
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			string[] kk=textBox1.Text.Split('\n');
			try {
				for (int i = 0; i < kk.Length; i++) {

				if(kk[i].Substring(0,1)!="#"){
					kk[i]="https://media.wanmen.org/"+kk[i];
					
						}
					}			                          
			}
			 catch (Exception) {	
			}
			textBox1.Text=string.Join("\n",kk);
		}
		
		//*****************
	}
}
