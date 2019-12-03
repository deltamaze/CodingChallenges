/* eslint-disable no-console */
const fs = require('fs');


class Main {
  constructor() {
    this.startingX = 0;
    this.startingY = 0;
    this.firstWirePoints = [];
    this.secondWirePoints = [];
    this.interestPoints = [];
  }

  calculatePoints(pathArray, pointsArray) {
    let stepCounter = 0;
    let lastX = this.startingX;
    let lastY = this.startingY;
    for (let i = 0; i < pathArray.length; i += 1) {
      const direction = pathArray[i].charAt(0);
      let steps = parseInt(pathArray[i].substr(1), 10);
      while (steps > 0) {
        stepCounter += 1;
        switch (direction) {
        case 'R':
          lastX += 1;
          break;
        case 'L':
          lastX -= 1;
          break;
        case 'U':
          lastY += 1;
          break;
        case 'D':
          lastY -= 1;
          break;
        default:
          break;
        }
        pointsArray.push({ x: lastX, y: lastY, steps: stepCounter });
        steps -= 1;
      }
    }
  }


  start() {
    const lines = fs.readFileSync('./Day3/input.txt').toString().split('\r\n');
    const firstWirePath = lines[0].split(',');
    const secondWirePath = lines[1].split(',');
    this.calculatePoints(firstWirePath, this.firstWirePoints);
    this.calculatePoints(secondWirePath, this.secondWirePoints);
    // look for intersects in new array
    for (let i = 0; i < this.firstWirePoints.length; i += 1) {
      for (let j = 0; j < this.secondWirePoints.length; j += 1) {
        if (this.firstWirePoints[i].x === this.secondWirePoints[j].x
          && this.firstWirePoints[i].y === this.secondWirePoints[j].y) {
          this.interestPoints.push({
            x: this.firstWirePoints[i].x,
            y: this.firstWirePoints[i].y,
            firstWireSteps: this.firstWirePoints[i].steps,
            secondWireSteps: this.secondWirePoints[j].steps
          });
        }
      }
    }
    let firstWireSteps = 99999999999;
    let secondWireSteps = 99999999999;
    let minSteps = 99999999999;
    // loop through intersects, and find the min total steps to reach that intersection
    for (let i = 0; i < this.interestPoints.length; i += 1) {
      const calcTotalSteps = this.interestPoints[i].firstWireSteps
        + this.interestPoints[i].secondWireSteps;
      if (calcTotalSteps < minSteps) {
        firstWireSteps = this.interestPoints[i].firstWireSteps;
        secondWireSteps = this.interestPoints[i].secondWireSteps;
        minSteps = calcTotalSteps;
      }
    }
    // write answer
    console.log(firstWireSteps);
    console.log(secondWireSteps);
    console.log(minSteps);
  }
}

const app = new Main();
app.start();
