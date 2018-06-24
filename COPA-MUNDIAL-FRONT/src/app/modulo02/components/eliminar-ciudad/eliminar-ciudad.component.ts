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
    {id:"1",nombre: 'Moscú',habitantes: 50, descripcion: 'hola', nomIngles:"Moscow",descIngles:"hello"},
    {id:"2",nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como', nomIngles:"Saint Petersburg",descIngles:"how"},
    {id:"3",nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas', nomIngles:"Kaliningrad",descIngles:"are you"},
    {id:"4",nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien', nomIngles:"Nizhny Novgorod",descIngles:"good"},
    {id:"5",nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere', nomIngles:"Volgograd",descIngles:"thanks"}
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
