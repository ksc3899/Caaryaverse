using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    
    private void Start()
    {
        
        playerController = GetComponent<PlayerController>();
    }

    #region AnimationFunctions

    public void Clap()
    {
        playerController.Clap();
    }

   

    

    #endregion
}
