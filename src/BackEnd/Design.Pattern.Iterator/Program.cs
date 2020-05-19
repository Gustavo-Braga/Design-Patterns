using Design.Pattern.Iterator.Aggregate;
using System;

namespace Design.Pattern.Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var collection = new AggregateCollection();
            collection[0] = "item A";
            collection[1] = "item B";
            collection[2] = "item C";

            Console.WriteLine($"Quantidade de itens = {collection.Count()}");


            collection.Add("item D");
            collection.Add("item E");
            collection.Add("item F");

            Console.WriteLine($"Quantidade de itens = {collection.Count()}");

            var iterator = collection.CreateIterator();

            var item = iterator.First();

            while(item != null)
            {
                Console.WriteLine(item);
                item = iterator.Next();
            }


            Console.ReadKey();
        }
    }
}
