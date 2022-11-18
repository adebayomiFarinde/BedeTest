namespace Bede.Data.Helpers
{
    internal static class ObjectExtension
    {
        public static string DoubleToOneDecimalToString(this double val)
        {
            return String.Format("{0:0.0}", Convert.ToDecimal(val));
        }
    }
}
