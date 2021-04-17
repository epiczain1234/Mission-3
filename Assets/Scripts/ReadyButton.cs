using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ReadyButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void On_Click_LoadSceneOrGiveError(){
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2){
            SceneManager.LoadScene("MultiplayerRoom");
        }
        else{
          Debug.Log("Not Enough Players to start game");
          // display pop-up message that there are not enought players

        }
    }
}
