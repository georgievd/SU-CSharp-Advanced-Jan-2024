namespace Generics
{
    public class Threeuple<T1, T2, T3> : CustomTuple<T1, T2>
    {
        public T3 Item3 { get; set; }

        public Threeuple(T1 item1, T2 item2, T3 item3) : base(item1, item2)
        {
            Item3 = item3;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
