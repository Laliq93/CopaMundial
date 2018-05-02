import { Component, OnInit } from '@angular/core';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-knockout-phase',
  templateUrl: './knockout-phase.component.html',
  styleUrls: ['./knockout-phase.component.css']
})
export class KnockoutPhaseComponent implements OnInit {

  constructor(private router: Router) 
  { }

  ngOnInit() {
  }

  faseGrupos(): void {
		this.router.navigate(['home/match']);
  }	
  
  details(): void {
		this.router.navigate(['home/match/Detalle/1']);
  }	

  public listmatches: Array<any>= [
    {
      "fase": "Octavos de final",
      "info": [ {
                  "fecha":"14 jun. 2018",
                  "estadio":"Ekaterinburg Arena",
                  "ciudad": "EKATERINBURG",
                  "equipo1": "",
                  "posicion1": "1C",
                  "bandera1": "",
                  "hora": "08:00",
                  "equipo2": "",
                  "posicion2": "2D",
                  "bandera2": "",
                  "puntaje": ""
                },
                {
                  "fecha":"14 jun. 2018",
                  "estadio":"estadio de San Petersburgo",
                  "ciudad": "ST. PETERSBURG",
                  "equipo1": "",
                  "posicion1": "1A",
                  "bandera1": "",
                  "hora": "11:00",
                  "equipo2": "",
                  "posicion2": "2B",
                  "bandera2": "",
                  "puntaje": ""
                },
                {
                  "fecha":"14 jun. 2018",
                  "estadio":"Fisht Stadium",
                  "ciudad": "SOCHI",
                  "equipo1": "",
                  "posicion1": "1B",
                  "bandera1": "",
                  "hora": "14:00",
                  "equipo2": "",
                  "posicion2": "2A",
                  "bandera2": "",
                  "puntaje": ""
                },
                {
                  "fecha":"14 jun. 2018",
                  "estadio":"Fisht Stadium",
                  "ciudad": "SOCHI",
                  "equipo1": "",
                  "posicion1": "1D",
                  "bandera1": "",
                  "hora": "14:00",
                  "equipo2": "",
                  "posicion2": "2C",
                  "bandera2": "",
                  "puntaje": ""
                },
                {
                  "fecha":"14 jun. 2018",
                  "estadio":"Fisht Stadium",
                  "ciudad": "SOCHI",
                  "equipo1": "",
                  "posicion1": "1E",
                  "bandera1": "",
                  "hora": "14:00",
                  "equipo2": "",
                  "posicion2": "2F",
                  "bandera2": "",
                  "puntaje": ""
                },
                {
                  "fecha":"14 jun. 2018",
                  "estadio":"Fisht Stadium",
                  "ciudad": "SOCHI",
                  "equipo1": "",
                  "posicion1": "1G",
                  "bandera1": "",
                  "hora": "14:00",
                  "equipo2": "",
                  "posicion2": "2H",
                  "bandera2": "",
                  "puntaje": ""
                },
                {
                  "fecha":"14 jun. 2018",
                  "estadio":"Fisht Stadium",
                  "ciudad": "SOCHI",
                  "equipo1": "",
                  "posicion1": "1F",
                  "bandera1": "",
                  "hora": "14:00",
                  "equipo2": "",
                  "posicion2": "2E",
                  "bandera2": "",
                  "puntaje": ""
                },
                {
                  "fecha":"14 jun. 2018",
                  "estadio":"Fisht Stadium",
                  "ciudad": "SOCHI",
                  "equipo1": "",
                  "posicion1": "1H",
                  "bandera1": "",
                  "hora": "14:00",
                  "equipo2": "",
                  "posicion2": "2G",
                  "bandera2": "",
                  "puntaje": ""
                }
              ]
  },
  {
    "fase": "Cuartos de final",
    "info": [ {
                "fecha":"16 jun. 2018",
                "estadio":"Kazan Arena",
                "ciudad": "KAZAN",
                "equipo1": "",
                "posicion1": "W49",
                "bandera1": "",
                "hora": "06:00",
                "equipo2": "",
                "posicion2": "W50",
                "bandera2": "",
                "puntaje": ""
              },
              {
                "fecha":"16 jun. 2018",
                "grupo":"Grupo D",
                "estadio":"Spartak Stadium",
                "ciudad": "MOSCOW",
                "equipo1": "",
                "posicion1": "W53",
                "bandera1": "",
                "hora": "09:00",
                "equipo2": "",
                "posicion2": "w54",
                "bandera2": "",
                "puntaje": ""
              },
              {
                "fecha":"14 jun. 2018",
                "estadio":"Fisht Stadium",
                "ciudad": "SOCHI",
                "equipo1": "",
                "posicion1": "W55",
                "bandera1": "",
                "hora": "14:00",
                "equipo2": "",
                "posicion2": "W56",
                "bandera2": "",
                "puntaje": ""
              },
              {
                "fecha":"14 jun. 2018",
                "estadio":"Fisht Stadium",
                "ciudad": "SOCHI",
                "equipo1": "",
                "posicion1": "W51",
                "bandera1": "",
                "hora": "14:00",
                "equipo2": "",
                "posicion2": "W52",
                "bandera2": "",
                "puntaje": ""
              }
              
            ]
},
{
  "fase": "Semifinales",
  "info": [ {
              "fecha":"16 jun. 2018",
              "estadio":"Kazan Arena",
              "ciudad": "KAZAN",
              "equipo1": "",
              "posicion1": "W57",
              "bandera1": "",
              "hora": "06:00",
              "equipo2": "",
              "posicion2": "W58",
              "bandera2": "",
              "puntaje": ""
            },
            {
              "fecha":"16 jun. 2018",
              "grupo":"Grupo D",
              "estadio":"Spartak Stadium",
              "ciudad": "MOSCOW",
              "equipo1": "",
              "posicion1": "W59",
              "bandera1": "",
              "hora": "09:00",
              "equipo2": "",
              "posicion2": "w60",
              "bandera2": "",
              "puntaje": ""
            }
            
          ]
},
{
  "fase": "Partido por el tercer puesto",
  "info": [ {
              "fecha":"16 jun. 2018",
              "estadio":"Kazan Arena",
              "ciudad": "KAZAN",
              "equipo1": "",
              "posicion1": "L61",
              "bandera1": "",
              "hora": "06:00",
              "equipo2": "",
              "posicion2": "L62",
              "bandera2": "",
              "puntaje": ""
            }            
          ]
},
{
  "fase": "Final",
  "info": [ {
              "fecha":"16 jun. 2018",
              "estadio":"Kazan Arena",
              "ciudad": "KAZAN",
              "equipo1": "",
              "posicion1": "W61",
              "bandera1": "",
              "hora": "06:00",
              "equipo2": "",
              "posicion2": "W62",
              "bandera2": "",
              "puntaje": ""
            }            
          ]
}

]
}
