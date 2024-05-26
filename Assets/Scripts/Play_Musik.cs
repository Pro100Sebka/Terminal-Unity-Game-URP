using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Musik : MonoBehaviour
{
    public AudioSource MusicSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
