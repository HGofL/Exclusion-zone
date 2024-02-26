using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   
   public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public static LevelManager instance;

   public GameObject deathScene;


   private void Awake()
   {
       if (LevelManager.instance == null) instance = this;
       else Destroy(gameObject);
   }

   public void GameOver()
   {
       UIManager _ui = GetComponent<UIManager>();
       if (_ui != null)
       {
           _ui.ToggleDeathPanel();
       }
   }

   public void RestartGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
