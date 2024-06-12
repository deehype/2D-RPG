using UnityEngine;
using UnityEngine.UI;

public class MonsterCounter : MonoBehaviour
{
    public Text monsterCountText;
    

    void Update()
    {
        // "Monster" 태그를 가진 모든 게임 오브젝트를 찾습니다.
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        // 몬스터 개수를 가져옵니다.
        int monsterCount = monsters.Length;
        // Text UI에 몬스터 개수를 표시합니다.
        monsterCountText.text = monsterCount.ToString();
    }
}
