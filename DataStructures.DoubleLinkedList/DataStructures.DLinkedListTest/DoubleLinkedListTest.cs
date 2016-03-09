using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataStructures.DLinkedListTest
{
    [TestClass]
    public class DoubleLinkedListTest
    {

        [TestMethod]
        public void CanAddSingleNodeToDoubleLinkedList()
        {
            var list = new DataStructures.DoubleLinkedList<int>();
            list.Push(10);
            Assert.IsTrue(list.Count == 1);
        }

        [TestMethod]
        public void CanAddMultipleNodesToDoubleLinkedList()
        {
            var list = new DataStructures.DoubleLinkedList<int>();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            list.Push(40);
            Assert.IsTrue(list.Count == 4);
        }

        [TestMethod]
        public void CanRemoveNodeFromDoubleLinkedList()
        {
            var list = new DataStructures.DoubleLinkedList<int>();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            var deletedItem = list.Pop();
            Assert.IsTrue(deletedItem == 30 && list.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CanRemoveNodeFromEmptyDoubleLinkedList()
        {
            var list = new DataStructures.DoubleLinkedList<int>();
            var deletedItem = list.Pop();
        }

        [TestMethod]
        public void CanGetNodesFromDoubleLinkedList()
        {
            List<int> stackInput = new List<int>() { 10, 20, 30, 40, 50 };
            var list = new DataStructures.DoubleLinkedList<int>();
            foreach (var integerItem in stackInput)
            {
                list.Push(integerItem);
            }
            List<int> stackOutput = new List<int>();
            foreach (var listItem in list)
            {
                stackOutput.Add(listItem);
            }

            CollectionAssert.AreEqual(stackInput, stackOutput);
        }

    }
}
