using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This distribution system (Realistic) is assuming that populations will stop consuming food after its
 * need is in the good rating. And that populations can have access to foodsource in different regions.
 */

public class RealisticFoodDistributionSystem : MonoBehaviour
{
    // Get all the food source on map with the type given
    private List<FoodSource> getFoodSourceByType(NeedType foodSourceType)
    {
        List<FoodSource> foodSources = new List<FoodSource>();

        // TODO: get all the food source on map by its type, `foodSourceType`.

        return foodSources;
    }

    // Get a list of animal population that has access to given food source
    private List<AnimalPopulation> getPopulationsCanAccess(FoodSource foodSource)
    {
        List<AnimalPopulation> populationsCanAccess = new List<AnimalPopulation>();

        // TODO: get list of animal population that has access to foodSource

        return populationsCanAccess;
    }

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

    private float getCompetionRating(List<AnimalPopulation> populations)
    {
        float competitionRating = 0;

        // TODO: compute competition rating(standard dev) of the donimance rating for the populations

        return competitionRating;
    }

    private void distributeFoodSource(FoodSource foodSource)
    {
        // TODO: distribute food source (same as naive method)
    }


    // This function will be envoked when a food source is marked "dirty"
    public void updateFoodType(NeedType foodSourceType)
    {
        List<FoodSource> foodSources = getFoodSourceByType(foodSourceType);

        SortedList ratingAndPopulationPair = new SortedList();

        foreach(FoodSource foodSource in foodSources)
        {
            List<AnimalPopulation> animalPopulations = getPopulationsCanAccess(foodSource);
            List<AnimalPopulation> populationsThatCanConsumeFoodSource = getPopulationsThatConsumeFoodSource(animalPopulations, foodSource.Type);
            float competionRating = getCompetionRating(populationsThatCanConsumeFoodSource);

            ratingAndPopulationPair.Add(competionRating, foodSource);
        }

        foreach (DictionaryEntry pair in ratingAndPopulationPair)
        {
            distributeFoodSource((FoodSource)pair.Value);
        }
    }
}
