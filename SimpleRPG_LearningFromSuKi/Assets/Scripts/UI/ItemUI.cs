using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    private ItemSO itemSO;

    public void InitItem(ItemSO itemSO)
    {
        string type = null;
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                type = "武器"; break;
            case ItemType.Consumble:
                type = "消耗品"; break;
        }
        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        typeText.text = type;
        this.itemSO = itemSO;
    }
    
    public void OnClick()
    {
        InventoryUI.Instance.OnItemClick(itemSO, this);
    }
}
