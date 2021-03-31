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
    string[] p1Lights;
    string[] p2Lights;
    int ActorNumber;
    void Start()
    {
        ActorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        lights = new string[6]{"Sphere","Sphere1","Sphere2", "Sphere3", "Sphere4", "Sphere5"};
        p1Lights = new string[6]{"Sphere","Sphere1","Sphere2", "Sphere3c", "Sphere4c", "Sphere5c"};
        p2Lights = new string [6]{"Sphere3", "Sphere4", "Sphere5", "Spherec", "Sphere1c", "Sphere2c"};
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
        // if actor number is 1 and its 6 lights are red, load the "lost the game scene"
        // if 
          bool lost = checkIfLost(p1Lights, p2Lights);
          if (lost)
            SceneManager.LoadScene("Lostthegame");
    }
    public bool checkIfLost(string []arr, string []arr2){
        PhotonView temp; 
        int reds = 0;
        int reds2 = 0;
        int Length = arr.Length;
        for (int i = 0; i < Length; i++){
            temp = GameObject.Find(arr[i]).GetComponent<PhotonView>();
            if (temp.GetComponent<Renderer>().material.color == Color.red){
                reds++;
            }
            temp = GameObject.Find(arr2[i]).GetComponent<PhotonView>();
            if (temp.GetComponent<Renderer>().material.color == Color.red){
                reds2++;
            }
        }
        // TODO: will change this to 3 
        if (reds == Length || reds2 == Length)
          return true;
        return false;
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
    
     [PunRPC]
     IEnumerator callLimiter(){
        while(true){
          float time = (float)Random.Range(1, 5);
          Debug.Log("The delay is now "  + time);
          yield return new WaitForSeconds(time);
          int grab = Random.Range(0, lights.Length);
          photonView = GameObject.Find(lights[grab]).GetComponent<PhotonView>();
          photonView.RPC("turnSphereRed", RpcTarget.All, null);

        }
     }
}
