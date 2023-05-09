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
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


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


        private void apiKeyTextBox_TextChanged(object sender, EventArgs e)
        {

            try
            {
                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v1/warehouses";

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET";

                //SS AUTH
                //string apiKey = ssAPIkeyTextBox.Text;
                //string apiSecret = ssApiSecretTextBox.Text;
                //requestObject.Credentials = new NetworkCredential(apiKey, apiSecret);

                //SE AUTH
                string engineApiKey = apiKeyTextBox.Text;
                requestObject.Headers.Add("API-key", engineApiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;


                //Get all warehouseId's
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    using (var reader = new StringReader(streamResponse))
                    {

                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            if (currentLine.Contains("warehouse_id") == true)
                            {

                                //Replace "warehouse_id": " ",
                                string WHID = currentLine.Replace(" \"warehouse_id\": \"", "");
                                string WHID2 = WHID.Replace("\",", "");

                                //add to textbox

                                warehouseIDlistBox.Text = WHID2 + "," + Environment.NewLine + warehouseIDlistBox.Text;

                            }
                            else
                            {
                                //remove all lines that dont contain WarehouseId
                                currentLine.Replace(currentLine, "");
                            }
                        }

                        //Add Warehouse Id's to listbox
                        string[] WarehouseIDlist = warehouseIDlistBox.Text.Split(',');

                        foreach (string WarehouseID in WarehouseIDlist)
                        {
                            if (WarehouseID.Trim() == "")
                                continue;
                            warehouseIDlistBox.Items.Add(WarehouseID.Trim());
                        }
                    }
                }
            }
            catch (Exception HTTPexception)
            {
                responseBodyrichTextbox.Text = (HTTPexception.Message);
            }

        }

        private void createLabelbutton_Click(object sender, EventArgs e)
        {
            //Set color and font
            responseBodyrichTextbox.Text = string.Empty;
            responseBodyrichTextbox.ForeColor = Color.Black;
            responseBodyrichTextbox.Font = new Font(responseBodyrichTextbox.Font, FontStyle.Regular);

            try
            {
                //ShipTo Ojbect Variables
                string service_code = serviceCodeTextBox.Text;
                string carrier_code = carrierCodeTextbox.Text;
                string shipToName = shipToNameTextBox.Text;
                string ship_date = shipDateTextBox.Text;
                string shipToaddressLine1 = shipToadd1TextBox.Text;
                string shipToaddressLine2 = shipToadd2TextBox.Text;
                string shipToaddressLine3 = shipToadd3TextBox.Text;
                string shipTocityLocality = shipToCityTextBox.Text;
                string shiptoPhone = shipToPhoneTextBox.Text;
                string shipToCompany = shipToComanyNameTextbox.Text;
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
                string shipFromaddressLine3 = shipFrmad3TextBox.Text;
                string shipFromPhone = shipFrmPhoneTextBox.Text;
                string shipFromCompany = shipFrmComTextBox.Text;
                string shipFromcityLocality = shipFrmCityTextBox.Text;
                string shipFromstateProvince = shipFrmStProvTextBox.Text;
                string shipFrompostalCode = shipFrmZipTextBox.Text;
                string shipFromcountryCode = shipFrmCountryTextBox.Text;

                string shipFromAddressresidentialIndicator = "no";
                if (shipFromresidentialCheckbox.Checked)
                {
                    shipFromAddressresidentialIndicator = "yes";
                }

                //warehouse id
                string warehouse_id = null;
                if (warehouseIdTextBox.Text != string.Empty)
                {
                    warehouse_id = warehouseIdTextBox.Text;
                }

                //confirmation
                string confirmation = "none";
                if(confirmationTextBox.Text != "none")
                {
                    confirmation = confirmationTextBox.Text;
                }

                //Is Return?
                string is_returnString = "false";

                bool is_return = false;
                if (isReturnCheckBox.Checked)
                {
                    is_return = true;
                    is_returnString = "true";
                }

                //Packages
                float weightValue = float.Parse(packageweightValueTextBox.Text);
                string weightUnit = packageweightUnitTextBox.Text;

                float dimensionsHeight = float.Parse(packageHeightTextBox.Text);
                float dimensionsWidth = float.Parse(packageWidthtextBox.Text);
                string dimensionsUnit = packageDimensionsUnitTextBox.Text;
                float dimensionsLength = float.Parse(packageLengthTextBox.Text);

                //Advanced Options Region
                #region Advanced Options

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

                bool use_ups_ground_freight_pricing; //Whether to use UPS Ground Freight pricing(https://www.shipengine.com/docs/shipping/ups-ground-freight/). If enabled, then a freight_class must also be specified.
                string freight_class = null; //The National Motor Freight Traffic Association freight class, such as "77.5", "110", or "250".

                string custom_field1 = null; //An arbitrary field that can be used to store information about the shipment.
                string custom_field2 = null; //An arbitrary field that can be used to store information about the shipment.
                string custom_field3 = null; //An arbitrary field that can be used to store information about the shipment.

                string origin_type = null; //Indicates if the package will be picked up or dropped off by the carrier 

                bool shipper_release;

                //COLLECT ON DELIVERY OBJECT
                string payment_type = null;
                //payment object "payment_amount"
                string currency = null; //The currencies that are supported by ShipEngine are the ones that specified by ISO 4217: https://www.iso.org/iso-4217-currency-codes.html
                double amount = 0;

                bool third_party_consignee = false; //Third Party Consignee option is a value-added service that allows the shipper to supply goods without commercial invoices being attached

                #endregion 

                //URI - POST
                WebRequest request = WebRequest.Create("https://api.shipengine.com/v1/labels");
                request.Method = "POST";

                //API Key
                string api_Key = apiKeyTextBox.Text;
                request.Headers.Add("API-key", api_Key);


                //POST REQUEST
                string createLabelrequestBody = "{\r\n    \"shipment\": " +
                    "{\r\n        \"validate_address\": \"no_validation\"" +
                    ",\r\n        \"carrier_id\": \"" + carrier_code + "\"" +
                    ",\r\n        \"warehouse_id\": \"" + warehouse_id + "\"" +
                    ",\r\n        \"service_code\": \"" + service_code + "\"" +
                    ",\r\n        \"external_order_id\": null," +
                    "\r\n        \"ship_date\": \"" + ship_date + "\"" +
                    ",\r\n        \"is_return_label\": " + is_returnString + "," +
                    "\r\n\r\n        \"items\": []," +
                    "\r\n\r\n        \"ship_to\": {\r\n            \"name\": \"" + shipToName + "\"," +
                    "\r\n            \"phone\": \"" + shiptoPhone + "\"," +
                    "\r\n            \"company_name\": \"" + shipToCompany + "\"," +
                    "\r\n            \"address_line1\": \"" + shipToaddressLine1 + "\"," +
                    "\r\n            \"address_line2\": \"" + shipToaddressLine2 + "\"," +
                    "\r\n            \"address_line3\": \"" + shipToaddressLine3 + "\"," +
                    "\r\n            \"city_locality\": \"" + shipTocityLocality + "\"," +
                    "\r\n            \"state_province\": \"" + shipTostateProvince + "\"," +
                    "\r\n            \"postal_code\": \"" + shipTopostalCode + "\"," +
                    "\r\n            \"country_code\": \"" + shipTocountryCode + "\"," +
                    "\r\n            \"address_residential_indicator\": \"" + shipToaddressResidentialindicator + "\"\r\n        }," +
                    "\r\n\r\n        \"ship_from\": {\r\n            \"name\": \"" + shipFromName + "\"," +
                    "\r\n            \"phone\": \"" + shipFromPhone + "\"," +
                    "\r\n            \"company_name\": \"" + shipFromCname + "\"," +
                    "\r\n            \"address_line1\": \"" + shipFromaddressLine1 + "\"," +
                    "\r\n            \"address_line2\": \"" + shipFromaddressLine2 + "\"," +
                    "\r\n            \"address_line3\": \"" + shipFromaddressLine3 + "\"," +
                    "\r\n            \"city_locality\": \"" + shipFromcityLocality + "\"," +
                    "\r\n            \"state_province\": \"" + shipFromstateProvince + "\"," +
                    "\r\n            \"postal_code\": \"" + shipFrompostalCode + "\"," +
                    "\r\n            \"country_code\": \"" + shipFromcountryCode + "\"," +
                    "\r\n            \"address_residential_indicator\": \"" + shipFromAddressresidentialIndicator + "\"\r\n        }," +
                    "\r\n\r\n        \"confirmation\": \"" + confirmation + "\",\r\n\r\n        \"advanced_options\": {" +
                    "\r\n            \"bill_to_account\": null," +
                    "\r\n            \"bill_to_country_code\": null," +
                    "\r\n            \"bill_to_party\": null," +
                    "\r\n            \"bill_to_postal_code\": null," +
                    "\r\n            \"canada_delivered_duty\": null," +
                    "\r\n            \"contains_alcohol\": \"false\"," +
                    "\r\n            \"delivered_duty_paid\": \"false\"," +
                    "\r\n            \"non_machinable\": \"false\"," +
                    "\r\n            \"saturday_delivery\": \"false\"," +
                    "\r\n            \"third-party-consignee\": \"false\"," +
                    "\r\n            \"ancillary_endorsements_option\": null," +
                    "\r\n            \"freight_class\": null," +
                    "\r\n            \"custom_field_1\": null," +
                    "\r\n            \"custom_field_2\": null," +
                    "\r\n            \"custom_field_3\": null," +
                    "\r\n            \"return_pickup_attempts\": null," +
                    "\r\n\r\n            \"dry_ice\": \"false\"," +
                    "\r\n            \"dry_ice_weight\": {" +
                    "\r\n                \"value\": \"0.00\"," +
                    "\r\n                \"unit\": \"pound\"\r\n            }," +
                    "\r\n\r\n            \"collect_on_delivery\": {" +
                    "\r\n                \"payment_type\": \"none\"," +
                    "\r\n                \"payment_amount\": {" +
                    "\r\n                    \"currency\": \"usd\"," +
                    "\r\n                    \"amount\": \"0.00\"\r\n                }\r\n            }\r\n        }," +
                    "\r\n\r\n        \"origin_type\": null," +
                    "\r\n        \"insurance_provider\": \"none\"," +
                    "\r\n        \"packages\": [\r\n            {" +
                    "\r\n                \"package_code\": \"package\"," +
                    "\r\n                \"weight\": {\r\n                    \"value\": " + weightValue + "," +
                    "\r\n                    \"unit\": \"" + weightUnit + "\"\r\n                }," +
                    "\r\n                \"dimensions\": {\r\n                    \"unit\": \"" + dimensionsUnit + "\"," +
                    "\r\n                    \"length\": " + dimensionsLength + "," +
                    "\r\n                    \"width\": " + dimensionsWidth + "," +
                    "\r\n                    \"height\": " + dimensionsHeight + "\r\n                }," +
                    "\r\n                \"insured_value\": {" +
                    "\r\n                    \"currency\": \"usd\"," +
                    "\r\n                    \"amount\": 0.00\r\n                }," +
                    "\r\n                \"label_messages\": {" +
                    "\r\n                    \"reference1\": null," +
                    "\r\n                    \"reference2\": null," +
                    "\r\n                    \"reference3\": null" +
                    "\r\n                },\r\n                \"external_package_id\": 0" +
                    "\r\n            }\r\n        ]" +
                    "\r\n    }" +
                    "\r\n}";

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
                responseBodyrichTextbox.Text = parseResponse.ReadToEnd();

                string responseBodyText = responseBodyrichTextbox.Text;

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
                responseBodyrichTextbox.ForeColor = Color.Red;
                responseBodyrichTextbox.Font = new Font(responseBodyrichTextbox.Font, FontStyle.Bold);

                responseBodyrichTextbox.Text = crateLabelError.Message;
            }

        }

        private void getRequestFormbutton_Click(object sender, EventArgs e)
        {
            getRequestForm form2 = new getRequestForm();
            form2.ShowDialog();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //URL SOURCE
                string URLstring = "https://api.shipengine.com/v1/warehouses/" + warehouseIDlistBox.Text;

                //REQUEST
                WebRequest requestObject = WebRequest.Create(URLstring);
                requestObject.Method = "GET";

                //SS AUTH
                //string apiKey = ssAPIkeyTextBox.Text;
                //string apiSecret = ssApiSecretTextBox.Text;
                //requestObject.Credentials = new NetworkCredential(apiKey, apiSecret);

                //SE AUTH
                string engineApiKey = apiKeyTextBox.Text;
                requestObject.Headers.Add("API-key", engineApiKey);

                //RESPONSE
                HttpWebResponse responseObjectGet = null;
                responseObjectGet = (HttpWebResponse)requestObject.GetResponse();
                string streamResponse = null;

               

                //Get Address
                using (Stream stream = responseObjectGet.GetResponseStream())
                {
                    StreamReader responseRead = new StreamReader(stream);
                    streamResponse = responseRead.ReadToEnd();

                    //
                    int originAddress1 = streamResponse.IndexOf(" \"origin_address\": ") + " \"origin_address\": ".Length;
                    int originAddress2 = streamResponse.LastIndexOf(" \"return_address\":");

                    string originAddress = streamResponse.Substring(originAddress1, originAddress2 - originAddress1);

                    using (var reader = new StringReader(originAddress))
                    {
                        for (string currentLine = reader.ReadLine(); currentLine != null; currentLine = reader.ReadLine())
                        {

                            //NAME
                            if (currentLine.Contains(" \"name\": \"") == true)
                            {

                                //Replace "warehouse_id": " ",
                                string Wh_Name1 = currentLine.Replace("\"name\": \"", "");
                                string Wh_Name = Wh_Name1.Replace("\",", "");

                                //add to textbox

                                shipFrmNameTextBox.Text = Wh_Name;

                            }

                            //PHONE
                            if(currentLine.Contains("\"phone\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_Phone1 = currentLine.Replace("\"phone\": \"", "");
                                string Wh_Phone = Wh_Phone1.Replace("\",", "");

                                //add to textbox

                                shipFrmPhoneTextBox.Text = Wh_Phone;
                            }

                            //Company
                            if (currentLine.Contains("\"company_name\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_CompanyName1 = currentLine.Replace("\"company_name\": \"", "");
                                string Wh_CompanyName = Wh_CompanyName1.Replace("\",", "");

                                //add to textbox

                                shipFrmComTextBox.Text = Wh_CompanyName;
                            }

                            //AddressLine 1
                            if (currentLine.Contains("\"address_line1\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_AddressL1 = currentLine.Replace("\"address_line1\": \"", "");
                                string Wh_AddressL = Wh_AddressL1.Replace("\",", "");

                                //add to textbox

                                shipFrmad1TextBox.Text = Wh_AddressL;
                            }

                            //AddressLine 2
                            if (currentLine.Contains("\"address_line2\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_AddressL2 = currentLine.Replace("\"address_line2\": \"", "");
                                string Wh_AddressL3 = Wh_AddressL2.Replace("\",", "");

                                //add to textbox

                                shipFrmad2TextBox.Text = Wh_AddressL3;
                            }

                            //AddressLine 3
                            if (currentLine.Contains("\"address_line3\": ") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_AddressL4 = currentLine.Replace("\"address_line3\": ", "");
                                string Wh_AddressL5 = Wh_AddressL4.Replace("\",", "");

                                //add to textbox

                                shipFrmad3TextBox.Text = Wh_AddressL5;
                            }

                            //City
                            if (currentLine.Contains("\"city_locality\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_City1 = currentLine.Replace("\"city_locality\": \"", "");
                                string Wh_City = Wh_City1.Replace("\",", "");

                                //add to textbox

                                shipFrmCityTextBox.Text = Wh_City;
                            }

                            //State Province
                            if (currentLine.Contains("\"state_province\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_StateProvince1 = currentLine.Replace("\"state_province\": \"", "");
                                string Wh_StateProvince = Wh_StateProvince1.Replace("\",", "");

                                //add to textbox

                                shipFrmStProvTextBox.Text = Wh_StateProvince;
                            }

                            //Postal Code
                            if (currentLine.Contains("\"postal_code\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                string Wh_PostalCode1 = currentLine.Replace("\"postal_code\": \"", "");
                                string Wh_PostalCode = Wh_PostalCode1.Replace("\",", "");

                                //add to textbox

                                shipFrmZipTextBox.Text = Wh_PostalCode;
                            }

                            //Country Code
                            if (currentLine.Contains("\"country_code\": \"") == true)
                            {
                                //Replace "warehouse_id": " ",
                                
                                string Wh_CountryCode1 = currentLine.Replace("\"country_code\": \"", "");
                                string Wh_CountryCode = Wh_CountryCode1.Replace("\",", "");
                                

                                //add to textbox

                                shipFrmCountryTextBox.Text = Wh_CountryCode;
                                //shipFrmCountryTextBox.Text = shipFrmCountryTextBox.Text.Replace("    ","");

                            }

                            IList<T> GetAllControls<T>(Control control) where T : Control
                            {
                                var TextBoxes = new List<T>();
                                foreach (Control item in control.Controls)
                                {
                                    var ctr = item as T;
                                    if (ctr != null)
                                        TextBoxes.Add(ctr);
                                    else
                                        TextBoxes.AddRange(GetAllControls<T>(item));
                                }
                                return TextBoxes;
                            }

                            var textBoxesList = GetAllControls<System.Windows.Forms.TextBox>(this);
                            foreach (System.Windows.Forms.TextBox TextBoxes in textBoxesList)
                            {
                                //"    Zero Cool"
                                TextBoxes.Text = TextBoxes.Text.Replace("    ", "");
                            }
                        }
                    }
                }
            }
            catch (Exception HTTPexception)
            {
                responseBodyrichTextbox.Text = (HTTPexception.Message);
            }
        }
    }
}
