namespace ImplementingStacksAndQueues
{
    internal class Program
    {
        static void Main()
        {
            //try
            //{
            //    CustomList list = new CustomList();
            //    list.Add(111);
            //    list.Add(999);
            //    list.Add(2000);
            //    Console.WriteLine(list);
            //    list.Swap(0, 3);
            //    Console.WriteLine(list);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Something went wrong");
            //   // throw;
            //}


            //Console.WriteLine(list[1]);

            //CustomStack stack = new CustomStack();

            //stack.Push(114);
            //stack.Push(225);
            //stack.Push(336);

            //Console.WriteLine(stack.Count);

            //stack.ForEach(Console.WriteLine);


            CustomQueue queue = new CustomQueue();
            queue.Enqueue(7);
            queue.Enqueue(99);
            queue.Enqueue(111);
            queue.Enqueue(413);
            Console.WriteLine(queue.Dequeue());

        }
    }
}
