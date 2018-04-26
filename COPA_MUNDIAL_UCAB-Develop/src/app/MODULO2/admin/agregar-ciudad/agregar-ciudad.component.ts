import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-agregar-ciudad',
  templateUrl: './agregar-ciudad.component.html',
  styleUrls: ['./agregar-ciudad.component.css']
})
export class AgregarCiudadComponent  {
  constructor(private router: Router){}

  volver(): void {
		this.router.navigate(['admin/city']);
  }	

}
