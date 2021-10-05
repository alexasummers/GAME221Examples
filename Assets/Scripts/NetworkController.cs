using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkController : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // establishes  connection with master server
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.ClourRegion + " server!");
    }
}
