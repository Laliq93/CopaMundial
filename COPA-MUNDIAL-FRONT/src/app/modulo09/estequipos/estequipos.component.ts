import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { estadisticasEquipo } from '../estadisticasequipo';

@Component({
  selector: 'app-estequipos',
  templateUrl: './estequipos.component.html',
  styleUrls: ['./estequipos.component.css']
})
export class EstequiposComponent implements OnInit {

  url : string;
  esta : estadisticasEquipo;
  equipo:number;
  variable : number;
  paises: any = [
    "Rusia","Brasil","Argentina","Uruguay",
    "Perú","Colombia","Panamá","Costa Rica",
    "México","Alemania","Bélgica","Croacia",
    "España","Francia","Inglaterra","Portugal",
    "Serbia","Dinamarca","Islandia","Suiza",
    "Suecia","Polonia","Arabia Saudí","República de Corea",
    "Irán","Japón","Australia","Túnez",
    "Egipto","Marruecos","Senegal","Nigeria"
    ].sort();

    datos:any = [
      {pais: 'México', goles: 50, asistencias:5,tamarillas:5,trojas:4,mjugados:4,calificacion:5},
      {pais: 'Polonia', goles: 50, asistencias:5,tamarillas:5,trojas:4,mjugados:4,calificacion:5},
      {pais: 'Iran', goles: 50, asistencias:5,tamarillas:5,trojas:4,mjugados:4,calificacion:5}
    ];   
    

  constructor(private route:Router, private http : HttpClient) {

    this.url = "http://localhost:54059/api/M09_estadisticas"
    this.equipo = 1;
   }

  ngOnInit() {
  }


  getEstadisticas(){
    console.log(this.url);
    if (this.variable != 0) {
      this.equipo = this.variable;
    }
   this.http.get<estadisticasEquipo>(this.url+'/equipo/'+this.equipo).subscribe(
     x => {
       this.esta = x;
       console.log(this.esta);
     }
   )
   this.route.navigate(['estadisticas/estequipos']);
  }

}
