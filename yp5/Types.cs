using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yp5
{
    public class ItemCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }

    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }

        // Связь с категорией
        public ItemCategory ItemCategory { get; set; }
    }

    public class ItemType
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
    }

}
