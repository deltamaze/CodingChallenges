const fs = require('fs');


class Main {
  static start() {
    const intCode = [];
    const array = fs.readFileSync('./Day2/input.txt').toString().split(',');
    // parse input into array of ints
    for (let i = 0; i < array.length; i += 1) {
      // perform weight calculation, add to moduleWeights
      const parsedNum = parseInt(array[i], 10);
      intCode.push(parsedNum);
    }
    // "before running the program, replace position 1 with the value 12
    // and replace position 2 with the value 2."
    intCode[1] = 12;
    intCode[2] = 2;
    // processintCode
    // process 4 at a time
    for (let i = 0; i < intCode.length; i += 4) {
      // process optCode
      if (intCode[i] === 99) {
        break;
      }
      if (intCode[i] === 1) { // addition
        // add
        const sum = intCode[intCode[i + 1]] + intCode[intCode[i + 2]];
        // save
        intCode[intCode[i + 3]] = sum;
      }
      if (intCode[i] === 2) { // multiplication
        // multi
        const product = intCode[intCode[i + 1]] * intCode[intCode[i + 2]];
        // save
        intCode[intCode[i + 3]] = product;
      }
    }
    // write out final answer
    // eslint-disable-next-line no-console
    console.log(intCode[0]);
  }
}


Main.start();
