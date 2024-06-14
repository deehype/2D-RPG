using UnityEngine;
using UnityEngine.UI;

public class PlayTimeDisplay : MonoBehaviour
{
    // UI 텍스트 컴포넌트에 대한 참조
    public Text playTimeText;

    // 플레이 타임을 추적하는 변수
    private float playTime;

    void Update()
    {
        // 매 프레임마다 플레이 타임을 증가시킵니다.
        playTime += Time.deltaTime;

        // 플레이 타임을 시, 분, 초 형식으로 변환합니다.
        int minutes = Mathf.FloorToInt((playTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(playTime % 60);

        // 텍스트 컴포넌트에 플레이 타임을 표시합니다.
        playTimeText.text = $"Play Time: {minutes:D2}:{seconds:D2}";
    }
}
