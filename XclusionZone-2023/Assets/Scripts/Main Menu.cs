using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image centerNavigationImage;
    public Sprite playSprite;
    public Sprite quitSprite;

    private Sprite originalSprite;

    void Start()
    {
        // Store the original sprite
        originalSprite = centerNavigationImage.sprite;
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnQuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the image when pointer enters the button
        if (gameObject.name == "StartButton")
        {
            centerNavigationImage.sprite = playSprite;
        }
        else if (gameObject.name == "QuitButton")
        {
            centerNavigationImage.sprite = quitSprite;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset the image when pointer exits the button
        centerNavigationImage.sprite = originalSprite;
    }
}
