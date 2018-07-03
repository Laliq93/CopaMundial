import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-modificar-partido',
  templateUrl: './modificar-partido.component.html',
  styleUrls: ['./modificar-partido.component.css']
})
export class ModificarPartidoComponent implements OnInit {

  public Id: number;

  constructor(private _location: Location,
    private route: ActivatedRoute) {
    this.route.params.subscribe(params => this.Id = params['idPartido']);
  }

  ngOnInit() {
  }

  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
