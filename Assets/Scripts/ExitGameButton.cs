using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameButton : MonoBehaviour
{
    //나가기 버튼을 눌렀을 때 호출될 함수
    public void ExitGame()
    {
        //게임 종료
        Application.Quit();
    }
}
