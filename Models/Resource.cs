
namespace Models
{
    public abstract class Resource
    {
        public static Resource Energy => new Energy();

        public static Resource None => new Energy();

        public int MaxValue { get; protected set; }
        public int Value { get; protected set; }

        public void Consume(int resourceConsumption)
        {
            Value -= resourceConsumption;
        }
    }
}