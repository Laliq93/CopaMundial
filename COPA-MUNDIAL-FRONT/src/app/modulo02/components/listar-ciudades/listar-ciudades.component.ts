import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-listar-ciudades',
  templateUrl: './listar-ciudades.component.html',
  styleUrls: ['./listar-ciudades.component.css']
})
export class ListarCiudadesComponent implements OnInit {

  ciudades: any = [
    "Rusia","Brasil","Argentina","Uruguay",
    "Perú","Colombia","Panamá","Costa Rica",
    "México","Alemania","Bélgica","Croacia"
    ].sort();
  
  constructor() { }

  ngOnInit() {
  }

}
