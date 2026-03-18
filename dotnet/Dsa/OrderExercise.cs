using System.Diagnostics;

namespace Dsa;

/*
### Exercise: Parallel Order Processing

You are developing a simple **order processing system** for an e-commerce platform.
The system receives a list of orders and must process them **concurrently** using **threads** to improve performance.

Each order contains the following information:
- **Order Id** (integer)
- **Order Value** (decimal)
- **Product Category** (string)
    
### Exercise Requirements
1. The program must contain an **initial collection of orders** with at least **100 simulated orders**.
2. Order processing must be performed **in parallel**, using **multiple threads**.
3. Each thread must:
    - Retrieve an order from a **shared queue of orders**
    - Simulate processing of the order (for example, using a small artificial delay)
    - Record the result in a **shared data structure**
4. During processing, the system must calculate:
    - **Total number of processed orders**
    - **Total processed value**
    - **Total value per category**
5. Since multiple threads will access shared data structures, the program must guarantee **safe concurrent access**.
6. The processing must only finish when **all orders have been processed**.
7. At the end of the execution, the program must print:
    - Total number of processed orders
    - Total value of all orders
    - Total value per category
    - Total processing execution time

### Constraints
- Use **appropriate data structures for concurrent scenarios** when necessary.
- The processing must actually occur **in parallel**, not sequentially.
- Avoid **race conditions** when updating aggregated results.
    

### Goal of the Exercise
This exercise is intended to practice:

- **Threads and parallelism**
- **Thread synchronization**
- **Shared data structures**
- **Concurrency control**
- **Data aggregation in a concurrent environment**.
*/

public class OrderExercise
{
    public static void MainOrderExercise()
    {
        var categories = new List<string>
        {
            "Roupas",
            "Livros",
            "Esportes",
            "Eletrônicos",
            "Casa",
        };
        var orders = new List<Order>();

        for (int i = 1; i < 1000; i++)
        {
            var order = new Order
            {
                Id = i,
                Price = Random.Shared.Next(1, 10000),
                Category = categories[Random.Shared.Next(0, 4)]
            };
            orders.Add(order);
        }
        
        var orderProcessor = new OrderProcessor();

        var stopWatch = Stopwatch.StartNew();
        Parallel.For(0, orders.Count, (i) =>
        {
            orderProcessor.Process(orders[i]);
        });
        stopWatch.Stop();

        Console.WriteLine("Total orders: {0}", orders.Count);
        Console.WriteLine("Total quantity: {0}", orderProcessor.TotalQuantity);
        Console.WriteLine("Total price: {0}", orderProcessor.TotalPrice);
        foreach (var category in categories)
        {
            if (orderProcessor.TotalsByCategory.TryGetValue(category, out var _))
            {
                Console.WriteLine("Total price for category {0}: {1}", category, orderProcessor.TotalByCategory(category));
            }
        }
        Console.WriteLine("Processing time: {0} ms", stopWatch.ElapsedMilliseconds);
    }
}

public class Order
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
    public bool Processed { get; set; }
}

public class OrderProcessor
{
    private readonly object locker = new object();
    public int TotalQuantity { get; private set; }
    public int TotalPrice { get; private set; }
    public readonly Dictionary<string, int> TotalsByCategory;

    public OrderProcessor()
    {
        TotalsByCategory = new Dictionary<string, int>();
    }

    public void Process(Order order)
    {
        lock(locker)
        {
            TotalQuantity += 1;
            TotalPrice += order.Price;

            if (TotalsByCategory.TryGetValue(order.Category,out var _) == false)
            {
                TotalsByCategory.Add(order.Category, 0);
            }

            TotalsByCategory[order.Category] += order.Price;
        }

        Thread.Sleep(Random.Shared.Next(300, 2000)); //simulate processing, between 300 and 2000 ms
    }

    public int TotalByCategory(string category)
    {
        return TotalsByCategory[category];
    }
}