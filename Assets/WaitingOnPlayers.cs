using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WaitingOnPlayers : MonoBehaviour
{
    // Start is called before the first frame update
    float startTime = 5f;
    float currentTime;
    [SerializeField] Text countdownText;
    void Start()
    {
      currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
      if (PhotonNetwork.CurrentRoom.PlayerCount == 2){
        currentTime -= 1 * Time.deltaTime;
        Debug.Log(currentTime + " seconds left till game start");
        if (0 >= currentTime){
          SceneManager.LoadScene("MultiplayerRoom");
        }


      }
    }
    void countDown(){

    }

}
