import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-consultar-ciudad',
  templateUrl: './consultar-ciudad.component.html',
  styleUrls: ['./consultar-ciudad.component.css']
})
export class ConsultarCiudadComponent implements OnInit {
  

  nombreCiudades: string[] = ['Moscu', 'Ekaterimburgo','Leningrado ','San Petersburgo','Samara', 'Rostov','Kazan', 'Novorossiysk', 'Sochi', 'Saransk', 'Nizhni Nóvgorod']


  constructor() { }

  ngOnInit() {
  }

}
