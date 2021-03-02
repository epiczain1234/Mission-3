using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworklightsScript : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    Rigidbody rb;
    PhotonView photonView;

    private void awake(){
      rb = GetComponent<Rigidbody>();
      photonView = GetComponent <PhotonView>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
    [PunRPC]
    public void ChangeColorToGreen(){

    }
}
