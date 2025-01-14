using Self_Ordering_Kiosk.db.Model;

namespace Self_Ordering_Kiosk.user
{
    public static class Cart
    {
        public static Dictionary<Product, int> contentsOfCart = new Dictionary<Product, int>();
        public static bool isTakeaway = false;
    }
}