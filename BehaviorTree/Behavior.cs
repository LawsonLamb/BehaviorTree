using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTree
{
    class Behavior
    {
        public string behavior;
        public string response;
        public List<Behavior> Children;
        public bool HasChild { get { return Children.Any(); } }
        public Behavior(string behavior, string response)
        {
            Children = new List<Behavior>();
            this.behavior = behavior;
            this.response = response;
        }

        public override string ToString()
        {
            return " Behavior: " + this.behavior + " Response: " + this.response;
        }

        public Behavior AddChild(Behavior b)
        {
            Children.Add(b);
            return b;
        }


    }
}
