﻿using Self_Ordering_Kiosk.db.Model;

namespace Self_Ordering_Kiosk
{
    public static class Cart
    {
        public static Dictionary<Product, int> contentsOfCart = new Dictionary<Product, int>();
    }
}