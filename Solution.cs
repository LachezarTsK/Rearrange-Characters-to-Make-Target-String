
using System;

public class Solution
{
    static readonly int ALPHABET_SIZE = 26;
    public int RearrangeCharacters(string availableLetters, string target)
    {
        int[] frequencyInAvailableLetters = new int[ALPHABET_SIZE];
        CalculateFrequency(frequencyInAvailableLetters, availableLetters);

        int[] frequencyInTarget = new int[ALPHABET_SIZE];
        CalculateFrequency(frequencyInTarget, target);

        return CalculateMaxNumberOfTargetCopies(frequencyInAvailableLetters, frequencyInTarget);
    }

    private void CalculateFrequency(int[] frequency, String source)
    {
        foreach (int letter in source)
        {
            ++frequency[letter - 'a'];
        }
    }

    private int CalculateMaxNumberOfTargetCopies(int[] frequencyInAvailableLetters, int[] frequencyInTarget)
    {
        int maxNumberOfTargetCopies = int.MaxValue;

        for (int letter = 0; letter < ALPHABET_SIZE; ++letter)
        {
            if (frequencyInTarget[letter] > 0)
            {
                int numberOfCopies = frequencyInAvailableLetters[letter] / frequencyInTarget[letter];
                maxNumberOfTargetCopies = Math.Min(numberOfCopies, maxNumberOfTargetCopies);
            }
        }

        return maxNumberOfTargetCopies;
    }
}
