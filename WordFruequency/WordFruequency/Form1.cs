﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WordFruequency
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        string filePath;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            string path = "C:\\..WordFruequency";
            // Filters for CSV, TXT files
            open.Filter = "CSV Files| *.csv| Text Files (*.txt) | *.txt| All Files (*.*)|*.*";
            open.Title = "Select a file to continue";
            open.InitialDirectory = path;
            open.CheckFileExists = true;
            open.CheckPathExists = true;

            // If OK is cliked, do this
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblFile.Text = open.FileName;
                filePath = lblPath.Text.ToString();

            }


            StreamReader sr = File.OpenText(lblFile.Text);
            
            int counter = 0;
            string delim = " ,."; //maybe some more delimiters like ?! and so on
            string[] fields = null;
            string line = null;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();//each time you read a line you should split it into the words
                line.Trim();
                fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                counter += fields.Length; //and just add how many of them there is
               

            }

            DataTable dt = new DataTable();
            
            dt.Columns.Add(new DataColumn("Number of Words", typeof(string)));

            dt.Columns.Add(new DataColumn("Number of Characters", typeof(string)));
            

            dt.Rows.Add(counter.ToString());
           

           dgWords.DataSource = dt;

            sr.Close();

           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
