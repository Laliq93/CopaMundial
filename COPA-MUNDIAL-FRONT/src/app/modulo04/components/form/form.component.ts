import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';
import { Equipo } from '../../models/equipo';
import { EquipoService } from '../../services/equipo.service';
import { HttpClient } from '@angular/common/http';
import { HttpModule } from '@angular/http';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  public ruta: string = '';
  public grupos = this.equipoService.getGrupos();
  public equipo: Equipo = new Equipo();
  API_ENDPOINT = 'http://localhost:54059/api/M4_GestionEquipo/';

  constructor(private location: Location, private router: Router,
              private equipoService: EquipoService, private http: HttpClient) { }

  ngOnInit() {
    this.ruta = this.router.url;

    // aqui ira el metodo que trae los datos del equipo para setearlos en los inputs
    this.equipo.nombre = 'Portugal';
    this.equipo.descripcion = 'esta es la descripcion de portugal';
    this.equipo.grupo = 'C';
    this.equipo.status = true;

    // console.log(this.http.get('http://localhost:54059/api/M4_GestionEquipo/prueba'));
}

enviar() {
  this.equipoService.getConfig()
    .subscribe((data) => console.log(data)
    );
}

regresar() {
  this.location.back(); // <-- regresar a la pagina previa al presionar cancelar
}

// metodo que abre ventana emergente para agregar un jugador al equipo que se esta creando
asociar() {
  window.open('/jugadores', '_blank', 'toolbar=yes,scrollbars=yes,resizable=yes,top=50,left=150,width=1000,height=600');
}

}
