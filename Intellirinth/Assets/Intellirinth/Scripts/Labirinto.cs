using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Labirinto : MonoBehaviour
{
    [SerializeField] GameObject[] prefabParede;
    [SerializeField] GameObject[] prefabPickup;
    [SerializeField] GameObject prefabChao;
    [SerializeField] GameObject prefabStart;
    [SerializeField] GameObject prefabEnd;
    [SerializeField] GameObject prefabTerrain;
    [SerializeField] GameObject prefabGrama;
    [SerializeField] GameObject prefabPlayer;
    [SerializeField] GameObject prefabPortal;

    public int colunaLabirinto;
    public int linhaLabirinto;

    int chaoE = 0;
    int varianteParede=0;
    int scaleTerrain = 5;
    public Vector3 startLocalition;
    public Vector3 endLocation;
    // Start is called before the first frame update
    private void Awake()
    {
        prefabPortal = GameObject.Find("Nivel");
        
    }

        void Start()
    {
        colunaLabirinto = prefabPortal.GetComponent<Nivel>().cLab;
        linhaLabirinto = prefabPortal.GetComponent<Nivel>().lLab;
        print("Linha " + linhaLabirinto + " Coluna " + colunaLabirinto);
        GerandoLabirinto();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEnd ()
    {
        for (int i = 0; i <=1; i++)
        {
            
            GameObject objChao = GameObject.Instantiate(prefabChao, new Vector3(startLocalition.x, startLocalition.y - 0.90f, startLocalition.z - (chaoE + 2)), Quaternion.identity); objChao.name = "EntradaChao" + "_" + i;
                       objChao = GameObject.Instantiate(prefabChao, new Vector3(endLocation.x, endLocation.y - 0.90f, endLocation.z + (chaoE + 2)), Quaternion.identity); objChao.name = "SaidaChao" + "_" + i;
            chaoE = 2;
        }
        
        GameObject start = GameObject.Instantiate(prefabStart, new Vector3(startLocalition.x, startLocalition.y - 0.90f, startLocalition.z-4), Quaternion.identity); start.name = "Start";
        GameObject end = GameObject.Instantiate(prefabEnd, new Vector3(endLocation.x, endLocation.y - 0.90f, endLocation.z + 4), Quaternion.identity); start.name = "End";

        GameObject player = GameObject.Instantiate(prefabPlayer, new Vector3(startLocalition.x, startLocalition.y - 0.1f, startLocalition.z - 4), Quaternion.identity); start.name = "Player";


        //GameObject startTerrain = GameObject.Instantiate(prefabTerrain, new Vector3(startLocalition.x + 1, startLocalition.y - 0.64f, startLocalition.z - 2), Quaternion.identity); start.name = "StartTerrain";
        //GameObject endTerrain = GameObject.Instantiate(prefabTerrain, new Vector3(endLocation.x - 1, endLocation.y - 0.64f, endLocation.z + 2), Quaternion.identity); start.name = "StartTerrain";

        //startTerrain.transform.localScale = new Vector3(scaleTerrain, 0.3f, 3.5f); 

        //GameObject end = GameObject.Instantiate(prefabChao, new Vector3(), Quaternion.identity); end.name = "End";
    }

    public void GerandoLabirinto()
    {
        Vector3 refT = prefabParede[0].GetComponent<Renderer>().bounds.size;
        Vector3 refP = new Vector3(-2, 0, -1);

        String temp = GerarLabirinto.generateMaze(colunaLabirinto, linhaLabirinto);
        string[] str = temp.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        int lin = str.Length;
        int col = str[0].Length;
        int item = (str.Length + str[0].Length) / 2;

        for (int l = 0; l < lin; l++)
        {
            for (int c = 0; c < col; c++)
            {
                if (str[l][c] == '1')
                {
                    //int rnd = Random.RandomRange(0, prefabParede.Length );
                    if (varianteParede == 0)
                    {
                        GameObject obj = GameObject.Instantiate(prefabParede[varianteParede], new Vector3(refT.x * l, refP.y, refT.z * c), Quaternion.identity); obj.name = "P" + l + "_" + c;

                    }
                    if (varianteParede == 1)
                    {
                        GameObject obj = GameObject.Instantiate(prefabParede[varianteParede], new Vector3(refT.x * l, refP.y, refT.z * c), Quaternion.identity); obj.name = "P" + l + "_" + c;

                    }
                    if (varianteParede == 0)
                    {
                        varianteParede = 1;
                    }
                    else
                    {
                        varianteParede = 0;
                    }

                }


                if (str[l][c] == '0')
                {
                    int rndPickup = Random.RandomRange(0, item - 2);
                    if (rndPickup == 1)
                    {
                        int rnd = Random.RandomRange(0, prefabPickup.Length);
                        GameObject obj = GameObject.Instantiate(prefabPickup[rnd], new Vector3(refT.x * l, refP.y, refT.z * c), Quaternion.identity); obj.name = "P" + l + "_" + c;

                        obj.transform.Rotate(new Vector3(90, 0, 0));
                    }
                    GameObject objChao = GameObject.Instantiate(prefabChao, new Vector3(refT.x * l, refP.y - 0.90f, refT.z * c), Quaternion.identity); objChao.name = "Chao" + l + "_" + c;
                }


                if (c == 0 && l == 1)
                {
                    startLocalition = new Vector3(refT.x * l, refP.y, refT.z * c);
                }
                if (c == col - 1 && l == lin - 2)
                {
                    endLocation = new Vector3(refT.x * l, refP.y, refT.z * c);
                }

            }
        }

        startEnd();
        prefabGrama.gameObject.SetActive(true);
        print("true");

    }


}
