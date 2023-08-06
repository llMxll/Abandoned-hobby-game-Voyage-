using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {MANA, HEALTH, CROWBAR, HANDGUN};
public enum Quality {BROKEN, NORMAL}

public class Item : MonoBehaviour
{

    public ItemType type;
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;
    public int maxSize;

    public Quality quality;

    public string itemName;
    public string description;

    public Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Backpackinv").GetComponent<Inventory>();
    }

    public void Use()
    {
        switch (type)
        {
            case ItemType.MANA:
                Debug.Log("used mana");
                break;
            case ItemType.HEALTH:
                Debug.Log("used health");
                break;
            case ItemType.CROWBAR:
                Debug.Log("used crowbar");
                break;
        }
    }

    public string GetTooltip()
    {
        string stats = string.Empty;
        string color = string.Empty;
        string newLine = string.Empty;

        if(description != string.Empty)
        {
            newLine = "\n";
        }
        switch (quality)
        {
            case Quality.NORMAL:
                color = "white";
                break;
            case Quality.BROKEN:
                color = "red";
                break;
        }
        return string.Format("<color=" + color + "><size=16>{0}</size></color><size=14><i><color=white>" +newLine+ "{1}</color></i>{2}</size>", itemName, description,stats);
    }


 private void OnMouseDown()
     {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            Collider[] nearby = Playermove.objectsaroundplayer;

            foreach (Collider near in nearby)
            {
                Collider tmpnear = near;
                    if (tmpnear == hit.collider)
                {
                    inventory.AddItem(near.GetComponent<Item>());
                }
            }
        }






        //replacing below
        /* foreach (Collider col in Playermove.objectsaroundplayer)
         {
             if (col.tag == "Item")
             {
                 inventory.AddItem(col.GetComponent<Item>());
             }
         }
         */
     }
}