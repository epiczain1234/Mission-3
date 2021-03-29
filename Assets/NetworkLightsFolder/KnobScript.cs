using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class KnobScript : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    public string affectedObject;
    private PhotonView photonView;
    void Start()
    {
        photonView = GameObject.Find(affectedObject).GetComponent<PhotonView>();
    }
    void OnMouseOver(){
      if (Input.GetMouseButtonUp(0)){
        Debug.Log("knob Click detected");
        photonView.RPC("turnSphereGreen", RpcTarget.All, null);
      }
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
}
