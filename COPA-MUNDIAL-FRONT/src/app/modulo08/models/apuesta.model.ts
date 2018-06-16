import { Injectable } from '@angular/core';

@Injectable()
export class Apuesta {}

export class Conexion {
         // RutaApi:string = 'http://localhost:54059/api/M08_Apuesta/';
         RutaApi = 'http://192.168.15.108:54059/api/M08_Apuesta/';
         Controlador: string;
       }
