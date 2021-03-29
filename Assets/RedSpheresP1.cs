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
   
        lights = new string[6]{"Sphere","Sphere1","Sphere2", "Sphere3", "Sphere4", "Sphere5"};
    
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
