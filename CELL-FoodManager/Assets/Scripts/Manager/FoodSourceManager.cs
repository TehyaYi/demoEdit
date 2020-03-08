using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSourceManager : MonoBehaviour
{
    //Food source manager will be keeping references to the food sources and telling the food dis. sys 
    //and environmental interactions sys. to update when they need to

    //list of all active food source instances
   // private IList<FoodSource> foodSourceList = new List<FoodSource>();

   // private RealisticFoodDistributionSystem distributionSystem = new RealisticFoodDistributionSystem();

    public GameObject[] foodSources;

/*
    public void add(FoodSource newFoodSource) {
        foodSourceList.Add(newFoodSource);
        // TODO : tell food dist and food env to update
    }
    
    public void delete(FoodSource oldFoodSource)
    {
        foodSourceList.Remove(oldFoodSource);
        // TODO : tell food dist and food env to update
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");
        print("This is the Food Source Manager");
    }

    // Update is called once per frame
    void Update()
    {
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
}
