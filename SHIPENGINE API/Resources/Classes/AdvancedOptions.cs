using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHIPENGINE_API.Resources.Classes
{
    public class AdvancedOptions
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

        string test = "";

    }
}
