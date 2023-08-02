using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] CharPrefabs;
    public GameObject player;

    private void Start()
    {
        player = Instantiate(CharPrefabs[(int)DataManager.instance.currentCharacter]);
        player.transform.position = transform.position;
    }
}
