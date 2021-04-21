using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnecterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject connect;

    public void connectButton(){
      if (connect != null){
         connect.SetActive(true);
      }
    }
}
