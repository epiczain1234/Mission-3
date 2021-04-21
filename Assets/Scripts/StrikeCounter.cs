using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class StrikeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text strikes;
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] == 1){
            strikes.text = "X";
        }
        if ((int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] == 2){
            strikes.text = "X X";
        }
        if ((int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] == 3){
            strikes.text = "X X X ";
        }
    }
}
