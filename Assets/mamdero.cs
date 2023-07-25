using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mamdero : MonoBehaviourPunCallbacks
{
    // public TextMeshProUGUI ConnectionStatus;  // �� �κ��� ����
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
        spawnPoints = new Transform[2]; // �迭 �ʱ�ȭ
        spawnPoints[0] = new GameObject().transform;
        spawnPoints[0].position = new Vector3(0, 0, 2);
        spawnPoints[1] = new GameObject().transform;
        spawnPoints[1].position = new Vector3(0, 0, -2);
        PhotonNetwork.JoinOrCreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 }, null);

    }

    // void Update()  // �� �κе� ����
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
        print("���� ���� �Ϸ�");
        PhotonNetwork.JoinOrCreateRoom("MyRoom", new RoomOptions { MaxPlayers = 2 }, null);
    }
    public override void OnCreatedRoom() => print("�� ���� �Ϸ�");

    public override void OnJoinedRoom()
    {
        print("�� ���� �Ϸ�");
        if (PhotonNetwork.IsMasterClient) { GameObject player = PhotonNetwork.Instantiate("Black Ninja", spawnPoints[0].position, Quaternion.identity); }
        else { GameObject player = PhotonNetwork.Instantiate("White Ninja", spawnPoints[1].position, Quaternion.identity); }
        canvasParent.SetActive(false);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) => print("�游������");

    public override void OnJoinRoomFailed(short returnCode, string message) => print("����������");

    // public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    // {
    //     print("�÷��̾� ����: " + newPlayer.NickName);
    //     if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
    //     {
    //         if (PhotonNetwork.IsMasterClient) // ���常 ó���ϵ��� ����
    //         {
    //             GameObject player1 = PhotonNetwork.Instantiate("Player", spawnPoints[0].position, Quaternion.identity);
    //             GameObject player2 = PhotonNetwork.Instantiate("Player", spawnPoints[1].position, Quaternion.identity);
    //         }
    //     }
    // }

    [ContextMenu("����")]
    void Info()
    {
        if (PhotonNetwork.InRoom)
        {
            print("���� �� �̸� : " + PhotonNetwork.CurrentRoom.Name);
            print("���� �� �ο� �� : " + PhotonNetwork.CurrentRoom.PlayerCount);
            print("���� �� �ִ� �ο� �� : " + PhotonNetwork.CurrentRoom.MaxPlayers);

            string playerStr = "�濡 �ִ� �÷��̾� ��� : ";
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) playerStr += PhotonNetwork.PlayerList[i].NickName + ", ";
            print(playerStr);
        }
    }
}
