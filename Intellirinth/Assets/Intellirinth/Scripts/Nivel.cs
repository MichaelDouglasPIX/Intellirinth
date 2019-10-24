using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Nivel : MonoBehaviour
{
    private int nivel;
    public int nivelG;

    public bool gameStart;
    public bool gameEnd;

    public int cLab;
    public int lLab;
    public int cTer;

    public string nome;
    string json;

    [SerializeField] GameObject playerUI;

    private void Awake()
    {
        
    }
        // Start is called before the first frame update
        void Start()
    {
        CarregarNivel();
        nivelG = nivel;
        NivelGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (nivelG == nivel +1 && gameEnd)
        {
            gameEnd = false;
            GuardarNivel();           
        }

    }

    public void GuardarNivel()
    {
        nome = gameObject.name;
        PlayerPrefs.SetInt("Nivel: ", nivelG);
        PlayerPrefs.SetString(nome, json);

    }

    public void RestartNivel()
    {
        nome = gameObject.name;
        PlayerPrefs.SetInt("Nivel: ", 0);
        PlayerPrefs.SetString(nome, json);
        Time.timeScale = 1f;
        Application.LoadLevel("Labirinto");

    }

    public void CarregarNivel()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
        {
            json = PlayerPrefs.GetString(gameObject.name);
            nivel = PlayerPrefs.GetInt("Nivel: ");
            
            
            print("Nivel Recuperado: " + nivel);
        }
        else
        {
            nivel = 0;
            NivelGame();
            print("Nivel Novo");
        }
    }

    public void NivelGame()
    {
        if (nivelG == 0)
        {
            cLab = 5;
            lLab = 5;
            cTer = 5;
        }
        if (nivelG == 1)
        {
            cLab = 7;
            lLab = 7;
            cTer = 7;
        }
        if (nivelG == 2 )
        {
            cLab = 9;
            lLab = 9;
            cTer = 9;
        }
        if (nivelG == 3)
        {
            cLab = 11;
            lLab = 11;
            cTer = 11;
        }
        if (nivelG == 4)
        {
            cLab = 13;
            lLab = 13;
            cTer = 13;
        }
        if (nivelG == 5)
        {
            cLab = 15;
            lLab = 15;
            cTer = 15;
        }
        if (nivelG == 6)
        {
            cLab = 17;
            lLab = 17;
            cTer = 17;
        }
        if (nivelG == 7)
        {
            cLab = 19;
            lLab = 19;
            cTer = 19;
        }
        if (nivelG == 8)
        {
            cLab = 21;
            lLab = 21;
            cTer = 21;
        }
        if (nivelG == 9)
        {
            cLab = 23;
            lLab = 23;
            cTer = 23;
        }
        if (nivelG == 10)
        {
            cLab = 25;
            lLab = 25;
            cTer = 25;
        }
        
        gameStart = true;
        playerUI.GetComponent<Countdown>().gameStart = gameStart;

    }
}
