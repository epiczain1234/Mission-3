using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TurnSpheresRed : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    private PhotonView photonView;
    string[] lights;
    void Start()
    {
      lights = new string[6]{"Sphere","Sphere1","Sphere2","Sphere3","Sphere4","Sphere5"};
      for (int i = 0; i < 6; i++){
        photonView = GameObject.Find(lights[i]).GetComponent<PhotonView>();
        photonView.GetComponent<Renderer>().material.color = Color.green;
      }
    }

    // Update is called once per frame
    void Update()
    {
      int green = 0;
      for (int i = 0; i < 6; i++){
        photonView = GameObject.Find(lights[i]).GetComponent<PhotonView>();
        if (photonView.GetComponent<Renderer>().material.color == Color.green){
            green++;
            Debug.Log("we now have " + green + " green speheres");
        }
        else{
          Debug.Log("I guess sphere " + i + " is actually " + photonView.GetComponent<Renderer>().material.color);
        }

      }
      if (green == 6){
          Debug.Log("attempting to grab a sphere and chance it color");
          // generate rangdom Integer
          int grab = Random.Range(0, 6);
          // set the array index sphere correlating to the int to red
          Debug.Log("changing the color of " + lights[grab] + " now");
          photonView = GameObject.Find(lights[grab]).GetComponent<PhotonView>();
          photonView.GetComponent<Renderer>().material.color = Color.red;
      }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){

      if (stream.IsWriting){

      }
      if (stream.IsReading){

      }

    }
}
