using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
    class Node<T>
    {
      public  List<Node<T>> Children;
        public bool HasChild { get { return Children.Any(); } }
        T Item { get;set;}
        public Node(T item)
        {
            Children = new List<Node<T>>();
            this.Item = item;
        }

        public Node<T> AddChild(T item)
        {
            Node<T> node = new Node<T>(item);
            Children.Add(node);
            return node;

        }


        public override string ToString()
        {
            return Item.ToString();
        }

 



    }
}
