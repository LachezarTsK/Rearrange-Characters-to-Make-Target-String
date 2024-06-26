
/**
 * @param {string} availablelLetters
 * @param {string} target
 * @return {number}
 */
var rearrangeCharacters = function (availableLetters, target) {
    this.ALPHABET_SIZE = 26;
    this.ASCII_SMALL_CASE_A = 97;

    const frequencyInAvailableLetters = new Array(this.ALPHABET_SIZE).fill(0);
    calculateFrequency(frequencyInAvailableLetters, availableLetters);

    const frequencyInTarget = new Array(this.ALPHABET_SIZE).fill(0);
    calculateFrequency(frequencyInTarget, target);

    return calculateMaxNumberOfTargetCopies(frequencyInAvailableLetters, frequencyInTarget);
};

/**
 * @param {number[]} frequency
 * @param {string} source
 * @return {void}
 */
function calculateFrequency(frequency, source) {
    for (let letter of source) {
        ++frequency[letter.codePointAt(0) - this.ASCII_SMALL_CASE_A];
    }
}

/**
 * @param {number[]} frequencyInAvailableLetters
 * @param {number[]} frequencyInTarget
 * @return {number}
 */
function calculateMaxNumberOfTargetCopies(frequencyInAvailableLetters, frequencyInTarget) {
    let maxNumberOfTargetCopies = Number.MAX_SAFE_INTEGER;

    for (let letter = 0; letter < this.ALPHABET_SIZE; ++letter) {
        if (frequencyInTarget[letter] > 0) {
            let numberOfCopies = Math.floor(frequencyInAvailableLetters[letter] / frequencyInTarget[letter]);
            maxNumberOfTargetCopies = Math.min(numberOfCopies, maxNumberOfTargetCopies);
        }
    }

    return maxNumberOfTargetCopies;
}
