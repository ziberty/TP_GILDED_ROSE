using GildedRoseKata;

namespace ConsoleUIKata;

public class ConsoleView : ShopOutputBoundary
{
    public void DisplayInventory(List<ItemResponse> inventory)
    {
        int index = 1;
        foreach (ItemResponse itemResponse in inventory)
        {
            Console.WriteLine(index + " - " + itemResponse.GetName() + " - " + itemResponse.GetValue() + "$");
            index++;
        }
    }

    public void DisplayBalance(int balance)
    {
        Console.WriteLine("Solde du magain : " + balance + "$");
    }
}