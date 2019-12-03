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
    let lastX = this.startingX;
    let lastY = this.startingY;
    for (let i = 0; i < pathArray.length; i += 1) {
      const direction = pathArray[i].charAt(0);
      let steps = parseInt(pathArray[i].substr(1), 10);
      while (steps > 0) {
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
        pointsArray.push({ x: lastX, y: lastY });
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
          this.interestPoints.push(this.firstWirePoints[i]);
        }
      }
    }
    let minX = 0;
    let minY = 0;
    let minDistance = 99999999999;
    // loop through intersects, and find the closest intersect to point of interest
    for (let i = 0; i < this.interestPoints.length; i += 1) {
      const calcDistance = Math.abs(this.interestPoints[i].x - this.startingX)
        + Math.abs(this.interestPoints[i].y - this.startingY);
      if (calcDistance < minDistance) {
        minX = this.interestPoints[i].x;
        minY = this.interestPoints[i].y;
        minDistance = calcDistance;
      }
    }
    // write answer
    console.log(minX);
    console.log(minY);
    console.log(minDistance);
  }
}

const app = new Main();
app.start();
