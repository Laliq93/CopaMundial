import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-modificar-ciudad',
  templateUrl: './modificar-ciudad.component.html',
  styleUrls: ['./modificar-ciudad.component.css']
})
export class ModificarCiudadComponent implements OnInit {

  
  ciudades: any = [
    {id:"1",nombre: 'Moscú',habitantes: 50, descripcion: 'hola', nomIngles:"Moscow",descIngles:"hello"},
    {id:"2",nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como', nomIngles:"Saint Petersburg",descIngles:"how"},
    {id:"3",nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas', nomIngles:"Kaliningrad",descIngles:"are you"},
    {id:"4",nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien', nomIngles:"Nizhny Novgorod",descIngles:"good"},
    {id:"5",nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere', nomIngles:"Volgograd",descIngles:"thanks"}
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
