using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirHurtAPI_Demo_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (SirHurtAPI.SirHurtAPI.GetAutoInject())
            {
                SirHurtAPI.SirHurtAPI.AutoInjectToggle();
            }
            if (SirHurtAPI.SirHurtAPI.getMultipleRBX())
            {
                SirHurtAPI.SirHurtAPI.multipleRBXToggle();
            }
            if (SirHurtAPI.Experimental.GetAutoInject())
            {
                SirHurtAPI.Experimental.AutoInjectToggle();
            }
        }

        private void InjectBtn_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.LaunchExploit();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.Execute(scriptBox.Text, true);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            scriptBox.Clear();
        }

        private void EFF_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.ExecuteFromFile(true);
        }

        private void oof123_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.AutoInjectToggle();
            oof123.Text = "Auto Inject: " + SirHurtAPI.SirHurtAPI.GetAutoInject().ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void InjectedCheck_Tick(object sender, EventArgs e)
        {
            injectedstring.Text = "Injected: " + SirHurtAPI.SirHurtAPI.isInjected().ToString();
        }

        private void AutoIJEx_Click(object sender, EventArgs e)
        {
            SirHurtAPI.Experimental.AutoInjectToggle();
            AutoIJEx.Text = "Auto Inject [Experimental]: " + SirHurtAPI.Experimental.GetAutoInject().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SirHurtAPI.Experimental.LaunchExploit();
        }

        private void openscripthub_Click(object sender, EventArgs e)
        {
            SirHurtAPI.Scripts.OpenScriptHub();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.multipleRBXToggle();
            button3.Text = "Multiple RBX: " + SirHurtAPI.SirHurtAPI.getMultipleRBX().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new exmpleScriptHub().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.oofRBX();
        }
    }
}
