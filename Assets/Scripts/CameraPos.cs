using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPos : MonoBehaviour
{
    private GameObject playerObj;

    void Start()
    {
    }

    void Update()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y + 3, transform.position.z);
    }


}
