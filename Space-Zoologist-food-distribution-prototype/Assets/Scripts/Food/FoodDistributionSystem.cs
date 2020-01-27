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
    private List<AnimalPopulation> animalPopulations = new List<AnimalPopulation>();

    void getAllFoodSource()
    {
        this.foodSources = foodSourceTileMapScript.getFoodSources();
    }

    void getAllAnimalPoplulation()
    {
        this.animalPopulations = animalController.GetAnimalPopulations();
    }

    void UpdateFoodNeeds()
    {
        // Reset food needs values
        foreach (FoodSource foodSource in foodSources)
        {
            foreach (AnimalPopulation animalPopulation in animalController.GetAnimalPopulations())
            {
                Need<float> foodSourceNeed = (Need<float>)animalPopulation.GetNeed(foodSource.Type);
                if (foodSourceNeed != null)
                {
                    foodSourceNeed.CurrentValue = 0f;
                }
            }
        }

        foreach (FoodSource foodSource in foodSources)
        {
            int totalDominance = 0;

            // The list of animals that can consume the food source.
            List<AnimalPopulation> animalsThatCanConsumeFoodSource = new List<AnimalPopulation>();

            // Iterate over all the existing animal populations and see if the food source is edible to any of them and
            // add them to animalsThatCanConsumeFoodSource list and also count up the total amount of dominance that will
            // be competing for the food source.
            foreach (AnimalPopulation animalPopulation in animalController.GetAnimalPopulations())
            {
                if (animalPopulation.IsEdible(foodSource))
                {
                    totalDominance += animalPopulation.PopulationDominance();
                    animalsThatCanConsumeFoodSource.Add(animalPopulation);
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

    // Start is called before the first frame update
    void Start()
    {
        this.animalController = GetComponent<AnimalController>();
    }

    // Update is called once per frame
    void Update()
    {
        getAllFoodSource();
        getAllAnimalPoplulation();
    }
}
