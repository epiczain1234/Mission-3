using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class CountDownTimer : MonoBehaviour
{
    // Start is called before the first frame
    float currentTime;
    float startingTime = 60f;
    int time;
    [SerializeField] Text countdownText;
    void Start()
    {
       currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
       currentTime -= 1 * Time.deltaTime;
       time = (int)(currentTime);
       countdownText.text = time.ToString();
       // TODO: Re-enable countdown timer
       if (0 >= currentTime){   
         Disconnect(); 
         SceneManager.LoadScene("WinScene");
         
       }
    }
       IEnumerator Disconnect(){
       PhotonNetwork.LeaveRoom();
       while(PhotonNetwork.InRoom)
          yield return null;
        Debug.Log("Left Room");
     }
}
