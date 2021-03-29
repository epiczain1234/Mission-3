using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class SliderLight : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    public string objectName;
    void Start()
    {
        photonView = GameObject.Find(objectName).GetComponent<PhotonView>();
    }
    [PunRPC]
    public void turnSphereRed(){
          photonView.GetComponent<Renderer>().material.color = Color.red;
        
     } 
    [PunRPC]
    public void turnSphereGreen(){
          photonView.GetComponent<Renderer>().material.color = Color.green;
        
     } 

    // Update is called once per frame
    void Update()
    {
        
    }
      // essetial interface component
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
}
