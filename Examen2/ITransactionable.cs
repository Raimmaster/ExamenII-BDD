using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public interface ITransactionable
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<InventoryTransaction> GetTransactions();
    }
}
