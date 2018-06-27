import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';
import { CiudadService } from '../../shared/ciudad.service';
import { Ciudad } from '../../shared/ciudad.model';
import { Location } from '@angular/common';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-eliminar-ciudad',
  templateUrl: './eliminar-ciudad.component.html',
  styleUrls: ['./eliminar-ciudad.component.css'],
  providers:[Ciudad,CiudadService]
})
export class EliminarCiudadComponent implements OnInit {

  /*ciudades: any = [
    {id:"1",nombre: 'Moscú',habitantes: 50, descripcion: 'hola', nomIngles:"Moscow",descIngles:"hello"},
    {id:"2",nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como', nomIngles:"Saint Petersburg",descIngles:"how"},
    {id:"3",nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas', nomIngles:"Kaliningrad",descIngles:"are you"},
    {id:"4",nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien', nomIngles:"Nizhny Novgorod",descIngles:"good"},
    {id:"5",nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere', nomIngles:"Volgograd",descIngles:"thanks"}
]  */
  
  ciudades :Array<Ciudad>;
  ciudadselected: Ciudad;
  id :number;
  //ciudades: any;

  constructor(private _location: Location, private route:Router, private ciudadservice: CiudadService){

  }
 // constructor(private router: Router){}

  ngOnInit() {
      this.ciudadservice.ObtenerListaCiudades().subscribe(
        result => {
            this.ciudades = result;
            this.route.navigate(['ciudades/eliminarCiudad']);
            console.log(this.ciudades)
        },
        error =>{
          console.log(<any>error)
       }
      )
  }


  eliminarElemento(): void{

    
   // $('select[id=Ciudad]').text('').remove();
  // console.log(this.ciudadselected);
   console.log(this.id+"aqui");
    this.ciudadservice.EliminarCiudad(this.id).subscribe(
      result =>{
          console.log(result);
          this.route.navigate(['ciudades/eliminarCiudad']);
      },
      error => {
          console.log(error)
      }
    )
  }

  selectChange($event){
    console.log($event)
    this.id =$event
  }

  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
