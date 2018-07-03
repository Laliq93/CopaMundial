import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';
import { Ciudad } from '../../shared/ciudad.model';
import { CiudadService } from '../../shared/ciudad.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-modificar-ciudad',
  templateUrl: './modificar-ciudad.component.html',
  styleUrls: ['./modificar-ciudad.component.css'],
  providers:[Ciudad,CiudadService]
})
export class ModificarCiudadComponent implements OnInit {

  ciudades :Ciudad[] = new Array<Ciudad>()
  ciudadselected: Ciudad = new Ciudad;
  id :number;
  nombre : string;
  descripcion:string;
  habitantes:number;
  habilit =-1;
  inputHabilitado:Boolean;
  
  ciudadess: any = [
    {id:"1",nombre: 'Moscú',habitantes: 50, descripcion: 'hola', nomIngles:"Moscow",descIngles:"hello"},
    {id:"2",nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como', nomIngles:"Saint Petersburg",descIngles:"how"},
    {id:"3",nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas', nomIngles:"Kaliningrad",descIngles:"are you"},
    {id:"4",nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien', nomIngles:"Nizhny Novgorod",descIngles:"good"},
    {id:"5",nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere', nomIngles:"Volgograd",descIngles:"thanks"}
]


habilitados: any = [
  "Habilitado","Deshabilitado"

]  
  
  constructor( private _location: Location, private route:Router, private ciudadservice: CiudadService){
    this.habilit = -1;
  }

  ngOnInit() {

    this.ciudadservice.ObtenerListaCiudades().subscribe(
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
            ciudad.Habilitado = element.Habilitado;
            this.ciudades.push(ciudad);
          });
          this.route.navigate(['ciudades/modificarCiudad']);
          console.log(this.ciudades)
      },
      error =>{
        console.log(<any>error)
     }
    )
    console.log("habilitado "+ this.habilit)
  }

  selectChange($event){
    console.log($event)
    this.id =$event
    this.ciudadselected = this.ciudades[this.id];
    console.log("ciudad elegida "+this.ciudades[this.id])
    console.log("city = "+this.ciudadselected+this.id)
    if (this.ciudadselected.Habilitado == true) {
      this.habilit =0
      
    }else{
      this.habilit=1
    }
    console.log("habilitado "+ this.habilit)
  }


  selectChangeHabilitado($event){
    console.log("habilitado "+ this.habilit)
    this.habilit = $event
  }


  modificar(){
    let city = new Ciudad;
    city.Id = this.ciudadselected.Id;
    console.log("habilitado "+ this.habilit)
    if (this.nombre == null || typeof this.nombre == "undefined") {
      city.Nombre = this.ciudadselected.Nombre;
    }
    else{
      city.Nombre = this.nombre;
    }
   
    if (this.descripcion == null || typeof this.descripcion == "undefined") {
      city.Descripcion = this.ciudadselected.Descripcion;
    }
    else{
        city.Descripcion = this.descripcion;
      }
    
    if (this.habitantes == null || typeof this.habitantes == "undefined") {
        city.Habitantes = this.ciudadselected.Habitantes;
    }
      else{
        city.Habitantes = this.habitantes;
      }
   if (this.habilit == 0) {
     city.Habilitado = true;
    }
    if (this.habilit ==1){
      city.Habilitado = false;
    }
    city.NombreIngles = "";
    city.DescripcionIngles = "";

    console.log(city);
    if(city.Nombre!=""){
    this.ciudadservice.ActualizarCiudad(city).subscribe(
      result => {
        console.log(result)
      },
      error =>{
        console.log(error)
      }
    )
    alert("Sus datos fueron procesados satisfactoriamente")
  }
  else{
    $("#idnombre").append("<span style='color: red'>Campo obligatorio</span>")
    }
  }

  

  mostrarInformacion(): void{
    if (this.ciudadselected.Habilitado == true) {
      this.habilit =0
      
    }else{
      this.habilit=1
    }
    console.log("habilitado "+ this.habilit)
    this.route.navigate(['ciudades/modificarCiudad']);
    
  /*  $('#Nombre').text('').append(this.ciudades[this.id].Nombre);
    $('#Habitantes').text('').append(this.ciudades[this.id].Habitantes.toString);
    $('#Descripcion').text('').append(this.ciudades[this.id].Descripcion);

    // =this.ciudades[this.id].Nombre.toString;
    /*this.ciudadess.forEach(function(value) { 
        if (value.nombre == $('select[id=Ciudad]').val()) { 
          $('#nombre').text('').append(value.nombre);
          $('#habitantes').text('').append(value.habitantes);
          $('#descripcion').text('').append(value.descripcion);
        } 
      }
    ); */
    
   
   
  
  
    
  }


  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }


}
