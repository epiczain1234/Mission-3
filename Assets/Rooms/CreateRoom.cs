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

    // PhotonNetwork.JoinOrCreateRoom(randomRoomName, options, TypedLobby.Default);
    PhotonNetwork.JoinRoom("Mission3");
  }

  public override void OnCreatedRoom(){
//    MasterManager.DebugConsole.AddText("Created Room Successfully", this);
  //  Debug.Log("Room created");

    Debug.Log("The current client has created a room and joined it");
  }
  public override void OnJoinRoomFailed(short returnCode, string message){
    Debug.Log("Failed to join room, creating a new one...");
    RoomOptions options = new RoomOptions();
    options.MaxPlayers = 2;
    string randomRoomName = "Mission3";
    PhotonNetwork.CreateRoom(randomRoomName, options, null);
  }

  public override void OnJoinedRoom(){
    SceneManager.LoadScene("ReadyUp");
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
