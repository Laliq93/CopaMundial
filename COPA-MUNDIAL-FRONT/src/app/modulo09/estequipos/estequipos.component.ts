import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-estequipos',
  templateUrl: './estequipos.component.html',
  styleUrls: ['./estequipos.component.css']
})
export class EstequiposComponent implements OnInit {

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
    

  constructor() { }

  ngOnInit() {
  }

}
