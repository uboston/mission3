namespace mission3;

public enum FoodCategory
{
    Fruit,
    Vegetable,
    Dairy,
    Meat,
    Grain,
    Snack,
    Beverage
}

public class FoodItem
{
    public string Name {get; set;}
    public FoodCategory Type {get; set;}
    public int Quantity {get; set;}
    public DateOnly ExpirationDate {get; set;}

    public FoodItem(string name, FoodCategory type, int quantity, DateOnly expirationDate)
    {
        Name = name;
        Type = type;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Category: {Type}, Quantity: {Quantity}, Expiration Date: {ExpirationDate}";
    }
}