using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SpellBook : MonoBehaviour {

    public GameObject spellSlot;
    public GameObject SpellBookPanel;
    
    public Image spellIcon;
    public Text SpellLevel;
    
    private int slotAmmount;
    public List<GameObject> slots = new List<GameObject>();
    Shoot _shoot;

    void Awake()
    {
        _shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
        slotAmmount = 15;
        for (int i = 0; i < _shoot.spells.Length; i++)
        {
            //GameObject tmpSlot;
            //tmpSlot = Instantiate(spellSlot);
            slots.Add(Instantiate(spellSlot));
            slots[i].GetComponent<SpellBookSlot>().ID = i;
            slots[i].GetComponent<SpellBookSlot>().Name = _shoot.spells[i].GetComponent<SpellDatabase>().itemName;
            slots[i].GetComponent<SpellBookSlot>().MinDamage = _shoot.spells[i].GetComponent<SpellDatabase>().MinDamage;
            slots[i].GetComponent<SpellBookSlot>().MaxDamage = _shoot.spells[i].GetComponent<SpellDatabase>().MaxDamage;
            slots[i].GetComponent<SpellBookSlot>().Level = _shoot.spells[i].GetComponent<SpellDatabase>().SpellLevel;

            slots[i].GetComponent<SpellBookSlot>().Description = _shoot.spells[i].GetComponent<SpellDatabase>().description;
            slots[i].GetComponent<SpellBookSlot>().Type = _shoot.spells[i].GetComponent<SpellDatabase>().type;
            slots[i].transform.SetParent(SpellBookPanel.transform);
            spellIcon.sprite = _shoot.spells[i].GetComponent<SpellDatabase>().icon;
            SpellLevel.text = _shoot.spells[i].GetComponent<SpellDatabase>().SpellLevel.ToString();
        }
    }

    //void Update()
    //{
    //    if (tooltip.activeSelf)
    //    {
    //        tooltip.transform.position = Input.mousePosition;
    //    }
    //}



}
