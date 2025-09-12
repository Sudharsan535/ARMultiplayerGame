using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting to Photon...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server!");
        PhotonNetwork.JoinLobby(); // auto join lobby
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby!");
        PhotonNetwork.JoinOrCreateRoom("TestRoom", new Photon.Realtime.RoomOptions { MaxPlayers = 4 }, default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room!");
        // Spawn player prefab
        PhotonNetwork.Instantiate("PlayerPrefab", new Vector3(0,0,0), Quaternion.identity);
    }
}
