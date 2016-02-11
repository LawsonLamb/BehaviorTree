using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace BehaviorTree
{
    class Tree
    {
        // public Node<Behavior> root;
        public Behavior root;
        public Tree()
        {


        }


        public void BuildTree(string fileName)
        {

            XmlTextReader reader = new XmlTextReader(fileName);


            while (reader.Read())
            {


                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                                              // Console.Write("<" + reader.Name);
                        string attribute = reader["behavior"];
                        Console.Write(" " + attribute);
                        attribute = reader["response"];
                        Console.Write(" " + attribute);
                        //   Console.WriteLine(">");
                        break;

                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                                                 //  Console.Write("</" + reader.Name);
                                                 // Console.WriteLine(">");
                        break;
                }
            }






        }

        public void BuildTreeManually()
        {/*
            root = new Node<Behavior>(new Behavior("root", "root"));

             Node<Behavior> idle = root.AddChild((new Behavior("Idle","")));
                idle.AddChild(new Behavior("", "Use Computer"));
                idle.AddChild(new Behavior("", "Patrol"));

            Node<Behavior> Incoming =  root.AddChild((new Behavior("Incoming Projectile", "")));
                Incoming.AddChild((new Behavior("", "Evade")));

            Node<Behavior> combat =  root.AddChild((new Behavior("Combat", "")));
                  Node<Behavior> Melee = combat.AddChild((new Behavior("Melee", "")));
                              Melee.AddChild((new Behavior("", "Flee")));
                              Melee.AddChild((new Behavior("", "Attack")));

            Node<Behavior> Ranged = combat.AddChild((new Behavior("Ranged", "")));
                             Ranged.AddChild((new Behavior("", "Weapon 1")));
                             Ranged.AddChild((new Behavior("", "Weapon 2")));
                              Ranged.AddChild((new Behavior("", "Weapon 3")));

            */


            root = new Behavior("root", "root");

            Behavior idle = root.AddChild((new Behavior("Idle", "")));
            idle.AddChild(new Behavior("", "Use Computer"));
            idle.AddChild(new Behavior("", "Patrol"));

            Behavior Incoming = root.AddChild((new Behavior("Incoming Projectile", "")));
            Incoming.AddChild((new Behavior("", "Evade")));

            Behavior combat = root.AddChild((new Behavior("Combat", "")));
            Behavior Melee = combat.AddChild((new Behavior("Melee", "")));
            Melee.AddChild((new Behavior("", "Flee")));
            Melee.AddChild((new Behavior("", "Attack")));

            Behavior Ranged = combat.AddChild((new Behavior("Ranged", "")));
            Ranged.AddChild((new Behavior("", "Weapon 1")));
            Ranged.AddChild((new Behavior("", "Weapon 2")));
            Ranged.AddChild((new Behavior("", "Weapon 3")));







        }


        public void Print()
        {
            traverse(root);


        }

        public void traverse(Behavior child)
        {
            Console.WriteLine(child.ToString());
            if (child.HasChild)
            {
                foreach (Behavior b in child.Children)
                {

                    traverse(b);

                }

            }



        }

        public void Search(String Behavior)
        {

            Behavior result = search(root,Behavior);
            if (result != null)
            {
             Console.WriteLine("RESULT: "+ result);

            }
            
           


        }


        Behavior search(Behavior child,string Value)
        {

            if (child.behavior == Value)
            {
                return child;
            }
            else if (child.HasChild)
            {

                foreach (Behavior b in child.Children)
                {
                    Behavior temp = search(b, Value);
                    if (temp != null)
                    {
                        Console.WriteLine(temp);
                        if (temp.behavior == Value)
                        {
                       
                            return temp;


                        }
                    }

                }
            }


                return null;
            

           


           }
            
       

        
    }
}
