import { Component, OnInit, NgZone, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Jugador } from '../../models/jugador';
import { Conexion } from '../../models/conexion';
import { JugadorService } from '../../services/jugador.service';
import {DTOMostrarJugador} from '../../models/dtomostrar-jugador';
import {DTOActivarJugador} from '../../models/dtoactivar-jugador';
import {HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Observable, Subject } from 'rxjs';

declare var bootbox, router: any;

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};


@Component({
  selector: 'app-jugadores',
  templateUrl: './jugadores.component.html',
  styleUrls: ['./jugadores.component.css']
})

@Injectable()
export class JugadoresComponent implements OnInit {
  title = 'Jugadores';
  conexion : Conexion;
  url : string;
  ListJugadores: DTOMostrarJugador[] = [];
  ListJugadoresActivos: DTOMostrarJugador[] = [];
  ListJugadoresInactivos: DTOMostrarJugador[] = [];
  jugador : Jugador;
  jugadorInactivo : DTOActivarJugador;
  jugadorActivo : DTOActivarJugador;


  readonly rootUrl =  'http://localhost:51543/api';

  constructor(private router: Router,
    public http: HttpClient) 
    { 
      this.conexion = new Conexion();
      this.jugador = new Jugador();
      this.jugadorInactivo = new DTOActivarJugador();
      this.jugadorActivo = new DTOActivarJugador();
    }

  ngOnInit() {

    this.obtenerJugadores();
    this.obtenerJugadoresActivos();
    this.obtenerJugadoresInactivos();

  }

  registrarJugador(playerRegistrationForm){
    this.conexion.controller = 'agregarJugador';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    console.log(this.url+ "url");

    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');


    const {Nombre, Apellido, FechaNacimiento, 
      LugarNacimiento, Peso, Altura, Posicion, 
      Numero, Equipo} = playerRegistrationForm.controls;
    

    console.log(playerRegistrationForm.controls, Nombre.value, Apellido.value);
    
    
    const player = {
      nombre          : Nombre.value,
      apellido        : Apellido.value,
      fechaNacimiento : FechaNacimiento.value,
      lugarNacimiento : LugarNacimiento.value,
      peso            : Peso.value,
      altura          : Altura.value,
      posicion        : Posicion.value,
      numero          : Numero.value,
      equipo          : Equipo.value  
    };
    

      this.http
      .post<Jugador>(this.url, player,  { responseType: 'json' })
      .subscribe(
        success => {
          console.log(success)
        },
        error =>{
          console.log('Player '+JSON.stringify({player})
        )
          alert("Error en el sistema")
        } 
      );
    
  }

  /*desactivarJugador (idJugador: number) {


    this.conexion.controller = 'activarJugador';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    console.log(idJugador);
    const playerActivo = {
      id          : idJugador
    };

    this.http
      .post<Jugador>(this.url, playerActivo,  { responseType: 'json' })
      .subscribe(
        success => {
          console.log(success)
          console.log('entro al post');
        },
        error =>{
          console.log('Player '+JSON.stringify({playerActivo})
        )
          alert("Error en el sistema")
        } 
      );

    
  }*/

  activarJugador(playerActivateForm){
    this.conexion.controller = 'activarJugador';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    console.log(this.url+ "url");

    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');

    const {Id} = playerActivateForm.controls;
    

    console.log(playerActivateForm.controls, Id.value);
    
    
    const player_activate = {
      id          : Id.value
    };
    

      this.http
      .post<DTOActivarJugador>(this.url, player_activate,  { responseType: 'json' })
      .subscribe(
        success => {
          console.log(success)
        },
        error =>{
          console.log('Player '+JSON.stringify({player_activate})
        )
          alert("Error en el sistema")
        } 
      );
    
  }

  desactivarJugador(playerInactivateForm){
    this.conexion.controller = 'desactivarJugador';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    console.log(this.url+ "url");

    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');

    const {Id} = playerInactivateForm.controls;
    

    console.log(playerInactivateForm.controls, Id.value);
    
    
    const player_inactivate = {
      id          : Id.value
    };
    

      this.http
      .post<DTOActivarJugador>(this.url, player_inactivate,  { responseType: 'json' })
      .subscribe(
        success => {
          console.log(success)
        },
        error =>{
          console.log('Player '+JSON.stringify({player_inactivate})
        )
          alert("Error en el sistema")
        } 
      );
    
  }

  
  obtenerJugadores(){
    this.conexion.controller = 'obtenerJugadores';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadores[i] = data[i];
      }
    });
  }

  obtenerJugadoresActivos(){
    this.conexion.controller = 'obtenerJugadoresActivo';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadoresActivos[i] = data[i];
      }
    });

  }

  obtenerJugadoresInactivos(){
    this.conexion.controller = 'obtenerJugadoresInactivo';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadoresInactivos[i] = data[i];
      }
    });

  }

}