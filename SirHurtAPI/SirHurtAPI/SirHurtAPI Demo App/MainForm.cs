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
        }

        private void InjectBtn_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.LaunchExploit();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            SirHurtAPI.SirHurtAPI.Execute(scriptBox.Text);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            scriptBox.Clear();
        }
    }
}
