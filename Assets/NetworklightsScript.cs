using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworklightsScript : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    void Start()
    {
      photonView = GameObject.Find("Sphere").GetComponent<PhotonView>();
      photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
    }

    [PunRPC]
    void RPC_ChangeColor(){
        Debug.Log("Color change code executed");
        GetComponent<Renderer>().material.color = Color.red;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
}
