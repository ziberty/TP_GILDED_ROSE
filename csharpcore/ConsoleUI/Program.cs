using GildedRoseKata;
namespace ConsoleUIKata
{
    public class ConsoleUI
    {
        static ItemsRepository itemsRepository = new InMemoryItemsRepository();
        static Shop shop = new Shop(itemsRepository);
        
        public static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowShopItems();
                        break;
                    case "2":
                        Console.WriteLine("Solde du magain : " + shop.Balance + "$");
                        break;
                    case "3":
                        shop.UpdateInventory();
                        Console.WriteLine("Les articles ont été mis à jour.");
                        break;
                    case "4":
                        ShowShopItems();
                        Console.WriteLine("\nQuel objet voulez vous vendre ?");
                        Item item = itemsRepository.GetInventory().ElementAt(int.Parse(Console.ReadLine()) - 1);
                        shop.SellItem(item.name, item.quality);
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

        public static void ShowShopItems()
        {
            foreach (Item item in itemsRepository.GetInventory())
            {
                Console.WriteLine((itemsRepository.GetInventory().IndexOf(item) + 1) + " - " + item.name + " - " + item.GetValue() + "$");
            }
        }
    }
}

