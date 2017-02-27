using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tooltip : MonoBehaviour {

    private Item item;
    private string data;
    GameObject tooltip;
        
    



    // Use this for initialization
    void Start()
    {

        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }


    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deativate()
    {
        tooltip.SetActive(false);
    }


    public void ConstructDataString()
    {
        string stats = string.Empty;
        string color = string.Empty;
        string newLine = string.Empty;

        if (item.Descriptions != string.Empty)
        {
            newLine = "\n";
        }

        switch (item.Rarity)
        {
            case "COMMON":
                color = "white";
                break;
            case "UNCOMMON":
                color = "lime";
                break;
            case "RARE":
                color = "navy";
                break;
            case "EPIC":
                color = "magenta";
                break;
            case "LEGENDARY":
                color = "orange";
                break;
            case "ARTIFACT":
                color = "red";
                break;
        }

        if (item.Strenght > 0)
        {
            stats += "\n" + item.Strenght.ToString() + " Сила";
        }

        if (item.Intellect > 0)
        {
            stats += "\n" + item.Intellect.ToString() + " Интеллект";
        }

        if (item.Dexterity > 0)
        {
            stats += "\n" + item.Dexterity.ToString() + " Ловкость";
        }

        if (item.Constitution > 0)
        {
            stats += "\n" + item.Constitution.ToString() + " Выносливость";
        }



        data = string.Format("<color=" + color + "><size=16>{0}</size></color><size=14><i><color=lime>" + newLine + "{1}</color></i>" + newLine + "{2}</size>", item.Title, stats, item.Descriptions );
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;


    }
}
