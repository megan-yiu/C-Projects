using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    public class InvItem
    {
        private int itemNo;
        private string description;
        private decimal price;

        public InvItem()
        {
        }

        public InvItem(int itemNo, string description, decimal price)
        {
            this.itemNo = itemNo;
            this.description = description;
            this.price = price;
        }

        public int ItemNo
        {
            get
            {
                return itemNo;
            }
            set
            {
                itemNo = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public virtual string GetDisplayText() => itemNo + "    " + description + " (" + price.ToString("c") + ")";
    }

    public class Plant : InvItem
    {
        private string size;
        
        public Plant()
        {
        }

        public Plant(int itemNo, string size, string description, 
            decimal price) : base(itemNo, description, price)
        {
            this.Size = size;
        }

        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public override string GetDisplayText() =>
            ItemNo + "    " + Size + " " + Description 
            + " (" + Price.ToString("c") + ")";
    }
    public class Supply : InvItem
    {
        private string manufacturer;

        public Supply()
        {
        }

        public Supply(int itemNo,string manufacturer, string description, 
            decimal price) : base(itemNo, description, price)
        {
            this.Manufacturer = manufacturer;
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }

        public override string GetDisplayText() =>
            ItemNo + "    " + Manufacturer + " "+ Description
            + " (" + Price.ToString("c") + ")";
    }

}
