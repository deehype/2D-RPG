using UnityEngine;
using UnityEngine.UI;

public class MonsterCounter : MonoBehaviour
{
    public Text monsterCountText;
    public int monsterCount;

    void Update()
    {
        // "Monster" �±׸� ���� ��� ���� ������Ʈ�� ã���ϴ�.
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        // ���� ������ �����ɴϴ�.
        int monsterCount = monsters.Length;
        // Text UI�� ���� ������ ǥ���մϴ�.
        monsterCountText.text = monsterCount.ToString();

        // ���Ͱ� 0�� �Ǹ� ���� ���Ḧ Ʈ�����մϴ�.
        if (monsterCount == 0)
        {
            GameManager.Instance.EndGame();
        }
    }

    
}
