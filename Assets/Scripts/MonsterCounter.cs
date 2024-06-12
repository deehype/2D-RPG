using UnityEngine;
using UnityEngine.UI;

public class MonsterCounter : MonoBehaviour
{
    public Text monsterCountText;
    

    void Update()
    {
        // "Monster" �±׸� ���� ��� ���� ������Ʈ�� ã���ϴ�.
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        // ���� ������ �����ɴϴ�.
        int monsterCount = monsters.Length;
        // Text UI�� ���� ������ ǥ���մϴ�.
        monsterCountText.text = monsterCount.ToString();
    }
}
