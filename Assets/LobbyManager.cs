using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [Header("Login UI")]
    public InputField playerNameInputField;
    public GameObject UI_LoginGameObject;
    //
    //
    // [Header("Connection Status UI")]
    // public GameObject ui_ConnectionStatusObject;
    //



    #region UNITY Methods
    void Start()
    {
        // uI_LobbyGameObject.SetActive(false);
        // ui_ConnectionStatusObject.SetActive(false);
        // UI_LoginGameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion


    #region UI Callback Methods
    public void OnEnterButtonClicked(){
      //uI_LobbyGameObject.SetActive(false);
      // UI_LoginGameObject.SetActive(false);
      // ui_ConnectionStatusObject.SetActive(true);

         string playerName = playerNameInputField.text;

         if (!string.IsNullOrEmpty(playerName)){
             PhotonNetwork.LocalPlayer.NickName = playerName;
             SceneManager.LoadScene("Connecting");
             PhotonNetwork.ConnectUsingSettings();
            if (PhotonNetwork.IsConnected){
                 SceneManager.LoadScene("Connected");
                 Debug.Log("Connected to server");
           }

         }
         else{
           Debug.Log("Null or Empty player name");
         }
    }
    #endregion

    // public void switchScene(){
    //   SceneManager.LoadScene("");
    // }


    #region PHOTON Callback Methods
    public override void OnConnected()
    {
        Debug.Log("We are connected to the Internet");

        // base.OnConnected();

    }
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to the server");
    }
    #endregion






}
