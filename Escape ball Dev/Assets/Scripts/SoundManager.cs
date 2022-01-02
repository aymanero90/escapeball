using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioClip coinClip, bridgeClip;
    [SerializeField]
    private AudioSource bridgeSound;
    [SerializeField]
    private AudioSource coinSound;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameObject[] obj = GameObject.FindGameObjectsWithTag("GameSound");
        if (obj.Length > 1)      
            Destroy(this.gameObject);        

        DontDestroyOnLoad(this.gameObject);
    }


    public void CoinSound()
    {
        coinSound.clip = coinClip;
        coinSound.Play();
    }

    public void BridgeSound()
    {
        bridgeSound.clip = bridgeClip;
        bridgeSound.Play();
    }

}
