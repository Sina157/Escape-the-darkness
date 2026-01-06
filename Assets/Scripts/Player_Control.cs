using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Player_Control : MonoBehaviour
{
    public float speed;
    private Vector2 startPos; 
    public Rigidbody rigidBody;
    public Light point_light;
    private Vector3 force;
    public int Energy;
    private bool moving = false;
    private bool Finished = false;


    private void UpdateEnergyText()
    {
        if (Time.timeScale == 0) return;
        GameObject ET = GameObject.Find("EnergyText");
        ET.GetComponent<Text>().text = Convert.ToString(Energy);
        if (Energy <= 0)
        {
            point_light.GetComponent<Light>().range = 0;
        }
    }
    

    void Start()
    {
        UpdateEnergyText();
    }

    public void move_up()
    {
        force = new Vector3(0, 0, speed);
        move_btn_click(force);
    }
    public void move_down()
    {
        force = new Vector3(0, 0, -speed);
        move_btn_click(force);
    }
    public void move_left()
    {
        force = new Vector3(-speed / 2, 0, 0);
        move_btn_click(force);
    }
    public void move_right()
    {
        force = new Vector3(speed / 2, 0, 0);
        move_btn_click(force);
    }

    private void move_btn_click(Vector3 force)
    {
        if (Energy <= 0) 
        {
            return;
        }
        rigidBody.AddForce(force);
        moving = true;
        Energy -= 1;
        UpdateEnergyText();
        StartCoroutine(set_move_state(2));
    }

        IEnumerator set_move_state(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            moving = false;
        }
    void Update()
    {
        if (rigidBody.position.y < -10 || (Energy <= 0 && rigidBody.linearVelocity == Vector3.zero && !moving && !Finished))
        {
            StartCoroutine(fill_screen("black"));
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            Energy = 0;
            UpdateEnergyText();
        }
    }
    void OnTriggerEnter()
    {
        Finished = true;
        rigidBody.linearVelocity = Vector3.zero;
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        GameObject sounds = GameObject.Find("Sounds");
        sounds.transform.GetChild(0).gameObject.SetActive(false);
        sounds.transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(fill_screen("yellow"));
    }

    private IEnumerator fill_screen(string color)
    {
        float x = 0, y = 0 , z = 0;
        if (color == "yellow")
        {
            x = 1f;
            y = 1f;
            z = 0;
        }
        var fadeDuration = 2;
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        var YellowScreen = GameObject.Find("YellowScreen");
        var image = YellowScreen.GetComponent<Image>();
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;

            image.color = new Color(x, y, z, alpha);
            yield return null; // صبر تا فریم بعد
        }

        image.color = new Color(x, y, z, 1f);
        if (color != "yellow")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            string thisLevel = SceneManager.GetActiveScene().name;
            int number = int.Parse(thisLevel.Split('_')[1]);

            int nextNumber = number + 1;
            string nextLevel = thisLevel.Split('_')[0] + "_" + nextNumber;
            if (Application.CanStreamedLevelBeLoaded(nextLevel)){
                if (PlayerPrefs.GetInt("Level") < nextNumber) 
                    PlayerPrefs.SetInt("Level", nextNumber);
                SceneManager.LoadScene(nextLevel);
            }else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            }
        }
            }
}
