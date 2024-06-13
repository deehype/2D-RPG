using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    

    public Image CharacterImg;
    public Text IdText;

    public Slider HpSlider;

    private GameObject player;
    public GameObject spawnPos;

    public Text Damage, Speed;

    

    

    void Start()
    {
        
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    void Update()
    {
        display();
        //UpdateMonsterCount();
    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHP;

        Damage.text = "Damage : " + GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage;
        Speed.text = "Speed : " + GameManager.Instance.player.GetComponent<Character>().Speed;
    }

    

    
}
