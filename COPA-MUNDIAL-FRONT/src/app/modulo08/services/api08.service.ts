import { Injectable } from '@angular/core';
import { Conexion } from '../models/index';
import { HttpClient } from '@angular/common/http';

declare var bootbox, router: any;

@Injectable({
  providedIn: 'root'
})
export class Api08Service {
  public connect: Conexion;

  constructor(private http: HttpClient) {
    this.connect = new Conexion();
  }

  private Error() {
    bootbox.alert();
  }

  private Succes(mensaje: string) {
    bootbox.alert(mensaje, function() {
      location.reload();
    });
  }

  public FatalError() {
    bootbox.alert('Problema al establecer la conexión con el servidor');
  }
}
