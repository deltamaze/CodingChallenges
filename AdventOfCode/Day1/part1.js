var fs = require('fs');


class Main {
  start(){
    let moduleWeights = []
    let finalSum = 0
    const array = fs.readFileSync('input.txt').toString().split("\n");
    for(let i = 0;i<array.length;i+=1) {
      //perform weight calculation, add to moduleWeights
        let parsedNum = parseFloat(array[i]);
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
        moduleWeights.push(parsedNum); // save into array for debugging
        console.log(parsedNum)
        //tally up result
        finalSum = finalSum + parsedNum
        console.log(parsedNum)
        console.log(finalSum)
    }
    //write out final answer
    console.log(finalSum)
    
    
  }
}

let app = new Main();
app.start();
