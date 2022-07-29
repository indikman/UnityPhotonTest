using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField] private Transform mainPlayer;
    [SerializeField] TMP_Text nikNameText;
    [SerializeField] private List<Renderer> renderersToHide;

    private PhotonView photonView;
    

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        mainPlayer = GameObject.FindObjectOfType<GamePlayer>().transform;

        if(photonView.IsMine)
        {
            foreach (Renderer child in renderersToHide)
            {
                child.enabled = false;
            }
        }
        else
        {
            SetNickName(photonView.Owner.NickName);
        }
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            transform.position = mainPlayer.position;
            transform.rotation = mainPlayer.rotation;
        }

        
    }
    public void SetNickName(string nickName)
    {
        nikNameText.SetText(nickName);
    }

}
