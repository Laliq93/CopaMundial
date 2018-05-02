import { Component, OnInit, AfterViewInit, ChangeDetectorRef} from '@angular/core';
import { trigger, state, style, transition, animate} from '@angular/animations';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Chart }  from 'chart.js';
import { Angular2Txt } from 'angular2-txt/Angular2-txt';

@Component({
  selector: 'achievement-admin',
  templateUrl: './achievement-admin.component.html',
  styleUrls: ['./achievement-admin.component.css'],
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translate3d(-100%, 0, 0)'
      })),
      state('out', style({
        transform: 'translate3d(0, 0, 0)'
      })),
      transition('in => out', animate('400ms'))
    ]),
    trigger('slideUpDown', [
      state('up', style({
        transform: 'translate3d(-100%, 0, 0)'
      })),
      state('down', style({
        transform: 'translate3d(0, 0, 0)'
      })),
      transition('up => down', animate('400ms'))
    ])
  ]
})
export class AchievementAdminComponent implements OnInit, AfterViewInit{
 	menuState: string;
 	val: number; 
 	activeGraphData: Array<number> = [20,50,70,100];
 	inactiveGraphData: Array<number> = [20,50,70,100];
	displayActiveAchievement: boolean = false; 
	isUpDown: string = "up";


	gestionarLogrosActive: boolean = false; 
	dashboardActive: boolean = true; 
	gestionarDatosActive: boolean = false; 

  	public activeData:any = {
        labels: ["D","L", "M", "M", "J", "V", "S"],
        datasets: [{
            label: '# of Votes',
            data: [1, 12, 15, 3, 5, 2, 3],
            backgroundColor: [
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(109, 197, 255, 1)'
            ],
            borderColor: [
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(109, 197, 255, 1)'
            ],
            borderWidth: 1
        }]
    };

  	public inactiveData:any = {
        labels: ["D","L", "M", "M", "J", "V", "S"],
        datasets: [{
            label: '# of Votes',
            data: [12, 3, 1, 2, 5, 2, 16],
            backgroundColor: [
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(237, 104, 74, 1)'
            ],
            borderColor: [
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(208, 208, 208, 1)',
                'rgba(237, 104, 74, 1)'
            ],
            borderWidth: 1
        }]
    };  	

    public activePieData:any = {
        datasets: [{
            label: '# of Votes',
            data: [1, 1, 2],
            backgroundColor: [
                'rgba(132, 185, 239, 1)',
                'rgba(251, 228, 201, 1)',
                'rgba(255, 93, 93, 1)'
            ],
            borderColor: [
                'rgba(132, 185, 239, 1)',
                'rgba(251, 228, 201, 1)',
                'rgba(255, 93, 93, 1)'
            ],
            borderWidth: 1
        }]
    };
    
    public inactivePieData:any = {
        datasets: [{
            label: '# of Votes',
            data: [1, 9, 6],
            backgroundColor: [
                'rgba(132, 185, 239, 1)',
                'rgba(251, 228, 201, 1)',
                'rgba(255, 93, 93, 1)'
            ],
            borderColor: [
                'rgba(132, 185, 239, 1)',
                'rgba(251, 228, 201, 1)',
                'rgba(255, 93, 93, 1)'
            ],
            borderWidth: 1
        }]
    };

 	constructor(private cdr: ChangeDetectorRef) {
 		this.menuState = 'in';
 		this.val = 0;
 	}

 	ngOnInit() {}

	ngAfterViewInit() {
		this.menuState = 'out';
		this.val += 1; // <- get error after
  		this.cdr.detectChanges();
	}

	toggleActiveAchievements(){
		this.displayActiveAchievement = !this.displayActiveAchievement;
		if (this.isUpDown == "up") {
			this.isUpDown = "down";
		} else {
			this.isUpDown = "up";
		}
	}

	toggleInactiveAchievements(){
		this.displayActiveAchievement = !this.displayActiveAchievement
		if (this.isUpDown == "up") {
			this.isUpDown = "down";
		} else {
			this.isUpDown = "up";
		}
	}

	setDashboardActive() {
		this.gestionarDatosActive = false;
		this.dashboardActive = true;
		this.gestionarLogrosActive = false;
	}	

	setManagementActive() {
		this.gestionarDatosActive = false;
		this.dashboardActive = false;
		this.gestionarLogrosActive = true;
	}

	setDataActive() {
		this.gestionarDatosActive = true;
		this.dashboardActive = false;
		this.gestionarLogrosActive = false;
	}

	showMatchDetail() {

	}

	downloaFormat() {
		var data = [
		  {
		    name: "Test 1",
		    age: 13,
		    average: 8.2,
		    approved: true,
		    description: "using 'Content here, content here' "
		  },
		  {
		    name: 'Test 2',
		    age: 11,
		    average: 8.2,
		    approved: true,
		    description: "using 'Content here, content here' "
		  },
		  {
		    name: 'Test 4',
		    age: 10,
		    average: 8.2,
		    approved: true,
		    description: "using 'Content here, content here' "
		  },
		];

		  var options = { 
		    fieldSeparator: ',',
		    quoteStrings: '"',
		    decimalseparator: '.',
		    showTitle: true,
		    showLabels: true,
		    useBom: true
		  };
		 
		new Angular2Txt(data, "formato_de_subida", options);
	}
}
