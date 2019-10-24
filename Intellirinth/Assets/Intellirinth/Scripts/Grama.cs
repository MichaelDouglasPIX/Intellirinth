using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grama : MonoBehaviour
{
    [SerializeField] GameObject[] prefabGrama;
    [SerializeField] GameObject prefabPortal;

    public GameObject spawLabirinto;
    Vector3 localizacao;
    Vector3 localizacaoEnd;
    Vector3 refT;
    int varianteGrama = 0;

    int colunaGrama;
    int linha = 2;
    int Maxcoluna = 2;
    int inColuna = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        prefabPortal = GameObject.Find("Nivel");

    }

    void Start()
    {
        localizacao = spawLabirinto.GetComponent<Labirinto>().startLocalition;
        localizacaoEnd = spawLabirinto.GetComponent<Labirinto>().endLocation;

        refT = localizacao; /*prefabGrama[0].GetComponent<Renderer>().bounds.size;*/
        Vector3 refP = new Vector3(-2, 0, -1);
        colunaGrama = prefabPortal.GetComponent<Nivel>().cTer;
        print("Grama "+colunaGrama);
        String temp = GerarGrama.generateMaze(colunaGrama, 2);
        string[] str = temp.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        int lin = str.Length;
        int col = str[0].Length;
       

        for (int l = 0; l < lin; l++)
        {
            for (int c = 0; c < col; c++)
            {
                if (str[l][c] == '1')
                {
                    if (varianteGrama == 0) {
                        //GameObject obj = GameObject.Instantiate(prefabGrama[rnd], new Vector3(refT.x * l, refP.y, refT.z * c), Quaternion.identity); obj.name = "P" + l + "_" + c;
                        GameObject obj = GameObject.Instantiate(prefabGrama[0], new Vector3(refT.x * l, refP.y - 2, refT.z * c - Maxcoluna), Quaternion.identity); obj.name = "tInicio" + l + "_" + c;
                        GameObject obj2 = GameObject.Instantiate(prefabGrama[0], new Vector3(refT.x * l, refP.y - 2, localizacaoEnd.z + Maxcoluna), Quaternion.identity); obj2.name = "tFinal" + l + "_" + c;
                        Maxcoluna = Maxcoluna + 2;
                    }
                    if (varianteGrama == 1 )
                    {
                        GameObject obj = GameObject.Instantiate(prefabGrama[1], new Vector3(refT.x * l, refP.y - 2, refT.z * c - Maxcoluna), Quaternion.identity); obj.name = "tInicioVariante" + l + "_" + c;
                        GameObject obj2 = GameObject.Instantiate(prefabGrama[1], new Vector3(refT.x * l, refP.y - 2, localizacaoEnd.z + Maxcoluna), Quaternion.identity); obj2.name = "tFinalVariante" + l + "_" + c;
                        Maxcoluna = Maxcoluna + 2;
                    }
                    if (varianteGrama == 0)
                    {
                        varianteGrama = 1;
                    }
                    else
                    {
                        varianteGrama = 0;
                    }
                }
                
                if (Maxcoluna > 6)
                {
                    Maxcoluna = 2;
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
