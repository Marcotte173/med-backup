public class creature
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
    protected int monCrit;
    protected int hit;
    protected int monHit;
    protected int def;
    protected int monDef;
    protected int spellDam;


    public creature(string name, string taunt, int hp, int xp, int dam, int gold)
    {
        this.name = name;
        mhp = hp;
        this.hp = mhp;
        this.xp = xp;
        this.dam = dam;
    }

    public string getName() { return name; }



}