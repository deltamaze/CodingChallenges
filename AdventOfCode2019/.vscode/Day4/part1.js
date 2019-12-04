/* eslint-disable no-console */
const fs = require('fs');


class Main {
  constructor() {

  }

  
  start() {
    
    let input = 172851;
    let matchingCriteria = 0;
    while (input <= 675869){
      let isDup = false;
      let isIncrease = true;
      //break out into array
      var digits = (""+input).split("");
      for(let i = 1;i <= digits.length; i+=1){
        const digit0=parseInt(digits[i-1],10)
        const digit1=parseInt(digits[i],10)
        if(digit1 < digit0 ){
          isIncrease = false;
        }
        if(digit1 == digit0){
          isDup = true;
        }
      }
      if (isDup && isIncrease){
        matchingCriteria += 1
      }
      //verify each digit is increasing
      //verify 2 of
      input++;
    }
    // write answer
    console.log(matchingCriteria);

  }
}

const app = new Main();
app.start();
