using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSourceManager : MonoBehaviour
{
 public GameObject[] foodSources;
 public bool updateDistribution;

    // Start is called before the first frame update
    void Start()
    {
        this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");
        updateDistribution = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
        /*
       this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");

        List<FoodSource> toUpdate = new List<FoodSource>();

        foreach(GameObject foodSource in this.foodSources)
        {
            if (!foodSourceList.Contains(foodSource.GetComponent<FoodSource>()))
            {
                this.add(foodSource.GetComponent<FoodSource>());
            }

            toUpdate.Add(foodSource.GetComponent<FoodSource>());
        }

*/
        //distributionSystem.update(toUpdate);

    
}
