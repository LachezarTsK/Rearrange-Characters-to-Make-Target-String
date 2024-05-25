
using System;

public class Solution
{
    static readonly int ALPHABET_SIZE = 26;
    public int RearrangeCharacters(string availablelLetters, string target)
    {
        int[] frequencyInAvailablelLetters = new int[ALPHABET_SIZE];
        CalculateFrequency(frequencyInAvailablelLetters, availablelLetters);

        int[] frequencyInTarget = new int[ALPHABET_SIZE];
        CalculateFrequency(frequencyInTarget, target);

        return CalculateMaxNumberOfTargetCopies(frequencyInAvailablelLetters, frequencyInTarget);
    }

    private void CalculateFrequency(int[] frequency, String source)
    {
        foreach (int letter in source)
        {
            ++frequency[letter - 'a'];
        }
    }

    private int CalculateMaxNumberOfTargetCopies(int[] frequencyInAvailablelLetters, int[] frequencyInTarget)
    {
        int maxNumberOfTargetCopies = int.MaxValue;

        for (int letter = 0; letter < ALPHABET_SIZE; ++letter)
        {
            if (frequencyInTarget[letter] > 0)
            {
                int numberOfCopies = frequencyInAvailablelLetters[letter] / frequencyInTarget[letter];
                maxNumberOfTargetCopies = Math.Min(numberOfCopies, maxNumberOfTargetCopies);
            }
        }

        return maxNumberOfTargetCopies;
    }
}
