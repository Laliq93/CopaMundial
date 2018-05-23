import { Component, NgZone } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
/* tslint:disable */


enum MODULES {
	CIUDADES = "CIUDADES",
	ESTADIOS = "ESTADIOS",
	EQUIPOS = "EQUIPOS",
	JUGADORES = "JUGADORES",
	PARTIDOS = "PARTIDOS",
	APUESTAS = "APUESTAS",
	ESTADISTICAS = "ESTADISTICAS",
}

class Module {
	name: MODULES;
	routeName: string;
	isActive: boolean;

	constructor(name, routeName, isActive) {
		this.name = name;
		this.routeName = routeName;
		this.isActive = isActive;
	}
}

type Menu = "menu" | "menu-2";

declare var $: any;

@Component({
	selector: 'home',
	templateUrl: './home.component.html',
	styleUrls: [/*'./menu.component.css', */'./home.component.css']
})

export class HomeComponent {

	private moduleArray: Array<Module>;
	private moduleMap: Map<MODULES, Module> = new Map<MODULES, Module>();
	private loadPanel: boolean;
	private menu: Menu;
	public esHome: boolean;

	constructor(private router: Router, private _zone: NgZone) {

		this.moduleArray = [
			new Module(MODULES.CIUDADES, "city", false),
			new Module(MODULES.ESTADIOS, "stadium", false),
			new Module(MODULES.EQUIPOS, "team", false),
			new Module(MODULES.JUGADORES, "player", false),
			new Module(MODULES.PARTIDOS, "match", false),
			new Module(MODULES.APUESTAS, "bet", false),
			new Module(MODULES.ESTADISTICAS, "statistic", false)
		];

		this.initialiseModules();
		this.menu = "menu";

	}
	ngOnInit(): void {
		//Called after the constructor, initializing input properties, and the first call to ngOnChanges.
		//Add 'implements OnInit' to the class.
		if (window.location.href == window.location.origin + "/home")
			this.esHome = false;
		else
			this.esHome = true;
	}

	initialiseModules(): void {
		for (var i = 0; i < this.moduleArray.length; i++) {
			this.moduleMap.set(this.moduleArray[i].name, this.moduleArray[i]);
		}

	}

	setModuleActive(module: MODULES) {
		this.moduleMap.forEach(function (module) {
			module.isActive = false;
		})

		this.moduleMap.get(module).isActive = true;
		this.esHome = true;

	}

	setHome() {
		this.esHome = true;
	}

	toggleUserPanel(): void {
		this.loadPanel = !this.loadPanel;
		if (this.loadPanel) {
			this.menu = "menu";
		} else {
			this.menu = "menu";
		}
	}

}
