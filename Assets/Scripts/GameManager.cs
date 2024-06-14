using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Text monsterCountText; // 몬스터 개수를 표시할 UI 텍스트
    public GameObject gameOverPanel; // 게임 오버 패널 (팝업 메시지)
    public string endSceneName = "EndScene"; // 종료씬의 이름

    public static GameManager Instance;

    public Define.Player SelectedPlayer;
    public string UserID;

    public float PlayerHP = 100f; //체력
    public float PlayerExp = 1f; //경험치
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
        // 초기 몬스터 개수를 설정
        gameOverPanel.SetActive(false); // 게임 오버 패널 비활성화

        gameManager = FindObjectOfType<GameManager>();

        // 초기 몬스터 개수를 세팅합니다.
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

        // 모든 몬스터가 제거되었을 때 게임 종료 처리
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
        gameOverPanel.SetActive(true); // 게임 오버 패널 활성화
        yield return new WaitForSeconds(2f); // 2초 대기
        SceneManager.LoadScene(endSceneName); // 종료씬으로 이동
    }

    public void EndGame()
    {
        StartCoroutine(ShowEndMessageAndLoadScene());
    }

    IEnumerator ShowEndMessageAndLoadScene()
    {
        // 팝업 메시지 표시
        gameOverPanel.SetActive(true);
        // 2초 대기
        yield return new WaitForSeconds(2);
        // 종료 씬으로 이동
        SceneManager.LoadScene(endSceneName);
    }
}
