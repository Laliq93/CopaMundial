import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit() {
  }

  regresar() {
    this.location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }

}
