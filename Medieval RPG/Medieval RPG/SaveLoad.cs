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

    public void load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HeroData));
        FileStream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/Save/player_data.xml", FileMode.Create);

        hero = serializer.Deserialize(stream) as HeroData;
        stream.Close();

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

    public HeroData()
    {

    }

    public void setPlayerInfo(Hero player, int wep, int arm)
    {
        name = player.getName();
        playerClass = player.getclass();
        health = player.gethp();
        weaponIndex = wep;
        armourIndex = arm;
        level = player.getplvl();
        gold = player.getgold();
        experience = player.getxp();
    }
}
