using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public static BackPackManager Instance;
    // 배낭 UI를 참조하는 공개된 GameObject
    public GameObject BackPack_UI;
    public Text CoinText;

    public Image[] ItemImages;
    private InventoryItemData[] InventoryItemDatas;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InventoryItemDatas = new InventoryItemData[ItemImages.Length];
    }

    void Update()
    {
        BackPackUIOn();
        CoinText.text = $"Coin: {GameManager.Instance.Coin:N0}";
    }

    private void BackPackUIOn()
    {
        // "I" 키가 눌렸는지 확인
        if (Input.GetKeyDown(KeyCode.I))
        {
            // 배낭 UI의 활성 상태를 전환
            // 현재 활성화 상태의 반대 값으로 설정
            BackPack_UI.SetActive(!BackPack_UI.activeSelf);
        }
    }

    public bool AddItem(InventoryItemData item)
    {
        for (int i = 0; i < ItemImages.Length; i++)
        {
            if (ItemImages[i].sprite == null)
            {
                ItemImages[i].sprite = item.itemImage;
                InventoryItemDatas[i] = item;
                return true;
            }
        }
        return false;
    }
}
