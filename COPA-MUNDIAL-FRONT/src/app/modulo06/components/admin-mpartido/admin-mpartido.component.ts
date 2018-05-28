import { Component, OnInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-mpartido',
  templateUrl: './admin-mpartido.component.html',
  styleUrls: ['./admin-mpartido.component.css']
})
export class AdminMpartidoComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }


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
    this.router.navigate(['partidos/partidos']);
  }

  matchDetails():void{
    this.router.navigate(['partidos/detallePartido']);
  }

}
