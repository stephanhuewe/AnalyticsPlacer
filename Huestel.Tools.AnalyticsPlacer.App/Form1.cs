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
            string rootDirectoryPath = "";
            string GACode = "";


            List<FileInfo> sourceFiles = GetFilesList(rootDirectoryPath);
            List<FileInfo> replacedFiles = PlaceAnalyticsCodeInFiles(GACode, sourceFiles);
        }

        private List<FileInfo> PlaceAnalyticsCodeInFiles(string gaCode, List<FileInfo> sourceFiles)
        {
            List<FileInfo> ret = new List<FileInfo>();

            foreach (var file in sourceFiles)
            {
                string fileContent = File.ReadAllText(file.FullName);

                string resultString = null;
                try
                {
                    resultString = Regex.Match(fileContent, "</head>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Value;
                }
                catch (ArgumentException ex)
                {
                    // Syntax error in the regular expression
                }


                if (!String.IsNullOrWhiteSpace(resultString))
                {

                    fileContent = fileContent.Replace(resultString, gaCode + resultString);
                    File.WriteAllText(file.FullName, fileContent);
                    ret.Add(file);
                }
            }

            return ret;
        }

        private List<FileInfo> GetFilesList(string rootDirectoryPath)
        {
            throw new NotImplementedException();
        }
    }
}
