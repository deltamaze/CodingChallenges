const fs = require('fs');

class Main {
  static start() {
    let matrix = [];
    const array = fs.readFileSync('../Day3/inputSample.txt').toString().split('\r\n');
    array.forEach(element => {
      let splitElem = element.split("");
      for(let x = 0; x < splitElem.length; x +=1)
      {
        if(matrix[x] == undefined){
          matrix[x] = [];
        }
        matrix[x].push(splitElem[x]);
      }
    });
    let getMax = (myArray) => {
      let one = 0;
      let zero = 0;
      for (let x = 0; x < myArray.length; x += 1) {
        if (myArray[x] == "0") {
          zero += 1;
          continue;
        }
        one += 1;
      }
      if (zero > one) {
        return "0";
      }
      return "1";
    };
    let getMin = (myArray) => {
      let one = 0;
      let zero = 0;
      for (let x = 0; x < myArray.length; x += 1) {
        if (myArray[x] == "0") {
          zero += 1;
          continue;
        }
        one += 1;
      }
      if (zero > one) {
        return "1";
      }
      return "0";
    };

    let firstCurveString = "";
    let secondCurveString = "";
    for(let x = 0; x < matrix.length; x +=1)
    {
      firstCurveString += getMax(matrix[x]);
      secondCurveString += getMin(matrix[x]);
    }
    
    let firstCurveInt = parseInt(firstCurveString,2);
    let secondCurveInt = parseInt(secondCurveString,2);
    let ans = firstCurveInt * secondCurveInt;

    console.log(ans);

  }
}


Main.start();
