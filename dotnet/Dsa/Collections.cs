using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Dsa
{
    public class Collections
    {
        public static void MainCollections()
        {
            // List is a generic collection that stores elements in a dynamic list.
            // It is based on an array and can automatically resize when needed.
            // It is NOT THREAD-SAFE!
            // BigO: O(1) for direct access at any position and insertion at the end, O(n) for insertion or removal at intermediate positions.
            var list = new List<string>();
            list.Add("Teste");
            list.Add("Teste2");
            list[1].ToString();
            Console.WriteLine(list[0]);
            
            var t = new int[]{};

            // Basically, it represents a HashMap, but it is older and not generic.
            // Note: Hashtable is considered a legacy collection and is generally not recommended for new development.
            // Instead, it's better to use Dictionary<TKey, TValue> for most scenarios.
            // It can store keys and values of any type, but this can lead to runtime type issues.
            // Is is NOT thread-safe! It can be used "as thread-safe" using Hashtable.Synchronized, but this can lead to performance issues.
            // BigO: O(1) for insertion, removal, and access operations, but O(n) in the worst case due to collisions.
            var hashTable = new Hashtable();
            hashTable.Add(1, "Teste");
            hashTable.Add("foo", "Teste2");
            Console.WriteLine("Hashtable -------------");
            Console.WriteLine(hashTable["bar"]);

            // Dictionary is a generic collection that stores key-value pairs.
            // It is considered a "modern" version of Hashtable, offering better performance and type safety.
            // Is is NOT thread-safe!
            // BigO: O(1) for insertion, removal, and access operations, but O(n) in the worst case due to collisions.
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("foo", "Teste2");
            // dictionary.Add("foo", "Teste3");
            Console.WriteLine("Dictionary -------------");
            Console.WriteLine(dictionary["foo"]);

            // HashSet is a collection that stores unique elements, meaning it does not allow duplicates.
            // Is is NOT thread-safe!
            // BigO: O(1) for insertion, removal, and existence check operations, but O(n) in the worst case due to collisions.
            var hashMap = new HashSet<string>();
            hashMap.Add("Teste");
            hashMap.Add("Teste2");
            hashMap.Add("Teste2");
            Console.WriteLine("HashSet -------------");
            Console.WriteLine(hashMap.Contains("Teste3"));

            // Stack is a LIFO (Last In, First Out) collection, meaning the last element added is the first one to be removed.
            // NÃO é thread-safe!
            // It is NOT thread-safe! It can be used "as thread-safe" using Stack.Synchronized, but this can lead to performance issues.
            // BigO: O(1) for push and pop operations, O(n) for search.
            var stack = new Stack<string>();
            stack.Push("Teste");
            stack.Push("Teste2");
            Console.WriteLine("Stack -------------");
            Console.WriteLine(stack.Pop());
            stack.Push("Teste3");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            // Queue é uma coleção que segue a ordem FIFO (First In, First Out), ou seja, o primeiro elemento adicionado é o primeiro a ser removido.
            // Queue is a FIFO (First In, First Out) collection, meaning the first element added is the first one to be removed.
            // NÃO é thread-safe!
            // It is NOT thread-safe! It can be used "as thread-safe" using Queue.Synchronized, but this can lead to performance issues.
            // BigO: O(1) for enqueue and dequeue operations, O(n) for search.
            var queue = new Queue<string>();
            queue.Enqueue("Teste");
            queue.Enqueue("Teste2");
            Console.WriteLine("Queue -------------");
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.WriteLine(queue.Peek());

            // ConcurrentDictionary
            var text = "A Samsung apresentou nesta quarta (25) seus três novos celulares da linha Galaxy S26 com funcionalidades de IA avançadas e uma inédita função de tela com proteção de privacidade que não precisa de película.\nOs celulares Galaxy S26, S26+ e S26 Ultra foram anunciados em um evento em São Francisco, nos EUA. Eles já estão disponíveis em pré-venda e chegam às lojas em 20 de março. Confira os preços abaixo.\nOs três anunciados são vendidos com duas opções de armazenamento (256 GB e 512 GB) e 12 GB de RAM. O opções S26 Ultra tem ainda uma versão mais avançada, com 1 TB de armazenamento e 16 GB de RAM.\nSegundo a Samsung, os modelos são fabricados no Brasil. Com isso, eles não serão afetados pelo aumento do imposto de importação para celulares e outras centenas de produtos, anunciado no início de fevereiro pelo governo federal.\nA linha S26 concorre diretamente com o iPhone 17, lançado em setembro de 2025.O Galaxy S26 Ultra, modelo mais avançado da linha, é o que vem com a principal novidade: um modo de privacidade na tela contra curiosos.\nQuando ativada, apenas quem está na frente do aparelho consegue ver o conteúdo. Quem está ao lado vê apenas uma tela preta.\nA privacidade da tela, segundo a Samsung, é ativada de forma rápida no painel de controle do celular.Ela funciona desativando alguns pontos de luz(pixels) do display, o que também ajuda a economizar energia.";
            WordCounterConcurrent(text);
            // Dictionary + Lock
            WordCounterLock(text);
            
            // BlockingCollection -> Provides a thread-safe collection that can be used to produce and consume items in a producer-consumer scenario.
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
            var data = blockingCollection.Take();
            Console.WriteLine($"Data taken: {data}");
            Console.WriteLine(blockingCollection.IsCompleted);
            Console.WriteLine(blockingCollection.IsAddingCompleted);
            data = blockingCollection.Take();
            Console.WriteLine($"Data taken: {data}");
            Console.WriteLine(blockingCollection.IsCompleted);
            Console.WriteLine(blockingCollection.IsAddingCompleted);
            // data = blockingCollection.Take(); -> throws error

            var priorityQueue = new PriorityQueue<string, int>();
            priorityQueue.Enqueue("Teste", 200);
            priorityQueue.Enqueue("Teste2", 10);
            priorityQueue.Enqueue("Teste3", 70);
            Console.WriteLine("PriorityQueue -------------");
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());
            Console.WriteLine(priorityQueue.Dequeue());

            // TODO:
            // ConcurrentQueue
            // ConcurrentStack
            // ConcurrentBag -> Thread-safe version of List<T>, but does not maintain the order of elements.
        }

        public static void WordCounterConcurrent(string text)
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

        public static void WordCounterLock(string text)
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
}