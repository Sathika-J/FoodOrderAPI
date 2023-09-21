namespace FoodOrderApi.Configurations
{
    public class BooleanConvertor
    {
        public static string ConvertToString(bool flag)
        {
            if (flag == true)
            {
                return "Delivered";
            }
            else
            {
                return "Processing";
            }
        }

        public static bool ConvertToBool(string flag)
        {
            if (flag.Equals("Delivered"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}