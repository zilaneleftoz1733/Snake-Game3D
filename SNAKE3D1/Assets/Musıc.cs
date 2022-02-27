using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musıc : MonoBehaviour
{
    // Start is called before the first frame update
    public class music : MonoBehaviour
    {
        void Awake()
        {
            GameObject[] musicObje = GameObject.FindGameObjectsWithTag("GameMusic");

            if (musicObje.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    }
}