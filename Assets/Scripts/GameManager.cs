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


    public Text playTimeText; // 플레이 타임을 표시할 UI 텍스트

    private float playTime; // 플레이 타임을 기록할 변수
    private bool isPlaying; // 게임이 진행 중인지 여부


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

        // 초기 몬스터 개수를 설정
        gameOverPanel.SetActive(false); // 게임 오버 패널 비활성화
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
            // 플레이 타임을 UI 텍스트에 업데이트
            playTimeText.text = "Play Time: " + FormatTime(playTime);
            yield return new WaitForSeconds(1f); // 1초마다 업데이트
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
        // 몬스터 개수 업데이트 (이 함수는 몬스터가 생성되거나 제거될 때 호출되어야 함)
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


