using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public static BackPackManager Instance;
    // 배낭 UI를 참조하는 공개된 GameObject
    public GameObject BackPack_UI;
    public Text CoinText;

    public Image[] ItemImages;
    private InventoryItemData[] InventoryItemDatas;

    private int defItemUsingCount = 0;
    private int speedItemUsingCount = 0;
    private int powerItemUsingCount = 0;

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

    public void ItemUse()
    {
        int siblingIndex = EventSystem.current.currentSelectedGameObject.transform.parent.GetSiblingIndex();
        InventoryItemData inventoryItem = InventoryItemDatas[siblingIndex];
        if (inventoryItem == null) return;

        if (inventoryItem.itemID == "HP")
        {
            GameManager.Instance.PlayerHP += 10f;
            GameManager.Instance.PlayerHP = Mathf.Min(GameManager.Instance.PlayerHP, 100f);
            PopupMsgManager.instance.ShowPopupMessage("체력이 10 회복되었습니다.");
        }
        else if (inventoryItem.itemID == "MP")
        {
            GameManager.Instance.PlayerMP += 10f;
            GameManager.Instance.PlayerMP = Mathf.Min(GameManager.Instance.PlayerMP, 100f);
            PopupMsgManager.instance.ShowPopupMessage("마나가 10 회복되었습니다.");
        }
        else if (inventoryItem.itemID == "HP_Power")
        {
            GameManager.Instance.PlayerHP += 100f;
            PopupMsgManager.instance.ShowPopupMessage("체력 전체가 회복 되었습니다.");
        }
        else if (inventoryItem.itemID == "MP_Power")
        {
            GameManager.Instance.PlayerMP += 100f;
            PopupMsgManager.instance.ShowPopupMessage("마나 전체가 회복 되었습니다.");
        }
        else if (inventoryItem.itemID == "Def")
        {
            StartCoroutine(DefItem());
        }
        else if (inventoryItem.itemID == "Speed")
        {
            StartCoroutine(SpeedItem());
        }
        else if (inventoryItem.itemID == "Power")
        {
            StartCoroutine(PowerItem());
        }
        else if (inventoryItem.itemID == "Super")
        {
            //보스전 나올 때 구현
        }
        else
        {
            Debug.LogError($"존재하지 않는 itemID[{inventoryItem.itemID}]");
            return;
        }

        InventoryItemDatas[siblingIndex] = null;
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
    } //End Item Use Method

    IEnumerator DefItem()
    {
        defItemUsingCount++;
        GameManager.Instance.PlayerDef *= 2;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("1. PlayerDef : " + GameManager.Instance.PlayerDef);
        yield return new WaitForSeconds(10f);

        defItemUsingCount--;
        GameManager.Instance.PlayerDef /= 2;
        if (defItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("2. PlayerDef : " + GameManager.Instance.PlayerDef);
    }

    IEnumerator SpeedItem()
    {
        speedItemUsingCount++;
        GameManager.Instance.Character.Speed *= 2f;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("1. Speed : " + GameManager.Instance.Character.Speed);
        yield return new WaitForSeconds(10f);

        speedItemUsingCount--;
        GameManager.Instance.Character.Speed /= 2f;
        if (speedItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("2. Speed : " + GameManager.Instance.Character.Speed);
    }

    IEnumerator PowerItem()
    {
        powerItemUsingCount++;
        GameManager.Instance.CharacterAttack.AttackDamage *= 2f;
        GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("1. Character Power.AttackDamage : " + GameManager.Instance.CharacterAttack.AttackDamage);
        yield return new WaitForSeconds(10f);

        powerItemUsingCount--;
        GameManager.Instance.CharacterAttack.AttackDamage /= 2f;
        if (powerItemUsingCount == 0)
            GameManager.Instance.Character.GetComponent<SpriteRenderer>().color = Color.white;
        Debug.Log("2. Character Power.AttackDamage : " + GameManager.Instance.CharacterAttack.AttackDamage);
    }
}
