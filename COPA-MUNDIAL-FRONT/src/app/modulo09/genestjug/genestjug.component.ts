import { Component, OnInit } from '@angular/core';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-genestjug',
  templateUrl: './genestjug.component.html',
  styleUrls: ['./genestjug.component.css']
})
export class GenestjugComponent implements OnInit {

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
    

    jugadores:any = [
      {pais: 'España',nombre: 50},
      {pais: 'Serbia', nombre: 1},
      {pais: 'Japón', nombre: 5},
      {pais: 'Alemania', nombre: 2},
      {pais: 'Rusia',nombre: 1000}
    ];   
    
     datos:any = [{nombre:'Cristiano Ronaldo',pais:'Portugal'},{nombre:'AAAA',pais:'Portugal'},{nombre:'EEE',pais:'España'}];

  constructor() { }

  ngOnInit() {
  }

  ngAfterViewInit(){
    var me=this;
    this.valor = $('#Pais').val();
    
    $('#Pais').change(function(){
      
      me.valor = $('#Pais').val();
      var Tabla = "";
      Tabla += "<table class='table'>";
      var cant = 1;
      for (var i=0; i<me.datos.length;i++) {
        if(me.valor==me.datos[i].pais){
        Tabla += '<tr>';
        Tabla += '<td>';
        Tabla += cant;
        cant +=1;
        Tabla += '</td>';
        Tabla += '<td>';
        Tabla += me.datos[i].nombre;
        Tabla += '</td>';
        Tabla += '<td>';
        var parametro=me.datos[i].nombre.split(" ").join("_");
        Tabla += '<a href="estadisticas/estjugador?nombre='+parametro+'"  class="btn btn-primary" >Ver estadistica</a>';
        Tabla += '</td>';
        Tabla += '</tr>';
      }}
      Tabla += '</table>';
      document.getElementById("Tabla").innerHTML = Tabla;
     
    });

    
  }

}


