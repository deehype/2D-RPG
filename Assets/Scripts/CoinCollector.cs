using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public int coins = 0; //���� ��

    public Text coinText; // UI�� ǥ�õ� �ؽ�Ʈ

    //������ �Ծ��� �� ȣ��Ǵ� �Լ�
    public void Collectcoin()
    {
        coins++; //���� �� ����
        UpdateCoinUI(); //UI ������Ʈ
    }

    // UI ������Ʈ �Լ�
    void UpdateCoinUI()
    {
        coinText.text =coins.ToString(); //���� ���� UI�� �ݿ�
    }
}
