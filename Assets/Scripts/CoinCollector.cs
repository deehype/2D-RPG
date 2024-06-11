using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int coins = 0; //코인 수

    public Text coinText; // UI에 표시될 텍스트

    //코인을 먹었을 때 호출되는 함수
    public void Collectcoin()
    {
        coins++; //코인 수 증가
        UpdateCoinUI(); //UI 업데이트
    }

    // UI 업데이트 함수
    void UpdateCoinUI()
    {
        coinText.text =coins.ToString(); //코인 수를 UI에 반영
    }
}
