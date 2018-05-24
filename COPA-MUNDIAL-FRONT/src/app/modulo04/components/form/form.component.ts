import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  public ruta: string = '';

  constructor(private location: Location, private router: Router) { }

  ngOnInit() {
    this.ruta = this.router.url;
    console.log('la ruta es ' + this.ruta);
  }

  regresar() {
    this.location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
