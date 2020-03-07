using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{

    private RealisticFoodDistributionSystem distributionSystem;
    private GameObject[] foodSources;
    private GameObject[] populations;


    // Start is called before the first frame update
    void Start()
    {
        this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");
        this.populations = GameObject.FindGameObjectsWithTag("population");
        this.distributionSystem = new RealisticFoodDistributionSystem();
    }

    // Update is called once per frame
    void Update()
    {
        this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");
        this.populations = GameObject.FindGameObjectsWithTag("population");

        List<FoodSource> foodSourceToUpdate = new List<FoodSource>();
        List<Population> populaionToUpdate = new List<Population>();

        foreach (GameObject foodSource in this.foodSources)
        {
            foodSourceToUpdate.Add(foodSource.GetComponent<FoodSource>());
        }
        foreach (GameObject population in this.populations)
        {
            populaionToUpdate.Add(population.GetComponent<Population>());
        }

        //this.distributionSystem.testerUpdate(foodSourceToUpdate, populaionToUpdate);
    }
}
