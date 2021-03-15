using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{
    public GameObject bariyer;
    public GameObject yem;
    public GameObject oyunBittiEkran;
    public GameObject agac;

    public TextMeshProUGUI oyunBittiText;

    void Start()
    {
        InvokeRepeating("DusmanSpawn", 0.0f, 0.9f);

        InvokeRepeating("AgaclarSpawn", 0.0f, 4f);

        Time.timeScale = 0.0f;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(GameObject.Find("baslaText"), 0.0f);

            Time.timeScale = 1.0f;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width)
                {
                    Destroy(GameObject.Find("baslaText"), 0.0f);

                    Time.timeScale = 1.0f;
                }
            }
        }

        GameObject[] bariyerler = GameObject.FindGameObjectsWithTag("bariyer");
        for (int i = 0; i < bariyerler.Length; i++)
        {
            Destroy(bariyerler[i], 3.8f);
        }

        GameObject[] agaclar = GameObject.FindGameObjectsWithTag("agac");
        for (int i = 0; i < agaclar.Length; i++)
        {
            Destroy(agaclar[i], 7f);
        }
    }

    void AgaclarSpawn()
    {
        Instantiate(agac, new Vector3(625, 207.9f, gameObject.transform.position.z + 70), Quaternion.identity);
        Instantiate(agac, new Vector3(640, 207.9f, gameObject.transform.position.z + 70), Quaternion.identity);
    }

    void DusmanSpawn()
    {

        float[] xliste = new float[] { 628.6f, 632f, 635.4f };
        int x1ran = Random.Range(0, 3);
        int x2ran = Random.Range(0, 3);
        int x3ran = Random.Range(0, 3);

        if (x1ran != x2ran)
        {
            Instantiate(bariyer, new Vector3(xliste[x1ran], 208.5f, gameObject.transform.position.z + 70), Quaternion.identity);
            Instantiate(bariyer, new Vector3(xliste[x2ran], 208.5f, gameObject.transform.position.z + 70), Quaternion.identity);
            Instantiate(yem, new Vector3(xliste[x3ran], 208.5f, gameObject.transform.position.z + 43), Quaternion.identity);
        }
        else
        {
            Instantiate(bariyer, new Vector3(628.6f, 208.5f, gameObject.transform.position.z + 70), Quaternion.identity);
            Instantiate(bariyer, new Vector3(635.4f, 208.5f, gameObject.transform.position.z + 70), Quaternion.identity);
            Instantiate(yem, new Vector3(xliste[x3ran], 208.5f, gameObject.transform.position.z + 43), Quaternion.identity);
        }

    }

    public void TekrarOyna()
    {
        GameObject.Find("oyunBittiEkran").SetActive(true);
        SceneManager.LoadScene("Scenes/SampleScene");

        Time.timeScale = 1.0f;
    }

    
}
