using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DoubleLinkedList<T> : IStack<T>
    {
        private class Node
        {
            public T data { get; set; }
            public Node prevNode { get; set; }
            public Node nextNode { get; set; }

            public Node(T newData)
            {
                data = newData;
                prevNode = null;
                nextNode = null;
            }
        }

        private Node headNode { get; set; }
        private Node currentNode { get; set; }
        public int Count { get; private set; }

        public void Push(T data)
        {
            Node newNode = new Node(data);
            newNode.prevNode = null;
            newNode.nextNode = null;

            if (headNode == null && currentNode == null)
            {
                headNode = newNode;
            }
            else
            {
                currentNode.nextNode = newNode;
                newNode.prevNode = currentNode;
            }
            currentNode = newNode;
            Count++;
            
        }

        public T Pop()
        {
            T data;
            if (headNode == null)   //if list doesn't contain elements
                throw new InvalidOperationException("Stack underflow");
            if (headNode.nextNode == null && headNode.prevNode == null) //if list contains one element
            {
                data = headNode.data;
                headNode = null;
                return data;
            }
            //if list contains more than 1 elements
            data = currentNode.data;            
            currentNode = currentNode.prevNode; //set the current node as last but one node
            currentNode.nextNode.prevNode = null;   //using the current node, set the prev node of deleted node to null
            currentNode.nextNode.nextNode = null;   //using the current node, st the next node of deleted node to null
            currentNode.nextNode = null;
            Count--;
            return data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node tempNode = headNode;
            while (tempNode != null)
            {
                yield return tempNode.data;
                tempNode = tempNode.nextNode;
            }
        }

    }
}
