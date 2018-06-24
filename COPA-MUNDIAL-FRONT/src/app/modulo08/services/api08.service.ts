import { Injectable } from '@angular/core';
import {
  DTOMostrarPartido,
  DTOMostrarLogros,
  DTOEnviarIdPartido,
  Conexion
} from '../models/index';

import { HttpClient } from '@angular/common/http';

declare var bootbox, router: any;

@Injectable({
  providedIn: 'root'
})

export class Api08Service {
  public connect: Conexion;
  public MostrarPartido: DTOMostrarPartido;
  public EnviarIdPartido: DTOEnviarIdPartido;
  public MostrarLogros: DTOMostrarLogros;

  constructor(private http: HttpClient) {
    this.connect = new Conexion();
    this.MostrarPartido = new DTOMostrarPartido();
    this.EnviarIdPartido = new DTOEnviarIdPartido();
  }

  public EnviarIdApuestaPartido(idPartido: number) {
    this.connect.Controlador = 'obtenerlogrosvofpartido';
    let url = this.connect.RutaApi + this.connect.Controlador;
    this.EnviarIdPartido.IdPartido = idPartido;

    this.http
      .put<DTOMostrarLogros>(url, this.EnviarIdPartido, {
        responseType: 'json'
      })
      .subscribe(
        data => {},
        Error => {
          this.FatalError();
        }
      );
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
