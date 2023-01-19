using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platform;

    private Transform playerTransform;

    private float spawnZ=-6.0f;

    private float platformLength=9.84f;

    private int numberOfPlatforms=7;

    private List<GameObject> activePlatform;

    private int  lastPlatformIndex=0;

    private float safeZone=20.0f;

    public Material[] skyboxes;

    public GameObject pointLight;

    public GameObject directionLight;

    private int i;
    public int j;
    private int k;

    // Start is called before the first frame update
    void Start()
    {
        activePlatform=new List<GameObject>();
        playerTransform=GameObject.FindGameObjectWithTag("Player").transform;
        for(int i=0;i<numberOfPlatforms;i++)
        {
            if(i<2)
                spawPlatform(0);
            else
            {
                spawPlatform();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z-safeZone>(spawnZ-numberOfPlatforms*platformLength))
        {

            spawPlatform();
            deletePlatform();
        }
    }

    private void spawPlatform(int platformIndex=-1)
    {
        GameObject start;
        if(platformIndex==-1)
        {
            start=Instantiate(platform[randomPlatformIndex()]) as GameObject;
            RenderSettings.skybox=skyboxes[i];
            if(k==1)
            {
                pointLight.gameObject.SetActive(true);
                directionLight.gameObject.SetActive(false);
            }
            else
            {
                pointLight.gameObject.SetActive(false);
                directionLight.gameObject.SetActive(true);
            }
        }
        else
        {
            start=Instantiate(platform[platformIndex]) as GameObject;
            RenderSettings.skybox=skyboxes[i];
            if(k==1)
            {
                pointLight.gameObject.SetActive(true);
                directionLight.gameObject.SetActive(false);
            }
            else
            {
                pointLight.gameObject.SetActive(false);
                directionLight.gameObject.SetActive(true);
            }
        }
        start.transform.SetParent(transform);
        start.transform.position=Vector3.forward*spawnZ;
        spawnZ+=platformLength;
        activePlatform.Add(start);
    }

    private void deletePlatform()
    {
        Destroy(activePlatform[0]);
        activePlatform.RemoveAt(0);
    }

    private int randomPlatformIndex()
    {
        if(platform.Length<=1)
            return 0;

        int randomIndex=lastPlatformIndex;
        while (randomIndex==lastPlatformIndex)
        {
            randomIndex=Random.Range(0,platform.Length);
        
        if(j<=50)
            {
                i=0;
                k=0;
                randomIndex=Random.Range(0,2);
                j++;
            }
       else if(j>50 && j<=100)
            {
                i=1;
                k=0;
                randomIndex=Random.Range(3,5);
                j++;
            }
        else if(j>100 && j<=150)
            {
                i=2;
                k=0;
                randomIndex=Random.Range(6,8);
                j++;
            }
        else if(j>150 && j<=200)
            {
                i=3;
                k=1;
                randomIndex=Random.Range(9,11);
                j++;
            }
        else if(j>200 && j<=250)
            {
                i=0;
                k=0;
                randomIndex=Random.Range(1,3);
                j++;
            }
        else if(j>250 && j<=300)
            {
                i=1;
                k=0;
                randomIndex=Random.Range(4,6);
                j++;
            }
        else if(j>300 && j<=350)
            {
                i=2;
                k=0;
                randomIndex=Random.Range(7,9);
                j++;
            }
        else if(j>350 && j<=400)
            {
                i=3;
                k=1;
                randomIndex=Random.Range(10,12);
                j++;
            }
        else
            {
                i=0;
                j=0;
                k=0;
                randomIndex=0;
            }
            
        }
        lastPlatformIndex=randomIndex;
        return randomIndex;
    }
}
