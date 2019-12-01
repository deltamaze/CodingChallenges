var fs = require('fs');


class Main {
  constructor(){
    this.finalSum = 0;
  }
  performCalcRecursive(startingWeight){
    let parsedNum = parseFloat(startingWeight);
    console.log(parsedNum)
    //divide by 3
    parsedNum = (parsedNum / 3);
    console.log(parsedNum)
    //round down
    parsedNum =Math.floor(parsedNum);
    console.log(parsedNum)
    //subtract 2
    parsedNum = parsedNum - 2;
    console.log(parsedNum)
    //save result
    //tally up result
    //if result is positive, tally up and keep going
    if(parsedNum > 0){
      this.finalSum = this.finalSum + parsedNum
      this.performCalcRecursive(parsedNum);
    }
    
  }
  start(){
    const array = fs.readFileSync('input.txt').toString().split("\n");
    for(let i = 0;i<array.length;i+=1) {
      //perform weight calculation, add to moduleWeights
      this.performCalcRecursive(array[i]);
    }
    //write out final answer
    console.log(this.finalSum)
    
    
  }
}

let app = new Main();
app.start();
