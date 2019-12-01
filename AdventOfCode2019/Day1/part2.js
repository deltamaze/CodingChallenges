const fs = require('fs');


class Main {
  constructor() {
    this.finalSum = 0;
  }

  performCalcRecursive(startingWeight) {
    let parsedNum = parseFloat(startingWeight);
    // divide by 3
    parsedNum /= 3;
    // round down
    parsedNum = Math.floor(parsedNum);
    // subtract 2
    parsedNum -= 2;
    // if result is positive, tally up and keep going
    if (parsedNum > 0) {
      this.finalSum += parsedNum;
      this.performCalcRecursive(parsedNum);
    }
  }

  start() {
    const array = fs.readFileSync('./Day1/input.txt').toString().split('\n');
    for (let i = 0; i < array.length; i += 1) {
      // perform weight calculation, add to moduleWeights
      this.performCalcRecursive(array[i]);
    }
    // write out final answer
    // eslint-disable-next-line no-console
    console.log(this.finalSum);
  }
}

const app = new Main();
app.start();
