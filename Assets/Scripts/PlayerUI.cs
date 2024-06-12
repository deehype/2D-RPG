using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject gameOverPanel; // 게임 오버 패널 (팝업 메시지)
    public string endSceneName = "EndScene"; // 종료씬의 이름

    public Image CharacterImg;
    public Text IdText;

    public Slider HpSlider;

    private GameObject player;
    public GameObject spawnPos;

    public Text Damage, Speed;

    public Text monsterCountText; // 몬스터 개수를 표시할 UI 텍스트

    void OnDestroy()
    {
       //UpdateMonsterCount();
    }

    void Start()
    {
        // 초기 몬스터 개수를 설정
        gameOverPanel.SetActive(false); // 게임 오버 패널 비활성화
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    void Update()
    {
        display();
        UpdateMonsterCount();
    }

    private void display()
    {
        CharacterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHP;

        Damage.text = "Damage : " + GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage;
        Speed.text = "Speed : " + GameManager.Instance.player.GetComponent<Character>().Speed;
    }

    public void UpdateMonsterCount()
    {
        // 몬스터 개수 업데이트 (이 함수는 몬스터가 생성되거나 제거될 때 호출되어야 함)
        GameManager.Instance.monsterCount = FindObjectsOfType<Monster>().Length;
        monsterCountText.text = "Monsters: " + GameManager.Instance.monsterCount;

        if (GameManager.Instance.monsterCount == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        gameOverPanel.SetActive(true); // 게임 오버 패널 활성화
        yield return new WaitForSeconds(2f); // 2초 대기
        SceneManager.LoadScene(endSceneName); // 종료씬으로 이동

    }
}
