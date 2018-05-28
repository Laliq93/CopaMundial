import { Component, OnInit, AfterViewInit } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { Usuario10, Conexion, IUsuario10 } from '../../models/usuario.model';
import { ApiService } from '../../services/api10.services';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Response } from '@angular/http';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-admin-usuario',
  templateUrl: './admin-usuario.component.html',
  styleUrls: ['./admin-usuario.component.css', '../style-usuario.component.css']
})
export class AdminUsuarioComponent implements OnInit {
  public _usuario: Usuario10;
  public _api10: ApiService;
  public ListUsuarios: Usuario10[] = [];
  public dtTrigger: Subject<any> = new Subject();
  public dtOptions: DataTables.Settings = {};
  private _conexion: Conexion;

  public _nombreNew;
  public _apellidoNew;
  public _generoNew;
  public _fechaNew;
  public _FotoNew;

  constructor(private http: HttpClient) {
    this._api10 = new ApiService(http);
    this._usuario = new Usuario10();
    this._conexion = new Conexion();
  }

  ngOnInit(): void {
    this.dtOptions = {
    };

    this.ObtenerDatos();
    this.VerUsuariosActivos();
  }

  ObtenerDatos() {
    this._usuario = this._api10.ObtenerDatos();
  }

  ObtenerUsuariosActivos() {
    this.ListUsuarios = this._api10.VerUsuariosActivos();
  }

  public VerUsuariosActivos() {
    this._conexion.Controlador = 'ObtenerUsuariosActivos';

    let url = this._conexion.RutaApi + this._conexion.Controlador;
    this.http
      .get<Usuario10>(url, { responseType: 'json' })
      .subscribe(data => {
        this.dtTrigger.next();
        for (let i = 0; i < Object.keys(data).length; i++) {
          this.ListUsuarios[i] = data[i];
        }
      });
  }
}
