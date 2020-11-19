using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{

    public Transform player;
    public Vector3 heightOffset;
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    public void TeleportPlayer(Vector3 newPosition)
    {
        source.PlayOneShot(clip);
        player.position = newPosition + heightOffset;
    }

}
