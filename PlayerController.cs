using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject MainCam;

    [SerializeField]
    private GameObject Cam1;

    [SerializeField]
    private GameObject Cam2;


    public GameObject Canvas;

    public PlayerSelection ps;

    private void Start()
    {
        Cam1.SetActive(false);
        Cam2.SetActive(false);
    }

    public void AirCraft1() {

        ps.SelectPlayer(this.gameObject);
        GetComponent<AirCraftController>().enabled = true;

        MainCam.SetActive(false);
        Cam1.SetActive(true);
        Cam2.SetActive(false);

        Canvas.SetActive(false);

    }
    public void AirCraft2()
    {
        ps.SelectPlayer(this.gameObject);
        GetComponent<AirCraftController>().enabled = true;

        MainCam.SetActive(false);
        Cam1.SetActive(false);
        Cam2.SetActive(true);

        Canvas.SetActive(false);
    }

}
