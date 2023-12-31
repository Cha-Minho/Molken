using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mamdero : MonoBehaviourPunCallbacks
{
    // public TextMeshProUGUI ConnectionStatus;  // 이 부분을 제거
    public TMP_InputField IDtext;
    public Button connectBtn;

    public Transform[] spawnPoints;
    public GameObject canvasParent;

    void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        spawnPoints = new Transform[2]; // 배열 초기화
        spawnPoints[0] = new GameObject().transform;
        spawnPoints[0].position = new Vector3(0, 0, 2);
        spawnPoints[1] = new GameObject().transform;
        spawnPoints[1].position = new Vector3(0, 0, -2);
        PhotonNetwork.JoinOrCreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 }, null);

    }

    // void Update()  // 이 부분도 제거
    // {
    //     ConnectionStatus.text = PhotonNetwork.NetworkClientState.ToString();
    // }

    public void JoinOrCreateRoom()
    {
        PhotonNetwork.LocalPlayer.NickName = IDtext.text;
        PhotonNetwork.JoinOrCreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnConnectedToMaster()
    {
        print("서버 접속 완료");
        PhotonNetwork.JoinOrCreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 }, null);
    }
    public override void OnCreatedRoom() => print("룸 생성 완료");

    public override void OnJoinedRoom()
    {
        print("룸 접속 완료");
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject player = PhotonNetwork.Instantiate("Black Ninja", spawnPoints[0].position, Quaternion.Euler(0, 180, 0));
        }
        else
        {
            GameObject player = PhotonNetwork.Instantiate("White Ninja", spawnPoints[1].position, Quaternion.identity);
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message) => print("방만들기실패");

    public override void OnJoinRoomFailed(short returnCode, string message) => print("방참가실패");

    // public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    // {
    //     print("플레이어 입장: " + newPlayer.NickName);
    //     if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
    //     {
    //         if (PhotonNetwork.IsMasterClient) // 방장만 처리하도록 변경
    //         {
    //             GameObject player1 = PhotonNetwork.Instantiate("Player", spawnPoints[0].position, Quaternion.identity);
    //             GameObject player2 = PhotonNetwork.Instantiate("Player", spawnPoints[1].position, Quaternion.identity);
    //         }
    //     }
    // }

    [ContextMenu("정보")]
    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("현재 방 이름 : " + PhotonNetwork.CurrentRoom.Name);
            print("현재 방 인원 수 : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("현재 방 최대 인원 수 : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "방에 있는 플레이어 목록 : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
    }
}
