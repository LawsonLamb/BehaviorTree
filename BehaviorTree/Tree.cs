using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace BehaviorTree
{
    enum SearchType
    {
        BreadthFirst,
        DepthFirst,
        MySearch,
        None,
    }
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

         void traverse(Behavior child)
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



		Behavior Response(Behavior parent){



			if (parent.HasChild) {

				Random ran = new Random ();
				int num = 	ran.Next (parent.Children.Count);

				return parent.Children [num];

			}

			return null;


		}


        Behavior BreadthFirst_Search(string Value)
        {

            Console.WriteLine("\n\tBREADTH FIRST SEARCH FOR: " + Value);
            Queue<Behavior> q = new Queue<Behavior>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                Behavior current = q.Dequeue();

                Console.WriteLine("\t\t"+current);
                if(current == null)
                {

                    continue;
                }
                if( current.behavior == Value)
                {
                    return current;

                }
                if (current.HasChild)
                {
                    foreach(Behavior b in current.Children)
                    {
                        q.Enqueue(b);
                    }
                }


                
               
            }
            return null;
        }
        Behavior DepthFirst_Search(string Value)
        {

           Console.WriteLine("\tDEPTH FIRST SEARCH FOR: " + Value);
            Stack<Behavior> s = new Stack<Behavior>();

            s.Push(root);

            while (s.Count > 0)
            {
                Behavior current = s.Pop();
               // Console.WriteLine("\t\t" + current);
                if (current == null)
                {

                    continue;
                }
                if (current.behavior == Value)
                {
                    return current;

                }
                if (current.HasChild)
                {
                    {
                        foreach (Behavior b in current.Children)
                        {

                            s.Push(b);
                        }
                    }
                }

               
            }
            return null;
        }

        public void Search(String Behavior, SearchType type)
        {
            Behavior result;
            switch (type)
            {
                case SearchType.BreadthFirst:
                    result = BreadthFirst_Search(Behavior);
                    if (result != null)
                    {
					result = Response (result);

						Console.WriteLine("RESULT: " + result.response);

                    }
                    break;

                case SearchType.DepthFirst:
                    result = DepthFirst_Search(Behavior);
                    if (result != null)
					{ 	result = Response (result);
                        Console.WriteLine("RESULT: " + result.response);

                    }
                    break;

                case SearchType.MySearch:
                    result = search(root, Behavior);
                    if (result != null)
					{		result = Response (result);
                        Console.WriteLine("RESULT: " + result.response);

                    }
                    break;



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
                       // Console.WriteLine(temp);
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
