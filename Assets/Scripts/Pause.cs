using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public TextMeshProUGUI changeButtonText;
    bool ispaused=false;
    public GameObject mainSound;

    public void Star()
    {
        changeButtonText=GetComponent<TextMeshProUGUI>();
    }
    public void pauseGame()
    {
        if(ispaused)
        {
            Time.timeScale=1;
            ispaused=false;
            mainSound.gameObject.SetActive(true);
            changeButtonText.text="PAUSE";
        }
        else
        {
            Time.timeScale=0;
            ispaused=true;
            mainSound.gameObject.SetActive(false);
            changeButtonText.text="PLAY";
        }
    }
}
