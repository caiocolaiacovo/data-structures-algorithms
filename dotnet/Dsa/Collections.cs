using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Dsa
{
    public class Collections
    {
        public static void MainCollections()
        {
            // List é uma coleção genérica que armazena elementos em uma lista dinâmica.
            // Ele é baseado em um array e pode redimensionar automaticamente quando necessário.
            // NÃO é thread-safe!
            // BigO: O(1) para acesso em qualquer posição e inserção no final, O(n) para inserção ou remoção em posições intermediárias.
            var list = new List<string>();
            list.Add("Teste");
            list.Add("Teste2");
            list[1].ToString();
            Console.WriteLine(list[0]);
            
            var t = new int[]{};

            // Basicamente representa um HashMap, mas é mais antigo e não é genérico
            // Ele pode armazenar chaves e valores de qualquer tipo, 
            // mas isso pode levar a problemas de tipo em tempo de execução.
            // NÃO é thread-safe! Pode ser usado "como thread-safe" usando Hashtable.Synchronized, mas isso pode levar a problemas de desempenho.
            // BigO: O(1) para operações de inserção, remoção e acesso, mas O(n) no pior caso devido a colisões.
            var hashTable = new Hashtable();
            hashTable.Add(1, "Teste");
            hashTable.Add("foo", "Teste2");
            Console.WriteLine("Hashtable -------------");
            Console.WriteLine(hashTable["bar"]);

            // Dictionary é uma coleção genérica que armazena pares de chave-valor.
            // Seria a versão moderna do Hashtable, oferecendo melhor desempenho e segurança de tipo.
            // NÃO é thread-safe! 
            // BigO: O(1) para operações de inserção, remoção e acesso, mas O(n) no pior caso devido a colisões.
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("foo", "Teste2");
            // dictionary.Add("foo", "Teste3");
            Console.WriteLine("Dictionary -------------");
            Console.WriteLine(dictionary["foo"]);

            // HashSet é uma coleção que armazena elementos únicos, ou seja, não permite duplicatas.
            // NÃO é thread-safe! 
            // BigO: O(1) para operações de inserção, remoção e verificação de existência, mas O(n) no pior caso devido a colisões.
            var hashMap = new HashSet<string>();
            hashMap.Add("Teste");
            hashMap.Add("Teste2");
            hashMap.Add("Teste2");
            Console.WriteLine("HashSet -------------");
            Console.WriteLine(hashMap.Contains("Teste3"));

            // Stack é uma coleção que segue a ordem LIFO (Last In, First Out), ou seja, o último elemento adicionado é o primeiro a ser removido.
            // NÃO é thread-safe!
            // BigO: O(1) para operações de push e pop, O(n) para busca.
            var stack = new Stack<string>();
            stack.Push("Teste");
            stack.Push("Teste2");
            Console.WriteLine("Stack -------------");
            Console.WriteLine(stack.Pop());
            stack.Push("Teste3");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            // Queue é uma coleção que segue a ordem FIFO (First In, First Out), ou seja, o primeiro elemento adicionado é o primeiro a ser removido.
            // NÃO é thread-safe!
            // BigO: O(1) para operações de enqueue e dequeue, O(n) para busca.
            var queue = new Queue<string>();
            queue.Enqueue("Teste");
            queue.Enqueue("Teste2");
            Console.WriteLine("Queue -------------");
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            Console.WriteLine(queue.Peek());

            // TODO:
            // Queue and ConcurrentQueue
            // Stack and ConcurrentStack
            // ConcurrentDictionary
            // ConcurrentBag -> Versão thread-safe do List<T>, mas não mantém a ordem dos elementos.
            // BlockingCollection -> Fornece uma coleção thread-safe que pode ser usada para produzir e consumir itens em um cenário de produtor-consumidor.

            var text = "A Samsung apresentou nesta quarta (25) seus três novos celulares da linha Galaxy S26 com funcionalidades de IA avançadas e uma inédita função de tela com proteção de privacidade que não precisa de película.\nOs celulares Galaxy S26, S26+ e S26 Ultra foram anunciados em um evento em São Francisco, nos EUA. Eles já estão disponíveis em pré-venda e chegam às lojas em 20 de março. Confira os preços abaixo.\nOs três anunciados são vendidos com duas opções de armazenamento (256 GB e 512 GB) e 12 GB de RAM. O opções S26 Ultra tem ainda uma versão mais avançada, com 1 TB de armazenamento e 16 GB de RAM.\nSegundo a Samsung, os modelos são fabricados no Brasil. Com isso, eles não serão afetados pelo aumento do imposto de importação para celulares e outras centenas de produtos, anunciado no início de fevereiro pelo governo federal.\nA linha S26 concorre diretamente com o iPhone 17, lançado em setembro de 2025.O Galaxy S26 Ultra, modelo mais avançado da linha, é o que vem com a principal novidade: um modo de privacidade na tela contra curiosos.\nQuando ativada, apenas quem está na frente do aparelho consegue ver o conteúdo. Quem está ao lado vê apenas uma tela preta.\nA privacidade da tela, segundo a Samsung, é ativada de forma rápida no painel de controle do celular.Ela funciona desativando alguns pontos de luz(pixels) do display, o que também ajuda a economizar energia.";
            WordCounterConcurrent(text);
            WordCounterLock(text);
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