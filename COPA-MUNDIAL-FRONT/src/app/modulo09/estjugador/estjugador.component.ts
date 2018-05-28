import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { estadisticas } from '../estadisticas';



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
 esta : estadisticas;
 url : string;
 player : number;
 

  constructor(private route:Router, private http : HttpClient) {
  //  this.route.queryParams.subscribe(params => {
   //   this.param1 = params['nombre'].split("_").join(" ");
     
     
  //});
  this.url = "http://localhost:54059/api/M09_estadisticas"
  this.player = 1;
   }

  ngOnInit() {
    this.url = "http://localhost:54059/api/M09_estadisticas"
      this.player = 1;
  }

  ngAfterViewInit(){
  }

  getEstadisticas(){
    console.log(this.url);
   this.http.get<estadisticas>(this.url+'/jugador/'+this.player).subscribe(
     x => {
       this.esta = x;
       console.log(this.esta);
     }
   )
   this.route.navigate(['estadisticas/estjugador']);
  }


}



