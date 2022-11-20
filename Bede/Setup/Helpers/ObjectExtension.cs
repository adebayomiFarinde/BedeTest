namespace Bede.Setup.Helpers
{
    public static class ObjectExtension
    {
        public static string DoubleToOneDecimalToString(this double val)
        {
            return String.Format("{0:0.0}", Convert.ToDecimal(val));
        }

        public static bool IsNull<T>(this T source)
        {
            return source == null;  
        }
    }

}
