using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class SaveLoad
{
    private HeroData hero;
    public Hero playerCharacter;
    public int weapon;
    public int armour;


    public SaveLoad()
    {
    }

    public void save(Hero player, int wep, int arm)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HeroData));
        FileStream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/player_data.xml", FileMode.Create);

        //set the herodata here.
        hero = new HeroData();
        hero.setPlayerInfo(player, wep, arm);

        serializer.Serialize(stream, hero);
        stream.Close();
    }

    public Hero load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HeroData));
        FileStream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/player_data.xml", FileMode.Open);

        hero = serializer.Deserialize(stream) as HeroData;
        stream.Close();

        return new Hero(hero.name, hero.health, hero.experience, hero.damage, hero.gold, hero.playerClass);

        //Load the information that we got into the hero here.
    }

}

public class HeroData
{
    public string name;
    public String playerClass;
    public int health;
    public int weaponIndex;
    public int armourIndex;
    public int level;
    public int gold;
    public int goldInBank;
    public int experience;
    public int damage;

    public HeroData()
    {

    }

    public void setPlayerInfo(Hero player, int wep, int arm)
    {
        name = player.getName();
        playerClass = player.getClass();
        health = player.getHP();
        weaponIndex = wep;
        armourIndex = arm;
        level = player.getLevel();
        gold = player.getGold();
        experience = player.getXP();
        damage = player.getDam();
    }
}
