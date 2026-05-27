using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Dsa
{
    public class Collections
    {
        public static void MainCollections()
        {
            Console.WriteLine("Collections -----------------------");

            /* 
            List is a generic collection that stores elements in a dynamic list.
            It is based on an array and can automatically resize when needed.
            Implements the IList<T> interface, which allows for indexed access to elements and provides methods for adding, removing, and searching for elements.
            Not thread-safe.
            
            Time complexity:
                - O(1) for direct access at any position
                - O(1) for insertion at the end (amortized, because it may need to resize the internal array)
                - O(n) for insertion or removal at intermediate positions (elements after the index must shift)
            */
            var list = new List<string>();
            list.Add("Teste"); // add element to the end of the list
            list.Add("Teste2");
            list.Insert(index: 1, "Teste3");
            Console.WriteLine(list[0]);

            /*
            LEGACY: Basically, it represents a HashMap, but it is older and not generic. It can store keys and values of any type, but this can lead to runtime type issues. Not thread-safe.
            
            Time complexity: 
            -   O(1) for insertion, removal, and access operations, but O(n) in the worst case due to collisions.
            */
            var hashTable = new Hashtable();
            hashTable.Add(1, "Teste");
            hashTable.Add("foo", "Teste2");
            Console.WriteLine("Hashtable -------------");
            Console.WriteLine(hashTable["bar"]);
            
            /*
            Dictionary is a generic collection that stores key-value pairs. It is considered a "modern" version of Hashtable, offering better performance and type safety. Not thread-safe.

            Time complexity: 
                - O(1) for insertion, removal, and access operations, but O(n) in the worst case due to collisions.
            */
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("foo", "Teste2");
            // dictionary.Add("foo", "Teste3");
            Console.WriteLine("Dictionary -------------");
            Console.WriteLine(dictionary["foo"]);

            /*
            HashSet is a collection that stores unique elements, meaning it does not allow duplicates. Not thread-safe.
            
            Time complexity: 
                - O(1) for insertion, removal, and existence check operations, but O(n) in the worst case due to collisions.
            */
            var hashMap = new HashSet<string>();
            hashMap.Add("Teste");
            hashMap.Add("Teste2");
            hashMap.Add("Teste2");
            Console.WriteLine("HashSet -------------");
            Console.WriteLine(hashMap.Contains("Teste3"));

            /*
            Stack is a LIFO (Last In, First Out) collection, meaning the last element added is the first one to be removed. Not thread-safe.

            Time complexity: 
                - O(1) for push and pop operations
                - O(n) for search.
            */
            var stack = new Stack<string>();
            stack.Push("Teste");
            stack.Push("Teste2");
            Console.WriteLine("Stack -------------");
            Console.WriteLine(stack.Pop());
            stack.Push("Teste3");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            /*
            Queue is a FIFO (First In, First Out) collection, meaning the first element added is the first one to be removed.
            Not thread-safe.

            Time complexity: 
                - O(1) for enqueue and dequeue operations
                - O(n) for search.
            */
            var queue = new Queue<string>();
            queue.Enqueue("Teste");
            queue.Enqueue("Teste2");
            Console.WriteLine("Queue -------------");
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.WriteLine(queue.Peek());

            /*
            ConcurrentDictionary is a thread-safe version of the Dictionary for concurrent access.

            Time complexity:
                - O(1) for AddOrUpdate, GetOrAdd, TryGetValue, TryRemove
            */
            var text = System.IO.File.ReadAllText("TextCountNews.txt");
            WordCounterWithConcurrentDictionary(text);
            WordCounterDictionaryAndLock(text);

            /*
            BlockingCollection provides a thread-safe collection that can be used to produce and consume items in a producer-consumer scenario.
            It wraps a concurrent collection with blocking Add/Take perations
            
            Time complexity:
                - O(1) for Add and Take (when backed by ConcurrentQueue). 
            */
            var blockingCollection = new BlockingCollection<string>();
            Console.WriteLine("BlockingCollection -------------");
            Console.WriteLine(blockingCollection.IsCompleted);
            Console.WriteLine(blockingCollection.IsAddingCompleted);
            blockingCollection.Add("Teste");
            blockingCollection.Add("Teste2");
            Console.WriteLine(blockingCollection.IsCompleted);
            Console.WriteLine(blockingCollection.IsAddingCompleted);
            blockingCollection.CompleteAdding();
            Console.WriteLine(blockingCollection.IsCompleted);
            Console.WriteLine(blockingCollection.IsAddingCompleted);
            // Gets blocked until an item is available or the collection is marked as complete for adding and empty.
            var data = blockingCollection.Take();
            Console.WriteLine($"Data taken: {data}");
            Console.WriteLine(blockingCollection.IsCompleted);
            Console.WriteLine(blockingCollection.IsAddingCompleted);
            data = blockingCollection.Take();
            Console.WriteLine($"Data taken: {data}");
            Console.WriteLine(blockingCollection.IsCompleted);
            Console.WriteLine(blockingCollection.IsAddingCompleted);
            // data = blockingCollection.Take(); -> throws error

            /*
            PriorityQueue is a min/max-heap (depending on the comparer) based collection that returns elements by priority.
            It uses an Array internally.
            Not thread-safe.

            Time complexity:
                - O(log n) for Enqueue and Dequeue
                - O(1) for Peek
            */
            var priorityQueue = new PriorityQueue<string, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            priorityQueue.Enqueue("Teste", 10);
            priorityQueue.Enqueue("Teste2", 200);
            priorityQueue.Enqueue("Teste2", 150);
            priorityQueue.Enqueue("Teste3", 70);
            Console.WriteLine("PriorityQueue -------------");
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());

            /*
            SortedDictionary maintains elements sorted by key only, using a binary tree (Red-Black tree).
            Sort the keys only, not the values.
            Not thread-safe.

            Time complexity:
                - O(log n) for Add, Remove, TryGetValue
                - O(log n) for First (LINQ method, but SortedDictionary doesn't implement IList and doesn't have direct access to the first element, so it needs to traverse the collection)
                - O(n) for Last (LINQ method, but SortedDictionary doesn't implement IList and doesn't have direct access to the first element, so it needs to traverse the collection)
                - O(n) for enumeration
            */
            var sortedDictionary = new SortedDictionary<string, int>();
            sortedDictionary.Add("banana", 8);
            sortedDictionary.Add("apple", 10);
            sortedDictionary.Add("pear", 1);
            sortedDictionary.Add("orange", 2);
            Console.WriteLine($"first: {sortedDictionary.First()}"); // [apple, 10]
            Console.WriteLine($"last: {sortedDictionary.Last()}"); // [pear, 1]

            /*
            SortedSet maintains unique elements sorted by a specified comparer, using a binary tree (Red-Black tree). Not thread-safe.

            Time complexity:
                - O(log n) for Add, Remove, Contains
                - O(n) for enumeration
            */
            var sortedSet = new SortedSet<File>(new FileComparer());
            sortedSet.Add(new File("file1.txt", 100));
            sortedSet.Add(new File("file2.txt", 50));
            sortedSet.Add(new File("file3.txt", 150));
            Console.WriteLine("SortedSet -------------");
            foreach (var file in sortedSet)            {
                Console.WriteLine($"{file.Path}: {file.Size}");
            }

            /*
            OrderedDictionary maintains both an ArrayList and a HashTable, keeping insertion order and allowing access by index or by key.
            Not thread-safe.

            Time complexity:
                - O(1) for access by index (on ArrayList)
                - O(1) for access by key (on HashTable)
                - O(1) for Insert
                - O(n) for Remove (because the ArrayList must shift elements)
            */
            var orderedDictionary = new OrderedDictionary();
            orderedDictionary.Add("banana", 8);
            orderedDictionary.Add("apple", 10);
            orderedDictionary.Add("pear", 1);
            orderedDictionary.Add("orange", 2);
            Console.WriteLine($"first: {orderedDictionary[0]}"); // [apple, 10]
            Console.WriteLine($"last: {orderedDictionary[3]}"); // [pear, 1]

            // TODO:
            // ConcurrentQueue
            // ConcurrentStack
            // ConcurrentBag -> Thread-safe version of List<T>, but does not maintain the order of elements.

            Console.WriteLine("End Collections ----------------------------------");
        }

        public static void WordCounterWithConcurrentDictionary(string text)
        {
            var splitedText = text
                .Replace(".", "")
                .Replace(",", "")
                .Replace("(", "")
                .Replace(")", "")
                .Split('\n');

            var wordCounts = new ConcurrentDictionary<string, int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, splitedText.Length, i =>
            {
                var words = splitedText[i].Split(' ');

                foreach (var w in words)
                {
                    wordCounts.AddOrUpdate(
                        w.ToLower(),
                        1,
                        updateValueFactory: (k, oldValue) => oldValue + 1);
                }
            });
            stopwatch.Stop();

            foreach (var kvp in wordCounts)
            {
                Console.WriteLine($"Word: {kvp.Key}, Count: {kvp.Value}");
            }
            Console.WriteLine("ConcurrentDictionary Time: " + stopwatch.ElapsedMilliseconds + "ms");
        }

        public static void WordCounterDictionaryAndLock(string text)
        {
            var splitedText = text
                .Replace(".", "")
                .Replace(",", "")
                .Replace("(", "")
                .Replace(")", "")
                .Split('\n');

            object locker = new object();
            var wordCounts = new Dictionary<string, int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, splitedText.Length, i =>
            {
                var words = splitedText[i].Split(' ');

                foreach (var w in words)
                {
                    var wLower = w.ToLower();
                    lock (locker)
                    {
                        wordCounts.TryGetValue(wLower, out var count);
                        wordCounts[wLower] = count + 1;
                    }
                }
            });
            stopwatch.Stop();

            foreach (var kvp in wordCounts)
            {
                Console.WriteLine($"Word: {kvp.Key}, Count: {kvp.Value}");
            }
            Console.WriteLine("Lock Time: " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }

    public class FileComparer : IComparer<File>
    {
        // Sort descending by size
        public int Compare(File? x, File? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            return y.Size.CompareTo(x.Size);
        }
    }

    public class File
    {
        public string Path { get; private set; }
        public int Size { get; private set; }

        public File(string path, int size)
        {
            Path = path;
            Size = size;
        }
    }
}