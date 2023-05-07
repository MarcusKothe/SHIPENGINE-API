using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Drawing.Text;
using System.Text.Json;
using SHIPENGINE_API.Resources.Classes;

namespace SHIPENGINE_API
{
    public partial class getRequestForm : Form
    {
        public getRequestForm()
        {
            InitializeComponent();
        }

        private void requestForm_Load(object sender, EventArgs e)
        {


        }

        private void requestbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                //URL SOURCE
                string URLstring = urlTexbox.Text;

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET";

                //SS AUTH
                string apiKey = ssAPIkeyTextBox.Text;
                string apiSecret = ssApiSecretTextBox.Text;
                requestObject.Credentials = new NetworkCredential(apiKey, apiSecret);
               
                //SE AUTH
                string engineApiKey = engineApiKeyTextBox.Text;
                requestObject.Headers.Add("API-key", engineApiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();

                //DATA
                string streamResponse = null;
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    format_json(streamResponse);
                    shipengineResponseBox.Text = streamResponse;

                    responseRead.Close();
                }

            }
            catch (Exception HTTPexception)
            {
                shipengineResponseBox.Text = (HTTPexception.Message);
            }

        }
        private static string format_json(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }


        private void addSeUrlButton_Click(object sender, EventArgs e)
        {
            urlTexbox.Text = string.Empty;
            urlTexbox.Text = "https://api.Shipengine.com/v1";
        }

        private void addSsUrlButton_Click(object sender, EventArgs e)
        {
            urlTexbox.Text = string.Empty;
            urlTexbox.Text = "https://ssapi.shipstation.com";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createLabelForm form2 = new createLabelForm();
            form2.ShowDialog();

        }
    }
}
