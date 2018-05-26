import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
declare var jquery:any;
declare var $ :any;

@Component({
  selector: 'app-estgeneral',
  templateUrl: './estgeneral.component.html',
  styleUrls: ['./estgeneral.component.css']
})
export class EstgeneralComponent implements OnInit {
  grupoactual:number = 1;
  partidos:boolean = false;
  estadisticas:boolean = true;
  numero:number;
  constructor(private router: Router){}

  ngOnInit() {
    $('#picker').pickdate();
  }

  clickedgrupo(valor: number):void  {
    // yourText is the argument from the template
    if (valor > 0 && valor<9) {
      this.grupoactual =valor;
    }
    console.log(this.grupoactual);
    this.router.navigate(['estadisticas/estadisticas']);
    
  }

  ClickPartidos(){
    this.partidos = false;
    this.estadisticas = true;
    console.log("partidos");
    this.router.navigate(['estadisticas/estadisticas']);
  }
  ClickEstadisticas(){
    this.partidos = true;
    this.estadisticas = false;

    console.log("estadisticas");
    this.router.navigate(['estadisticas/estadisticas']);
  }

  click(){
    console.log("aqui el nombre: "+this.numero);
  }



}
