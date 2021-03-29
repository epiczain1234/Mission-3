using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class Networklights4 : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    private PhotonView correlatedView;
    void Start(){
      photonView = GameObject.Find("Sphere4").GetComponent<PhotonView>();
      correlatedView = GameObject.Find("Sphere4c").GetComponent<PhotonView>();
    }
    // use this function on a ui button (will eventuall move this to a lever)
    // public void ChangeColorOnClick(){
    //   photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
    // }
    void OnMouseOver(){
      if (Input.GetMouseButtonUp(0)){
        Debug.Log("Sphere Click detected");
        photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
      }
    }

    [PunRPC]
    void RPC_ChangeColor(){
        Debug.Log("Color change code executed");
        if (GetComponent<Renderer>().material.color == Color.red){
            GetComponent<Renderer>().material.color = Color.green;
        }
        // if material is green and clicked (Strike Condition)
        else{
          int oldStrikes = (int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] + 1;
          PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable{{"Strikes", oldStrikes}});
          Debug.Log("We now have a total of " + (int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] + " strikes");
        }
        correlatedView.RPC("turnSphereRed", RpcTarget.All, null);

    }
      [PunRPC]
    public void turnSphereRed(){
          Debug.Log("attempting to grab a sphere4 and chance it color");
          photonView.GetComponent<Renderer>().material.color = Color.red;
        
     } 
    // essetial interface component
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
}
