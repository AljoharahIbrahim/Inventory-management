// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

public class Item
{

    public string CreatedDate { set; get; }
    public string Name { set; get; }
    public int Quantity { set; get; }

    public Item(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
        CreatedDate = DateTime.Now.ToString();
    }
    public Item(string name, int quantity, string createdDate)
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

    public IEnumerable<Item> SortByDate(){
        return collectionList.OrderBy(item => item.CreatedDate);
        
    }
      public IEnumerable<Item> SortByDateDESC(){
        return collectionList.OrderByDescending(item => item.CreatedDate);    
    }
    public void GroupByDate(){ //**

        string currentMonth = DateTime.Now.ToString();
         
    }

}

public class App
{
    public static void Main(string[] args)
    {
        Store store = new Store(3);
        Item item1 = new Item("Fitem1", 5);
        Item item2 = new Item("Atem2", 6, new DateTime(2023, 7, 1).ToString());
        store.addItem(item1);
        store.addItem(item2);
        // // run for loop of collection to check item is added or not
        // foreach (var item in store.collectionList)
        // {
        //     Console.WriteLine($"item is print: {item.Name}");
        // }
        // store.deleteItem(item2);
        store.GetCurrentVolume();
        store.FindItemByName("item1");
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
