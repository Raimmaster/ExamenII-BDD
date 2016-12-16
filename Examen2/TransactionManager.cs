using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    class TransactionManager
    {
        private ITransactionable _transactionRepository;

        public TransactionManager(ITransactionable transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<Product> CalculateFinalQuantity(/*IEnumerable<Product> products*/)
        {
            var transactions = _transactionRepository.GetTransactions();

            var listProductsLessThan = new List<Product>();
            
            foreach(var product in _transactionRepository.GetProducts())
            {
                InsertProductWithQtyLessThan(transactions, product, listProductsLessThan);
            }

            return listProductsLessThan;
        }

        private static void InsertProductWithQtyLessThan(IEnumerable<InventoryTransaction> transactions, Product product, List<Product> listProductsLessThan)
        {
            var quantity = 0;

            foreach (var transaction in transactions)
            {
                //addTransactionIfLowerThan(product, transaction);
                if (product.Code == transaction.ProductCode)
                {
                    string tranType = transaction.TransactionType;
                    if (tranType.Equals("In"))
                        quantity += transaction.Qty;
                    else
                        quantity -= transaction.Qty;
                }
            }

            if (quantity < 10)
            {
                listProductsLessThan.Add(product);
            }
        }   
    }
}
