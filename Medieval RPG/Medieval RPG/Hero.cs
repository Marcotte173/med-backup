public class Hero : creature
{
    public string pClass;
    protected int plvl;
    protected int pot;


    public Hero(string name, string taunt, int hp, int xp, int dam, int gold)
    : base(name, taunt, hp, xp, dam, gold)
    {
        plvl = 1;
        pot = 1;
        xpneeded = 21;
        this.gold = gold;
    }

    public void setclass(int shp, string classname, int energy, int dam, int hit, int crit, int def, int spelldam)
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
        this.spellDam = spellDam;
    }

    public void lvlup()
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

    public void setlosepot() { pot -= 1; }
    public void setfullhealth() { hp = mhp; }
    public void setminhealth() { hp = 1; }

    public void addxp(int exp) { xp += exp; }
    public void addpot(int p) { pot += p; }
    public void addgold(int x) { gold += x; }
    public void subgold(int y) { gold -= y; }
    public void subhp(int z) { hp -= z; }
    public void subenergy(int e) { energy -= e; }
    public void losegold() { gold = 0; }
    public void losexp() { xp = 0; }

    public int getCrit() { return crit; }
    public int getDef() { return def; }
    public int getHit() { return hit; }
    public int getsdam() { return sdam; }
    public int getshp() { return smhp; }
    public string getclass() { return pClass; }
    public int getplvl() { return plvl; }
    public int getDam() { return dam; }
    public int getxpneeded() { return xpneeded; }
    public int gethp() { return hp; }
    public int getmhp() { return mhp; }
    public int getenergy() { return energy; }
    public int getmaxenergy() { return maxenergy; }
    public int getpot() { return pot; }
    public int getgold() { return gold; }
    public int getxp() { return xp; }
}