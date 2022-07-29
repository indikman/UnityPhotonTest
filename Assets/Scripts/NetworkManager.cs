using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Transform spawnPoint;

    private GameObject networkPlayer;

    private void Start()
    {
        // Instantiate the player
        networkPlayer = PhotonNetwork.Instantiate("NetworkPlayer", spawnPoint.position, Quaternion.identity);
        networkPlayer.GetComponent<NetworkPlayer>().SetNickName(PhotonNetwork.NickName);

        // ping checker
        InvokeRepeating("CheckPing", 1, 3);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Logger.Log("Joined the room");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(networkPlayer);
        SceneManager.LoadScene("lobby");
    }


    private GameObject newPlayerObj;

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Logger.Log("New player joined! " + newPlayer.NickName);

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Logger.Log($"Player {otherPlayer.NickName} left the room");
        
    }


    // Leaving the room back to the menu
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void CheckPing()
    {
        Logger.Log("PING : " + PhotonNetwork.GetPing());
    }

}
