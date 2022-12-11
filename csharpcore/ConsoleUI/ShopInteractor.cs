using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleUIKata;

namespace GildedRoseKata
{
    public class ShopInteractor
    {
        private static ConsoleView _consoleView = new ConsoleView();
        static ConsoleController _controller = new ConsoleController(itemsGateway);
        static ItemsGateway itemsGateway = new InMemoryItemsRepository();
        static List<ItemResponse> inventory = new List<ItemResponse>();

        private static void SetInventory()
        {
            inventory = itemsGateway.GetInventory().Select(item =>
                new ItemResponse(item.name, item.sellIn, item.quality, item.GetValue())).ToList();
        }

        public static void Main(string[] args)
        {
            SetInventory();
            
            while (true)
            {
                DisplayMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        _consoleView.DisplayInventory(inventory);
                        break;
                    case "2":
                        _consoleView.DisplayBalance(_controller.Balance);
                        break;
                    case "3":
                        _controller.UpdateInventory();
                        Console.WriteLine("Les articles ont été mis à jour.");
                        break;
                    case "4":
                        _consoleView.DisplayInventory(inventory);
                        Console.WriteLine("\nQuel objet voulez vous vendre ?");
                        Item item = itemsGateway.GetInventory().ElementAt(int.Parse(Console.ReadLine()) - 1);
                        _controller.SellItem(new SellItemRequest(item.name, item.quality));
                        break;
                    case "5":
                        return;
                }
            }
        }
        
        public static void DisplayMenu()
        {
            Console.WriteLine("----- BIENVENUE DANS LA BOUTIQUE GILDED ROSE -----");
            Console.WriteLine("Choisissez une action :");
            Console.WriteLine("1) Afficher les articles disponibles");
            Console.WriteLine("2) Afficher le solde du magasin");
            Console.WriteLine("3) Lancer une mise à jour des articles");
            Console.WriteLine("4) Vendre un article");
            Console.WriteLine("5) Quitter");
        }
    }
}