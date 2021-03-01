using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateRoom : MonoBehaviourPunCallbacks
{
 //  TODO: setup random room name generation for multiple concurrent room instance
  public void OnClick_CreateRoom(){
    RoomOptions options = new RoomOptions();
    options.MaxPlayers = 4;
    string randomRoomName = "Room" + Random.Range(0, 1000);
    PhotonNetwork.JoinOrCreateRoom(randomRoomName, options, TypedLobby.Default);
  }

  public override void OnCreatedRoom(){
//    MasterManager.DebugConsole.AddText("Created Room Successfully", this);
  //  Debug.Log("Room created");
    SceneManager.LoadScene("Actual");
    Debug.Log("The current client has created a room and joined it");
  }

  public override void OnJoinedRoom(){
    Debug.Log(PhotonNetwork.NickName + " joined " + PhotonNetwork.CurrentRoom.Name + " Player Count is now " + PhotonNetwork.CurrentRoom.PlayerCount);
  }

  public override void OnCreateRoomFailed(short returnCode, string message){
    //  MasterManager.DebugConsole.AddText("Room Creation Failed " + , this);
    Debug.Log("Room Creation Failed");
  }
  public override void OnPlayerEnteredRoom(Player newPlayer){
    Debug.Log(newPlayer.NickName + " Joined " + PhotonNetwork.CurrentRoom.Name + " Player Count is now " + PhotonNetwork.CurrentRoom.PlayerCount);
  }

}
