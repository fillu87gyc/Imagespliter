﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1() => InitializeComponent();

		private void button1_Click(object sender, EventArgs e)
		{
			//OpenFileDialogクラスのインスタンスを作成
			OpenFileDialog ofd = new OpenFileDialog
			{
				InitialDirectory = @"D:\Drive\Google ドライブ\寮食メニュー\生データ",
			
				Filter = "すべてのファイル(*.*)|*.*",
				FilterIndex = 2,
				Title = "開くファイルを選択してください",
				RestoreDirectory = true,
				CheckFileExists = true,
				CheckPathExists = true
			};
			ofd.ShowDialog();
			Bitmap img = new Bitmap(ofd.FileName);
			int width = img.Width / 7;
			int height = img.Height / 3;
			for (int row = 0; row < 7; row++)
			{
				for (int column = 0; column < 3; column++)
				{					
					Rectangle Rect = new Rectangle((row * width), (column * height), width, height);
					var newimg = img.Clone(Rect, img.PixelFormat);
					newimg.Save(local + row + column + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
					newimg.Dispose();
				}
			}
		}
		string local = @"D:\Drive\Google ドライブ\寮食メニュー\加工済み\";
		private void button2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(local);
		}
	}
}
