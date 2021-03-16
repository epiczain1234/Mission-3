using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RedSpheresP1 : MonoBehaviour, IPunObservable
{
     // Start is called before the first frame update
    private PhotonView photonView;
    string[] lights;
    void Start()
    {
      if (PhotonNetwork.LocalPlayer.ActorNumber == 1){
        lights = new string[3]{"Sphere","Sphere1","Sphere2"};
      }
      else if (PhotonNetwork.LocalPlayer.ActorNumber == 2){
        lights = new string[3]{"Sphere3","Sphere4","Sphere5"};
      }
      for (int i = 0; i < lights.Length; i++){
        photonView = GameObject.Find(lights[i]).GetComponent<PhotonView>();
        photonView.GetComponent<Renderer>().material.color = Color.green;
      }
      StartCoroutine("callLimiter", 6f);
    }

    // Update is called once per frame
    void Update()
    {
    //     StartCoroutine("Reset", 10f);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
    [PunRPC]
    public void turnSphereRed(){
        Debug.Log("attempting to grab a sphere and chance it color");
          int grab = Random.Range(0, lights.Length - 1);
          photonView = GameObject.Find(lights[grab]).GetComponent<PhotonView>();
          Debug.Log("changing the color of " + lights[grab] + " now");
          photonView.GetComponent<Renderer>().material.color = Color.red;
        
     } 
     IEnumerator callLimiter(){
        while(true){
          float time = (float)Random.Range(1, 5);
          Debug.Log("The delay is now "  + time);
          yield return new WaitForSeconds(time);
          turnSphereRed();

        }
     }
}
