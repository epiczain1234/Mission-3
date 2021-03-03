using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworklightsScript : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    void Start(){
      photonView = GameObject.Find("Sphere").GetComponent<PhotonView>();
    }
    // use this function on a ui button (will eventuall move this to a lever)
    public void ChangeColorOnClick(){
      photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
    }

    [PunRPC]
    void RPC_ChangeColor(){
        Debug.Log("Color change code executed");
        if (GetComponent<Renderer>().material.color == Color.red){
            GetComponent<Renderer>().material.color = Color.green;
        }

        else{
            GetComponent<Renderer>().material.color = Color.red;
        }

    }
    // essetial interface component
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
}
