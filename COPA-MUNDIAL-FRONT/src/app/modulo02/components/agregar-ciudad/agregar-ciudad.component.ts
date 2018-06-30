import { Component, OnInit } from '@angular/core';
import { NgForOfContext } from '@angular/common';
import { NgForm } from '@angular/forms';
import {CiudadService} from '../../shared/ciudad.service';
import { Ciudad } from '../../shared/ciudad.model';
import { Binary } from '@angular/compiler';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
declare var jquery:any;
declare var $ :any;


@Component({
  selector: 'app-agregar-ciudad',
  templateUrl: './agregar-ciudad.component.html',
  styleUrls: ['./agregar-ciudad.component.css'],
  providers:[Ciudad,CiudadService]
})
export class AgregarCiudadComponent implements OnInit {

  formulario = {
    nombreES : "",
    habitantes : 0,
    descripcion : "",
    nombreEN :"",
    descripcionEN : ""
  }
  imagen: Blob;
  ima : Blob;
  archivo: File;
  responsecity : Ciudad;
  url:String = "http://localhost:51543/api/ciudad/"
  

  constructor(  private _location: Location, private route:Router, private ciudadservice: CiudadService){}
  //constructor(private ciudadService : CiudadService) { }

  ngOnInit() {
    this.resetForm();
  }

  subirciudad(){
    let ciudad = new Ciudad();
    
    ciudad.Nombre = this.formulario.nombreES
    ciudad.Descripcion = this.formulario.descripcion
    ciudad.Habitantes = this.formulario.habitantes
    ciudad.DescripcionIngles = this.formulario.descripcionEN
    ciudad.NombreIngles = this.formulario.nombreEN
    
   if (ciudad.Habitantes>0){
     if (ciudad.Nombre!=""){
          if (ciudad.NombreIngles!=""){
            if (ciudad.Descripcion!=""){
              if (ciudad.DescripcionIngles!=""){
              this.ciudadservice.agregarciudad(ciudad).subscribe(
                result => {
                
                  console.log(result);
                
                },
                error =>{
                  console.log(<any>error)
                }   
              )
            }
            else{
              $("#iddescripcionEN").append("<span style='color: red'>Campo obligatorio</span>")
              }
          }
            else{
              $("#iddescripcion").append("<span style='color: red'>Campo obligatorio</span>")
              }
          }
          else{
            $("#idnombreEN").append("<span style='color: red'>Campo obligatorio</span>")
            }
      }
        else{
        $("#idnombre").append("<span style='color: red'>Campo obligatorio</span>")
        }
   }
    else{
      alert("Sus datos no han sido procesados satisfactoriamente, habitantes tiene que ser > 0")
    }
  }
  

  



  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

  /*agregarciudad():Observable<any>{
    let ciudad = new Ciudad();
    ciudad.nombre = this.formulario.nombre;
    ciudad.poblacion = this.formulario.habitantes;
    ciudad.descripcion = this.formulario.descripcion;
    ciudad.imagen = this.imagen;
    console.log(`Nombre ${this.formulario.nombre} Habitantes ${this.formulario.habitantes} Descripcion ${this.formulario.descripcion}`)
    console.log(ciudad);
 
    /*let ciudad : Object ={nombre:this.formulario.nombre,
                          poblacion:this.formulario.habitantes,
                          descripcion:this.formulario.descripcion,
                          imagen:this.imagen  }
    let json = JSON.stringify(ciudad);
    let params = "json="+json;
    let headers = new HttpHeaders().set('Content-Type','application/x-www-form-urlencoded');
         
    return this.http.post(this.url+'agregarciudad',params,{headers:headers})

};*/
 /*agregarciudad(){
  let ciudad = new Ciudad();
  
  ciudad.nombre = this.formulario.nombre;
  ciudad.poblacion = this.formulario.habitantes;
  ciudad.descripcion = this.formulario.descripcion;
  //ciudad.imagen = this.imagen;
  //console.log(`Nombre ${this.formulario.nombre} Habitantes ${this.formulario.habitantes} Descripcion ${this.formulario.descripcion}`)
 // console.log(ciudad);
   this.ciudadservice.agregarciudad(ciudad).subscribe(
     result => {
       this.ima = result.imagen;
       console.log(result);
       this.route.navigate(['ciudades/agregarCiudad']);
     },
     error =>{
        console.log(<any>error)
     }
     
   )
 }*/

 resetForm(Form? : NgForm){
    if(Form != null)
      Form.reset();
      this.formulario = {
        nombreES:'',
        habitantes: 0,
        descripcion:'',
        nombreEN:'',
        descripcionEN :''
      
      }
  }

  


    handleFileInput(file: File) {
     // this.imagen = file;
      console.log(file);
    } 

    imprimirimagen(){
      console.log(this.archivo)
    }
    saveImagen(arch: File){
     // this.imagen = arch; 
      //FileReader.readAsArrayBuffer()
      //arch.slice(start)
     // console.log(arch);
      this.imagen = arch[0].slice(0,arch.size);
      //this.imagen =arch[0]
      console.log("g"+this.imagen)
    }

    /*
    getEstadisticas(){
      console.log(this.url);
      if (this.variable != 0) {
        this.equipo = this.variable;
      }
     this.http.get<estadisticasEquipo>(this.url+'/equipo/'+this.equipo).subscribe(
       x => {
         this.esta = x;
         console.log(this.esta);
       }
     )
     this.route.navigate(['estadisticas/estequipos']);
    }*/
  
    
}
