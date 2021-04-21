using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class SwitchLights : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    private PhotonView correlatedView;
    public string thisObject;
    public string affectedObject;
    void Start(){
      photonView = GameObject.Find(thisObject).GetComponent<PhotonView>();
      correlatedView = GameObject.Find(affectedObject).GetComponent<PhotonView>();
    }
    // use this function on a ui button (will eventuall move this to a lever)
    // public void ChangeColorOnClick(){
    //   photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
    // }
    // make this so that only actor number 1 can affect change on this sphere
    void OnMouseOver(){
      if (Input.GetMouseButtonUp(0)){
        Debug.Log("lever Click detected");
        photonView.RPC("RPC_ChangeColor", RpcTarget.All, null);
      }
    }

    [PunRPC]
    void RPC_ChangeColor(){
        Debug.Log("Color change code executed for lever to end game");
        if (correlatedView.GetComponent<Renderer>().material.color == Color.red){
            correlatedView.GetComponent<Renderer>().material.color = Color.green;
        }
        else {
          int oldStrikes = (int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] + 1;
          Debug.Log("More Strikes");
          PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable{{"Strikes", oldStrikes}});
          Debug.Log("We now have a total of " + (int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] + " strikes");
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
