using System;
using System.Xml;
namespace BehaviorTree
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            Tree tree = new Tree();
            tree.BuildTreeManually();
            tree.Print();
            tree.Search("Idle");
            tree.Search("Incoming Projectile");
            tree.Search("Combat");
            tree.Search("Melee");
            tree.Search("Ranged");
            tree.Search("BREAK");
            

            Console.ReadLine();
        }



	}
}
