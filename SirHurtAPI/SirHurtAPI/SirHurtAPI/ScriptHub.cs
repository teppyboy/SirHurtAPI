using Newtonsoft.Json.Linq;
using SirHurtAPI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirHurtAPI
{
    internal partial class ScriptHub : Form
    {
		internal static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
		{
			return true;
		}
		public ScriptHub()
        {
            InitializeComponent();
			var arrey = Scripts.DLScriptHub();
			foreach (string KaguyaSamaIsBestGirl in arrey)
			{
				ScriptLstBox.Items.Add(KaguyaSamaIsBestGirl);
			}
			ScriptLstBox.SelectedIndex = 0;
		}
		public static Bitmap GetImageByName(string imageName)
		{
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			string resourceName = asm.GetName().Name + ".Properties.Resources";
			var rm = new System.Resources.ResourceManager(resourceName, asm);
			return (Bitmap)rm.GetObject(imageName);
		}
		private object prevSelItem = null;

		private async void ScriptLstBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (prevSelItem != ScriptLstBox.SelectedItem)
			{
				prevSelItem = ScriptLstBox.SelectedItem;
				previewImg.Image = GetImageByName("asshurt2");
				previewTxt.Text = "Loading preview...";
				var Tuples = await Scripts.GetScriptInfoFromName(prevSelItem.ToString());
				previewTxt.Text = Tuples.Item1;
				previewImg.LoadAsync(Tuples.Item2);
			}
		}
		private void exec_Click(object sender, EventArgs e)
		{
			string text = ScriptLstBox.SelectedItem.ToString();
			Scripts.ExecuteFromName(text);
			
		}
	}
}
