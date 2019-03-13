public class item

{

    protected string itemName;
    protected int itemEffect;
    protected int itemPrice;




    public item(string name, int dam, int price)
    {

        itemName = name;
        itemEffect = dam;
        itemPrice = price;

    }

    public string getName() { return itemName; }
    public int getDam() { return itemEffect; }
    public int getPrice() { return itemPrice; }

}