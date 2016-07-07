namespace Specifications
{
    public static class StringTestExtentions
    {
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}