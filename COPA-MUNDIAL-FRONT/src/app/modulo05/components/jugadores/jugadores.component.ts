import { Component, OnInit } from '@angular/core';
import { Jugador } from '../../models/jugador';
import { Conexion } from '../../models/conexion';
import { JugadorService } from '../../services/jugador.service';
import {DTOMostrarJugador} from '../../models/dtomostrar-jugador';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-jugadores',
  templateUrl: './jugadores.component.html',
  styleUrls: ['./jugadores.component.css']
})
export class JugadoresComponent implements OnInit {
  title = 'Jugadores';
  conexion : Conexion;
  url : string;
  ListJugadores: DTOMostrarJugador[] = [];
  ListJugadoresActivos: DTOMostrarJugador[] = [];
  ListJugadoresInactivos: DTOMostrarJugador[] = [];


  constructor(private jugadorService: JugadorService,
    public http: HttpClient) 
    { 
      this.conexion = new Conexion();
    }

  ngOnInit() {

    this.obtenerJugadores();
    this.obtenerJugadoresActivos();
    this.obtenerJugadoresInactivos();

  }
  
  obtenerJugadores(){
    this.conexion.controller = 'obtenerJugadores';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    console.log(this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }));
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadores[i] = data[i];
      }
    });
  }

  obtenerJugadoresActivos(){
    this.conexion.controller = 'obtenerJugadoresActivo';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    console.log(this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }));
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadoresActivos[i] = data[i];
      }
    });

  }

  obtenerJugadoresInactivos(){
    this.conexion.controller = 'obtenerJugadoresInactivo';
    this.url = this.conexion.GetApiJugador() + this.conexion.controller;
    console.log(this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }));
    
    this.http.get<DTOMostrarJugador>(this.url,  { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        this.ListJugadoresInactivos[i] = data[i];
      }
    });

  }

}