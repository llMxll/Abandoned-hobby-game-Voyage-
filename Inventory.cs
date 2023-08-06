using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Inventory : MonoBehaviour {

    private RectTransform inventoryRect;
    static public float inventorywidth, inventoryheight;
    public int slots;
    public int rows;
    public float slotpaddingleft, slotpaddingtop;
    public float slotsize;
    public GameObject slotPrefab;
    public GameObject Hidebutt;
    private List<GameObject> allslots;

    private static Slot from, to;

    public GameObject iconPrefab;
    private static GameObject hoverObject;
    public Canvas canvas;

    private static GameObject clicked;
    public GameObject selectstacksize;
    private static GameObject selectstacksizestatic;
    public Text stacktext;
    private int splitamount;
    private int maxStackCount;
    private static Slot movingSlot;

    public GameObject tooltipObject;
    private static GameObject tooltip;
    public Text sizetextObject;
    private static Text sizeText;
    public Text visualtextObject;
    private static Text visualtext;

    //ADD GAME OOBJECTS HERE!! ***********************************************
    public GameObject health;
    public GameObject crowbar;

    private static Inventory instance;
    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Inventory>();
            }
            return Inventory.instance;
        }
    }


    private float hoverYOffset;

    public EventSystem eventSystem;

    private static int emptySlot;

    public static int EmptySlot
    {
        get
        {
            return emptySlot;
        }

        set
        {
            emptySlot = value;
        }
    }

    void Start ()
    {
        tooltip = tooltipObject;
        sizeText = sizetextObject;
        visualtext = visualtextObject;
        selectstacksizestatic = selectstacksize;

        Createlayout();

        movingSlot = GameObject.Find("Movingslot").GetComponent<Slot>();

    }
	
	void Update ()
    {
        //Things that happen when item clicked outside inventory atm destroy
        if (Input.GetMouseButtonUp(0))
        {
            if (!eventSystem.IsPointerOverGameObject(-1) && from != null)
            {
                from.GetComponent<Image>().color = Color.white;
                from.ClearSlot();
                Destroy(GameObject.Find("Hover"));
                to = null;
                from = null;
                hoverObject = null;
                emptySlot++;
            }
            else if (!eventSystem.IsPointerOverGameObject(-1) && !movingSlot.IsEmpty)
            {
                movingSlot.ClearSlot();
                Destroy(GameObject.Find("Hover"));
            }
        }

		if (hoverObject != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
            position.Set(position.x, position.y - hoverYOffset);
            hoverObject.transform.position = canvas.transform.TransformPoint(position);
        }
	}

    public void ShowToolTip(GameObject slot)
    {
        Slot tmpslot = slot.GetComponent<Slot>();

        if (!tmpslot.IsEmpty && hoverObject == null && !selectstacksizestatic.activeSelf)
        {
            visualtext.text = tmpslot.CurrentItem.GetTooltip();
            sizeText.text = visualtext.text;

            tooltip.SetActive(true);


            // fix bug here
            float xPos = slot.transform.position.x + slotpaddingleft;
            float yPos = slot.transform.position.y - slot.GetComponent<RectTransform>().sizeDelta.y - slotpaddingtop;

            tooltip.transform.position = new Vector2(xPos, yPos);
        }
    }

    public void HideToolTip()
    {
        tooltip.SetActive(false);
    }

    private void Createlayout()
    {
        //delete old
        if (allslots != null)
        {
            foreach (GameObject go in allslots)
            {
                Destroy(go);
            }

            Destroy(GameObject.Find("Hidebutt"));
        }

        //Create
        allslots = new List<GameObject>();

        hoverYOffset = slotsize * 0.01f;

        EmptySlot = slots;

        inventorywidth = ((slots / rows) + 1) * (slotsize + slotpaddingleft) + slotpaddingleft;
        inventoryheight = rows * (slotsize + slotpaddingtop) + slotpaddingtop;
        inventoryRect = GetComponent<RectTransform>();
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventorywidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryheight);

        int coloumns = slots / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < coloumns; x++)
            {
                GameObject newslot = (GameObject)Instantiate(slotPrefab);
                RectTransform slotRect = newslot.GetComponent<RectTransform>();
                newslot.name = "Slot";
                newslot.transform.SetParent(this.transform.parent);
                slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotpaddingleft * (x + 2) + (slotsize * (x + 1)), -slotpaddingtop * (y + 1) - (slotsize * y) + inventoryheight / 2);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotsize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotsize);
                newslot.transform.localScale = new Vector3 (1,1,1);
        newslot.transform.SetParent(this.transform);
                allslots.Add(newslot);
            }
        }
        GameObject newbutt = (GameObject)Instantiate(Hidebutt);
        RectTransform buttRect = newbutt.GetComponent<RectTransform>();
        newbutt.name = "Hidebutt";
        newbutt.transform.SetParent(this.transform.parent);
        buttRect.localPosition = inventoryRect.localPosition + new Vector3(slotpaddingleft * 1, inventoryheight / 2 - slotsize / 2 - slotpaddingtop);
        buttRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotsize);
        buttRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotsize);
        newbutt.transform.localScale = new Vector3(1, 1, 1);

    }

    public bool AddItem(Item item)
    {
        if (item.maxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        else
        {
            foreach (GameObject slot in allslots)
            {
                Slot tmp = slot.GetComponent<Slot>();

                if (!tmp.IsEmpty)
                {
                    if (tmp.CurrentItem.type == item.type && tmp.IsAvailable)
                    {
                        if (!movingSlot.IsEmpty && clicked.GetComponent<Slot>() == tmp.GetComponent<Slot>())
                        {
                            continue;
                        }
                        else
                        {
                            tmp.Additem(item);
                            return true;
                        }
                    }
                }
            }
            if (EmptySlot > 0)
            {
                PlaceEmpty(item);
            }
        }
        return false;
    }

    private bool PlaceEmpty(Item item)
    {
        if (EmptySlot > 0)
        {
            foreach (GameObject slot in allslots)
            {
                Slot tmp = slot.GetComponent<Slot>();

                if (tmp.IsEmpty)
                {
                    tmp.Additem(item);
                    EmptySlot--;
                    return true;
                }
            }
        }
        return false;
    }

    public void MoveItem(GameObject clicked)
    {
        Inventory.clicked = clicked;

        if (!movingSlot.IsEmpty)
        {
            Slot tmp = clicked.GetComponent<Slot>();

            if (tmp.IsEmpty)
            {
                tmp.AddItems(movingSlot.Items);
                movingSlot.Items.Clear();
                Destroy(GameObject.Find("Hover"));
            }
            else if (!tmp.IsEmpty && movingSlot.Items.Peek().type == tmp.CurrentItem.type && tmp.IsAvailable)
            {
                MergeStacks(movingSlot, tmp);
            }
        }
        else if (from == null && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.gray;
                CreateHoverIcon();
            }
        }
        else if (to == null && !Input.GetKey(KeyCode.LeftShift))
        {
            to = clicked.GetComponent<Slot>();
            Destroy(GameObject.Find("Hover"));
        }
        if (to != null && from != null)
        {
                if (!to.IsEmpty && from.CurrentItem.type == to.CurrentItem.type && to.IsAvailable)
                {
                    MergeStacks(from, to);
                }
                else
                {
                    Stack<Item> tmpTo = new Stack<Item>(to.Items);
                    to.AddItems(from.Items);

                    if (tmpTo.Count == 0)
                    {
                        from.ClearSlot();
                    }
                    else
                    {
                        from.AddItems(tmpTo);
                    }
                }
                from.GetComponent<Image>().color = Color.white;
                to = null;
                from = null;
                hoverObject = null;
            }
        }

    private void CreateHoverIcon()
    {
        hoverObject = (GameObject)Instantiate(iconPrefab);
        hoverObject.GetComponent<Image>().sprite = clicked.GetComponent<Image>().sprite;
        hoverObject.name = "Hover";

        RectTransform hoverTransform = hoverObject.GetComponent<RectTransform>();
        RectTransform clickedTransform = clicked.GetComponent<RectTransform>();

        hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, clickedTransform.sizeDelta.x);
        hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clickedTransform.sizeDelta.y);

        hoverObject.transform.SetParent(GameObject.Find("GUI").transform, true);
        hoverObject.transform.localScale = clicked.gameObject.transform.localScale;

        hoverObject.transform.GetChild(0).GetComponent<Text>().text = movingSlot.Items.Count > 1 ? movingSlot.Items.Count.ToString() : string.Empty;
    }

    public void SetStackInfo (int maxStackCount)
    {
        selectstacksize.SetActive(true);
        tooltip.SetActive(false);
        splitamount = 0;
        this.maxStackCount = maxStackCount;
        stacktext.text = splitamount.ToString();
    }

    public void SplitStack()
    {
        selectstacksize.SetActive(false);
        if (splitamount == maxStackCount)
        {
            MoveItem(clicked);
        }
        else if (splitamount > 0)
        {
            movingSlot.Items = clicked.GetComponent<Slot>().RemoveItems(splitamount);

            CreateHoverIcon();
        }
    }

    public void ChangeStackText(int i)
    {
        splitamount += i;

        if(splitamount < 0)
        {
            splitamount = 0;
        }
        if (splitamount > maxStackCount)
        {
            splitamount = maxStackCount;
        }

        stacktext.text = splitamount.ToString();
    }

    public void MergeStacks(Slot source, Slot destination)
    {
        int max = destination.CurrentItem.maxSize - destination.Items.Count;
        int count = source.Items.Count < max ? source.Items.Count : max;

        for (int i = 0; i < count; i++)
        {
            destination.Additem(source.RemoveItem());
            hoverObject.transform.GetChild(0).GetComponent<Text>().text = movingSlot.Items.Count.ToString();

        }
        if (source.Items.Count == 0)
        {
            source.ClearSlot();
            Destroy(GameObject.Find("Hover"));
        }
    }

    // SAVING -------------------------------------------------------------
    public void SaveInventory()
    {
        string content = string.Empty;

        for (int i =0; i < allslots.Count; i++)
        {
            Slot tmp = allslots[i].GetComponent<Slot>();

            if (!tmp.IsEmpty)
            {
                content += i + "-" + tmp.CurrentItem.type.ToString() + "-" + tmp.Items.Count.ToString() + ";";
            }
        }
        PlayerPrefs.SetString("content", content);
        PlayerPrefs.SetInt("slots", slots);
        PlayerPrefs.SetInt("rows", rows);
        PlayerPrefs.SetFloat("slotpaddingleft", slotpaddingleft);
        PlayerPrefs.SetFloat("slotpaddingtop", slotpaddingtop);
        PlayerPrefs.SetFloat("slotsize", slotsize);
        PlayerPrefs.SetFloat("xPos", inventoryRect.position.x);
        Debug.Log(inventoryRect.position.y);
        PlayerPrefs.SetFloat("yPos", inventoryRect.position.y);

        PlayerPrefs.Save();
    }

    //LOADING --------------------------------------------------------------------
