const fs = require('fs');


class Main {
  static start() {
    const moduleWeights = [];
    let finalSum = 0;
    const array = fs.readFileSync('./Day1/input.txt').toString().split('\n');
    for (let i = 0; i < array.length; i += 1) {
      // perform weight calculation, add to moduleWeights
      let parsedNum = parseFloat(array[i]);
      // divide by 3
      parsedNum /= 3;
      // round down
      parsedNum = Math.floor(parsedNum);
      // subtract 2
      parsedNum -= 2;
      // save result
      moduleWeights.push(parsedNum); // save into array for debugging
      // tally up result
      finalSum += parsedNum;
    }
    // write out final answer
    // eslint-disable-next-line no-console
    console.log(finalSum);
  }
}


Main.start();
