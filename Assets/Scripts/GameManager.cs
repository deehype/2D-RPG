using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string CharacterName;
    public string UserID;

    public float PlayerHP = 100f; //체력
    public float PlayerMP = 100f;
    public float PlayerExp = 1f; //경험치
    public float PlayerDef = 1f;
    public int Coin = 0;

    public GameObject player;

    public Character Character
    {
        get { return player.GetComponent<Character>(); }
    }

    public Attack CharacterAttack
    {
        get { return Character.AttackObj.GetComponent<Attack>();}
    }

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

        DontDestroyOnLoad(Instance);
    }

    private void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + CharacterName);
        player = Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);

        return player;
    }
}
