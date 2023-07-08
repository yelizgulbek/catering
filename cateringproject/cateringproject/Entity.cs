using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cateringproject
{
    public class Customers
    {
        public Guid customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }

        public override string ToString()
        {
            return $"{first_name}{last_name}";
        }

    }


    public class Menus
    {
        public Guid menu_id { get; set; }
        public string menu_name { get; set; }
        public string menu_description { get; set; }
        public string price { get; set; }

        public override string ToString()
        {
            return $"{menu_name}";
        }

    }

    public class Order_details
    {
        public Guid order_detail_id { get; set; }
        public string order_id { get; set; }
        public string menu_id { get; set; }
        public string quantity { get; set; }

    }

    public class Orders
    {
        public Guid order_id { get; set; }
        public string customer_id { get; set; }
        public string order_date { get; set; }
        public string event_date { get; set; }
        public string event_type { get; set; }
        public string guest_count { get; set; }
    }


    public class Payments
    {
        public Guid payment_id { get; set; }
        public string order_id { get; set; }
        public string payment_type { get; set; }
        public string  payment_amount { get; set; }
        public string payment_date{ get; set; }

    }
}
