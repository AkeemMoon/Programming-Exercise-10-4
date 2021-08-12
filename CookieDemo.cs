using static System.Console;
class CookieDemo2
{
   static void Main()
   {
            SpecialCookieOrder oneDozen = new SpecialCookieOrder();
            SpecialCookieOrder twoDozen = new SpecialCookieOrder();
            SpecialCookieOrder threeDozen = new SpecialCookieOrder();

            oneDozen.OrderNum = "101";
            oneDozen.Name = "Arthur";
            oneDozen.CookieType = "chocolate chip";
            oneDozen.SpecialDescription = "gluten-free";
            oneDozen.Dozens = 1;

            twoDozen.OrderNum = "102";
            twoDozen.Name = "Brown";
            twoDozen.CookieType = "peanut butter";
            twoDozen.SpecialDescription = "sugar-free";
            twoDozen.Dozens = 2;

            threeDozen.OrderNum = "103";
            threeDozen.Name = "Cooper";
            threeDozen.CookieType = "sugar";
            threeDozen.SpecialDescription = "iced";
            threeDozen.Dozens = 3;

            Display(oneDozen);
            Display(twoDozen);
            Display(threeDozen);

   }
     public static void Display(SpecialCookieOrder order)
        {
            WriteLine("Order #{0, -6}   {1, -15}", order.OrderNum, order.Name);
            WriteLine("  type: {0} {1}", order.SpecialDescription, order.CookieType);
            WriteLine("   {0} dozen --- ${1}", order.Dozens, order.Price);
        }
}
class CookieOrder
{
    public string OrderNum { get; set; }
    public string Name { get; set; }
    public string CookieType { get; set; }
    protected int dozens;
    public const int LOWPRICE = 13;
    public const int HIGHPRICE = 15;
    public const int CUTOFF = 2;
    public virtual int Dozens
      {
        get
         {
            return dozens;
         }
          set
          {
            dozens = value;
              if (Dozens <= CUTOFF)
                    Price = Dozens * HIGHPRICE;
              else
                    Price = CUTOFF * HIGHPRICE + (Dozens - CUTOFF) * LOWPRICE;
                }
            }
      public double Price {get; set;}
              class SpecialCookieOrder : CookieOrder
        {
            public string SpecialDescription { get; set; }
            private const int PRICECUTOFF = 40;
            private const int LOWSPECIAL = 8;
            private const int HIGHSPECIAL = 10;
            public override int Dozens
            {
                set
                {
                    dozens = value;
                    if (dozens <= CUTOFF)
                        Price = dozens * HIGHPRICE;
                    else
                        Price = CUTOFF * HIGHPRICE * (dozens - CUTOFF) * LOWPRICE;
                    if (Price < PRICECUTOFF)
                        Price += HIGHSPECIAL;
                    else
                        Price += LOWSPECIAL;
                }
            }

        }

}
