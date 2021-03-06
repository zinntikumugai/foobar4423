﻿using foobar4423.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace foobar4423
{
    public partial class Form_Config : Form
    {
        public Form_Config()
        {
            InitializeComponent();
        }

        private void Form_Config_Load(object sender, EventArgs e)
        {
            LoadConfig();
            textBox_filePath.SelectionStart = 0;
            textBox_format.SelectionStart = 0;
        }

        private void button_filePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.FileName = "foobar2000.exe";
            ofd.InitialDirectory = @"C:\Program Files (x86)\foobar2000\";
            ofd.Filter = "実行ファイル(*.exe)|*.exe";
            ofd.Title = "foobar2000 の実行ファイルを選択してください";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox_filePath.Text = ofd.FileName;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveConfig();
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        internal void SaveConfig()
        {
            Settings.Default.FoobarFilePath = textBox_filePath.Text;
            Settings.Default.NowPlayingFormat = textBox_format.Text;
            Settings.Default.IsBalloon = checkBox_balloon.Checked;

            Settings.Default.Save();
        }
        
        /// <summary>
        /// 読み込み
        /// </summary>
        private void LoadConfig()
        {
            textBox_filePath.Text = Settings.Default.FoobarFilePath;
            textBox_format.Text = Settings.Default.NowPlayingFormat;
            checkBox_balloon.Checked = Settings.Default.IsBalloon;
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("フォーマットを初期設定に戻しますか?", "確認",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                textBox_format.Text = Resources.DefaultFormat;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Webページを表示します。", "確認",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Process.Start(Resources.HelpUrl);
            }
        }
    }
}
