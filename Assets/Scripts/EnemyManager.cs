using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public float maxTime = 60f;
    public float maxStep = 4f;
    public TMP_Text TimeText;
    public GameObject Enemy;
    GameObject[] EnemySpawn;


    void Start()
    {
        EnemySpawn = GameObject.FindGameObjectsWithTag("spawn");

        StartCoroutine(StartEnemySpawn());
    }

    IEnumerator StartEnemySpawn()
    {
        float currentTime = 0f;
        float currentStep = maxStep;
        
        while(currentTime> maxTime)
        {
            yield return new WaitForSeconds(1f);
            currentTime++;
            TimeText.text = currentTime.ToString();
            currentStep--;
            if (currentStep==0)
            {
                GameObject instanciateEnemy= Instantiate(Enemy, EnemySpawn[Random.Range(0, EnemySpawn.Length)].transform);
                

                if(currentTime > maxTime*0.75f)
                {
                    instanciateEnemy.GetComponent<EnemyControler>().lifeTime= maxStep - 1;
                    currentStep = maxStep-1;
                }else if (currentTime > maxTime * 0.5f)
                {
                    instanciateEnemy.GetComponent<EnemyControler>().lifeTime = maxStep - 2;
                    currentStep = maxStep - 2;
                }
                else
                {
                    instanciateEnemy.GetComponent<EnemyControler>().lifeTime = maxStep;
                    currentStep = maxStep;
                }
                    
            }
        }
        
    }
}
