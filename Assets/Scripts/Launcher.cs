using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{

    [SerializeField] private string gameVersion = "1";
    [SerializeField] private byte maxPlayersPerRoom = 4;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        Logger.Log("Connecting...");
        if (PhotonNetwork.IsConnected)
        {
            // join the room if connected
            Logger.Log("Already connected. Joining a random room");
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    void Start()
    {
        //Connect();
    }

    public override void OnConnectedToMaster()
    {
        Logger.Log("Connected to master");

        PhotonNetwork.JoinRandomRoom();
        Logger.Log("Joining a random room");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Logger.Log("Random room joining failure!,  creating a new room!");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers =  maxPlayersPerRoom});

    }


    public override void OnJoinedRoom()
    {
        Logger.Log("Joined Room!");
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Logger.Log($"Disconnected {cause.ToString()}");
    }

    
}
