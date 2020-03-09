using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 This method assumes 'one region' i.e. all animals and plants present on the map can access everything
*/


public class FoodDistribution_tester : MonoBehaviour
{
    
 private float totalFood;
 public GameObject[] populationsObjects;
 private float totalDominance;
 public GameObject[] foodSources;
 public bool updateDistribution;
    
    void Start()
    {
        this.foodSources = GameObject.FindGameObjectsWithTag("foodSource");
        updateDistribution = true;
    }
    
    void Update()
    {
        if(updateDistribution)
        {
            updateDistribution = false;
            distribute();  
        }
    }

    public void distribute()
    {
        totalDominance = 0;
        totalFood = 0;
        print("distribution system is updating");
        foreach(GameObject food in foodSources)
        {
            totalFood = totalFood + getFoodSourceOutput(food);
        }
        print(totalFood);

        List<Population> animals = getPopulationsCanAccess();
        foreach(Population animal in animals)
        {
            totalDominance = totalDominance + getPopulationTotalDominance(animal);
        }

        distributeTotalFood(totalFood, totalDominance, animals);
    }

    private float getFoodSourceOutput(GameObject foodSource)
    {
        FoodSource source = foodSource.GetComponent<FoodSource>();
        return source.totalOutput;
    }


    private void distributeTotalFood(float totalFood, float totalDominance, List<Population> populationsList)
    {
        foreach(Population population in populationsList)
        {
            float groupFood = totalFood * getPopulationTotalDominance(population) / totalDominance;
            float individualFood = groupFood / getPopulationSize(population);
            //updateFoodNeed(individualFood, population)
            print(individualFood);
        }
    }

    public void updateFoodNeed(float individualFood, Population pop)
    {
        //TODO: This is the function that will integrate with the needs system
    }

/*
    // Get the different food source types available on the map
    private List<FoodTypes> getAllFoodTypesAvailable()
    {
        List<FoodTypes> foodSourceTypes = new List<FoodTypes>();
        // TODO: get all the food source in the region by its type, `foodSourceType`.
        return foodSourceTypes;
    }
*/

/*
    // Get the different food sources of that type in the region
    private List<FoodSource> getAllFoodOnMap()
    {
        List<FoodSource> foodSources = new List<FoodSource>();
        // TODO: get all food sources on the map
        return foodSources;
    }

   */


        // Get a list of animal population that has access to given region
    private List<Population> getPopulationsCanAccess()
    {
        this.populationsObjects = GameObject.FindGameObjectsWithTag("population");
        List<Population> populationsCanAccess = new List<Population>();
        foreach(GameObject populationObject in populationsObjects)
        {
            Population population = populationObject.GetComponent<Population>();
            populationsCanAccess.Add(population);
            print("a population was counted");
        }
        return populationsCanAccess;
    }

/*
// Get list of populations that can consume given food source in given list of population
    private List<AnimalPopulation> getPopulationsThatConsumeFoodSource(List<AnimalPopulation> allPopulations, NeedType foodSourceType)
    {
        List<AnimalPopulation> canConsumePopulations = new List<AnimalPopulation>();
        foreach(AnimalPopulation population in allPopulations)
        {
            // TODO: check in population can consume foodSourceType
            if (true)
            {
                canConsumePopulations.Add(population);
            }
        }
        return canConsumePopulations;
    }
*/

    private float getPoplulationDominance(Population population)
    {
      return population.PopulationDominace;
    }

    private float getPopulationTotalDominance(Population population)
    {
        float totalDom = getPoplulationDominance(population) * getPopulationSize(population);
        return totalDom;
    }

    private float getPopulationSize(Population population)
    {
        return population.PopulationSize;
    }

/*
    private void distributeTotalFood(FoodSourceType type, int totalFood, List<AnimalPopulation> populationsList)
    {
        float totalDomiance = 0f;
        foreach(AnimalPopulation population in populations)
        {
            totalDomiance = totalDomiance + getPopulationTotalDominace(population);
        }
        foreach(AnimalPopulation population in populations)
        {
            float groupFood = totalFood * getPopulationTotalDominace(population) / totalDomiance;
            float individualFood = groupFood / getPopulationSize();
            updateNeedRating(population, individualFood, type);
        }
    }
*/

    /*
    private void distributeFoodByRegion(Region region)
    {
        List<FoodSourceType> listOfTypes = getFoodSourceTypes(region);
        List<AnimalPopulation> listOfAnimals = getPopulationsCanAccess(region);
        foreach(FoodSourceType type in listOfTypes)
        {
            List<FoodSource> foodSources = getFoodSources(region, type);
            int totalFood = 0;
            foreach(FoodSource source in foodSources){
                totalFood = totalFood + getFoodSourceOutput(source);
            }
            List<AnimalPopulation> animalsCanEat = getPopulationsThatConsumeFoodSource(listOfAnimals);
            distributeTotalFood(type, totalFood, animalsCanEat);
        }
    }
*/



}
