public class Weapon : Item
{
    public Weapon(string name, int dam, int price)
    : base(name, dam, price)
    { }

    public void setWeapon(Weapon wep)
    {
        itemName = wep.getName();
        itemEffect = wep.getDam();
        itemPrice = wep.getPrice();
    }
}