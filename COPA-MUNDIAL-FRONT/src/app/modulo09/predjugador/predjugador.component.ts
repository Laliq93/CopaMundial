import { Component, OnInit } from '@angular/core';
declare var jquery:any;
declare var $ :any;


@Component({
  selector: 'app-predjugador',
  templateUrl: './predjugador.component.html',
  styleUrls: ['./predjugador.component.css']
})
export class PredjugadorComponent implements OnInit {

valor: any = "Alemania";

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
    {prediccion: 'Probabilidad que anote gol', porcentaje: 50},
    {prediccion: 'Probabilidad que asista', porcentaje: 1},
    {prediccion: 'Probabilidad que sea amonestado', porcentaje: 2}
  ];   

  jugadores:any = [
    {pais: 'España',nombre: 50},
    {pais: 'Serbia', nombre: 1},
    {pais: 'Japón', nombre: 5},
    {pais: 'Alemania', nombre: 2},
    {pais: 'Rusia',nombre: 1000}
  ];   

  
  constructor() { }



  ngOnInit() {
    
    $('#picker').pickdate();
  }

  ngAfterViewInit(){
    var me=this;
    this.valor = $('#Pais').val();
    $('#Pais').change(function(){
      me.valor = $('#Pais').val();
      $('#Jugador').remove();
      var datos = Object.keys(me.jugadores).map((key) => me.jugadores[key]);
      datos.forEach(function(element){
        if (me.valor==element[0]){
          $('#Jugador').add(element[1]);
        }
      });
    
    });
    
  }

}
