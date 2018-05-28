import { Component, OnInit, NgZone } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Partido } from '../../models/partido';


const httpOptions = {

  header : new HttpHeaders({
    'Content-Type': 'application/json'
  })
};


@Component({
  selector: 'app-admin-cpartido',
  templateUrl: './admin-cpartido.component.html',
  styleUrls: ['./admin-cpartido.component.css']
})
export class AdminCpartidoComponent implements OnInit {

  partido: Partido;
  PartidoForm = new Partido();
  listmatches: Array<any>= [];

  readonly rootUrl =  'http://localhost:54059';

  constructor(private router: Router,private http: HttpClient, private _zone: NgZone) {
      this.partido = new Partido();
   }
  
 

   ngOnInit() {

  }

  OnSubmit(form : NgForm){
    this.RegisterPartido(form.value);
  }
  

  
  RegisterPartido(partido : Partido){
    const body: Partido = {
      id: 0,
      fecha : partido.fecha,
      horaInicio : partido.horaInicio,
      arbitro : partido.arbitro,
      equipo1 : partido.equipo1,
      equipo2 : partido.equipo2,
      estadio : partido.estadio
    }

    return this.http.post(this.rootUrl + '/api/M6_Partido/AgregarPartido/', body);
  };




  matchCreate(): void {
    this.router.navigate(['partidos/crearPartido']);
  }

  matchUpdate(): void {
    this.router.navigate(['partidos/modificarPartido']);
  }
  
  matchList(): void {
    this.router.navigate(['partidos/listaPartidos']);
  }
  
  matchLineup(): void {
    this.router.navigate(['partidos/crearAlineacion']);
  }





}
