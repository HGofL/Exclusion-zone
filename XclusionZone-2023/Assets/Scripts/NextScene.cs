using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        FindObjectOfType<LevelManager>().LoadNextScene();
    }
}
