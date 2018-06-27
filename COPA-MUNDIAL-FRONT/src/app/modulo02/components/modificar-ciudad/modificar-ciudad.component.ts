import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';
import { Ciudad } from '../../shared/ciudad.model';
import { CiudadService } from '../../shared/ciudad.service';

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
  
  ciudadess: any = [
    {id:"1",nombre: 'Moscú',habitantes: 50, descripcion: 'hola', nomIngles:"Moscow",descIngles:"hello"},
    {id:"2",nombre: 'San Petersburgo', habitantes: 1, descripcion: 'como', nomIngles:"Saint Petersburg",descIngles:"how"},
    {id:"3",nombre: 'Kaliningrado', habitantes: 5, descripcion: 'estas', nomIngles:"Kaliningrad",descIngles:"are you"},
    {id:"4",nombre: 'Nizhny Nóvgorod', habitantes: 2, descripcion: 'bien', nomIngles:"Nizhny Novgorod",descIngles:"good"},
    {id:"5",nombre: 'Volgogrado',habitantes: 1000, descripcion: 'chevere', nomIngles:"Volgograd",descIngles:"thanks"}
]  
  
  constructor(private route:Router, private ciudadservice: CiudadService){}

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
            this.ciudades.push(ciudad);
          });
          this.route.navigate(['ciudades/modificarCiudad']);
          console.log(this.ciudades)
      },
      error =>{
        console.log(<any>error)
     }
    )
  }

  selectChange($event){
    console.log($event)
    this.id =$event
    this.ciudadselected = this.ciudades[this.id];
    console.log("ciudad elegida "+this.ciudades[this.id])
    console.log("city = "+this.ciudadselected+this.id)
  }

  modificar(){
    let city = new Ciudad;
    city.Id = this.ciudadselected.Id;
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
   
    city.NombreIngles = "";
    city.DescripcionIngles = "";
    console.log(city);
    this.ciudadservice.ActualizarCiudad(city).subscribe(
      result => {
        console.log(result)
      },
      error =>{
        console.log(error)
      }
    )
  }

  

  mostrarInformacion(): void{
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



  //volver(): void {
	//	this.router.navigate(['admin/city']);
  //}


}
