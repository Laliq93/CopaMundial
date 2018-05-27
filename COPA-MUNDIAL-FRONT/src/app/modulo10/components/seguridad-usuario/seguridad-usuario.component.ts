import { Component, OnInit } from '@angular/core';
import { Usuario10 } from '../../models/usuario.model';
import { ApiService } from '../../services/api10.services';
import { HttpClient } from '@angular/common/http';

declare var bootbox: any;

@Component({
  selector: 'app-seguridad-usuario',
  templateUrl: './seguridad-usuario.component.html',
  styleUrls: [
    './seguridad-usuario.component.css',
    '../style-usuario.component.css'
  ]
})
export class SeguridadUsuarioComponent implements OnInit {
  public _usuario: Usuario10;
  public _api10: ApiService;

  public _correoConfirm;

  constructor(private http: HttpClient) {
    this._api10 = new ApiService(http);
    this._usuario = new Usuario10();
  }

  ngOnInit() {
    this._usuario = this._api10.ObtenerDatos();
  }

  VerificarEmail() {
    if (
      this._correoConfirm === this._usuario.Correo &&
      this._correoConfirm != null &&
      this._usuario.Correo != null
    ) {
      this._api10.ActualizarCorreo(this._usuario);
    } else {
      bootbox.alert('Son distintios');
    }
  }
}
