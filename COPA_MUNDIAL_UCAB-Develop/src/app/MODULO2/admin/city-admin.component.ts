import { Component } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'city-admin',
  templateUrl: './city-admin.component.html',
  styleUrls: ['./city-admin.component.css']
})
export class CityAdminComponent {
  constructor(private router: Router){}

  AgregarCiudad(): void {
		this.router.navigate(['admin/city/agregar']);
  }	
  
  ConsultarCiudad(): void {
		this.router.navigate(['admin/city/consultar']);
  }	
  
  ModificarCiudad(): void {
		this.router.navigate(['admin/city/modificar']);
  }	
  

  EliminarCiudad(): void {
		this.router.navigate(['admin/city/eliminar']);
  }	
  ResumenCiudad(): void {
		this.router.navigate(['admin/city/resumen']);
  }	


}
