using System;
using System.Xml;
namespace BehaviorTree
{
	class MainClass
	{
		public static void Main (string[] args)
		{
           /// Tree tree = new Tree();
			MyXML xml = new MyXML (@"Tree.xml");
			xml.Read ();
			/*
            tree.BuildTreeManually();
            tree.Print();

            tree.Search("Idle",SearchType.BreadthFirst);
            tree.Search("Incoming Projectile", SearchType.BreadthFirst);
            tree.Search("Combat", SearchType.BreadthFirst);
            tree.Search("Melee", SearchType.BreadthFirst);
            tree.Search("Ranged", SearchType.BreadthFirst);
            tree.Search("BREAK", SearchType.BreadthFirst);


            tree.Search("Idle", SearchType.DepthFirst);
            tree.Search("Incoming Projectile", SearchType.DepthFirst);
            tree.Search("Combat", SearchType.DepthFirst);
            tree.Search("Melee", SearchType.DepthFirst);
            tree.Search("Ranged", SearchType.DepthFirst);
            tree.Search("BREAK", SearchType.DepthFirst);
		*/
		
            Console.ReadLine();
        }



	}
}