public void Loadinventory()
    {
        string content = PlayerPrefs.GetString("content");
        slots = PlayerPrefs.GetInt("slots");
        rows = PlayerPrefs.GetInt("rows");
        slotpaddingleft = PlayerPrefs.GetFloat("slotpaddingleft");
        slotpaddingtop = PlayerPrefs.GetFloat("slotpaddingtop");
        slotsize = PlayerPrefs.GetFloat("slotsize");

        Debug.Log(PlayerPrefs.GetFloat("yPos"));
        inventoryRect.position = new Vector3(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"), inventoryRect.position.z);
        Debug.Log(inventoryRect.position.y);

        Createlayout();

        string[] splitcontent = content.Split(';');

        for (int x = 0; x < splitcontent.Length-1; x++)
        {
            string[] splitvalues = splitcontent[x].Split('-');
            int index = Int32.Parse(splitvalues[0]);
            ItemType type = (ItemType)Enum.Parse(typeof(ItemType), splitvalues[1]);
            int amount = Int32.Parse(splitvalues[2]);
            for (int i = 0; i < amount; i++)
            {
                switch (type)
                {
                    case ItemType.HEALTH:
                        allslots[index].GetComponent<Slot>().Additem(health.GetComponent<Item>());
                        break;
                    case ItemType.CROWBAR:
                        allslots[index].GetComponent<Slot>().Additem(crowbar.GetComponent<Item>());
                        break;
                }
            }
        }
    }
}
