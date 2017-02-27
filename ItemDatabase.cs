using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;


public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
    }

    public Item FetchItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;
        
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], 
                itemData[i]["title"].ToString(), 
                (int)itemData[i]["value"],
                (int)itemData[i]["stats"]["power"], 
                (int)itemData[i]["stats"]["defence"],
                (int)itemData[i]["stats"]["strenght"],
                (int)itemData[i]["stats"]["intellect"],
                (int)itemData[i]["stats"]["dexterity"],
                (int)itemData[i]["stats"]["constitution"], 
                itemData[i]["descriptions"].ToString(),
                (bool)itemData[i]["stackable"], 
                itemData[i]["rarity"].ToString(), 
                itemData[i]["slug"].ToString()));
        }
    }
}


public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }

    public int Power { get; set; }
    public int Defence { get; set; }
    public int Strenght { get; set; }
    public int Intellect { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }


    public string Descriptions { get; set; }
    public bool Stackable { get; set; }
    public string Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string title, int value, int power, int defence, int strenght, int intellect, int dexterity, int constitution, string descriptions, bool stackable, string rarity, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;

        this.Power = power;
        this.Defence = defence;
        this.Strenght = strenght;
        this.Intellect = intellect;
        this.Dexterity = dexterity;
        this.Constitution = constitution;

        this.Descriptions = descriptions;
        this.Stackable = stackable;
        this.Rarity = rarity;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + Slug);

    }

    public Item()
    {
        this.ID = -1;
    }
}
