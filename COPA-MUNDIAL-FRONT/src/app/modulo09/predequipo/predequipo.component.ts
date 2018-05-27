import { Component, OnInit } from '@angular/core';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-predequipo',
  templateUrl: './predequipo.component.html',
  styleUrls: ['./predequipo.component.css']
})
export class PredequipoComponent implements OnInit {

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
      {prediccion: 'Probabilidad que gane el juego', porcentaje: 50},
      {prediccion: 'Probabilidad que empate el juego', porcentaje: 20},
      {prediccion: 'Probabilidad que meta un gol', porcentaje: 15},
      {prediccion: 'Probabilidad que no meta un gol', porcentaje: 3}
    ];   

  constructor() { }

  ngOnInit() {
    $('#picker').pickdate();
  }

}
