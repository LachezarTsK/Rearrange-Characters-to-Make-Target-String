
import kotlin.math.min

class Solution {

    private companion object {
        const val ALPHABET_SIZE = 26
    }

    fun rearrangeCharacters(availableLetters: String, target: String): Int {
        val frequencyInAvailableLetters = IntArray(ALPHABET_SIZE)
        calculateFrequency(frequencyInAvailableLetters, availableLetters)

        val frequencyInTarget = IntArray(ALPHABET_SIZE)
        calculateFrequency(frequencyInTarget, target)

        return calculateMaxNumberOfTargetCopies(frequencyInAvailableLetters, frequencyInTarget)
    }

    private fun calculateFrequency(frequency: IntArray, source: String) {
        for (letter in source) {
            ++frequency[letter - 'a']
        }
    }

    private fun calculateMaxNumberOfTargetCopies(
        frequencyInAvailableLetters: IntArray,
        frequencyInTarget: IntArray
    ): Int {
        var maxNumberOfTargetCopies = Int.MAX_VALUE

        for (letter in 0..<ALPHABET_SIZE) {
            if (frequencyInTarget[letter] > 0) {
                val numberOfCopies = frequencyInAvailableLetters[letter] / frequencyInTarget[letter]
                maxNumberOfTargetCopies = min(numberOfCopies, maxNumberOfTargetCopies)
            }
        }

        return maxNumberOfTargetCopies
    }
}
