public class Hero : Creature
{
    public string pClass;
    protected int plvl;
    protected int pot;


    public Hero(string name, int hp, int xp, int dam, int gold)
    : base(name, hp, xp, dam, gold)
    {
        plvl = 1;
        pot = 1;
        xpneeded = 21;
    }
    public Hero(string name, int hp, int xp, int dam, int gold, string Class)
    : base(name, hp, xp, dam, gold)
    {
        plvl = 1;
        pot = 1;
        xpneeded = 21;
        pClass = Class;
    }

    public void setClass(int shp, string classname, int energy, int dam, int hit, int crit, int def, int spelldam)
    {
        hp = shp + 6;
        mhp = hp;
        this.pClass = classname;
        this.energy = energy;
        this.maxenergy = energy;
        this.dam = dam;
        sdam = dam;
        smhp = shp;
        senergy = energy;
        this.hit = hit;
        this.crit = crit;
        this.dam = dam;
        this.def = def;
        this.spellDam = spelldam;
    }

    public void levelUp()
    {
        xp -= xpneeded;
        plvl++;
        xpneeded = (plvl * 15) + plvl + 5;
        dam += sdam;
        mhp += smhp;
        hp = mhp;
        maxenergy += senergy / 2;
        energy = maxenergy;
        if (this.pClass == "Mage")
            spellDam += 3;
        hit += 2;
        crit += 2;
        def += 2;
    }

    public void reducePotions() { pot -= 1; }
    public void setFullHealth() { hp = mhp; }
    public void setMinHealth() { hp = 1; }

    public void addXP(int exp) { xp += exp; }
    public void addPot(int p) { pot += p; }
    public void addGold(int x) { gold += x; }
    public void subGold(int y) { gold -= y; }
    public void subHP(int z) { hp -= z; }
    public void subEnergy(int e) { energy -= e; }
    public void loseGold() { gold = 0; }
    public void loseXP() { xp = 0; }

    public int getCrit() { return crit; }
    public int getDef() { return def; }
    public int getHit() { return hit; }
    public int getSDam() { return sdam; }
    public int getSHP() { return smhp; }
    public string getClass() { return pClass; }
    public int getLevel() { return plvl; }
    public int getDam() { return dam; }
    public int getXPNeeded() { return xpneeded; }
    public int getHP() { return hp; }
    public int getMHP() { return mhp; }
    public int getEnergy() { return energy; }
    public int getMaxEnergy() { return maxenergy; }
    public int getPot() { return pot; }
    public int getGold() { return gold; }
    public int getXP() { return xp; }
}