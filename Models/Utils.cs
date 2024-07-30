namespace Models
{
    public static class Utils
    {
        public static int ToInt(this double value)
        {
            return (int)Math.Round(value);
        }
    }
}
