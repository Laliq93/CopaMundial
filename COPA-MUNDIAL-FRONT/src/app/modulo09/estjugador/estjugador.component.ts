import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';




@Component({
  selector: 'app-estjugador',
  templateUrl: './estjugador.component.html',
  styleUrls: ['./estjugador.component.css']
})
export class EstjugadorComponent implements OnInit {


  datos:any = [
    {pais: 'México', goles: 50, asistencias:5,tamarillas:5,trojas:4,mjugados:4,calificacion:5},
    {pais: 'Polonia', goles: 50, asistencias:5,tamarillas:5,trojas:4,mjugados:4,calificacion:5},
    {pais: 'Iran', goles: 50, asistencias:5,tamarillas:5,trojas:4,mjugados:4,calificacion:5}
  ];   

  jugador = {peso:60,altura:1.2,edad:38};

 param1:string;

  constructor(private route:ActivatedRoute) {
    this.route.queryParams.subscribe(params => {
      this.param1 = params['nombre'].split("_").join(" ");
  });
   }

  ngOnInit() {
  }

  ngAfterViewInit(){


  }
}



