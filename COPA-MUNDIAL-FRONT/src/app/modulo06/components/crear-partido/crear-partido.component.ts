import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-crear-partido',
  templateUrl: './crear-partido.component.html',
  styleUrls: ['./crear-partido.component.css']
})
export class CrearPartidoComponent implements OnInit {

  constructor(private _location: Location) {
  }

  ngOnInit() {
  }

  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
