using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance = null;
    public bool gameStarted = false;
    public TextMeshProUGUI title = null;
    public Button startButton = null;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
    public void StartGame()
    {
        gameStarted = true;
        title.enabled = false;
        startButton.gameObject.SetActive(false);
    }
}