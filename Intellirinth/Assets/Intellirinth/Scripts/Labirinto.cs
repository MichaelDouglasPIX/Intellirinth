using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Labirinto : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabParede;
    [SerializeField]
    GameObject[] prefabPickup;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 refT = prefabParede[0].GetComponent<Renderer>().bounds.size;
        Vector3 refP = new Vector3(-2, 0, -1);

        String temp = GerarLabirinto.generateMaze(10, 10);
        string[] str = temp.Split(new char[]{ '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        int lin = str.Length;
        int col = str[0].Length;
        int item = (str.Length + str[0].Length) / 2;
        print(item);

        for (int l=0; l< lin; l++)
        {
            for(int c=0; c<col; c++)
            {
                if (str[l][c] == '1')
                {
                    int rnd = Random.RandomRange(0, prefabParede.Length );
                    GameObject obj = GameObject.Instantiate(prefabParede[rnd], new Vector3(refT.x * l, refP.y, refT.z * c),Quaternion.identity); obj.name = "P" + l + "_" + c;
                }
                if (str[l][c] == '0')
                {
                    int rndPickup = Random.RandomRange(0, item);
                    if (rndPickup == 1)
                    {
                        int rnd = Random.RandomRange(0, prefabPickup.Length);
                        GameObject obj = GameObject.Instantiate(prefabPickup[rnd], new Vector3(refT.x * l, refP.y, refT.z * c), Quaternion.identity); obj.name = "P" + l + "_" + c;
                    }
                }

            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
