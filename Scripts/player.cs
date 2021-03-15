using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    public TextMeshProUGUI skorYazi;
    public TextMeshProUGUI oyunBittiText;
    public GameObject kamera;
    public GameObject oyunBittiEkran;
    public GameObject planefab;
    public GameObject cimenlik;

    Vector3 ofset;

    public int skor = 0;

    private void Start()
    {
        ofset = kamera.transform.position - gameObject.transform.position;

        Instantiate(planefab, new Vector3(632f, 207.9f, -803.2f), Quaternion.identity);
        Instantiate(cimenlik, new Vector3(632f, 207.8f, -803.2f), Quaternion.identity);
    }
    void Update()
    {
        gameObject.transform.Translate(0, 0, 20 * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SolKlavyeHareket();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SagKlavyeHareket();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                SolDokunmatikHareket(touch);

                SagDokunmatikHareket(touch);
            }
        }
    }

    void SolKlavyeHareket()
    {
        if (gameObject.transform.position.x != 628.6f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 3.4f, 207.9f, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(628.6f, 207.9f, gameObject.transform.position.z);
        }
    }

    void SagKlavyeHareket()
    {
        if (gameObject.transform.position.x != 635.4f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 3.4f, 207.9f, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(635.4f, 207.9f, gameObject.transform.position.z);
        }
    }

    void SolDokunmatikHareket(Touch touch)
    {
        if (touch.position.x < Screen.width / 2 && gameObject.transform.position.x != 628.6f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 3.4f, 207.9f, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x == 628.6f)
        {
            gameObject.transform.position = new Vector3(628.6f, 207.9f, gameObject.transform.position.z);
        }
    }

    void SagDokunmatikHareket(Touch touch)
    {
        if (touch.position.x > Screen.width / 2 && gameObject.transform.position.x != 635.4f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 3.4f, 207.9f, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x == 635.4f)
        {
            gameObject.transform.position = new Vector3(635.4f, 207.9f, gameObject.transform.position.z);
        }
    }

    private void LateUpdate()
    {
        kamera.transform.position = gameObject.transform.position + ofset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bariyer")
        {
            Time.timeScale = 0.0f;

            oyunBittiEkran.SetActive(true);

            oyunBittiText.SetText("Kaybettiniz !");

            skor = 0;
        }   

        if (collision.gameObject.tag == "yem")
        {
            Destroy(collision.gameObject);
            
            skor++;

            skorYazi.SetText(skor.ToString());
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "yol")
        {

            Vector3 yolposition = collider.transform.position;
            yolposition.z = collider.transform.position.z + collider.transform.localScale.z*10;
            Instantiate(planefab, yolposition, Quaternion.identity);
            Instantiate(cimenlik, new Vector3(yolposition.x, 207.8f, yolposition.z), Quaternion.identity);

            Destroy(collider.gameObject, 7.0f);
        }
    }
}
