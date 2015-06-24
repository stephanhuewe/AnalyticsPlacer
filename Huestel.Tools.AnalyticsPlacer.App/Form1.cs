using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huestel.Tools.AnalyticsPlacer.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            // Check if GA code is set
            if (String.IsNullOrWhiteSpace(txtGACode.Text))
            {
                MessageBox.Show("Analytics Code not set", "Missing GA code", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            btnReplace.Enabled = false;

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            // Get directories
            if (sourceDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                if (targetDirectoryDialog.ShowDialog() == DialogResult.OK)
                {
                    worker.RunWorkerAsync();
                }
            }

            btnReplace.Enabled = false;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done!", "Process finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblProgress.Text = "Processing file no. " + e.ProgressPercentage;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            PlaceAnalyticsCodeInFiles(worker, txtGACode.Text, sourceDirectoryDialog.SelectedPath,
                       targetDirectoryDialog.SelectedPath);

        }

        /// <summary>
        /// Place code in html files,
        /// </summary>
        /// <param name="worker">BackgroundWorker</param>
        /// <param name="gaCode">Google Analytics Code</param>
        /// <param name="sourceDirectory">Source Directory</param>
        /// <param name="targetDirectory">Target Directory</param>
        private void PlaceAnalyticsCodeInFiles(BackgroundWorker worker, string gaCode, string sourceDirectory, string targetDirectory)
        {
            int i = 0;

            List<string> files = Directory.EnumerateFiles(sourceDirectory, "*.*", SearchOption.AllDirectories).ToList();
            int numberoOfFiles = files.Count;
            
            foreach (string file in files)
            {
                worker.ReportProgress((i));
                i++;

                string fileContent = File.ReadAllText(file);

                string resultString = null;
                try
                {
                    resultString = Regex.Match(fileContent, "</head>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Value;
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }


                if (!String.IsNullOrWhiteSpace(resultString))
                {
                    fileContent = fileContent.Replace(resultString, gaCode + resultString);

                    string directory = Path.GetDirectoryName(file);
                    string fileName = Path.GetFileName(file);
                    string finalDirectory = targetDirectory + directory.Replace(sourceDirectory, "");

                    if (!Directory.Exists(finalDirectory))
                    {
                        Directory.CreateDirectory(finalDirectory);
                    }

                    string finalPath = finalDirectory + "\\" + fileName;
                    File.WriteAllText(finalPath, fileContent);                    
                }
            }
        }

    }
}
