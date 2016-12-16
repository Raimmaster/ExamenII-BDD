using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Moq;

namespace Examen2
{
    [Binding]
    public class ExamenProductsTest
    {
        private Mock<ITransactionable> _transactionMock = new Mock<ITransactionable>();    
        private List<Product> productsWithQtyLessThan = new List<Product>();

        [Given(@"I have the follwing products")]
        public void GivenIHaveTheFollwingProducts(Table table)
        {
            var products = table.CreateSet<Product>();
            _transactionMock.Setup(product => product.GetProducts()).Returns(products);
        }
        
        [Given(@"I have the following inventory transactions")]
        public void GivenIHaveTheFollowingInventoryTransactions(Table table)
        {
            var inventoryTransactions = table.CreateSet<InventoryTransaction>();
            _transactionMock.Setup(transaction => transaction.GetTransactions()).Returns(inventoryTransactions);
        }
        
        [When(@"we check which products needs backorder")]
        public void WhenWeCheckWhichProductsNeedsBackorder()
        {
            var transactionManger = new TransactionManager(_transactionMock.Object);
            productsWithQtyLessThan =  transactionManger.CalculateFinalQuantity(/*_transactionMock.Object.GetProducts()*/);
        }
        
        [Then(@"the following products will appear that needs back order")]
        public void ThenTheFollowingProductsWillAppearThatNeedsBackOrder(Table table)
        {
            var finalProds = new List<Product>(); 
            fillListWithSet(table.CreateSet<Product>(), finalProds);

            for (int i = 0; i < finalProds.Count; ++i)
            {
                var obtainedListProduct = productsWithQtyLessThan.ElementAt(i);
                var finProd = finalProds.ElementAt(i);
                Assert.AreEqual(obtainedListProduct.Code, finProd.Code);
            }
        }

        private void fillListWithSet(IEnumerable<Product> tableSet, List<Product> list)
        {
            foreach (var inv in tableSet)
                list.Add(inv);
        }
    }
}
