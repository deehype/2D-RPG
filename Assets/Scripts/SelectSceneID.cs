using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSceneID : MonoBehaviour
{
    public Text idText;

    private void Start()
    {
        idText = GetComponent<Text>();
        idText.text = GameManager.Instance.UserID;
    }
}
