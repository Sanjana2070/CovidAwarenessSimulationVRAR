using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public GameObject player;

    public void TeleportPlayer()
    {
        SceneManager.LoadScene("Living Room");
    }
}
