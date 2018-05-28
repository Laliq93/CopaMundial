import { Component, OnInit, AfterViewChecked, Input } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { Equipo } from '../../models/equipo';
import { Pais } from '../../models/pais';
import { EquipoService } from '../../services/equipo.service';

declare var jQuery: any;

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit, AfterViewChecked {
  @Input() public idEquipo: string = null;
  public grupos: string[];
  public banderaSeleccionada: string;
  public paises: Pais[];
  public equipo: Equipo;

  constructor(
    private _location: Location,
    private _router: Router,
    private _equipoService: EquipoService
  ) {}

  ngOnInit() {
    this.grupos = this._equipoService.obtenerGrupos();

    this._equipoService.obtenerPaises().subscribe(data => (this.paises = data));

    if (this.idEquipo !== null) {
      this._equipoService.obtenerEquipo(this.idEquipo).subscribe(data => {
        this.equipo = data;
        this.banderaSeleccionada = this.equipo.pais.urlBandera;
      });
    } else {
      this.equipo = new Equipo();
    }
  }

  ngAfterViewChecked() {

    jQuery('.floating-label .custom-select, .floating-label .form-control').floatinglabel();

  }

  enviar() {
    this._equipoService.editarEquipo(this.equipo).subscribe(data => {
      console.log(data);
    });
  }

  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

  cambiarEquipo(paisIso: string) {
    this.banderaSeleccionada = this.paises.find(
      i => i.iso === paisIso
    ).urlBandera;
  }

  // metodo que abre ventana emergente para agregar un jugador al equipo que se esta creando
  asociar() {
    window.open(
      '/jugadores',
      '_blank',
      'toolbar=yes,scrollbars=yes,resizable=yes,top=50,left=150,width=1000,height=600'
    );
  }
}
