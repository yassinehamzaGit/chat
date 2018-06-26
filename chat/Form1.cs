using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Nexmo.Api;
using Nexmo.Api.Voice;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Apis.Translate.v2.Data;
using TranslationsResource = Google.Apis.Translate.v2.Data.TranslationsResource;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;
using System.IO;
using Google.Apis.Util;
using static Google.Apis.Drive.v3.CommentsResource;
using System.Web.Http;

namespace chat
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
          
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private void addContactButton_Click(object sender, EventArgs e)
        {
            Form4 h = new Form4();
            h.Show();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        protected void addConversationTextBox(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("Me: " + sendMessageText.Text);  
            String message = sendMessageText.Text;
            String credentialsFilePath = "C:\\Users\\yassinehamza\\Downloads\\AutoSim-e21f13837857.json";
            String nexmoApiKeyPath = "C:\\Users\\yassinehamza\\Downloads\\ApiKey.txt";
            String apiSecret =System.IO.File.ReadAllText(nexmoApiKeyPath);
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            TranslationClient client = TranslationClient.Create();
            var response = client.TranslateText(message, "ru");
            this.listBox1.Items.Add("Me: " + response.TranslatedText);
            var client2 = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "6faa305b",
                ApiSecret = apiSecret
            });

            /*
            var results = client2.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Acme Inc",
                to = "+491783452896",
                text = response.TranslatedText,
                type = "unicode"
            });
            */
            this.sendMessageText.Text = "";
        }
        public ActionResult Get([FromUri]SMS.SMSInbound response)
        {
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


    }
}
