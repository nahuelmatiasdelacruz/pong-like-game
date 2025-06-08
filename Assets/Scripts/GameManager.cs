using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance = null;
    public bool gameStarted = false;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
}