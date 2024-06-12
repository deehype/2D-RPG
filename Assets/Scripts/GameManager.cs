using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    

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
        DontDestroyOnLoad(Instance);
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + SelectedPlayer.ToString());
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }

    void Start()
    {
        
        playTime = 0f;
        isPlaying = true;
        StartCoroutine(UpdatePlayTime());

        gameManager = FindObjectOfType<GameManager>();
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

   

    
}
