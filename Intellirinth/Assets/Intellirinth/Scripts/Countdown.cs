using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject prefabUI;
    [SerializeField] GameObject prefabGameOver;
    [SerializeField] GameObject prefabPortal;
    public Text displayNivel;
    public Text displayContagem;
    public float contagem = 30.0f;
    int nivel;
    public bool gameStart = false;
    public bool contagemStart = false;


    private void Awake()
    {
        prefabPortal = GameObject.Find("Nivel");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            nivel = prefabPortal.GetComponent<Nivel>().nivelG;
            NivelScreen();
            TimeScreen();
            contagemStart = true;
            gameStart = false;
        }

        if (contagemStart) {
            if (contagem > 0.0f)
            {
                TimeScreen();
            }
            else
            {
                Time.timeScale = 0f;
                prefabUI.gameObject.SetActive(false);
                prefabGameOver.gameObject.SetActive(true);
                contagemStart = false;
            }
        }
    }

    void TimeScreen()
    {
        contagem -= Time.deltaTime;
        displayContagem.text = "Time: "+contagem.ToString("F2");
    }
    void NivelScreen()
    {
        
        displayNivel.text = "Nivel: " + nivel;
    }
}
