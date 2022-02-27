using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed=5;
    public float steerSpeed=180;
    public GameObject bodyPrefab;
    public int Gap;
    public GameObject GOText;
    public GameObject PlayAgainbutton;

    public int Score;
    public Text scoreText;


    List<GameObject> bodyParts = new List<GameObject>();
    List<Vector3> PositionHistory = new List<Vector3>();

    private void Start()
    {
        GOText.SetActive(false);
        PlayAgainbutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        float steerDirection = Input.GetAxis("Horizontal");
       transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);
        PositionHistory.Insert(0, transform.position);


        int index = 0;

        foreach(var body in bodyParts)
        {

            Vector3 point = PositionHistory[Mathf.Clamp(index * Gap, 0, PositionHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * moveSpeed * Time.deltaTime;

            body.transform.LookAt(point);
            index++;  
        }
         scoreText.text = Score.ToString();
    }
    void GrowSnake()
    {

        GameObject body = Instantiate(bodyPrefab);
        bodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="food")
        {

            GrowSnake();
            Destroy(other.gameObject);
            Score++;
        }
        if( other.gameObject.tag == "wall")
        {
            GOText.SetActive(true);
            Time.timeScale = 0;
            PlayAgainbutton.SetActive(true);
        }
    }
    public void PlayAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }


}


