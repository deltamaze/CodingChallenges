/* eslint-disable no-console */
const fs = require('fs');


class Main {
  static start() {
    const initialIntCode = [];
    let intCode = [];
    const array = fs.readFileSync('./Day2/input.txt').toString().split(',');
    // parse input into array of ints
    for (let i = 0; i < array.length; i += 1) {
      const parsedNum = parseInt(array[i], 10);
      initialIntCode.push(parsedNum);
    }

    // processintCode, plugging in a value into the noun and verb until desired output is found
    for (let a = 0; a <= 99; a += 1) {
      for (let b = 0; b <= 99; b += 1) {
        const noun = a;
        const verb = b;
        // reset intCode
        intCode = initialIntCode.slice();
        // plug in noun and verb:
        intCode[1] = noun;
        intCode[2] = verb;

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
        if (intCode[0] === 19690720) {
          console.log(intCode[1]);
          console.log(intCode[2]);
          console.log('breakpoint');
        }
      }
    }
  }
}


Main.start();
