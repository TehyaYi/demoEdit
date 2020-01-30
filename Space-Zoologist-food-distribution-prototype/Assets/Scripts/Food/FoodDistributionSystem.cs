using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDistributionSystem : MonoBehaviour
{
    // This gives access to all the food sources on map
    [SerializeField] private FoodSourceTileMapScript foodSourceTileMapScript;
    // This gives access to all animal popluations
    private AnimalController animalController;
    private List<FoodSource> foodSources;
    private List<AnimalPopulation> animalPopulations = new List<AnimalPopulation>();

    private void getAllFoodSource()
    {
        this.foodSources = foodSourceTileMapScript.getFoodSources();
    }

    private void getAllAnimalPoplulation()
    {
        this.animalPopulations = animalController.GetAnimalPopulations();
    }


    /*
     * Notes: this implementation is has bad time complexity and not a optimal solution.
     * Goal: lower time complexity.
     */
    // Calculate and update food distrubution based on given formula
    private void UpdateFoodNeeds()
    {
        // Distribute by food source
        foreach (FoodSource foodSource in foodSources)
        {
            int totalDominance = 0;

            // The list of animals that can consume the food source.
            List<AnimalPopulation> animalsThatCanConsumeFoodSource = new List<AnimalPopulation>();

            // Iterate over all the existing animal populations and see if the food source is edible to any of them and
            // add them to animalsThatCanConsumeFoodSource list and also count up the total amount of dominance that will
            // be competing for the food source.
            foreach (AnimalPopulation animalPopulation in this.animalPopulations)
            {
                if (animalPopulation.IsEdible(foodSource))
                {
                    // Add poplulation dominace to total dominance
                    totalDominance += animalPopulation.PopulationDominance();
                    animalsThatCanConsumeFoodSource.Add(animalPopulation);

                    // Reset food source need value
                    Need<float> foodSourceNeed = (Need<float>)animalPopulation.GetNeed(foodSource.Type);
                    if (foodSourceNeed != null)
                    {
                        foodSourceNeed.CurrentValue = 0f;
                    }
                }
            }

            // Calculate the FoodPerIndividual score for each animal population.
            foreach (AnimalPopulation animalPopulation in animalsThatCanConsumeFoodSource)
            {
                float populationFood = ((float)animalPopulation.PopulationDominance() / (float)totalDominance) * foodSource.Output;
                float foodPerIndividual = populationFood / (float)animalPopulation.PopulationSize;
                Need<float> foodSourceNeed = (Need<float>)animalPopulation.GetNeed(foodSource.Type);
                //Debug.Log(foodSourceNeed.CurrentValue);
                foodSourceNeed.CurrentValue += foodPerIndividual;
            }
        }
    }

    // For other system to call 
    public void manualUpdate()
    {
        this.getAllFoodSource();
        this.getAllAnimalPoplulation();
        this.UpdateFoodNeeds();
    }

    // Start is called before the first frame update
    private void Start()
    {
        this.animalController = GetComponent<AnimalController>();
    }

    // Update is called once per frame
    private void Update()
    {
        this.getAllFoodSource();
        this.getAllAnimalPoplulation();
        this.UpdateFoodNeeds();
    }
}
