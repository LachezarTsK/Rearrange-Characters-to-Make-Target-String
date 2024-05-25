
function rearrangeCharacters(availablelLetters: string, target: string): number {
    this.ALPHABET_SIZE = 26;
    this.ASCII_SMALL_CASE_A = 97;

    const frequencyInAvailablelLetters = new Array(this.ALPHABET_SIZE).fill(0);
    calculateFrequency(frequencyInAvailablelLetters, availablelLetters);

    const frequencyInTarget = new Array(this.ALPHABET_SIZE).fill(0);
    calculateFrequency(frequencyInTarget, target);

    return calculateMaxNumberOfTargetCopies(frequencyInAvailablelLetters, frequencyInTarget);
};

function calculateFrequency(frequency: number[], source: string): void {
    for (let letter of source) {
        ++frequency[letter.codePointAt(0) - this.ASCII_SMALL_CASE_A];
    }
}


function calculateMaxNumberOfTargetCopies(frequencyInAvailablelLetters: number[], frequencyInTarget: number[]): number {
    let maxNumberOfTargetCopies = Number.MAX_SAFE_INTEGER;

    for (let letter = 0; letter < this.ALPHABET_SIZE; ++letter) {
        if (frequencyInTarget[letter] > 0) {
            let numberOfCopies = Math.floor(frequencyInAvailablelLetters[letter] / frequencyInTarget[letter]);
            maxNumberOfTargetCopies = Math.min(numberOfCopies, maxNumberOfTargetCopies);
        }
    }

    return maxNumberOfTargetCopies;
}
