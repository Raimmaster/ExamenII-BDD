using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Examen2
{
    [Binding]
    public class ExamenMinMaxTest
    {
        private Tuple<int, int> minMax;
        private Tree arbol = new Tree();

        [Given(@"I have the following tree nodes")]
        public void GivenIHaveTheFollowingTreeNodes(Table table)
        {
            var nodeTable = table.CreateSet<AlterNode>();
            List<AlterNode> nodeList = new List<AlterNode>();
            fillListWithSet(nodeTable, nodeList);

            fillTreeWithList(arbol, nodeList); 
        }

        private void fillTreeWithList(Tree arbol, List<AlterNode> nodeList)
        {
            foreach(var node in nodeList)
            {
                arbol.Insert(node.Value);
            }
        }

        private void fillListWithSet(IEnumerable<AlterNode> tableSet, List<AlterNode> list)
        {
            foreach (var inv in tableSet)
                list.Add(inv);
        }

        [When(@"get tree stats is called")]
        public void WhenGetTreeStatsIsCalled()
        {
            minMax = arbol.GetStats();
        }
        
        [Then(@"max value should be (.*) and min value should be (.*)")]
        public void ThenMaxValueShouldBeAndMinValueShouldBe(int p0, int p1)
        {
            Assert.AreEqual(minMax.Item1, p1);
            Assert.AreEqual(minMax.Item2, p0);
        }
    }
}
