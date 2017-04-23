using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaxScript;

namespace Send2Max
{
    public partial class Form1 : Form
    {
        List<Process> scriptTargetProcess = new List<Process>();
        Process[] processes;

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txt_filepath.Enabled = true;
            btn_pickfile.Enabled = true;
            txt_oneliner.Enabled = false;
        }

        private void rad_oneliner_CheckedChanged(object sender, EventArgs e)
        {
            txt_filepath.Enabled = false;
            btn_pickfile.Enabled = false;
            txt_oneliner.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MultipleMaxPopup theForm = new MultipleMaxPopup();
            theForm.ShowDialog();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //First find the 3dsMax processes running
            processes = MaxScript.Send2Max.Get3dsMaxProcesses();
            scriptTargetProcess.Clear();
            
            //Logic going through three scenarios: max isn't running, one max is running, multiple maxes are running
            if (processes.Length == 0)
            {
                MessageBox.Show("No 3ds Max instance found. Can't send the script, sorry");
            }
            if (processes.Length == 1)
            {
                scriptTargetProcess.Add(processes[0]);
                MessageBox.Show("Found one 3ds Max instance found. Sending the script now");
            }
            if (processes.Length > 1)
            {
                lbx_maxwindows.Enabled = true;
                //Console.WriteLine("Found {0} 3ds Max instance running. Which one do you want to use?", processes.Length);
                for (int n = 0; n < processes.Length; n++)
                {
                    lbx_maxwindows.Items.Add(processes[n].MainWindowTitle);
                }
                lbx_maxwindows.Items.Add("All of them");

                Console.WriteLine();
                int val;
                Console.WriteLine("You pressed " + info.KeyChar.ToString());
                if (int.TryParse(info.KeyChar.ToString(), out val))
                {
                    if (val <= processes.Length)
                    {
                        if (val == processes.Length)
                        {
                            scriptTargetProcess = processes.ToList<Process>();
                        }
                        else
                        {
                            scriptTargetProcess.Add(processes[val]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0} is not a valid choice, please run the tool again, bye!", info.KeyChar.ToString());
                }
            }

        }

        private void lbx_maxwindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            scriptTargetProcess.Add(processes[lbx_maxwindows.SelectedIndex]);
        }
    }
}
