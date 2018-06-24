import { Injectable } from '@angular/core';
import {Ciudad} from './ciudad.model';
import { HttpClient, HttpHeaders, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { toBase64String } from '@angular/compiler/src/output/source_map';
@Injectable()
export class CiudadService {

  selectedCiudad : Ciudad;
  url:String = "http://localhost:51543/api/ciudad/";

  constructor(public http: HttpClient) { }


  agregarciudad(ciudad : Ciudad):Observable<any>{
  
    //console.log(`Nombre ${this.formulario.nombre} Habitantes ${this.formulario.habitantes} Descripcion ${this.formulario.descripcion}`)
    //console.log(ciudad);
   // console.log(ciudad.imagen);
    let formData = new FormData();
    formData.append('dato', ciudad.imagen);
    //ciudad.imagen;
    //String.toString(ciudad.imagen);
    
    
    
   // formData.append('nombre',ciudad.nombre);
    //formData.append('poblacion',ciudad.poblacion);
    /*let ciudad : Object ={nombre:this.formulario.nombre,
                          poblacion:this.formulario.habitantes,
                          descripcion:this.formulario.descripcion,
                          imagen:this.imagen  }*/
   /// let json = JSON.stringify(ciudad);
    //let params = "json="+json;
   // formData.append(json);
  // headers.append();
    let headers = new HttpHeaders().set('Content-Type','application/undefined');
         
    return this.http.post<Ciudad>(this.url+'api/upload',formData/*{headers:headers}*/)

     };
}
