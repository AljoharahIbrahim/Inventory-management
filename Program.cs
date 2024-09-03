
public class Item
{
    public DateTime CreatedDate { set; get; }
    public string Name { set; get; }
    public int Quantity { set; get; }

    public Item(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
        CreatedDate = DateTime.Now;
    }
    public Item(string name, int quantity, DateTime createdDate)
    {
        Name = name;
        Quantity = quantity;
        CreatedDate = createdDate;
    }

}

public class Store
{

    public List<Item> collectionList;
    private int capacity;
    public Store(int capacity)
    {
        collectionList = new List<Item>();
        this.capacity = capacity;
    }

    public void addItem(Item newItem)
    {
        try
        {
            int capacityOfItems = 0;
            foreach (var item in collectionList)
            {
                capacityOfItems++;
                if (item.Name == newItem.Name)
                {
                    throw new Exception("item name already exists in our array");
                }
            }
            if (capacityOfItems <= capacity)
            {
                collectionList.Add(newItem);
                Console.WriteLine($"Added item successfully");
            }
            else
            {
                Console.WriteLine($"you dont have a valid number of capacity to added");
            }

        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Exception {ex.Message}");
        }
    }

    public void deleteItem(Item deletedItem)
    {
        try
        {
            foreach (var item in collectionList.ToList()) //* .ToList()
            {
                if (item.Name == deletedItem.Name)
                {
                    if (collectionList.Remove(deletedItem))
                        Console.WriteLine($"deleted item successfully");
                }
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Exception {ex.Message}");

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

    public IEnumerable<Item> SortByNameAsc()
    {
        return collectionList.OrderBy(item => item.Name);
    }

    public IEnumerable<Item> SortByDate()
    {
        return collectionList.OrderBy(item => item.CreatedDate);

    }
    public IEnumerable<Item> SortByDateDESC()
    {
        return collectionList.OrderByDescending(item => item.CreatedDate);
    }

    public IEnumerable<IGrouping<string, Item>> GroupByDate()
    {

        DateTime currentMonth = DateTime.Now;
        DateTime threeMonthAgo = currentMonth.AddMonths(-3);
        var groupedResult = collectionList.GroupBy(Item =>
        {
            if (Item.CreatedDate >= threeMonthAgo)
                return "newList";
            else
                return "Old";
        });
        return groupedResult;

    }

}

public class App
{
    public static void Main(string[] args)
    {
        //
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        // var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        // var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        // var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        // var coffee = new Item("Coffee", 20);
        // var sandwich = new Item("Sandwich", 15);
        // var batteries = new Item("Batteries", 10);
        // var umbrella = new Item("Umbrella", 5);
        // var sunscreen = new Item("Sunscreen", 8);
        Store store = new Store(15);
        store.addItem(waterBottle);
        store.addItem(chocolateBar);
        store.addItem(notebook);
        store.addItem(pen);
        store.addItem(tissuePack);
        store.addItem(shampoo);
        store.addItem(soap);
        var groupByDate = store.GroupByDate();
        foreach (var group in groupByDate)
        {
            Console.WriteLine($"{group.Key} Items:");
            foreach (var item in group)
            {
                Console.WriteLine($" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
            }
        }
        //*******

        // // run for loop of collection to check item is added or not
        // foreach (var item in store.collectionList)
        // {
        //     Console.WriteLine($"item is print: {item.Name}");
        // }
        //*******
        store.deleteItem(waterBottle);
        store.GetCurrentVolume();
        store.FindItemByName("Pen");
        var SortByNameAscList = store.SortByNameAsc();
        foreach (var item in SortByNameAscList)
        {
            Console.WriteLine($"{item.Name}");
        }
        var SortByDateList = store.SortByDate();
        foreach (var item in SortByNameAscList)
        {
            Console.WriteLine($"{item.CreatedDate}");
        }
    }
}
