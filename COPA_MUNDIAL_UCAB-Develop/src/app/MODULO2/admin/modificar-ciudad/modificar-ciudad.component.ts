import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-modificar-ciudad',
  templateUrl: './modificar-ciudad.component.html',
  styleUrls: ['./modificar-ciudad.component.css']
})
export class ModificarCiudadComponent  {

  constructor(private router: Router){}

  volver(): void {
		this.router.navigate(['admin/city']);
  }

}
