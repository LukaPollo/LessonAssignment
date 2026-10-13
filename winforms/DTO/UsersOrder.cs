using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winforms
{
    internal class UsersOrder
    {
        public string UserName { get; set; }
        public int OrderId { get; set; }
        public decimal OrderValue { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
