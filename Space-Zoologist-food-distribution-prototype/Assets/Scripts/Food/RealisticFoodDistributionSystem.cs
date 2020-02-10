using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This distribution system (Realistic) is assuming that populations will stop consuming food after its
 * need is in the good rating. And that populations can have access to foodsource in different regions.
 */

public class RealisticFoodDistributionSystem : MonoBehaviour
{
    // 
    List<FoodSource> getFoodSourceByType()
    {

    }

    List<AnimalPopulation> getPopulationsCanAccess(FoodSource);
    Bool animalCanConsume(AnimalPopulation, FoodSource.type);
    List<AnimalPopulation> getPopulationIsEdible(List<AnimalPopulation>, FoodSource);
    float getCompetionRating(List<AnimalPopulation>);
    void distributeFoodSource(FoodSource)


    void updateFoodType(FoodSource.type)
    {
        List<FoodSource> foodSources = getFoodSourceByType();

        SortedList ratingAndPopulationPair = new SortedList();

        forEach(fs in foodSources)
        {
            List<AnimalPopulation> animalPopulations = getPopulationsCanAccess(fs);
            List<AnimalPopulation> populationsThatCanConsumeFoodSource(animalPopulations, fs);
            float competionRating = getCompetionRating(populationsThatCanConsumeFoodSource);

            ratingAndPopulationPair.Add(competionRating, fs);
        }

        foreach (DictionaryEntry pair in ratingAndPopulationPair)
        {
            distributeFoodSource(pair.Value);
        }
    }
}
