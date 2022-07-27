using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    // Variabel instance membuat sebuah kelas dapat dipanggil oleh kelas lainnya secara mudah
    public static GameData instance;

    public bool isSinglePlayer;
    public float gameTimer;

    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);  // Menyimpan variabel walau berbeda scene
    }
}
