
public class Solution {

    private static final int ALPHABET_SIZE = 26;

    public int rearrangeCharacters(String availableLetters, String target) {
        int[] frequencyInAvailableLetters = new int[ALPHABET_SIZE];
        calculateFrequency(frequencyInAvailableLetters, availableLetters);

        int[] frequencyInTarget = new int[ALPHABET_SIZE];
        calculateFrequency(frequencyInTarget, target);

        return calculateMaxNumberOfTargetCopies(frequencyInAvailableLetters, frequencyInTarget);
    }

    private void calculateFrequency(int[] frequency, String source) {
        for (int letter : source.toCharArray()) {
            ++frequency[letter - 'a'];
        }
    }

    private int calculateMaxNumberOfTargetCopies(int[] frequencyInAvailableLetters, int[] frequencyInTarget) {
        int maxNumberOfTargetCopies = Integer.MAX_VALUE;

        for (int letter = 0; letter < ALPHABET_SIZE; ++letter) {
            if (frequencyInTarget[letter] > 0) {
                int numberOfCopies = frequencyInAvailableLetters[letter] / frequencyInTarget[letter];
                maxNumberOfTargetCopies = Math.min(numberOfCopies, maxNumberOfTargetCopies);
            }
        }

        return maxNumberOfTargetCopies;
    }
}
