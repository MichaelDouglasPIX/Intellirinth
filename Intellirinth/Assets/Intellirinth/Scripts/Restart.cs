using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject prefabUI;
    [SerializeField] GameObject prefabWin;
    [SerializeField] GameObject prefabPortal;
    int nivelAtual;
    bool endFase = false;

    private void Awake()
    {
        prefabPortal = GameObject.Find("Nivel");
        prefabUI = GameObject.Find("UI");
        prefabWin = GameObject.Find("Win");
        prefabWin.gameObject.SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {
        nivelAtual = prefabPortal.GetComponent<Nivel>().nivelG;
        print("nivel atual" + nivelAtual);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            prefabPortal.GetComponent<Nivel>().nivelG = nivelAtual + 1;
            endFase = true;
            prefabPortal.GetComponent<Nivel>().gameEnd = endFase;
            PassarNivel();
            //print("Player");
        }
    }


    public void PassarNivel()
    {
        Time.timeScale = 0f;
        prefabUI.GetComponent<Countdown>().contagemStart = false;
        prefabUI.gameObject.SetActive(false);
        prefabWin.gameObject.SetActive(true);
    }

     
}
