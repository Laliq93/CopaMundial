import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EquipoService implements OnInit {

  API_ENDPOINT = 'http://localhost:54059/api/M4_GestionEquipo/';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get(this.API_ENDPOINT + 'prueba').subscribe(data => {
      console.log('la respuesta de la api es: ' + data);
    });
  }

}
