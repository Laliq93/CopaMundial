import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';
import { Ciudad } from '../../shared/ciudad.model';
import { CiudadService } from '../../shared/ciudad.service';
import { Location } from '@angular/common';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-consultar-ciudad',
  templateUrl: './consultar-ciudad.component.html',
  styleUrls: ['./consultar-ciudad.component.css'],
  providers:[Ciudad,CiudadService]
})
export class ConsultarCiudadComponent implements OnInit {


  /*ciudades: any = [
      {id:"1",nombre: 'Moscú',habitantes: 50, descripcion: 'hola', nomIngles:"Moscow",descIngles:"hello"},
      {id:"2",nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como', nomIngles:"Saint Petersburg",descIngles:"how"},
      {id:"3",nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas', nomIngles:"Kaliningrad",descIngles:"are you"},
      {id:"4",nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien', nomIngles:"Nizhny Novgorod",descIngles:"good"},
      {id:"5",nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere', nomIngles:"Volgograd",descIngles:"thanks"}
  ]  
*/
ciudades :Ciudad[] = new Array<Ciudad>()
  ciudadselected: Ciudad = new Ciudad;
  id :number;


  constructor(private _location: Location,private route:Router, private ciudadservice: CiudadService){}
 // constructor(private router: Router){}

  ngOnInit() {
  $('#infoCiudad').hide();
  this.ciudadservice.ObtenerListaCiudadesHabilitadas().subscribe(
    ciudades => {
      //this.ciudades = ciudades.map(<Ciudad[]>);
      ciudades.forEach(element => {
        console.log(element)
        let ciudad = new Ciudad;
        ciudad.Id = element.Id;
        ciudad.Nombre = element.Nombre;
        ciudad.Descripcion = element.Descripcion;
        ciudad.Habitantes = element.Habitantes;
        ciudad.NombreIngles = element.NombreIngles;
        ciudad.DescripcionIngles = element.DescripcionIngles;
        this.ciudades.push(ciudad);
      });
      this.route.navigate(['ciudades/consultarCiudad']);
      console.log(this.ciudades)
  },
    error =>{
      console.log(<any>error)
   }
  )
  }


mostrarInformacion(): void{

  /*this.ciudades.forEach(function(value) { 
    	if (value.nombre == $('select[id=Ciudad]').val()) { 
        $('p[id=nombre]').text('').append(value.nombre);
        $('p[id=habitantes]').text('').append(value.habitantes);
        $('p[id=descripcion]').text('').append(value.descripcion);
      } 
    }
  ); 
  $('h2[id=nombreCiudad]').text('').append($('select[id=Ciudad]').val());
 
  
*/
  $('#infoCiudad').show();
  
}

selectChange($event){
  console.log($event)
  this.id =$event
  this.ciudadselected = this.ciudades[this.id];
}
 
regresar() {
  this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
}

}
