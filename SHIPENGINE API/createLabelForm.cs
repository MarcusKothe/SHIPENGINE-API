using SHIPENGINE_API.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SHIPENGINE_API
{
    public partial class createLabelForm : Form
    {
        public createLabelForm()
        {
            InitializeComponent();
        }

        private void createLabelForm_Load(object sender, EventArgs e)
        {
          
        }

        public void AdvancedOptions()
        {

            string bill_to_account = null; //This field is used to bill shipping costs to a third party. This field must be used in conjunction with the bill_to_country_code, bill_to_party, and bill_to_postal_code fields.
            string bill_to_country_code = null; //The two-letter ISO 3166-1 country code of the third-party that is responsible for shipping costs.
            string bill_to_party = null; //Indicates whether to bill shipping costs to the recipient or to a third-party. When billing to a third-party, the bill_to_account, bill_to_country_code, and bill_to_postal_code fields must also be set.
            string bill_to_postal_code = null; //The postal code of the third-party that is responsible for shipping costs.
            bool contains_alcohol = false; //Indicates that the shipment contains alcohol.
            bool delivered_duty_paid = false; //Indicates that the shipper is paying the international delivery duties for this shipment. This option is supported by UPS, FedEx, and DHL Express.
            
            //DRY ICE OBJECT
            bool dry_ice = false; //Indicates if the shipment contain dry ice
            float dry_ice_weight; //The weight of the dry ice in the shipment
            double dry_ice_weight_value = 0;
            string dry_ice_weight_unit;

            bool non_machinable = false; //Indicates that the package cannot be processed automatically because it is too large or irregularly shaped. This is primarily for USPS shipments. See Section 1.2 of the USPS parcel standards for details.
            bool saturday_delivery = false; //Enables Saturday delivery, if supported by the carrier.

            //FEDEX FREIGHT OBJECT Provide details for the Fedex freight service
            string shipper_load_and_count = null;
            string booking_confirmation = null;

            bool use_ups_ground_freight_pricing;
            string freight_class = null;






        }

        private void createLabelbutton_Click(object sender, EventArgs e)
        {
            //Set color and font
            richTextBox2.Text = string.Empty;
            richTextBox2.ForeColor = Color.Black;
            richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Regular);

            try
            {
                //ShipTo Ojbect Variables
                string service_code = serviceCodeTextBox.Text;
                string shipToName = shipToNameTextBox.Text;
                string shipToaddressLine1 = shipToadd1TextBox.Text;
                string shipToaddressLine2 = shipToadd2TextBox.Text;
                string shipTocityLocality = shipToCityTextBox.Text;
                string shipTostateProvince = shipToStProvTextBox.Text;
                int shipTopostalCode = int.Parse(shipToZipTextBox.Text);
                string shipTocountryCode = shipToCntryCdTextBox.Text;

                string shipToaddressResidentialindicator = "No";
                if (residentialCheckbox.Checked)
                {
                    shipToaddressResidentialindicator = "yes";
                }

                //ShipFrom Object Variables
                string shipFromName = shipFrmNameTextBox.Text;
                string shipFromCname = shipFrmComTextBox.Text;
                string shipFromaddressLine1 = shipFrmad1TextBox.Text;
                string shipFromaddressLine2 = shipFrmad2TextBox.Text;
                string shipFromcityLocality = shipFrmCityTextBox.Text;
                string shipFromstateProvince = shipFrmStProvTextBox.Text;
                string shipFrompostalCode = shipFrmZipTextBox.Text;
                string shipFromcountryCode = shipFrmCountryTextBox.Text;

                string shipFromAddressresidentialIndicator = "no";
                if (shipFromresidentialCheckbox.Checked)
                {
                    shipFromAddressresidentialIndicator = "yes";
                }

                //Packages
                float weightValue;
                string weightUnit;

                float dimensionsHeight;
                float dimensionsWidth;
                string dimensionsUnit;
                float dimensionsLength;

                //URI - POST
                WebRequest request = WebRequest.Create("https://api.shipengine.com/v1/labels");
                request.Method = "POST";

                //API Key
                string api_Key = apiKeyTextBox.Text;
                request.Headers.Add("API-key", api_Key);


                //POST REQUEST
                string createLabelrequestBody = "{\r\n  \"shipment\": {\r\n    \"service_code\": \"" + service_code + "\",\r\n    \"ship_to\": {\r\n      \"name\": \"" + shipToName + "\",\r\n      \"address_line1\": \"" + shipToaddressLine1 + "\",\r\n      \"city_locality\": \"" + shipTocityLocality + "\",\r\n      \"state_province\": \""
                    + shipTostateProvince + "\",\r\n      \"postal_code\": \"" + shipTopostalCode.ToString() + "\",\r\n      \"country_code\": \"" + shipTocountryCode + "\",\r\n      \"address_residential_indicator\": \"" + shipToaddressResidentialindicator + "\"\r\n    }" +
                    ",\r\n    \"ship_from\": {\r\n      \"name\": \"" + shipFromName + "\",\r\n      \"company_name\": \" TEST\",\r\n      \"phone\": \"555-555-5555\",\r\n      \"address_line1\": \"4009 Marathon Blvd\",\r\n      \"city_locality\": \"Austin\",\r\n      \"state_province\": \"TX\",\r\n      " +
                    "\"postal_code\": \"78756\",\r\n      \"country_code\": \"US\",\r\n      \"address_residential_indicator\": \"no\"\r\n    },\r\n    \"packages\": [\r\n      {\r\n        \"weight\": {\r\n          \"value\": 20,\r\n          \"unit\": \"ounce\"\r\n        },\r\n        \"dimensions\": {\r\n          \"height\": 6,\r\n " +
                    "         \"width\": 12,\r\n          \"length\": 24,\r\n          \"unit\": \"inch\"\r\n        }\r\n      }\r\n    ]\r\n  }\r\n}";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(createLabelrequestBody);

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                Stream stream = request.GetRequestStream();

                stream.Write(data, 0, data.Length);
                stream.Close();

                WebResponse requestResponse = request.GetResponse();
                stream = requestResponse.GetResponseStream();

                StreamReader parseResponse = new StreamReader(stream);
                richTextBox2.Text = parseResponse.ReadToEnd();

                string responseBodyText = richTextBox2.Text;

                // GET LABEL IMAGE
                //LABEL_DOWNLOAD OBJECT
                int labelDownloadOBJ1 = responseBodyText.IndexOf("\"label_download\"") + "\"label_download\"".Length;
                int labelDownloadOBJ2 = responseBodyText.LastIndexOf("\"form_download\"");
                stream.Close();

                string labelDownloadOBJ3 = responseBodyText.Substring(labelDownloadOBJ1, labelDownloadOBJ2 - labelDownloadOBJ1);
                //Needed to specify as UPS contains two Label download objects

                int imgURL1 = labelDownloadOBJ3.IndexOf("\"png\": \"") + "\"png\": \"".Length;
                int imgURL2 = labelDownloadOBJ3.LastIndexOf(".png");
                stream.Close();

                string imgURL3 = labelDownloadOBJ3.Substring(imgURL1, imgURL2 - imgURL1);

                labelImageBox.Load(imgURL3 + ".png");

                //SAVE LOCAL LOG OF LABEL IMAGE @"..\..\Resources"

                string labelFilepath = @"..\..\Resources\Labels";
                // labelImageBox.Image.Save(labelFilepath, System.Drawing.Imaging.ImageFormat.Png);

                //CLOSE STREAM
                parseResponse.Close();
                stream.Close();

            }
            catch (Exception crateLabelError)
            {
                //Make color red and bold
                richTextBox2.ForeColor = Color.Red;
                richTextBox2.Font = new Font(richTextBox2.Font, FontStyle.Bold);

                richTextBox2.Text = crateLabelError.Message;
            }

        }

    }
}
