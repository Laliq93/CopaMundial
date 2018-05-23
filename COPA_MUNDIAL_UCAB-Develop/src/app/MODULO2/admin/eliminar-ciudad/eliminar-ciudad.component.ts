import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';
@Component({
  selector: 'app-eliminar-ciudad',
  templateUrl: './eliminar-ciudad.component.html',
  styleUrls: ['./eliminar-ciudad.component.css']
})
export class EliminarCiudadComponent  {
  nombreCiudades: string[] = ['Moscu', 'Ekaterimburgo','Leningrado ','San Petersburgo','Samara', 'Rostov','Kazan', 'Novorossiysk', 'Sochi', 'Saransk', 'Nizhni Nóvgorod']
  
  constructor(private router: Router){}

  volver(): void {
		this.router.navigate(['admin/city']);
  }
  ModificarCiudad(): void {
		this.router.navigate(['admin/city/modificar']);
  }	
}
