import { Injectable } from '@angular/core';
import { Usuario10, IUsuario10, Conexion } from '../models/usuario.model';
import { RouterModule, Router } from '@angular/router';
import {
  HttpClient,
  HttpParams,
  HttpHeaders,
  HttpErrorResponse
} from '@angular/common/http';

declare var bootbox, router: any;

@Injectable()
export class ApiService {
  private _usuario10: Usuario10;
  private _conexion: Conexion;
  constructor(private http: HttpClient) {
    this._usuario10 = new Usuario10();
    this._conexion = new Conexion();
    this._usuario10.Id = 2;
    // const httpHeaders = new HttpHeaders().set('Accept', 'application/json');
  }

  public ObtenerDatos(): Usuario10 {
    this._conexion.Controlador = 'ObtenerUsuario/';

    let url =
      this._conexion.RutaApi + this._conexion.Controlador + this._usuario10.Id;

    this.http.get<IUsuario10>(url, { responseType: 'json' }).subscribe(data => {
      this._usuario10.Nombre = data.Nombre;
      this._usuario10.Apellido = data.Apellido;
      this._usuario10.Correo = data.Correo;
      this._usuario10.FechaNacimiento = data.FechaNacimiento;
      this._usuario10.Activo = data.Activo;
      this._usuario10.Genero = data.Genero;
      this._usuario10.EsAdmin = data.EsAdmin;
      // this._usuario10.Message = data.Message;
    });

    return this._usuario10;
  }

  public EditarPerfil(usuario: Usuario10): string {
    this._conexion.Controlador = 'ActualizarPerfil';
    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http
      .put<IUsuario10>(url, usuario, { responseType: 'json' })
      .subscribe(data => {
        if (data != null) {
          console.log(data);
        } else {
          this.Succes('Usuario Editado Corectamente.');
        }
      });

    return null;
  }

  public ActualizarCorreo(usuario: Usuario10, correoNuevo) {
    this._usuario10 = usuario;
    this._conexion.Controlador = 'ActualizarCorreoUsuario';
    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http.put<IUsuario10>(url, usuario, { responseType: 'json' }).subscribe(
      data => {
        if (data != null) {
          this._usuario10.Message = data.Message;
          this.Error(this._usuario10);
        } else {
          this.Succes('Correo editado con éxito');
        }
      },
      Error => {}
    );
  }

  public ActualizarClave(usuario: Usuario10, claveNueva: string) {
    this._usuario10 = usuario;
    this._conexion.Controlador = 'ActualizarClaveUsuario/' + claveNueva;
    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http
      .put<IUsuario10>(url, usuario, { responseType: 'json' })
      .subscribe(data => {
        if (data != null) {
          this._usuario10.Message = data.Message;
          this.Error(this._usuario10);
        } else {
          this.Succes('Clave editada con éxito');
        }
      });
  }

  public DesactivarCuentaPropia(usuario: Usuario10) {
    this._usuario10 = usuario;
    this._conexion.Controlador = 'DesactivarUsuarioPropio';
    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http
      .put<IUsuario10>(url, usuario, { responseType: 'json' })
      .subscribe(data => {
        if (data != null) {
          this._usuario10.Message = data.Message;
          this.Error(this._usuario10);
        } else {
          this.Succes('Cuenta desactivada con éxito');
        }
      });
  }

  public AdministradorActivarCuenta(usuario: Usuario10) {
    this._usuario10 = usuario;
    this._conexion.Controlador = 'ActivarUsuario';
    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http
      .put<IUsuario10>(url, usuario, { responseType: 'json' })
      .subscribe(data => {
        if (data != null) {
          this._usuario10.Message = data.Message;
          this.Error(this._usuario10);
        } else {
          this.Succes('Cuenta activada con éxito');
        }
      });
  }

  public AdministradorDesactivaCuenta(usuario: Usuario10) {
    this._usuario10 = usuario;
    this._conexion.Controlador = 'AdministradorDesactivaUsuario';
    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http
      .put<IUsuario10>(url, usuario, { responseType: 'json' })
      .subscribe(data => {
        if (data != null) {
          this._usuario10.Message = data.Message;
          this.Error(this._usuario10);
        } else {
          this.Succes('Cuenta desactivada con éxito');
        }
      });
  }

  public VerUsuariosActivos() {
    let listaUsuarios: Usuario10[] = new Array();

    this._conexion.Controlador = 'ObtenerUsuariosActivos';

    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http.get<IUsuario10>(url, { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        listaUsuarios[i] = data[i];
      }
    });
  }

  public VerUsuariosNoActivos() {
    let listaUsuarios: Usuario10[] = new Array();

    this._conexion.Controlador = 'ObtenerUsuariosNoActivos';

    let url = this._conexion.RutaApi + this._conexion.Controlador;

    this.http.get<IUsuario10>(url, { responseType: 'json' }).subscribe(data => {
      for (let i = 0; i < Object.keys(data).length; i++) {
        listaUsuarios[i] = data[i];
      }
    });
  }

  public CrearUsuarioAdministrador() {}

  private Error(usuario: Usuario10) {
    bootbox.alert(this._usuario10.Message);
  }

  private Succes(mensaje: string) {
    bootbox.alert(mensaje);
  }

  private FatalError() {}
}
