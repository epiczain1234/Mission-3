using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class NetworklightsScript : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    private PhotonView correlatedView;
    void Start(){
      photonView = GameObject.Find("Sphere").GetComponent<PhotonView>();
      correlatedView = GameObject.Find("Spherec").GetComponent<PhotonView>();
    }
    // use this function on a ui button (will eventuall move this to a lever)
    // public void ChangeColorOnClick(){
    //   photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
    // }
    // make this so that only actor number 1 can affect change on this sphere
    void OnMouseOver(){
      if (Input.GetMouseButtonUp(0)){
        Debug.Log("Sphere Click detected");
        photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
      }
    }

    [PunRPC]
    void RPC_ChangeColor(){
        Debug.Log("Color change code executed for sphere to end game");
        if (GetComponent<Renderer>().material.color == Color.red){
            GetComponent<Renderer>().material.color = Color.green;
        }
        else {
          int oldStrikes = (int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] + 1;
          Debug.Log("More Strikes");
          PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable{{"Strikes", oldStrikes}});
          Debug.Log("We now have a total of " + (int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] + " strikes");
        }
        Debug.Log("I am now affecting sphere 3");
        correlatedView.GetComponent<Renderer>().material.color = Color.red;

   
    }
      [PunRPC]
    public void turnSphereRed(){
          Debug.Log("attempting to grab a sphere and chance it color");
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
