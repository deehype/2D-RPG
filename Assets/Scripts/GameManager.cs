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


    public Text playTimeText; // �÷��� Ÿ���� ǥ���� UI �ؽ�Ʈ

    private float playTime; // �÷��� Ÿ���� ����� ����
    private bool isPlaying; // ������ ���� ������ ����


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
        playTime = 0f;
        isPlaying = true;
        StartCoroutine(UpdatePlayTime());

        gameManager = FindObjectOfType<GameManager>();
    }

    void OnDestroy()
    {
        UpdateMonsterCount();
    }

    private void Update()
    {
        if (isPlaying)
        {
            playTime += Time.deltaTime;
        }
    }

    IEnumerator UpdatePlayTime()
    {
        while (isPlaying)
        {
            // �÷��� Ÿ���� UI �ؽ�Ʈ�� ������Ʈ
            playTimeText.text = "Play Time: " + FormatTime(playTime);
            yield return new WaitForSeconds(1f); // 1�ʸ��� ������Ʈ
        }
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    public void IncrementMonsterCount()
    {
        monsterCount++;
        UpdateMonsterCount();
    }

    public void UpdateMonsterCount()
    {
        // ���� ���� ������Ʈ (�� �Լ��� ���Ͱ� �����ǰų� ���ŵ� �� ȣ��Ǿ�� ��)
        GameManager.Instance.monsterCount = FindObjectsOfType<Monster>().Length;

        monsterCount--;
        if (monsterCount == 0)
        {
            EndGame();
        }
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


