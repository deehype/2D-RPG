using UnityEngine;

public class Monster : MonoBehaviour
{
    public float MonsterHP = 30f;
    public float MonsterDamage = 2f;
    public float MonsterExp = 3;

    private float moveTime = 0f;
    private float TurnTime = 0;
    private bool isDie = false;

    public float MoveSpeed = 3f;
    public GameObject[] ItemObj; //마나, 체력, 코인

    private Animator MonsterAnimator;

    private int monsterCount = 0; //필드에 있는 몬스터 수

    private GameManager GameManager;

    void Start()
    {
        MonsterAnimator = this.GetComponent<Animator>();

        GameManager = FindObjectOfType<GameManager>();


    }

    void Update()
    {
        MonsterMove();
    }

    

    private void MonsterMove()
    {
        if (isDie) return;
        
        moveTime += Time.deltaTime;

        if (moveTime <= TurnTime)
        {
            this.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            TurnTime = Random.Range(1, 3);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) return;

        if (collision.gameObject.tag == "Player")
        {
            MonsterAnimator.SetTrigger("Attack");
            GameManager.Instance.PlayerHP -= MonsterDamage;
        }

        if (collision.gameObject.tag == "Attack")
        {
            MonsterAnimator.SetTrigger("Damage");
            MonsterHP -= collision.gameObject.GetComponent<Attack>().AttackDamage;

            if (MonsterHP <= 0)
            {
                MonsterDie();
            }
        }
    }

    private void MonsterDie()
    {
        isDie = true;
        MonsterAnimator.SetTrigger("Die");
        GameManager.Instance.PlayerExp += MonsterExp;

        GetComponent<Collider2D>().enabled = false;
        Invoke("CreateItem", 1.5f);

    }

    private void CreateItem()
    {
        int itemRandom = Random.Range(0, ItemObj.Length);
        if (itemRandom < ItemObj.Length)
        {
            Instantiate(ItemObj[itemRandom], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        Destroy(gameObject);
    }

    // 몬스터가 생성될 때마다 호출되는 함수
    public void IncrementMonsterCount()
    {
        monsterCount++; // 몬스터 수 증가
        UpdateMonsterCountUI(); // UI 업데이트
    }

    // 몬스터가 사라질 때마다 호출되는 함수
    public void DecrementMonsterCount()
    {
        monsterCount--; // 몬스터 수 감소
        UpdateMonsterCountUI(); // UI 업데이트
    }

    // UI 업데이트 함수
    void UpdateMonsterCountUI()
    {
        Debug.Log(monsterCount);
        // 여기에 필요한 UI 업데이트 코드를 추가하세요.
    }
}
