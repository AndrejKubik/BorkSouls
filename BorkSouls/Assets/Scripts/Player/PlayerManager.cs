using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public bool musicStart;
    public bool musicStarted;
    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioClip music;
    [SerializeField] UI ui;

    private void Start()
    {
        musicStart = false;
        musicStarted = false;
    }

    private void Update()
    {
        if (musicStart && !musicStarted) //if the trigger for music was used
        {
            playerAudio.PlayOneShot(music); //start playing boss music
            ui.bossHPBar.gameObject.SetActive(true); //show boss hp bar
            musicStarted = true; //prevent multiple playbacks
            musicStart = false; //reset the music start trigger
        }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart the scene   
    }
}
