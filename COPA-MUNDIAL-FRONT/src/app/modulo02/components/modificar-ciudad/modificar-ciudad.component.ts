import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-modificar-ciudad',
  templateUrl: './modificar-ciudad.component.html',
  styleUrls: ['./modificar-ciudad.component.css']
})
export class ModificarCiudadComponent implements OnInit {

  
  ciudades: any = [
    {nombre: 'Moscú',habitantes: 50, descripcion: 'hola'},
      {nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como'},
      {nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas'},
      {nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien'},
      {nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere'}
  ]  
  
  //constructor(private router: Router){}

  ngOnInit() {
  }

  mostrarInformacion(): void{

    this.ciudades.forEach(function(value) { 
        if (value.nombre == $('select[id=Ciudad]').val()) { 
          $('#nombre').text('').append(value.nombre);
          $('#habitantes').text('').append(value.habitantes);
          $('#descripcion').text('').append(value.descripcion);
        } 
      }
    ); 
   
   
  
  
    
  }



  //volver(): void {
	//	this.router.navigate(['admin/city']);
  //}


}
