import { Injectable } from '@angular/core';

@Injectable()
export class Usuario10 {
  public Id: number = 2;
  public NombreUsuario: string;
  public Nombre: string;
  public Apellido: string;
  public FechaNacimiento: string;
  public Correo: string;
  public Genero: string;
  public Password: string;
  public FotoPath: string;
  public EsAdmin: boolean;
  public Activo: boolean;
  public Message: string;
}

export interface IUsuario10 {
  Id: number;
  NombreUsuario: string;
  Nombre: string;
  Apellido: string;
  FechaNacimiento: string;
  Correo: string;
  Genero: string;
  Password: string;
  FotoPath: string;
  EsAdmin: boolean;
  Activo: boolean;
  Message: string;
}

export class Conexion {
  //RutaApi:string = 'http://localhost:54059/api/M10_Usuario/';
  RutaApi = 'http://192.168.15.108:54059/api/M10_Usuario/';
  Controlador: string;
}
