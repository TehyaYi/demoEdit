using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDistributionSystem : MonoBehaviour
{
    // This gives access to all the food sources on map
    [SerializeField] private FoodSourceTileMapScript foodSourceTileMapScript;
    private List<FoodSource> foodSources;

    // This gives access to all animal popluations
    private AnimalController animalController;

    void getAllFoodSource()
    {
        // Get the list of food sources on the map
        foodSources = foodSourceTileMapScript.getFoodSources();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getAllFoodSource();
    }
}
