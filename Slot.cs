using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Stack<Item> items;


    public Text StackTxt;
    public Sprite slotEmpty;
    public Sprite slotHighlight;
    public bool IsEmpty
    {
        get { return Items.Count == 0;  }
    }

    public bool IsAvailable
    {
        get {return CurrentItem.maxSize > Items.Count; }
    }

    public Item CurrentItem
    {
        get { return Items.Peek(); }
    }

    public Stack<Item> Items
    {
        get
        {
            return items;
        }

        set
        {
            items = value;
        }
    }

    //before start
    void Awake()
    {
        Items = new Stack<Item>();
    }

    // Use this for initialization
    void Start () {

        
        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform txtRect = StackTxt.GetComponent<RectTransform>();

        int txtScleFactor = (int)(slotRect.sizeDelta.x * 0.60);
        StackTxt.resizeTextMaxSize = txtScleFactor;
        StackTxt.resizeTextMinSize = txtScleFactor;

        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x);
        txtRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Additem (Item item)
    {
        Items.Push(item);

        if (Items.Count > 1)
        {
            StackTxt.text = Items.Count.ToString();
        }

        ChangeSprite(item.spriteNeutral, item.spriteHighlighted);
    }

    public void AddItems(Stack<Item> items)
    {
        this.Items = new Stack<Item>(items);

        StackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

        ChangeSprite(CurrentItem.spriteNeutral, CurrentItem.spriteHighlighted);
    }


    private void ChangeSprite(Sprite neutral, Sprite highlight)
    {
        GetComponent<Image>().sprite = neutral;

        SpriteState st = new SpriteState();

        st.highlightedSprite = highlight;
        st.pressedSprite = neutral;

        GetComponent<Button>().spriteState = st;
    }

    private void UseItem()
    {
        if (!IsEmpty)
        {
            Items.Pop().Use();

            StackTxt.text = Items.Count > 1 ? Items.Count.ToString() : string.Empty;

            if (IsEmpty)
            {
                ChangeSprite(slotEmpty, slotHighlight);
                Inventory.EmptySlot++;
            }
        }
    }

    public void ClearSlot()
    {
        Items.Clear();
        ChangeSprite(slotEmpty, slotHighlight);
        StackTxt.text = string.Empty;
    }

    public Stack<Item> RemoveItems(int amount)
    {
        Stack<Item> tmp = new Stack<Item>();
        for (int i = 0; i < amount; i++)
        {
            tmp.Push(items.Pop());
        }

        StackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

        return tmp;

    }

    public Item RemoveItem()
    {
        Item tmp;
        tmp = Items.Pop();
        StackTxt.text = items.Count > 1 ? items.Count.ToString() : string.Empty;
        return tmp;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
     if (eventData.button == PointerEventData.InputButton.Right && !GameObject.Find("Hover"))
        {
            UseItem();
        }
     else if (eventData.button == PointerEventData.InputButton.Left && Input.GetKey(KeyCode.LeftShift) && !IsEmpty && !GameObject.Find("Hover"))
        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(Inventory.Instance.canvas.transform as RectTransform, Input.mousePosition, Inventory.Instance.canvas.worldCamera, out position);
            Inventory.Instance.selectstacksize.SetActive(true);
            Inventory.Instance.selectstacksize.transform.position = Inventory.Instance.canvas.transform.TransformPoint(position);
            Inventory.Instance.SetStackInfo(items.Count);
        }
    }

}
