using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class Menu : NetworkedBehaviour
{
    public GameObject menuPanel;
    public GameObject playerDestroy;
    public void Host()
    {
        Destroy(playerDestroy);
        NetworkingManager.Singleton.StartHost();
        menuPanel.SetActive(false);
    }

    public void Join()
    {
        Destroy(playerDestroy);
        NetworkingManager.Singleton.StartClient();
        menuPanel.SetActive(false);
    }
}
