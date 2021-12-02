const fs = require('fs');


class Main {
  static start() {
    let x = 0;
    let aim = 0;
    let y = 0;
    const array = fs.readFileSync('./inputSample.txt').toString().split('\n');
    array.forEach(element => {
      var splitItem = element.toString().split(" ");
      if(splitItem[0]== "forward")
      {
        x += parseInt(splitItem[1]);
        y += (parseInt(splitItem[1]) * aim);
      }
      if(splitItem[0]== "up")
      {
        aim -= parseInt(splitItem[1]);
      }
      if(splitItem[0]== "down")
      {
        aim += parseInt(splitItem[1]);
      }
      console.log(x);
      console.log(y);
    });
    
    console.log(x * y);
  }
}


Main.start();
