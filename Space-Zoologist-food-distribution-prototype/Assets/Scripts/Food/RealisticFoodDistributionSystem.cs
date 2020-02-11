using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
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
        List<float> populationDominaces = new List<float>();

        
        // Get all dominaces in a list
        foreach(AnimalPopulation population in populations)
        {
            populationDominaces.Add(getPoplulationDomiance(population));
        }


        // Compute competition rating(standard deviviation)
        float avg = populationDominaces.Average();
        competitionRating = (float)Math.Sqrt(populationDominaces.Average(v => Math.Pow(v - avg, 2)));


        return competitionRating;
    }

    private float getPoplulationDomiance(AnimalPopulation population)
    {
        float domiance = 0f;

        // TODO: get dominace rating for given population

        return domiance;
    }

    private float getPopulationTotalDominace(AnimalPopulation population)
    {
        float totalDomiance = 0f;

        // TODO: get dominace rating for given population

        return totalDomiance;
    }

    private float getFoodSourceOutput(FoodSource foodSource)
    {
        float output = 0f;

        // TODO: get food source output

        return output;
    }

    private float getPopulationSize(AnimalPopulation population)
    {
        float populationSize = 0f;

        // TODO: get animal population size

        return populationSize;
    }


    private void distributeFoodSource(FoodSource foodSource, List<AnimalPopulation> populations)
    {
        
        foreach(AnimalPopulation population in populations)
        {
            float populationFood = getPoplulationDomiance(population) / getPopulationTotalDominace(population) * getFoodSourceOutput(foodSource);
            float foodPerIndividual = populationFood / getPopulationSize(population);

            // TODO: update food source need with foodPerIndividual
        }
    }

    // This function will be envoked when a food source is marked "dirty"
    public void updateFoodType(NeedType foodSourceType)
    {
        List<FoodSource> foodSources = getFoodSourceByType(foodSourceType);

        var ratingAndPopulationPair = new SortedList();
        var foodSourceAndCanCosumePopulation = new Dictionary<FoodSource, List<AnimalPopulation>>();

        foreach (FoodSource foodSource in foodSources)
        {
            List<AnimalPopulation> animalPopulations = getPopulationsCanAccess(foodSource);
            List<AnimalPopulation> populationsThatCanConsumeFoodSource = getPopulationsThatConsumeFoodSource(animalPopulations, foodSource.Type);

            foodSourceAndCanCosumePopulation.Add(foodSource, populationsThatCanConsumeFoodSource);
             
            float competionRating = getCompetionRating(populationsThatCanConsumeFoodSource);
            ratingAndPopulationPair.Add(competionRating, foodSource);
        }

        foreach (DictionaryEntry pair in ratingAndPopulationPair)
        {
            distributeFoodSource((FoodSource)pair.Value, foodSourceAndCanCosumePopulation[(FoodSource)pair.Value]);
        }
    }
}
