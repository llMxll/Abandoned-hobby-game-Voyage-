using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Quickbar : MonoBehaviour {

    private RectTransform QSRect;
    private float QSwidth, QSheight;
    public int slots;
    public int rows;
    public float slotpaddingleft, slotpaddingtop;
    public float slotsize;
    public GameObject QSslotPrefab;
    private List<GameObject> allslots;

    private static Slot from, to;

    public GameObject iconPrefab;
    private static GameObject hoverObject;
    public Canvas canvas;

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

        Createlayout();

    }
	
	void Update ()
    {
        //Things that happen when item clicked outside QS atm destroy
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
        }

		if (hoverObject != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out position);
            position.Set(position.x, position.y - hoverYOffset);
            hoverObject.transform.position = canvas.transform.TransformPoint(position);
        }
	}

    private void Createlayout()
    {
        allslots = new List<GameObject>();

        hoverYOffset = slotsize * 0.01f;

        EmptySlot = slots;

        QSwidth = (slots / rows) * (slotsize + slotpaddingleft) + slotpaddingleft;
        QSheight = rows * (slotsize + slotpaddingtop) + slotpaddingtop;
        QSRect = GetComponent<RectTransform>();
        QSRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, QSwidth);
        QSRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, QSheight);

        int coloumns = slots / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < coloumns; x++)
            {
                GameObject newslot = (GameObject)Instantiate(QSslotPrefab);
                RectTransform slotRect = newslot.GetComponent<RectTransform>();
                newslot.name = "Slot";
                newslot.transform.SetParent(this.transform.parent);
                slotRect.localPosition = QSRect.localPosition + new Vector3(slotpaddingleft * (x + 1) + (slotsize * (x + 1)) - QSwidth/2, slotpaddingtop * (y + 1) - (slotsize * y));
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotsize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotsize);
                allslots.Add(newslot);
            }
        }
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
            foreach(GameObject slot in allslots)
            {
                Slot tmp = slot.GetComponent<Slot>();

                if (!tmp.IsEmpty)
                {
                    if (tmp.CurrentItem.type == item.type && tmp.IsAvailable)
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
        if (from == null)
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.gray;

                hoverObject = (GameObject)Instantiate(iconPrefab);
                hoverObject.GetComponent<Image>().sprite = clicked.GetComponent<Image>().sprite;
                hoverObject.name = "Hover";

                RectTransform hoverTransform = hoverObject.GetComponent<RectTransform>();
                RectTransform clickedTransform = clicked.GetComponent<RectTransform>();

                hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, clickedTransform.sizeDelta.x);
                hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clickedTransform.sizeDelta.y);

                hoverObject.transform.SetParent(GameObject.Find("GUI").transform, true);
                hoverObject.transform.localScale = from.gameObject.transform.localScale;
            }
        }
        else if (to == null)
        {
            to = clicked.GetComponent<Slot>();
            Destroy(GameObject.Find("Hover"));
        }
        if (to != null && from != null)
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
            from.GetComponent<Image>().color = Color.white;
            to = null;
            from = null;
            hoverObject = null;
        }
    }
}
