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
		List<JToken> list = null;
		private readonly static string DllName = "[SirHurtAPI]";
		public ScriptHub()
        {
            InitializeComponent();
			try
			{
				using (WebClient wc = new WebClient())
				{
					Console.WriteLine(DllName + "Starting download script list async...");
					ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(SirHurtAPI.AlwaysGoodCertificate);
					ServicePointManager.Expect100Continue = true;
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
					wc.DownloadStringCompleted += Wc_DownloadStringCompleted;
					wc.DownloadStringAsync(new Uri("https://asshurthosting.pw/upl/UIScriptHub/fetch.php"));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(DllName + "Unable to download script list...");
				Console.WriteLine(ex);
			}
		}
		public static Bitmap GetImageByName(string imageName)
		{
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			string resourceName = asm.GetName().Name + ".Properties.Resources";
			var rm = new System.Resources.ResourceManager(resourceName, asm);
			return (Bitmap)rm.GetObject(imageName);
		}

		private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			Console.WriteLine(DllName + "Done!, decoding");
			string string_ = e.Result;
			list = JObject.Parse(string_)["scripts"].Children().Children<JToken>().ToList<JToken>();
			foreach (JToken jtoken in list)
			{
				ScriptLstBox.Items.Add(jtoken["Name"].ToString());
			}
			ScriptLstBox.SetSelected(0, true);
			Console.WriteLine(DllName + "Decode sucess.");
		}
		private object prevSelItem = null;

		private async void ScriptLstBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (prevSelItem != ScriptLstBox.SelectedItem)
			{
				prevSelItem = ScriptLstBox.SelectedItem;
				string b = ScriptLstBox.SelectedItem.ToString();
				foreach (JToken jtoken in list)
				{
					if (jtoken["Name"].ToString() == b)
					{
						previewImg.Image = GetImageByName("asshurt2");
						previewTxt.Text = "Loading preview...";
						Console.WriteLine(DllName + "Loaded wait image + wait text");
						Console.WriteLine(DllName + "Correct Name!, downloading image");
						await Task.Delay(50);
						ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(SirHurtAPI.AlwaysGoodCertificate);
						ServicePointManager.Expect100Continue = true;
						ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
						previewImg.LoadAsync(jtoken["Picture"].ToString());
					}
				}
			}
		}
		private async void exec_Click(object sender, EventArgs e)
		{
			string text = ScriptLstBox.SelectedItem.ToString();
			Console.WriteLine(DllName + "Script selected: " + text);
			foreach (JToken jtoken in list)
			{
				if (jtoken["Name"].ToString() == text)
				{
					text = jtoken["FileName"].ToString();
					Console.WriteLine(DllName + "File name:" + text);
				}
			}
			try
			{
				SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=" + text + "'))()", true);
			}
			catch (Exception ex)
			{
				if (ex.ToString() == DllName + "Cleaning sirhurt.dat")
				{
					MessageBox.Show("Don't execute script too fast!", "SirHurtAPI");
				}
			}
		}

		private void previewImg_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Console.WriteLine(DllName + "Downloaded image + shown image, changing description...");
			string b = ScriptLstBox.SelectedItem.ToString();
			foreach (JToken jtoken in list)
			{
				if (jtoken["Name"].ToString() == b)
				{
					previewTxt.Text = jtoken["Desc"].ToString();
					Console.WriteLine(DllName + "Changed Description text");
				}
			}
		}
	}
}
