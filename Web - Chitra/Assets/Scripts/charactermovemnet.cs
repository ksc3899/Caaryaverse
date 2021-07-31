using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charactermovemnet : MonoBehaviour
{
    public GameObject box;
    public GameObject text1;
    public GameObject text2;
    public GameObject field;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeText());
        StartCoroutine(ButtonDrop());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(30,0,0), Time.deltaTime);
        if (transform.position.y > -5f)
        {
            box.SetActive(true);
        }
        else
        {
            box.SetActive(false);
        }
    }
    public IEnumerator ChangeText()
    {
        yield return new WaitForSeconds(8f);
        text1.SetActive(false);
        text2.SetActive(true);
    }
    public IEnumerator ButtonDrop()
    {
        yield return new WaitForSeconds(12f);
        character.SetActive(false);
        field.SetActive(true);
    }

}
