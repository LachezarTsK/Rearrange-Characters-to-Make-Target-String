
#include <span>
#include <string>
#include <limits>
#include <algorithm>
using namespace std;

class Solution {

    static const int ALPHABET_SIZE = 26;

public:
    int rearrangeCharacters(const string& availableLetters, const string& target) const {
        array<int, ALPHABET_SIZE> frequencyInAvailableLetters{};
        calculateFrequency(frequencyInAvailableLetters, availableLetters);

        array<int, ALPHABET_SIZE> frequencyInTarget{};
        calculateFrequency(frequencyInTarget, target);

        return calculateMaxNumberOfTargetCopies(frequencyInAvailableLetters, frequencyInTarget);
    }

private:
    void calculateFrequency(span<int> frequency, string_view source) const {
        for (const auto& letter : source) {
            ++frequency[letter - 'a'];
        }
    }

    int calculateMaxNumberOfTargetCopies(span<const int>frequencyInAvailableLetters, span<const int> frequencyInTarget) const {
        int maxNumberOfTargetCopies = numeric_limits<int>::max();

        for (int letter = 0; letter < ALPHABET_SIZE; ++letter) {
            if (frequencyInTarget[letter] > 0) {
                int numberOfCopies = frequencyInAvailableLetters[letter] / frequencyInTarget[letter];
                maxNumberOfTargetCopies = min(numberOfCopies, maxNumberOfTargetCopies);
            }
        }

        return maxNumberOfTargetCopies;
    }
};
