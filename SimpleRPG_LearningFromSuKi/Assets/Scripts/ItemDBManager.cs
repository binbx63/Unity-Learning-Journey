using UnityEngine;

public class ItemDBManager : MonoBehaviour
{
    public static ItemDBManager Instance { get; private set; }
    public ItemDBSO itemDB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); return;
        }
        Instance = this;
    }

    public ItemSO GetRandomItem()
    {
        int randomIndex = Random.Range(0, itemDB.itemList.Count);
        return itemDB.itemList[randomIndex];
    }
}
