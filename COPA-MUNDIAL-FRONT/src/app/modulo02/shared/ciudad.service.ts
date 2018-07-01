import { Injectable } from '@angular/core';
import {Ciudad} from './ciudad.model';
import { HttpClient, HttpHeaders, HttpClientModule, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { toBase64String } from '@angular/compiler/src/output/source_map';
import { RequestOptions } from '@angular/http';

@Injectable()
export class CiudadService {

  selectedCiudad : Ciudad;
  url:string = "http://localhost:51543/api/ciudad/";

  constructor(public http: HttpClient) { }


  agregarciudad(ciudad : Ciudad):Observable<any>{
  
   
    let json = JSON.stringify(ciudad);
    let params = json;
 
    let headers = new HttpHeaders().set('Content-Type','application/json');
         
    return this.http.post<Ciudad>(this.url,params,{headers: headers});

     };

     ObtenerListaCiudades() : Observable<Ciudad[]>{
        let headers = new HttpHeaders().set('Content-Type','application/json');
        return this.http.get<Ciudad[]>(this.url,{headers: headers});
     }

     EliminarCiudad(id:number):Observable<any>{
     // let headers = new HttpHeaders().set('Content-Type','application/json');
      return this.http
      .request('DELETE', this.url, { body: {id: id}})
      
      }

      ActualizarCiudad(ciudad:Ciudad):Observable<any>{

        let json = JSON.stringify(ciudad);
        let headers = new HttpHeaders().set('Content-Type','application/json');
        return this.http.put(this.url,json,{headers:headers})
      }
      ObtenerListaCiudadesHabilitadas() : Observable<Ciudad[]>{
        let headers = new HttpHeaders().set('Content-Type','application/json');
        return this.http.get<Ciudad[]>(this.url+'/habilitada',{headers: headers});
     }
}
 