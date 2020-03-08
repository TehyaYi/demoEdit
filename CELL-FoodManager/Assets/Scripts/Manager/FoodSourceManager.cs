using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSourceManager : MonoBehaviour
{
    //Food source manager will be keeping references to the food sources and telling the food dis. sys 
    //and environmental interactions sys. to update when they need to

    List<FoodSource> toUpdate = new List<FoodSource>();

    //list of all active food source instances
    private IList<FoodSource> foodSourceList = new List<FoodSource>();

    private RealisticFoodDistributionSystem distributionSystem = new RealisticFoodDistributionSystem();

    public GameObject[] foodSources;

    public void add(FoodSource newFoodSource) {
        foodSourceList.Add(newFoodSource);
        // TODO : tell food dist and food env to update
    }
    
    public void delete(FoodSource oldFoodSource)
    {
        foodSourceList.Remove(oldFoodSource);
        // TODO : tell food dist and food env to update
    }

    // Start is called before the first frame update
    void Start()
    {
        this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");
       

        foreach (GameObject foodSource in this.foodSources)
        {

            if (!foodSourceList.Contains((FoodSource)foodSource.GetComponent("Food Source")))
            {
                this.add((FoodSource)foodSource.GetComponent("Food Source"));
            }

            toUpdate.Add((FoodSource)foodSource.GetComponent("Food Source"));
            print("hello");
        }
        print(toUpdate.Count);
        if (toUpdate.Count > 0)
        {
            distributionSystem.update(toUpdate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");

        
    }
}
