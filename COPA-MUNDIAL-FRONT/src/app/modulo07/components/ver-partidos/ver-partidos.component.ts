import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LogrosService } from '../../services/logros.service';
import { DTOListaPartidosLogros } from '../../models/DTOListaPartidosLogros';

@Component({
  selector: 'app-ver-partidos',
  templateUrl: './ver-partidos.component.html',
  styleUrls: ['./ver-partidos.component.css']
})
export class VerPartidosComponent implements OnInit {

  
public listmatches: DTOListaPartidosLogros[] =[];
public partidosFinalizados : DTOListaPartidosLogros[] = [];
  constructor(private _logrosService: LogrosService, private http: HttpClient, private router: Router)
  {
      this._logrosService = new LogrosService(http);
      this.listmatches = this._logrosService.ObtenerProximosPartidos();
      this.partidosFinalizados = this._logrosService.ObtenerPartidosFinalizados();
   }

  ngOnInit() {
  }

  public LlamarLogros(idPartido) {
     this.router.navigate(['/logros/logroEquipo',idPartido]);
   }
}
