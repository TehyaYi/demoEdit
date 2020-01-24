using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDistributionSyst : MonoBehaviour
{

    [SerializeField] private FoodSourceTileMapScript foodSourceTileMapScript;
    private List<FoodSource> foodSources;

    void getAllFoodSource()
    {
        // Get the list of food sources in the reserves
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
