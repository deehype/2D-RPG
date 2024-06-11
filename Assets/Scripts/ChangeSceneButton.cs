using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    //이동할 씬의 이름을 지정할 변수
    public string sceneName;

    public void ChangeScene()
    {
        //씬을 로드하여 이동
        SceneManager.LoadScene(sceneName);
    }
}
