import { Component, OnInit } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
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
  isValid = false;

  public _usuario: Usuario10;
  public _api10: ApiService;

  public _correoNuevo;
  public _correoConfirm;
  public _passConfirm;
  public _passConfirm2;

  constructor(private http: HttpClient) {
    this._api10 = new ApiService(http);
    this._usuario = new Usuario10();
  }

  ngOnInit() {
    this._usuario = this._api10.ObtenerDatos();
  }

  VerificarEmail() {
    if (this._correoConfirm === this._usuario.Correo && this._correoConfirm != null && this._usuario.Correo != null) {
      this._api10.ActualizarCorreo(this._usuario, this._correoNuevo);
    } else {
      bootbox.alert('Los correos son distintos');
    }
  }

  DesactivarPerfil() {
    this._api10.DesactivarCuentaPropia(this._usuario);
  }

  CambiarContrasena() {
    if (this._passConfirm === this._passConfirm2) {
      this._api10.ActualizarClave(this._usuario, this._passConfirm2);
    } else {
      bootbox.alert('Las contraseñas son distintas');
    }
  }

  changeValue(valid: boolean) {
    this.isValid = valid;
  }
}
