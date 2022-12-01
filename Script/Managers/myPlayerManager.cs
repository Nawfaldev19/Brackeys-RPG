using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class myPlayerManager : MonoBehaviour
{

#region Singleton
    public static myPlayerManager instance;
    void Awake()
    {
        instance= this;
    }
    #endregion    

    public GameObject playerInstance;
    
    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
