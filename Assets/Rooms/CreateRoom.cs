using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateRoom : MonoBehaviourPunCallbacks
{
  // [SerializedField]
  // private Text _roomName;
  // Add modular room name in create funciton

  public void OnClick_CreateRoom(){
    RoomOptions options = new RoomOptions();
    options.MaxPlayers = 4;
    PhotonNetwork.JoinOrCreateRoom("basic", options, TypedLobby.Default);
  }

  public override void OnCreatedRoom(){
//    MasterManager.DebugConsole.AddText("Created Room Successfully", this);
    Debug.Log("Room created");
    SceneManager.LoadScene("Actual");

  }

  public override void OnCreateRoomFailed(short returnCode, string message){
    //  MasterManager.DebugConsole.AddText("Room Creation Failed " + , this);
    Debug.Log("Room Creation Failed");
  }
}
