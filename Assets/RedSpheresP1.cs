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
      lights = new string[3]{"Sphere","Sphere1","Sphere2"};
      for (int i = 0; i < lights.Length; i++){
        photonView = GameObject.Find(lights[i]).GetComponent<PhotonView>();
        photonView.GetComponent<Renderer>().material.color = Color.green;
      }
      StartCoroutine("callLimiter");
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
          int grab = Random.Range(0, lights.Length);
          photonView = GameObject.Find(lights[grab]).GetComponent<PhotonView>();
          while (photonView.GetComponent<Renderer>().material.color == Color.red){
              grab = Random.Range(0, lights.Length);
              Debug.Log("changing the color of " + lights[grab] + " now");
              photonView = GameObject.Find(lights[grab]).GetComponent<PhotonView>();
          }
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
