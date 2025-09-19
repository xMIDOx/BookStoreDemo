public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal price) => price;
}

public class StudentDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal price) => price * 0.9m; // 10% off
}

public class SeasonalDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal price) => price * 0.8m; // 20% off
}
