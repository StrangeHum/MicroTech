using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class TestStart : MonoBehaviour
{
    [SerializeField] private Button buttonStartHost;
    [SerializeField] private Button buttonStartServer;
    [SerializeField] private Button buttonStartClient;
    private void Awake()
    {
        buttonStartHost.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        buttonStartServer.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        buttonStartClient.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
    }
}
