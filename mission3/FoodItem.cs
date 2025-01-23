namespace mission3;

// Category types
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

// Attributes for class
public class FoodItem
{
    public string Name {get; set;}
    public FoodCategory Type {get; set;}
    public int Quantity {get; set;}
    public DateOnly ExpirationDate {get; set;}

    // Constructor for FoodItem class
    public FoodItem(string name, FoodCategory type, int quantity, DateOnly expirationDate)
    {
        Name = name;
        Type = type;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    // Prints out the object with its attributes all nice and neat
    public override string ToString()
    {
        return $"Name: {Name}, Category: {Type}, Quantity: {Quantity}, Expiration Date: {ExpirationDate}";
    }
}