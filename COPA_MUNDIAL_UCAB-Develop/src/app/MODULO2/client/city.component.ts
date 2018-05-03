import { Component } from '@angular/core';

@Component({
  selector: 'city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent {  
  public modulo: string = "dos"; 
  nombreCiudades: string[] = ['Moscu', 'Ekaterimburgo','Leningrado ','San Petersburgo','Samara', 'Rostov','Kazan', 'Novorossiysk', 'Sochi', 'Saransk', 'Nizhni Nóvgorod', 'caracas', 'zulia', 'delta amacuro']


}
