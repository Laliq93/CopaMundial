import { Component, OnInit, NgZone, AfterViewInit } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { Usuario10 } from '../../models/usuario.model';
import { ApiService } from '../../services/api10.services';
import { HttpClient } from '@angular/common/http';

declare var jQuery: any;
declare var bootbox: any;

@Component({
  selector: 'app-configuracion-usuario',
  templateUrl: './configuracion-usuario.component.html',
  styleUrls: [
    './configuracion-usuario.component.css',
    '../style-usuario.component.css'
  ]
})
export class ConfiguracionUsuarioComponent implements OnInit, AfterViewInit {
  public _usuario: Usuario10;
  public _api10: ApiService;

  constructor(private _zone: NgZone, private http: HttpClient) {
    this._api10 = new ApiService(http);
    this._usuario = new Usuario10();
  }

  ngOnInit() {
    this._usuario = this._api10.ObtenerDatos();
  }

  ngAfterViewInit(): void {
    this._zone.runOutsideAngular(() => {
      jQuery('#exampleInputDatePicker1').pickdate({
        cancel: 'Borrar',
        closeOnCancel: false,
        closeOnSelect: true,
        container: 'body',
        containerHidden: 'body',
        firstDay: 1,
        formatSubmit: 'dd/mmmm/yyyy',
        hiddenPrefix: 'prefix_',
        hiddenSuffix: '_suffix',
        labelMonthNext: 'Ir al mes siguiente',
        labelMonthPrev: 'Ir al mes anterior',
        labelMonthSelect: 'Choose a month from the dropdown menu',
        labelYearSelect: 'Choose a year from the dropdown menu',
        ok: 'Cerrar',
        onClose: function() {
          console.log('Datepicker closes');
        },
        onOpen: function() {
          console.log('Datepicker opens');
        },
        selectMonths: true,
        selectYears: 100,
        today: 'Hoy'
      });
    });
  }
}
