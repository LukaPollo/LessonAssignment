using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface IproductOrder
    {
        int Id { get; }
        int productId { get; }
    }
    public interface Iorder
    {
        string name { get; set; }
        decimal price { get; set; }
    }
}
