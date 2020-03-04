using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;


/*
 * This distribution system (Realistic) is assuming that populations will stop consuming food after its
 * need is in the good rating. And that populations can have access to foodsource in different regions.
 */

/*
 * Note:
 *  - the food source type is an enum (int).
 *  - need to add error handling.
 *  - TPS test with all access.
 */

public class RealisticFoodDistributionSystem
{

    private float getFoodSourceOutput(FoodSource foodSource) { return foodSource.getOutput(); }
    private float getPopulationDominace(Population population) { return population.PopulationDominace; }
    private int getPopulationSize(Population population) { return population.PopulationSize; }

    // Get a list of animal population that has access to given food source
    private List<Population> getPopulationsCanAccess(FoodSource foodSource)
    {
        List<Population> populationsCanAccess = new List<Population>();

        // TODO: get list of animal population that has access to foodSource. (RPS)

        return populationsCanAccess;
    }

    private float getTotoalDominaceOfPopulations(List<Population> populations)
    {
        float totalDominace = 0f;

        foreach(Population population in populations)
        {
            totalDominace += getPopulationDominace(population);
        }

        return totalDominace;
    }
   

    // Get list of populations that can consume given food source in given list of population
    private List<Population> getPopulationsThatConsumeFoodSource(List<Population> allPopulations, FoodSource foodSource)
    {
        List<Population> canConsumePopulations = new List<Population>();

        foreach(Population population in allPopulations)
        {
            // TODO: check in population can consume foodSourceType. (Population)
            if (population.IsEdible(foodSource))
            {
                canConsumePopulations.Add(population);
            }
        }

        return canConsumePopulations;
    }

    private float getCompetionRating(List<Population> populations)
    {
        float competitionRating = 0;
        List<float> populationDominaces = new List<float>();

        
        // Get all dominaces in a list
        foreach(Population population in populations)
        {
            populationDominaces.Add(getPopulationDominace(population));
        }

        // Compute competition rating(standard deviviation)
        float avg = populationDominaces.Average();
        competitionRating = (float)Math.Sqrt(populationDominaces.Average(v => Math.Pow(v - avg, 2)));

        return competitionRating;
    }

    
    
    private void distributeFoodSource(FoodSource foodSource, List<Population> populations)
    {
        float totalDominace = getTotoalDominaceOfPopulations(populations);


        foreach(Population population in populations)
        {
            float populationFood = getPopulationDominace(population) / totalDominace * getFoodSourceOutput(foodSource);
            float foodPerIndividual = populationFood / getPopulationSize(population);

            //Debug.Log("food output: " + getFoodSourceOutput(foodSource));
            //Debug.Log("total dominace: " + totalDominace);
            //Debug.Log("pop dominace: " + getPopulationDominace(population));

            // TODO: update food source need with foodPerIndividual
            population.updateNeed(foodSource.getType(), foodPerIndividual);
        }
    }

    // This function will be envoked when a type of food source is marked "dirty"
    public void update(List<FoodSource> foodSources)
    {
        var ratingAndPopulationPair = new SortedList();
        var foodSourceAndCanCosumePopulation = new Dictionary<FoodSource, List<Population>>();

        foreach (FoodSource foodSource in foodSources)
        {
            List<Population> Populations = getPopulationsCanAccess(foodSource);
            List<Population> populationsThatCanConsumeFoodSource = getPopulationsThatConsumeFoodSource(Populations, foodSource);

            foodSourceAndCanCosumePopulation.Add(foodSource, populationsThatCanConsumeFoodSource);
             
            float competionRating = getCompetionRating(populationsThatCanConsumeFoodSource);
            ratingAndPopulationPair.Add(competionRating, foodSource);
        }

        foreach (DictionaryEntry pair in ratingAndPopulationPair)
        {
            distributeFoodSource((FoodSource)pair.Value, foodSourceAndCanCosumePopulation[(FoodSource)pair.Value]);
        }
    }

    // This function will be envoked when a type of food source is marked "dirty"
    public void testerUpdate(List<FoodSource> foodSources, List<Population> populations)
    {
        SortedList ratingAndPopulationPair = new SortedList(new DuplicateKeyComparer<float>());
        var foodSourceAndCanCosumePopulation = new Dictionary<FoodSource, List<Population>>();

        foreach (FoodSource foodSource in foodSources)
        {
            //List<Population> populations = getPopulationsCanAccess(foodSource);
            List<Population> populationsThatCanConsumeFoodSource = getPopulationsThatConsumeFoodSource(populations, foodSource);

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

public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
{
   
    public int Compare(TKey x, TKey y)
    {
        int result = x.CompareTo(y);

        if (result == 0)
            return 1;   // Handle equality as beeing greater
        else
            return result;
    }
}
