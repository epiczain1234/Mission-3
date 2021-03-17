using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworklightsScript : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    private PhotonView correlatedView;
    void Start(){
      photonView = GameObject.Find("Sphere").GetComponent<PhotonView>();
      correlatedView = GameObject.Find("Sphere3").GetComponent<PhotonView>();
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
        Debug.Log("Color change code executed");
        if (GetComponent<Renderer>().material.color == Color.red){
            GetComponent<Renderer>().material.color = Color.green;
        }
        Debug.Log("I am now affecting sphere 3");
        correlatedView.GetComponent<Renderer>().material.color = Color.red;

   
    }
    // essetial interface component
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
}
