using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SirHurtAPI;

namespace SirHurtAPI_Demo_App
{
    public partial class exmpleScriptHub : Form
    {
        public exmpleScriptHub()
        {
            InitializeComponent();
            var arrey = Scripts.DLScriptHub();
            foreach (string KaguyaSamaIsBestGirl in arrey)
            {
                listBox1.Items.Add(KaguyaSamaIsBestGirl);
            }
            listBox1.SelectedIndex = 0;
        }
        private object prevSelItem = null;

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (prevSelItem != listBox1.SelectedItem)
            {
                prevSelItem = listBox1.SelectedItem;
                richTextBox1.Text = "Loading preview...";
                var Tuples = await Scripts.GetScriptInfoFromName(prevSelItem.ToString());
                richTextBox1.Text = Tuples.Item1;
                pictureBox1.LoadAsync(Tuples.Item2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = listBox1.SelectedItem.ToString();
            Scripts.ExecuteFromName(text);
        }
    }
}
