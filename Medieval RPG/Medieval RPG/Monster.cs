public class monster : creature
{
    public monster(string name, string taunt, int hp, int xp, int dam, int gold)
    : base(name, taunt, hp, xp, dam, gold)
    { }

    public void setmonster(monster mon)
    {
        name = mon.getName();
        hp = mon.getmonHp();
        xp = mon.getmonXp();
        dam = mon.getmonDam();
        gold = mon.getmonGold();
        taunt = mon.getmonTaunt();
    }

    public string getmonName() { return name; }
    public int getmonHp() { return hp; }
    public int getmonXp() { return xp; }
    public int getmonDam() { return dam; }
    public int getmonGold() { return gold; }
    public string getmonTaunt() { return taunt; }
    public void subhp(int x) { hp -= x; }
    public void addslimedown(int s) { slimedown += s; }
    public int getslimedown() { return slimedown; }
}