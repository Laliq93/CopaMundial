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

  datos:any = [
    {pos: 1, jugador: "Gerard Pique", goles:2,amarillas:4,rojas:5,asistencias:7},
    {pos: 1, jugador: "Cristiano Ronaldo", goles:4,amarillas:1,rojas:4,asistencias:5},
    {pos: 1, jugador: "Lionel Messi", goles:6,amarillas:0,rojas:3,asistencias:4},
    {pos: 1, jugador: "Sergei Ignashevich", goles:1,amarillas:2,rojas:2,asistencias:8},
    {pos: 1, jugador: "Ali Karimi", goles:3,amarillas:1,rojas:1,asistencias:6},
    {pos: 1, jugador: "Aaron Mooy", goles:5,amarillas:2,rojas:4,asistencias:4}
  ];   

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
