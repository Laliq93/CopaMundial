import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-crear-alineacion',
  templateUrl: './crear-alineacion.component.html',
  styleUrls: ['./crear-alineacion.component.css']
})
export class CrearAlineacionComponent implements OnInit {

  public listaJugadores = [
    {
      nombre: 'NIGMATULLIN',
      posicion: 'portero',
      numero: '1',
      estado: 'suplente'
    },
    {
      nombre: 'KOVTUN',
      posicion: 'defensa',
      numero: '2',
      estado: 'suplente'
    },
    {
      nombre: 'NIKIFOROV',
      posicion: 'defensa',
      numero: '3',
      estado: 'suplente'
    },
    {
      nombre: 'SOLOMATIN',
      posicion: 'defensa',
      numero: '5',
      estado: 'suplente'
    },
    {
      nombre: 'SEMSHOV',
      posicion: 'defensa',
      numero: '6',
      estado: 'suplente'
    },
    {
      nombre: 'ONOPKO',
      posicion: 'medio',
      numero: '7',
      estado: 'suplente'
    },
    {
      nombre: 'KARPIN',
      posicion: 'medio',
      numero: '8',
      estado: 'suplente'
    },
    {
      nombre: 'TITOV',
      posicion: 'medio',
      numero: '9',
      estado: 'suplente'
    },
    {
      nombre: 'BESCHASTNYKH',
      posicion: 'delantero',
      numero: '11',
      estado: 'suplente'
    },
    {
      nombre: 'PIMENOV',
      posicion: 'delantero',
      numero: '19',
      estado: 'suplente'
    },
    {
      nombre: 'IZMAYLOV',
      posicion: 'delantero',
      numero: '20',
      estado: 'suplente'
    },
    {
      nombre: 'SMERTIN',
      posicion: 'portero',
      numero: '19',
      estado: 'suplente'
    },
    {
      nombre: 'MOSTOVOY',
      posicion: 'defensor',
      numero: '10',
      estado: 'suplente'
    },
    {
      nombre: 'CHERCHESOV',
      posicion: 'defensor',
      numero: '12',
      estado: 'suplente'
    },
    {
      nombre: 'DAEV',
      posicion: 'delantero',
      numero: '13',
      estado: 'suplente'
    },
    {
      nombre: 'CHIGAYNOV',
      posicion: 'delantero',
      numero: '14',
      estado: 'suplente'
    },
    {
      nombre: 'ALENICHEV',
      posicion: 'delantero',
      numero: '15',
      estado: 'suplente'
    }
  ];

  constructor() { }

  ngOnInit() {
  }

}
