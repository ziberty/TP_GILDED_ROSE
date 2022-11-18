using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace GildedRoseKata
{
    public class FileItemsRepository : ItemsRepository
    {
        private IList<Item> inventoryItems = new List<Item>();
        private const string Path = @"inventoryItems.csv";

        public IList<Item> GetInventory()
        {
            ReadCsvLines(Path);
            return inventoryItems;
        }

        private void ReadCsvLines(string path)
        {
            using(TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                while (!csvParser.EndOfData)
                {
                    string[] item = csvParser.ReadFields();
                    AddItem(item);
                }
            }
        }

        private void AddItem(string[] item)
        {
            switch (item[4])
            {
                case "AgingItem":
                    inventoryItems.Add(new AgingItem(item[0], int.Parse(item[1]), int.Parse(item[2]), 5));
                    break;
                case "ConjuredItem":
                    inventoryItems.Add(new AgingItem(item[0], int.Parse(item[1]), int.Parse(item[2]), 46));
                    break;
                case "EventItem":
                    inventoryItems.Add(new AgingItem(item[0], int.Parse(item[1]), int.Parse(item[2]), 12));
                    break;
                case "GenericItem":
                    inventoryItems.Add(new AgingItem(item[0], int.Parse(item[1]), int.Parse(item[2]), 32));
                    break;
                case "LegendaryItem":
                    inventoryItems.Add(new AgingItem(item[0], int.Parse(item[1]), int.Parse(item[2]), 69));
                    break;
            }
        }

        public void SaveInventory(IList<Item> items)
        {
            File.WriteAllLines(Path, items.Select(item => string.Join(";", item, ";", item.GetType().Name)));
        }

        public Item FindItem(string type, int quality)
        {
            return GetInventory().FirstOrDefault(item => item.name == type && item.quality == quality);
        }
    }
}