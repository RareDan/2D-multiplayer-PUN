using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput, joinInput;

    public void CreateRoom()
    {
        if (createInput.text.Length < 2)
        {
            Debug.Log("Number of room for create should be more than 2 symbols");
            return;
        }

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;

        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        if (joinInput.text.Length < 2)
        {
            Debug.Log("Number of room for join should be more than 2 symbols");
            return;
        }
        
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}
