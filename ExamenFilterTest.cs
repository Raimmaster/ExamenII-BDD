using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examen2
{
    [Binding]
    public class ExamenFilterTest
    {
        private List<InventoryTransaction> invTrans = new List<InventoryTransaction>();

        [Given(@"I have the following inventory transaction")]
        public void GivenIHaveTheFollowingInventoryTransaction(Table table)
        {
            var tableSet = table.CreateSet<InventoryTransaction>();
            fillListWithSet(tableSet, invTrans);
        }

        private void fillListWithSet(IEnumerable<InventoryTransaction> tableSet, List<InventoryTransaction> list)
        {
            foreach (var inv in tableSet)
                list.Add(inv);
        }

        [When(@"filter by transacion type '(.*)'")]
        public void WhenFilterByTransacionType(string p0)
        {
            var filteredList = invTrans.Where(inv => inv.TransactionType.Equals(p0)).ToList();
            
            invTrans.Clear();
            invTrans = filteredList;
        }
        
        [Then(@"the transactions should look like")]
        public void ThenTheTransactionsShouldLookLike(Table table)
        {
            var tableList = new List<InventoryTransaction>();
            fillListWithSet(table.CreateSet<InventoryTransaction>() ,tableList);

            for (int i = 0; i < tableList.Count; ++i)
            {
                var firstListElement = invTrans.ElementAt(i);
                var secondListElement = tableList.ElementAt(i);

                Assert.AreEqual(firstListElement.ProductCode, secondListElement.ProductCode);
                Assert.AreEqual(firstListElement.Qty, secondListElement.Qty);
            }
            //Assert.AreEqual(invTrans.ToArray(), tableList.ToArray());
        }
    }
}
