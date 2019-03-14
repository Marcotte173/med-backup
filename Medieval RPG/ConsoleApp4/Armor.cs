public class Armor : Item
{
    public Armor(string name, int dam, int price)
    : base(name, dam, price)
    { }

    public void setArmor(Armor armour)
    {
        itemName = armour.getName();
        itemEffect = armour.getDam();
        itemPrice = armour.getPrice();
    }
}