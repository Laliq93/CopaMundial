import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-eliminar-ciudad',
  templateUrl: './eliminar-ciudad.component.html',
  styleUrls: ['./eliminar-ciudad.component.css']
})
export class EliminarCiudadComponent implements OnInit {

  ciudades: any = [
    {nombre: 'Moscú',habitantes: 50, descripcion: 'hola'},
      {nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como'},
      {nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas'},
      {nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien'},
      {nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere'}
  ]  

  
  constructor(){}
 // constructor(private router: Router){}

  ngOnInit() {
  }


  eliminarElemento(): void{

    
    $('select[id=Ciudad]').text('').remove();
    
  }

  //volver(): void {
		//this.router.navigate(['admin/city']);
  //}

}
