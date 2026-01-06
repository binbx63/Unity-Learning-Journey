using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid;
    public GameObject propertyTemplate;

    private ItemSO itemSO;
    private ItemUI itemUI;

    void Start()
    {
        propertyTemplate.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void UpdateItemDetailUI(ItemSO itemSO, ItemUI itemUI)
    {
        this.itemSO = itemSO;
        this.itemUI = itemUI;
        this.gameObject.SetActive(true);

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
        descriptionText.text = itemSO.description;

        foreach (Transform child in propertyGrid.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Destroy(child.gameObject);
            }
        }
        foreach (ItemProperty property in itemSO.propertyList)
        {
            string propertyStr = null;
            string propertyName = null;
            switch (property.propertyType)
            {
                case ItemPropertyType.HPValue:
                    propertyName = "生命值"; break;
                case ItemPropertyType.EnergyValue:
                    propertyName = "饥饿值"; break;
                case ItemPropertyType.MentalValue:
                    propertyName = "精神值"; break;
                case ItemPropertyType.SpeedValue:
                    propertyName = "速度值"; break;
                case ItemPropertyType.AttackValue:
                    propertyName = "攻击力"; break;
                default:
                    break;
            }
            propertyStr = propertyName + "+" + property.value;
            GameObject go = GameObject.Instantiate(propertyTemplate);
            go.SetActive(true);
            go.transform.SetParent(propertyGrid.transform, false);
            go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = propertyStr;
        }
    }
    
    public void OnUseButtonClick()
    {
        InventoryUI.Instance.OnItemUse(itemSO, itemUI);
        this.gameObject.SetActive(false);
    }
}
