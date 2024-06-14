using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Text monsterCountText; // ���� ������ ǥ���� UI �ؽ�Ʈ
    public GameObject gameOverPanel; // ���� ���� �г� (�˾� �޽���)
    public string endSceneName = "EndScene"; // ������� �̸�

    public static GameManager Instance;

    public Define.Player SelectedPlayer;
    public string UserID;

    public float PlayerHP = 100f; //ü��
    public float PlayerExp = 1f; //����ġ
    public int Coin = 0;

    public Text coinText;

    public int monsterCount;
    public GameObject player;

    private GameManager gameManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        UserID = PlayerPrefs.GetString("ID");

        DontDestroyOnLoad(gameObject);
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }

    void Start()
    {
        // �ʱ� ���� ������ ����
        gameOverPanel.SetActive(false); // ���� ���� �г� ��Ȱ��ȭ

        gameManager = FindObjectOfType<GameManager>();

        // �ʱ� ���� ������ �����մϴ�.
        monsterCount = FindObjectsOfType<Monster>().Length;
        UpdateMonsterCountText();
    }

    public void IncrementMonsterCount()
    {
        monsterCount++;
        UpdateMonsterCountText();
    }

    public void DecrementMonsterCount()
    {
        monsterCount--;
        UpdateMonsterCountText();

        // ��� ���Ͱ� ���ŵǾ��� �� ���� ���� ó��
        if (monsterCount <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    private void UpdateMonsterCountText()
    {
        monsterCountText.text = "Monsters: " + monsterCount;
    }

    IEnumerator GameOver()
    {
        gameOverPanel.SetActive(true); // ���� ���� �г� Ȱ��ȭ
        yield return new WaitForSeconds(2f); // 2�� ���
        SceneManager.LoadScene(endSceneName); // ��������� �̵�
    }

    public void EndGame()
    {
        StartCoroutine(ShowEndMessageAndLoadScene());
    }

    IEnumerator ShowEndMessageAndLoadScene()
    {
        // �˾� �޽��� ǥ��
        gameOverPanel.SetActive(true);
        // 2�� ���
        yield return new WaitForSeconds(2);
        // ���� ������ �̵�
        SceneManager.LoadScene(endSceneName);
    }
}
