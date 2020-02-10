# CELL_Food Distribution System

## Overall
This script discribes a system to distribute all food sources to all animal populations in a single level. It is meant to be attech to a script holder in each level.

## How it works
This distrubution function `UpdateFoodNeeds` will be given an food source type and do that following:

* Realistic method
    1. Locate all food sources with the given type, `foodSources`.
    2. For each food source, `foodSource`, get all the animal that has access to it, `animalPopulations`.
    3. For all the animal populations, `animalPopulations`, remove the populations that does not consume `foodSource`, to get a new list `animalsPopulationsThatCanConsumeFoodSource`.
    4. Compute the competition rating (standard deviation) for each `foodSource`.
    5. Sort the food sources from `foodSource` based on the competition rating in increading order.
    6. Distribute each food source from `foodSources` starting with food source with low competition rating to high.

* Naive method
    Step 1,2,3 is the same as realistic method. Jump to step 6 and distribute in any order.

## Detail

### Formulas:
* Population dominance = species dominance • population size
* Group food = (population dominance / total dominance) • food source production
* Individual food = group food / population size


### How to get vars need: 
* dominance rating - store in Animal class, total dominance can be get by `PopulationDominance` in `AnimalPopluatoion.cs`
* food sources - call `FoodSourceTileMapScript.getFoodSources()`.

### Pseudocode

```C#

class FoodDistributionSystem
{
    func getAllAnimalPoplulation();
    func getAllFoodSource();
    func UpdateFoodNeeds();

    void getFoodSourceByType()
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

        foreach(DictionaryEntry pair in ratingAndPopulationPair)
        {
            distributeFoodSource(pair.Value);
        }
    }
}
```

# Objective(s)
* break functionality into different functions, each function handles exactlly one thing
* try to reduce time complexity


## Notes

* The systems behavior outsome should be easy for player to notice the effect of a change to the system.

