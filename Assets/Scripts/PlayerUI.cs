using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject gameOverPanel; // ���� ���� �г� (�˾� �޽���)
    public string endSceneName = "EndScene"; // ������� �̸�

    public Image CharacterImg;
    public Text IdText;

    public Slider HpSlider;

    private GameObject player;
    public GameObject spawnPos;

    public Text Damage, Speed;

    public Text monsterCountText; // ���� ������ ǥ���� UI �ؽ�Ʈ

    void OnDestroy()
    {
       //UpdateMonsterCount();
    }

    void Start()
    {
        // �ʱ� ���� ������ ����
        gameOverPanel.SetActive(false); // ���� ���� �г� ��Ȱ��ȭ
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
        // ���� ���� ������Ʈ (�� �Լ��� ���Ͱ� �����ǰų� ���ŵ� �� ȣ��Ǿ�� ��)
        GameManager.Instance.monsterCount = FindObjectsOfType<Monster>().Length;
        monsterCountText.text = "Monsters: " + GameManager.Instance.monsterCount;

        if (GameManager.Instance.monsterCount == 0)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        gameOverPanel.SetActive(true); // ���� ���� �г� Ȱ��ȭ
        yield return new WaitForSeconds(2f); // 2�� ���
        SceneManager.LoadScene(endSceneName); // ��������� �̵�

    }
}
