import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {
  grupoactual:number = 1;
  partidos:boolean = false;
  estadisticas:boolean = true;
  numero:number;
  constructor(private router: Router){}

	 ngOnInit() {
  }
  clickedgrupo(valor: number):void  {
    // yourText is the argument from the template
    if (valor > 0 && valor<9) {
      this.grupoactual =valor;
    }
    console.log(this.grupoactual);
    this.router.navigate(['home/statistic']);
    
  }

  ClickPartidos(){
    this.partidos = false;
    this.estadisticas = true;
    console.log("partidos");
    this.router.navigate(['home/statistic']);
  }
  ClickEstadisticas(){
    this.partidos = true;
    this.estadisticas = false;

    console.log("estadisticas");
    this.router.navigate(['home/statistic']);
  }

  click(){
    console.log("aqui el nombre: "+this.numero);
  }

  

  equipos:any = [ //any indica que puede ser de cualquier tipo de objeto, en este caso un arreglo
    {grupo: 1, nombre: 'Portugal', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 1, nombre: 'España', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 1, nombre: 'Marruecos', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 1, nombre: 'RI de Iran', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 2, nombre: 'Francia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 2, nombre: 'Australia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 2, nombre: 'Peru', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 2, nombre: 'Dinamarca', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 3, nombre: 'Argentina', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 3, nombre: 'Islandia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 3, nombre: 'Croacia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 3, nombre: 'Nigeria', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 4, nombre: 'Brasil', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 4, nombre: 'Suiza', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 4, nombre: 'Costa Rica', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 4, nombre: 'Serbia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 5, nombre: 'Alemania', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 5, nombre: 'Mexico', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 5, nombre: 'Suecia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 5, nombre: 'Republica de Corea', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 6, nombre: 'Belgica', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 6, nombre: 'Panama', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 6, nombre: 'Tunez', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 6, nombre: 'Inglaterra', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 7, nombre: 'Polonia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 7, nombre: 'Senegal', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 7, nombre: 'Colombia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 7, nombre: 'Japon', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 8, nombre: 'Rusia', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 8, nombre: 'Arabia Saudi', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 8, nombre: 'Egipto', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0},
    {grupo: 8, nombre: 'Uruguay', pj: 0, g: 0, e: 0, p: 0, gf: 0, gc: 0, masmenos: 0, pts: 0}   
  ];


}
