// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

public class Item
{
    private string createdDate;
    public string Name { set; get; }
    public int Quantity { set; get; }

    public Item(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
        createdDate = DateTime.Now.ToString();
    }
}

public class Store
{
    public List<Item> collectionList;

    public Store()
    {
        collectionList = new List<Item>();
    }

    public void addItem(Item newItem)
    {
        try
        {
            foreach (var item in collectionList)
            {
                if (item.Name == newItem.Name)
                {
                    throw new Exception("item name already exists in our array");
                }
            }
            collectionList.Add(newItem);
            Console.WriteLine($"Added item successfully");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Exception {ex.Message}");
        }
    }

    public void deleteItem(Item deletedItem)
    {
        foreach (var item in collectionList)
        {
            if (item.Name == deletedItem.Name)
            {
                collectionList.Remove(deletedItem);
                Console.WriteLine($"deleted item successfully");
            }
        }
    }

    public void GetCurrentVolume()
    {
        double volume = 0;
        foreach (var item in collectionList)
        {
            volume += item.Quantity;
        }
        Console.WriteLine($"Current Volume ={volume}");
    }

    public Item? FindItemByName(string itemName)
    {
        // use FirstOrDefault(), find first item based on condition and then return item, stop the loop
        var itemFound = collectionList.FirstOrDefault(item => item.Name == itemName);
        return itemFound;
    }

    public void SortByNameAsc() { }
}

public class App
{
    public static void Main(string[] args)
    {
        Store store = new Store();
        Item item1 = new Item("item1", 5);
        Item item2 = new Item("item2", 6);
        store.addItem(item1);
        store.addItem(item2);

        // // run for loop of collection to check item is added or not
        // foreach (var item in store.collectionList)
        // {
        //     Console.WriteLine($"item is print: {item.Name}");
        // }
        // store.deleteItem(item2);
        // store.GetCurrentVolume();
        // store.FindItemByName("item1");
    }
}
