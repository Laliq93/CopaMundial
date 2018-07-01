import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-modificar-partido',
  templateUrl: './modificar-partido.component.html',
  styleUrls: ['./modificar-partido.component.css']
})
export class ModificarPartidoComponent implements OnInit {

  public equipo1: string = null;
  public equipo2: string = null;

  constructor(private _location: Location) {

  }

  ngOnInit() {
  }

  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
