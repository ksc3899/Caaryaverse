using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawning : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject box;
   public void update()
    {
        box.transform.position = new Vector3(0, 0, 0);
    }
    public void shift()
    {
        box.transform.position = new Vector3(0, 0, 0);
    }
}
