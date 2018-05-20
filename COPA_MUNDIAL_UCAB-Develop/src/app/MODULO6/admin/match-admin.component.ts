import { Component } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'match-admin',
  templateUrl: './match-admin.component.html',
  styleUrls: ['./match-admin.component.css']
})
export class MatchAdminComponent {

  constructor(private router: Router){}


    matchCreate(): void {
  		this.router.navigate(['admin/match/create']);
    }

    matchUpdate(): void {
  		this.router.navigate(['admin/match/update']);
    }

  public listmatches: Array<any>= [
      {
        "dia": "Jueves 14 Junio",
        "info": [ {
                    "fecha":"14 jun. 2018",
                    "grupo":"Grupo A",
                    "estadio":"Ekaterinburg Arena",
                    "ciudad": "EKATERINBURG",
                    "equipo1": "Egipto",
                    "bandera1": "../../../assets/banderas/egy.png",
                    "hora": "08:00",
                    "equipo2": "Uruguay",
                    "bandera2": "../../../assets/banderas/uru.png",
                    "puntaje": "1 - 0 "
                  },
                  {
                    "fecha":"14 jun. 2018",
                    "grupo":"Grupo B",
                    "estadio":"estadio de San Petersburgo",
                    "ciudad": "ST. PETERSBURG",
                    "equipo1": "Marruecos",
                    "bandera1": "../../../assets/banderas/mar.png",
                    "hora": "11:00",
                    "equipo2": "RI de Irán",
                    "bandera2": "../../../assets/banderas/irn.png",
                    "puntaje": "2 - 1 "
                  },
                  {
                    "fecha":"14 jun. 2018",
                    "grupo":"Grupo B",
                    "estadio":"Fisht Stadium",
                    "ciudad": "SOCHI",
                    "equipo1": "Portugal",
                    "bandera1": "../../../assets/banderas/por.png",
                    "hora": "14:00",
                    "equipo2": "España",
                    "bandera2": "../../../assets/banderas/esp.png",
                    "puntaje": ""
                  }
                ]
    },
    {
      "dia": "Sábado 16 junio",
      "info": [ {
                  "fecha":"16 jun. 2018",
                  "grupo":"Grupo C",
                  "estadio":"Kazan Arena",
                  "ciudad": "KAZAN",
                  "equipo1": "Francia",
                  "bandera1": "../../../assets/banderas/fra.png",
                  "hora": "06:00",
                  "equipo2": "Australia",
                  "bandera2": "../../../assets/banderas/aus.png",
                  "puntaje": ""
                },
                {
                  "fecha":"16 jun. 2018",
                  "grupo":"Grupo D",
                  "estadio":"Spartak Stadium",
                  "ciudad": "MOSCOW",
                  "equipo1": "Argentina",
                  "bandera1": "../../../assets/banderas/arg.png",
                  "hora": "09:00",
                  "equipo2": "Islandia",
                  "bandera2": "../../../assets/banderas/isl.png",
                  "puntaje": ""
                }

              ]
  }

  ]
}
