using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class RedSpheresP1 : MonoBehaviour, IPunObservable
{
     // Start is called before the first frame update
    private PhotonView photonView;
    string[] lights;
    void Start()
    {
      if (PhotonNetwork.LocalPlayer.ActorNumber == 1){
        
        lights = new string[3]{"Sphere","Sphere1","Sphere2"};
        Debug.Log("Null Reference at Actor 1 Scene");
      }
      else if (PhotonNetwork.LocalPlayer.ActorNumber == 2){
        lights = new string[3]{"Sphere3","Sphere4","Sphere5"};
        Debug.Log("Null Reference at Actor 2 Scene");
      }
      for (int i = 0; i < lights.Length; i++){
        photonView = GameObject.Find(lights[i]).GetComponent<PhotonView>();
        photonView.GetComponent<Renderer>().material.color = Color.green;
      }
      PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable{{"Strikes", 0}});
      StartCoroutine("callLimiter", 6f);
    }

    // Update is called once per frame
    void Update()
    {
      //  TODO: Re-Enable this hastable checking script 
        Debug.Log("wE HAVE " + (int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] + " strikes in total");
        if ((int)PhotonNetwork.CurrentRoom.CustomProperties["Strikes"] >= 3){
          SceneManager.LoadScene("Lostthegame");
        }
      
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
        //  Debug.Log("Null Reference at Turning Spheres red for actor " + PhotonNetwork.LocalPlayer.ActorNumber + " The Specific Sphere is " + lights[grab]);
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
