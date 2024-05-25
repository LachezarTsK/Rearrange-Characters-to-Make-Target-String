
package main

import (
	"fmt"
	"math"
)

const ALPHABET_SIZE = 26

func rearrangeCharacters(availableLetters string, target string) int {
	var frequencyInAvailableLetters = make([]int, ALPHABET_SIZE)
	calculateFrequency(frequencyInAvailableLetters, availableLetters)

	var frequencyInTarget = make([]int, ALPHABET_SIZE)
	calculateFrequency(frequencyInTarget, target)

	return calculateMaxNumberOfTargetCopies(frequencyInAvailableLetters, frequencyInTarget)
}

func calculateFrequency(frequency []int, source string) {
	for _, letter := range source {
		frequency[letter-'a']++
	}
}

func calculateMaxNumberOfTargetCopies(frequencyInAvailableLetters []int, frequencyInTarget []int) int {
	var maxNumberOfTargetCopies = math.MaxInt

	for letter := 0; letter < ALPHABET_SIZE; letter++ {
		if frequencyInTarget[letter] > 0 {
			var numberOfCopies = frequencyInAvailableLetters[letter] / frequencyInTarget[letter]
			maxNumberOfTargetCopies = min(numberOfCopies, maxNumberOfTargetCopies)
		}
	}

	return maxNumberOfTargetCopies
}
