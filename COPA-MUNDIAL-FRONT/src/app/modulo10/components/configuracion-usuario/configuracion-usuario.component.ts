import { Component, OnInit, NgZone, AfterViewInit } from '@angular/core';

declare var jQuery: any;

@Component({
  selector: 'app-configuracion-usuario',
  templateUrl: './configuracion-usuario.component.html',
  styleUrls: ['./configuracion-usuario.component.css', '../style-usuario.component.css']
})

export class ConfiguracionUsuarioComponent implements OnInit, AfterViewInit {

  constructor(private _zone: NgZone) { }

  ngOnInit() {
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
        onClose: function () {
          console.log('Datepicker closes');
        },
        onOpen: function () {
          console.log('Datepicker opens');
        },
        selectMonths: true,
        selectYears: 100,
        today: 'Hoy'
      });
    });

  }

}
