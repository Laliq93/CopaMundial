import { Component, Input, trigger, state, animate, transition, style, AfterViewInit, ElementRef } from '@angular/core';
import { Chart }  from 'chart.js';

@Component({
  selector: 'percentage-graph',
  templateUrl: './percentage-graph.component.html',
  styleUrls: [ './percentage-graph.component.css' ]
})

export class PercentageGraphComponent implements AfterViewInit {
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
     type: 'pie',
        data: this.data,
        options: {
          cutoutPercentage: 50,
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
              display: false,
              id: 'y-axis-0',
              gridLines: {
                display: false,
                drawBorder: false
              },
              ticks: {  
                display: false       
              }
            }],
            xAxes: [{
              display: false,
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