using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

[RequireComponent(typeof(TMP_InputField))]
public class PlayerName : MonoBehaviour
{

    private TMP_InputField inputField;

    string nickName;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();

        if(PlayerPrefs.HasKey("NICKNAME"))
        {
            nickName = PlayerPrefs.GetString("NICKNAME");
            inputField.text = nickName;

        }

        PhotonNetwork.NickName = nickName;
    }

    public void SetPlayerName(string value)
    {
        if (string.IsNullOrEmpty(value))
            return;

        PhotonNetwork.NickName = value;

        PlayerPrefs.SetString("NICKNAME", value);
    }
}
