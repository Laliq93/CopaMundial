import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {

  public idEquipo;

  constructor(private _route: ActivatedRoute) {
    this._route.params.subscribe( params => this.idEquipo = params['id'] );
  }

  ngOnInit() {}
}
