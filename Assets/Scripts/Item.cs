using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Stats & Abilities")]
    public int healthBonus;
    public int ammoBonus;
    public float speedBonus;
    public float fireRateBonus;
    public float reloadBonus;
    public string specialAbility;

    [Header("Description")]

    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    
    
    private float itemTextClock;
    private bool textShown;

    private TMPro.TextMeshProUGUI itemTitle;
    private TMPro.TextMeshProUGUI itemSubtitle;
    private RoomManager roomManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemTitle = GameObject.Find("ItemTitle").GetComponent<TMPro.TextMeshProUGUI>();
        itemSubtitle = GameObject.Find("ItemSubtitle").GetComponent<TMPro.TextMeshProUGUI>();
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();
        textShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (textShown == true)
        {
            itemTitle.text = itemName;
            itemSubtitle.text = itemDescription;
            if (itemTextClock < Time.time)
            {
                itemTitle.text = "";
                itemSubtitle.text = "";
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (textShown == false)
            {
                collision.GetComponent<ItemManager>().NewItem(this);
                itemTextClock = Time.time + 2f;
                textShown = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
                roomManager.rooms[roomManager.position].treasureTaken = true;
            }
        }
    }
}
