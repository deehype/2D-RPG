using UnityEngine;
using UnityEngine.UI;

public class PlayTimeDisplay : MonoBehaviour
{
    // UI �ؽ�Ʈ ������Ʈ�� ���� ����
    public Text playTimeText;

    // �÷��� Ÿ���� �����ϴ� ����
    private float playTime;

    void Update()
    {
        // �� �����Ӹ��� �÷��� Ÿ���� ������ŵ�ϴ�.
        playTime += Time.deltaTime;

        // �÷��� Ÿ���� ��, ��, �� �������� ��ȯ�մϴ�.
        int minutes = Mathf.FloorToInt((playTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);

        // �ؽ�Ʈ ������Ʈ�� �÷��� Ÿ���� ǥ���մϴ�.
        playTimeText.text = $"Play Time: {minutes:D2}:{seconds:D2}";
    }
}
