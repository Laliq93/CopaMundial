import { Component, OnInit } from '@angular/core';
import { Timestamp } from 'rxjs';
import { Time } from '@angular/common';

@Component({
  selector: 'app-estpartidos',
  templateUrl: './estpartidos.component.html',
  styleUrls: ['./estpartidos.component.css']
})
export class EstpartidosComponent implements OnInit {

  location:string;
  time:Date;
  grupo:string

  equipo1:Equipo
  equipo2:Equipo;


  constructor() { 
    this.initData()
  }

  ngOnInit() {
  }
  initData(){
    this.equipo1 = new Equipo();
    this.equipo1.nombre = 'Venezuela';
    this.equipo1.goles = 2
    this.equipo1.offsides = 5
    this.equipo1.tarjetasAmarillas = 3
    this.equipo1.tarjetasRojas = 2
    this.equipo1.tiros = 10

    this.equipo2 = new Equipo()
    this.equipo2.nombre = 'Espana'
    this.equipo2.goles = 1
    this.equipo2.offsides = 3
    this.equipo2.tarjetasAmarillas = 4
    this.equipo2.tarjetasRojas = 3
    this.equipo2.goles = 5

    this.location = 'Mi casa'
    this.time= new Date()
    this.time.setDate(15)
    this.grupo = 'A'
  }

}

class Equipo {
  nombre:string;
  goles:number;
  tiros:number;
  tarjetasAmarillas:number;
  tarjetasRojas:number;
  offsides:number;

}
