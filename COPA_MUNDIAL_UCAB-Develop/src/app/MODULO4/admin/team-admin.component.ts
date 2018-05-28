import { Component } from '@angular/core';
import {RouterModule, Router } from '@angular/router';

@Component({
  selector: 'team-admin',
  templateUrl: './team-admin.component.html',
  styleUrls: ['./team-admin.component.css']
})
export class TeamAdminComponent {

  constructor(private router: Router) {}

  CrearEquipo(): void {
    this.router.navigate(['admin/team/crear']);
  }

  EditarEquipo(): void {
    this.router.navigate(['admin/team/editar']);
  }

  InhabilitarEquipo(): void {
    this.router.navigate(['admin/team/inhabilitar']);
  }

}
