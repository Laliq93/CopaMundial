import { Component, Input, trigger, state, animate, transition, style, AfterViewInit, ElementRef } from '@angular/core';
import { Chart }  from 'chart.js';

@Component({
  selector: 'achievement-graph',
  templateUrl: './achievement-graph.component.html',
  styleUrls: [ './achievement-graph.component.css' ]
})

export class AchievementGraphComponent implements AfterViewInit {
  @Input() graphId: string; 
  @Input() data: any; 

  public chart: Chart;

  private canvasElement: HTMLCanvasElement;
  private testElement: HTMLCanvasElement;

  constructor(public elementRef: ElementRef) { }

  ngAfterViewInit() {
    this.setCanvasDimensions();
    this.initializeGraph();
  }

  private setCanvasDimensions() {
        this.canvasElement = <HTMLCanvasElement> document.getElementById(this.graphId);
  }

  private initializeGraph() {
    let options = {
     type: 'bar',
        data: this.data,
        options: {
          layout: {
              padding: {
                  left: 0,
                  right: 0,
                  top: 0,
                  bottom: 0
              }
          },
          responsive: true,
          maintainAspectRatio: true,
          tooltips: {
            enabled: false
          },
          elements: {
            line: {
              tension: 0,
            }
          },
          legend: {
            display: false
          },
          animation: {
            duration: 1000,
          },
          scales: {
            yAxes: [{
              display: true,
              id: 'y-axis-0',
              gridLines: {
                display: true,
                drawBorder: false
              },
              ticks: {  
                display: false       
              }
            }],
            xAxes: [{
              display: true,
              id: 'x-axis-0',
              ticks: {
              },
              gridLines: {
                display: false,
                drawBorder: false,
                lineWidth: 0
              }
            }]
          }
      }
    }

    this.chart = new Chart(this.canvasElement, options);
  }
}