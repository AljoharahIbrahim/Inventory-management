
public class Item
{
    // create properties of attributes * the first char should be in the capital 
    public DateTime CreatedDate { set; get; }
    public string Name { set; get; }
    public int Quantity { set; get; }

    // create constructor
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

    // method addItem to the collectionList
    public void addItem(Item newItem)
    {
        try
        {
            // check of the given item is exist in the collectionList using FindItemByName method
            if (FindItemByName(newItem.Name) == null)
            {
                //case 1: if the item is (Not exist) and the (capacity of the list is valied) to add new items
                if ((collectionList.Count) <= capacity)
                {
                    collectionList.Add(newItem);
                    Console.WriteLine($"Added item successfully");
                }
                //case 2: if the item is (Not exist) but the (capacity of the list is Not valied) to add new items
                else
                {
                    Console.WriteLine($"you dont have a valid number of capacity to added");
                }
            }

            else
            {
                //case 3: if the item is exist will Not be added in the collectionList
                throw new Exception("item name already exists in our array");

            }

        }


        catch (System.Exception ex)
        {
            Console.WriteLine($"Exception {ex.Message}");
        }
    }

    // method deleteItem that delete given item in collectionList
    public void deleteItem(Item deletedItem)
    {
        try
        {
            foreach (var item in collectionList.ToList()) //* .ToList()
            {
                // check of the given item is exist in the collectionList
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

    // method GetCurrentVolume in the collectionList
    public void GetCurrentVolume()
    {
        double volume = 0;
        foreach (var item in collectionList)
        {
            // sum each quantity of the items in the collectionList
            volume += item.Quantity;
        }
        Console.WriteLine($"Current Volume ={volume}");
    }

    // method FindItemByName in the collectionList
    public Item? FindItemByName(string itemName)
    {
        // use FirstOrDefault(), find first item based on condition and then return item, stop the loop
        var itemFound = collectionList.FirstOrDefault(item => item.Name == itemName);
        return itemFound;
    }

    // method SortByNameAsc in the collectionList
    public IEnumerable<Item> SortByNameAsc()
    {
        return collectionList.OrderBy(item => item.Name);
    }

    // method SortByDate in the collectionList
    public IEnumerable<Item> SortByDate()
    {
        return collectionList.OrderBy(item => item.CreatedDate);

    }
    // method SortByDateDESC in the collectionList
    public IEnumerable<Item> SortByDateDESC()
    {
        return collectionList.OrderByDescending(item => item.CreatedDate);
    }

    // method GroupByDate in the collectionList
    public IEnumerable<IGrouping<string, Item>> GroupByDate()
    {
        int threeMonthAgo = DateTime.Now.Month - 3;
        string newList = "New Arrival";
        string oldList = "Old Arrival";
        return collectionList.GroupBy(Item =>
        {
            if (Item.CreatedDate.Month >= threeMonthAgo)
            {
                return newList;
            }
            else
            {
                return oldList;
            }
        });
    }
}

public class App
{
    public static void Main(string[] args)
    {
        // create items 
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        // create instance of store to added the item  
        Store store = new Store(300);
        System.Console.WriteLine("adding list of items to the list\n");
        store.addItem(waterBottle);
        store.addItem(waterBottle);
        store.addItem(notebook);
        store.addItem(pen);
        store.addItem(tissuePack);
        store.addItem(shampoo);
        store.addItem(soap);

        // System.Console.WriteLine("\n check items that adding or not\n");
        // // run for loop of collection to check item is added or not
        // foreach (var item in store.collectionList)
        // {
        //     Console.WriteLine($"item is print: {item.Name}");
        // }

        // call deleteItem() method 
        System.Console.WriteLine("\ndelete water Bottle item\n");
        store.deleteItem(waterBottle);
        // call GetCurrentVolume() method 
        System.Console.WriteLine("\nGet Current Volume of the list\n");
        store.GetCurrentVolume();
        // call FindItemByName() method 
        System.Console.WriteLine("\nFind Pin item \n");
        var itemInformation = store.FindItemByName("Pen");
        if (itemInformation != null)
        {
            Console.WriteLine($"{itemInformation.Name}\n{itemInformation.CreatedDate}\n{itemInformation.Quantity}");
        }
        else
        {
            Console.WriteLine($"we dont have this item in the list");
        }
        // call SortByNameAscList() method 
        System.Console.WriteLine("\nSort items By Name Asc \n");
        var SortByNameAscList = store.SortByNameAsc();
        foreach (var item in SortByNameAscList)
        {
            Console.WriteLine($"{item.Name}");
        }
        // call SortByDateDESC() method 
        System.Console.WriteLine("\nSort items By Date Des \n");
        var SortByDateDesList = store.SortByDateDESC();
        foreach (var item in SortByDateDesList)
        {
            Console.WriteLine($"{item.CreatedDate}");
        }
        // call SortByDateList() method 
        System.Console.WriteLine("\nSort items By Date Asc \n");
        var SortByDateList = store.SortByDate();
        foreach (var item in SortByDateList)
        {
            Console.WriteLine($"{item.CreatedDate}");
        }

        // call GroupByDate() method to seprate the items into two list ( new and Old)
        System.Console.WriteLine("\nGrouping the items By Date\n");
        var groupByDate = store.GroupByDate();
        foreach (var group in groupByDate)
        {
            Console.WriteLine($"{group.Key} Items:");
            foreach (var item in group)
            {
                Console.WriteLine($" - {item.Name}, Created: {item.CreatedDate.ToShortDateString()}");
            }
        }
    }
}
