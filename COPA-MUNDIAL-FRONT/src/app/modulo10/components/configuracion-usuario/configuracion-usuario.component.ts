import { Component, OnInit, NgZone, AfterViewInit  } from '@angular/core';

declare var jQuery: any;

@Component({
  selector: 'app-configuracion-usuario',
  templateUrl: './configuracion-usuario.component.html',
  styleUrls: ['./configuracion-usuario.component.css', '../style-usuario.component.css']
})

export class ConfiguracionUsuarioComponent implements OnInit, AfterViewInit {

  constructor(private _zone: NgZone) {}

  ngOnInit() {
  }

  ngAfterViewInit(): void {

    this._zone.runOutsideAngular(() => {
      jQuery('#copaNavdrawer').navdrawer('show');
    });

  }

}
