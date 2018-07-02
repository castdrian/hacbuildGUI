using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace hacbuildGUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            string hbe = AppDomain.CurrentDomain.BaseDirectory + "\\hacbuild.exe";

            bool hbcheck = File.Exists(hbe);

            if (hbcheck == false) 
            {
                DialogResult hbcheckd = System.Windows.Forms.MessageBox.Show(" The hacbuild binary is not present in the current working\n" +
                    " directory. " +
                    "You will now be redirected to the download page.",
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                if (hbcheckd == System.Windows.Forms.DialogResult.OK)
                {
                    Process.Start("https://github.com/LucaFraga/hacbuild/releases/latest");
                    Process.GetCurrentProcess().Kill();
                }
            }

            string ktxt = AppDomain.CurrentDomain.BaseDirectory + "\\keys.txt";

            bool kcheck = File.Exists(ktxt);

            if (kcheck == false)
            {
                DialogResult kcheckd = System.Windows.Forms.MessageBox.Show(" keys.txt is missing.\n Please add it to the current working directory to ensure that\n" +
                    " hacbuild will work properly.",
                    "Warning", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (kcheckd == System.Windows.Forms.DialogResult.Cancel)
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
        FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
        System.Windows.Threading.DispatcherTimer scrolltimer = new System.Windows.Threading.DispatcherTimer();


        private void scrolltimer_Tick(object sender, EventArgs e)
        {
            txtConsole.ScrollToEnd();
        }

        public class TextBoxWriter : TextWriter
        {
            System.Windows.Controls.TextBox _output = null;

            public TextBoxWriter(System.Windows.Controls.TextBox output)
            {
                _output = output;
            }

            public override void Write(char value)
            {
                base.Write(value);
                _output.Dispatcher.BeginInvoke(new Action(() =>
                {
                    _output.AppendText(value.ToString());
                }));
            }

            public override Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
            }

        }

        public async void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            string hbdir = AppDomain.CurrentDomain.BaseDirectory + "\\hacbuild.exe";
            string arg = @"read xci " + inputxcidisplay.Text;

            Process hbd = new Process();
            hbd.StartInfo.FileName = hbdir;
            hbd.StartInfo.Arguments = arg;
            hbd.StartInfo.CreateNoWindow = true;
            hbd.StartInfo.RedirectStandardOutput = true;
            hbd.StartInfo.UseShellExecute = false;
            hbd.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            hbd.EnableRaisingEvents = true;
            Console.SetOut(new TextBoxWriter(txtConsole));
            hbd.OutputDataReceived += (s, ea) => { Console.WriteLine($"{ea.Data}"); };

            scrolltimer.Tick += new EventHandler(scrolltimer_Tick);
            scrolltimer.Interval = new TimeSpan(0, 0, 1);

            hbd.Start();
            hbd.BeginOutputReadLine();

            await Task.Run(() => hbd.WaitForExit());

            hbd.Close();
        }

        public async void UTButton_Click(object sender, RoutedEventArgs e)
        {
            string hbdir = AppDomain.CurrentDomain.BaseDirectory + "\\hacbuild.exe";
            string arg = @"hfs0 " + inputdisplay.Text + @" " + outputdisplay.Text;

            Process hbd = new Process();
            hbd.StartInfo.FileName = hbdir;
            hbd.StartInfo.Arguments = arg;
            hbd.StartInfo.CreateNoWindow = true;
            hbd.StartInfo.RedirectStandardOutput = true;
            hbd.StartInfo.UseShellExecute = false;
            hbd.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            hbd.EnableRaisingEvents = true;
            Console.SetOut(new TextBoxWriter(txtConsole));
            hbd.OutputDataReceived += (s, ea) => { Console.WriteLine($"{ea.Data}"); };

            scrolltimer.Tick += new EventHandler(scrolltimer_Tick);
            scrolltimer.Interval = new TimeSpan(0, 0, 1);

            hbd.Start();
            hbd.BeginOutputReadLine();
            scrolltimer.Start();

            await Task.Run(() => hbd.WaitForExit());

            hbd.Close();
        }

        public async void BRButton_Click(object sender, RoutedEventArgs e)
        {
            string hbdir = AppDomain.CurrentDomain.BaseDirectory + "\\hacbuild.exe";
            string arg = @"xci " + inputdisplay.Text + @" " + outputdisplay.Text;

            Process hbd = new Process();
            hbd.StartInfo.FileName = hbdir;
            hbd.StartInfo.Arguments = arg;
            hbd.StartInfo.CreateNoWindow = true;
            hbd.StartInfo.RedirectStandardOutput = true;
            hbd.StartInfo.UseShellExecute = false;
            hbd.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            hbd.EnableRaisingEvents = true;
            Console.SetOut(new TextBoxWriter(txtConsole));
            hbd.OutputDataReceived += (s, ea) => { Console.WriteLine($"{ea.Data}"); };

            scrolltimer.Tick += new EventHandler(scrolltimer_Tick);
            scrolltimer.Interval = new TimeSpan(0, 0, 1);

            hbd.Start();
            hbd.BeginOutputReadLine();
            scrolltimer.Start();

            await Task.Run(() => hbd.WaitForExit());

            hbd.Close();
        }

        public async void BNSUButton_Click(object sender, RoutedEventArgs e)
        {
            string hbdir = AppDomain.CurrentDomain.BaseDirectory + "\\hacbuild.exe";
            string arg = @"xci_auto " + inputdisplay.Text + @" " + outputdisplay.Text;

            Process hbd = new Process();
            hbd.StartInfo.FileName = hbdir;
            hbd.StartInfo.Arguments = arg;
            hbd.StartInfo.CreateNoWindow = true;
            hbd.StartInfo.RedirectStandardOutput = true;
            hbd.StartInfo.UseShellExecute = false;
            hbd.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
            hbd.EnableRaisingEvents = true;
            Console.SetOut(new TextBoxWriter(txtConsole));
            hbd.OutputDataReceived += (s, ea) => { Console.WriteLine($"{ea.Data}"); };

            scrolltimer.Tick += new EventHandler(scrolltimer_Tick);
            scrolltimer.Interval = new TimeSpan(0, 0, 1);

            hbd.Start();
            hbd.BeginOutputReadLine();
            scrolltimer.Start();

            await Task.Run(() => hbd.WaitForExit());

            hbd.Close();
        }

        private void IPButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result = openFolderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                inputdisplay.Text = openFolderDialog.SelectedPath;
            }
        }

        private void OPButton_Click(object sender, RoutedEventArgs e)
        {
            saveFileDialog.Filter = "NSW XCI File|*.xci";
            saveFileDialog.Title = "Choose Output File";

            if (saveFileDialog.ShowDialog() == true)
                outputdisplay.Text = saveFileDialog.FileName;
        }

        private void CRButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("hacbuildGUI" + "\nVersion: 1.0" + "\nDeveloped by: adrifcastr" +
                "\n" + "\nCredit to:" + "\nLucaFraga for hacbuild");
        }

        private void IPSButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "NSW XCI File|*.xci";
            openFileDialog.Title = "Select a NSW XCI File";

            if (openFileDialog.ShowDialog() == true)
                inputxcidisplay.Text = openFileDialog.FileName;
        }
    }
}
 