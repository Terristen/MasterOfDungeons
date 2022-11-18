using System;


namespace MoD 
{
    class Program
    {
        static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, World again!");


            
            var player = new TestPlayer();
            var behavior = new HeartBeat();

            player.Event_OnRun();
            player.AddComponent(ComponentSystem.ComponentType.Behavior, behavior, "heart");
            player.Event_OnRun();

            player.RemoveComponent(ComponentSystem.ComponentType.Behavior,"heart");
            player.Event_OnRun();

            player.AddProperty("Name", "Merlin");

            Console.WriteLine(player.GetPropertyValue<string>("Name"));

        }
    }




}



