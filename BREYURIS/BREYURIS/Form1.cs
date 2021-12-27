using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace BREYURIS
{
    public partial class Form1 : Form
    {
        string inputfilename;
        string sourceArchive;
        string patchfolder;
        string ypfversion;
        string ypfFileName;
        StringBuilder m_output;

        public Form1()
        {
            InitializeComponent();
        }
        void SortOutputHandler(object sender, DataReceivedEventArgs e)
        {
            /*Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                richTextBox2.AppendText(e.Data ?? string.Empty);
            }));*/
            string outputString = e.Data;
            MethodInvoker append = () => richTextBox2.AppendText(e.Data ?? string.Empty);
            richTextBox2.BeginInvoke(append);
        }
        void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("Output from other process");
            Debug.WriteLine(e.Data);

            // Add the data, one line at a time, to the string builder
            m_output.AppendLine(e.Data);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /* string strCmdText;
            strCmdText = "/c VNTextPatch extractlocal "+ inputfilename+" script.xlsx";

            var startInfo = new ProcessStartInfo("cmd", strCmdText)
            {
                WorkingDirectory = @"VNTranslationTools/",

                //Arguments = "/k" // will leave the process running until you type exit
            };

            Process.Start(startInfo); 
            using (Process sortProcess = new Process())
            {
                sortProcess.StartInfo.FileName = "cmd.exe";
                sortProcess.StartInfo.WorkingDirectory = @"VNTranslationTools/";
                sortProcess.StartInfo.Arguments = "/c VNTextPatch extractlocal " + inputfilename + " script.xlsx";
                sortProcess.StartInfo.CreateNoWindow = true;
                sortProcess.StartInfo.UseShellExecute = false;
                sortProcess.StartInfo.RedirectStandardOutput = true;

                // Set event handler
                sortProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);

                // Start the process.
                sortProcess.Start();

                // Start the asynchronous read
                sortProcess.BeginOutputReadLine();

                sortProcess.WaitForExit();
            }*/

            m_output = new StringBuilder();

            //e.Handled = true;
            //e.SuppressKeyPress = true;
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "cmd.exe";
            cmdStartInfo.WorkingDirectory = @"VNTranslationTools/";
            cmdStartInfo.Arguments = "/c VNTextPatch extractlocal " + inputfilename + " script.xlsx";
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = false;

            Process cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();

            cmdProcess.StandardInput.WriteLine(richTextBox2.Text);
            cmdProcess.StandardInput.WriteLine("exit");

            cmdProcess.WaitForExit();

            // And now that everything's done, just set the text
            // to whatever's in the stringbuilder
            richTextBox2.Text = m_output.ToString();

            // We're done with the stringbuilder, let the garbage
            // collector free it
            m_output = null;

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputfilename = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*string strCmdText;
            strCmdText = "/c VNTextPatch insertlocal " + inputfilename + " script.xlsx " + patchfolder;
            //System.Environment.GetFolderPath = @"VNTranslationTools";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var startInfo = new ProcessStartInfo("cmd", strCmdText)
            {
                WorkingDirectory = @"VNTranslationTools/",

                //Arguments = "/k" // will leave the process running until you type exit
            };

            Process.Start(startInfo);*/
            m_output = new StringBuilder();

            //e.Handled = true;
            //e.SuppressKeyPress = true;
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "cmd.exe";
            cmdStartInfo.WorkingDirectory = @"VNTranslationTools/";
            cmdStartInfo.Arguments = "/c VNTextPatch insertlocal " + inputfilename + " script.xlsx " + patchfolder;
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = false;

            Process cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();

            cmdProcess.StandardInput.WriteLine(richTextBox2.Text);
            cmdProcess.StandardInput.WriteLine("exit");

            cmdProcess.WaitForExit();

            // And now that everything's done, just set the text
            // to whatever's in the stringbuilder
            richTextBox2.Text = m_output.ToString();

            // We're done with the stringbuilder, let the garbage
            // collector free it
            m_output = null;


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            patchfolder = textBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*string strCmdText;
            strCmdText = "/c YPF_manager.exe -p "+ ypfFileName;
            //System.Environment.GetFolderPath = @"VNTranslationTools";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var startInfo = new ProcessStartInfo("cmd", strCmdText)
            {
                WorkingDirectory = @"YPF Manager Tool/",

                //Arguments = "/k" // will leave the process running until you type exit
            };*/

            m_output = new StringBuilder();

            //e.Handled = true;
            //e.SuppressKeyPress = true;
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "cmd.exe";
            cmdStartInfo.WorkingDirectory = @"YPF Manager Tool/";
            cmdStartInfo.Arguments = "/c YPF_manager.exe -p " + ypfFileName;
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = false;

            Process cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();

            cmdProcess.StandardInput.WriteLine(richTextBox2.Text);
            cmdProcess.StandardInput.WriteLine("exit");

            cmdProcess.WaitForExit();

            // And now that everything's done, just set the text
            // to whatever's in the stringbuilder
            richTextBox2.Text = m_output.ToString();

            // We're done with the stringbuilder, let the garbage
            // collector free it
            m_output = null;

           // Process.Start(startInfo);
            using (StreamReader readtext = new StreamReader(@"YPF Manager Tool/ypfversion.txt"))
            {
                ypfversion = readtext.ReadLine();
                
            }
            textBox2.Text = ypfversion;

            System.Threading.Thread.Sleep(2000);

            using (StreamReader readtext = new StreamReader(@"YPF Manager Tool/ypfversion.txt"))
            {
                ypfversion = readtext.ReadLine();

            }
            textBox2.Text = ypfversion;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*string strCmdText;
            strCmdText = "/c YPF_manager.exe -c "+ sourceArchive +" -v "+ textBox2.Text;
            //System.Environment.GetFolderPath = @"VNTranslationTools";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var startInfo = new ProcessStartInfo("cmd", strCmdText)
            {
                WorkingDirectory = @"YPF Manager Tool/",

                //Arguments = "/k" // will leave the process running until you type exit
            };
            Process.Start(startInfo);*/
            m_output = new StringBuilder();

            //e.Handled = true;
            //e.SuppressKeyPress = true;
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "cmd.exe";
            cmdStartInfo.WorkingDirectory = @"YPF Manager Tool/";
            cmdStartInfo.Arguments = "/c YPF_manager.exe -c " + sourceArchive + " -v " + textBox2.Text;
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = false;

            Process cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();

            cmdProcess.StandardInput.WriteLine(richTextBox2.Text);
            cmdProcess.StandardInput.WriteLine("exit");

            cmdProcess.WaitForExit();

            // And now that everything's done, just set the text
            // to whatever's in the stringbuilder
            richTextBox2.Text = m_output.ToString();

            // We're done with the stringbuilder, let the garbage
            // collector free it
            m_output = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            sourceArchive = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            ypfFileName = textBox5.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*string strCmdText;
            strCmdText = "/c YPF_manager.exe -e " + ypfFileName;
            //System.Environment.GetFolderPath = @"VNTranslationTools";
            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            var startInfo = new ProcessStartInfo("cmd", strCmdText)
            {
                WorkingDirectory = @"YPF Manager Tool/",

                //Arguments = "/k" // will leave the process running until you type exit
            };

            Process.Start(startInfo);*/
            m_output = new StringBuilder();

            //e.Handled = true;
            //e.SuppressKeyPress = true;
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "cmd.exe";
            cmdStartInfo.WorkingDirectory = @"YPF Manager Tool/";
            cmdStartInfo.Arguments = "/c YPF_manager.exe -e " + ypfFileName;
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = false;

            Process cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();

            cmdProcess.StandardInput.WriteLine(richTextBox2.Text);
            cmdProcess.StandardInput.WriteLine("exit");

            cmdProcess.WaitForExit();

            // And now that everything's done, just set the text
            // to whatever's in the stringbuilder
            richTextBox2.Text = m_output.ToString();

            // We're done with the stringbuilder, let the garbage
            // collector free it
            m_output = null;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
