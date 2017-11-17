using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Kamera seuraa pelihahmoa
    public MovementController player;

    // Halutaanko että kamera seuraa
    public bool isFollowing;

    public float xOffset;
    public float yOffset;

    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<MovementController>();
        isFollowing = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (isFollowing)
        {
            // Jos kamera seuraa, niin otetaan pelihahmon sijainti (x,y) sekä
            // kameran sijainti z-arvo.
            transform.position = new Vector3(player.transform.position.x + xOffset,
                player.transform.position.y + yOffset, transform.position.z);
        }

    }
}
