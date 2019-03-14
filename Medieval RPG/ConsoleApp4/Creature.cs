public class Creature
{
    protected string name;
    protected int hp;
    protected int mhp;
    protected int energy;
    protected int maxenergy;
    protected int xp;
    protected int xpneeded;
    protected int gold;
    protected int dam;
    protected int sdam;
    protected int smhp;
    protected int senergy;
    protected string taunt;
    protected int slimedown;
    protected int crit;
    protected int hit;
    protected int def;
    protected int spellDam;


    public Creature(string name, int hp, int xp, int dam, int gold)
    {
        this.name = name;
        mhp = hp;
        this.hp = mhp;
        this.xp = xp;
        this.dam = dam;
        this.gold = gold;
    }

    public string getName() { return name; }

}