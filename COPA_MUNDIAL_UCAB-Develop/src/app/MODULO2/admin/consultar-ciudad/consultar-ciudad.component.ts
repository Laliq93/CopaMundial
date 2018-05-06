import { Component, OnInit } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-consultar-ciudad',
  templateUrl: './consultar-ciudad.component.html',
  styleUrls: ['./consultar-ciudad.component.css']
})
export class ConsultarCiudadComponent  {

  constructor(private router: Router){}

  volver(): void {
		this.router.navigate(['admin/city']);
  }
  
}
