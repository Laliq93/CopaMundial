import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient} from '@angular/common/http';
//import { HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm, FormsModule } from '@angular/forms';
import { LogrosService } from '../../services/logros.service';
import { DTOLogroCantidad } from '../../models/DTOLogroCantidad';
import { DTOLogroPartidoId } from '../../models/DTOLogroPartidoId';
import { DTOMostrarLogrosPartido } from '../../models/DTOMostrarLogrosPartido';
import { catchError, map, tap } from 'rxjs/operators';
import {  DTOListaPartidosLogros } from '../../models/DTOListaPartidosLogros';

@Component({
  selector: 'app-logro-cantidad',
  templateUrl: './logro-cantidad.component.html',
  styleUrls: ['./logro-cantidad.component.css']
})
export class LogroCantidadComponent implements OnInit {

  public listaDTOLogroCantidad: DTOMostrarLogrosPartido[] = [];//Contiene una lista de todos los logros del partido
  public partido:  DTOListaPartidosLogros = null;
  public dtoPartidoId: DTOLogroPartidoId;
  public dtoLogroCantidad : DTOLogroCantidad;
  public _newLogro;
  public _newCantidad;
  public idPartido : number;

  public asignarLogroEActive: boolean = false;
  public modificarLogroEActive: boolean = false;
  public consultarLogroEActive: boolean = false;
  public resultadoLogroEActive: boolean = false;
  public apiURL = 'http://localhost:51543/api/logros/';
  constructor(private _logrosService: LogrosService, public router: ActivatedRoute, private http: HttpClient, public router2: Router)
  {
      this._logrosService = new LogrosService(http);
      this.dtoLogroCantidad = new DTOLogroCantidad();
      this.idPartido = parseInt(
           this.router.snapshot.paramMap.get('idPartido')
         );
   }


  ngOnInit() {
    this.partido = this._logrosService.ObtenerPartidoDTO(this.idPartido);
    this.obtenerLogrosCantidadDTO(this.idPartido);

  }


  setAsignarLogroEActive() {
    this.asignarLogroEActive = true;
    this.modificarLogroEActive = false;
    this.consultarLogroEActive = false;
    this.resultadoLogroEActive = false;

  }

  clear()
  {
    this.asignarLogroEActive = false;
    this.modificarLogroEActive = false;
    this.consultarLogroEActive = false;
    this.resultadoLogroEActive = false; 
    this._newLogro = "";
  }

  setModificarLogroEActive(dto: DTOMostrarLogrosPartido) {
    this.asignarLogroEActive = false;
    this.modificarLogroEActive = true;
    this.consultarLogroEActive = false;
    this.resultadoLogroEActive = false;
    this._newLogro = dto.Logro;

  }

  setConsultarLogroEActive() {
    this.asignarLogroEActive = false;
    this.modificarLogroEActive = false;
    this.consultarLogroEActive = true;
    this.resultadoLogroEActive = false;
  }

  setResultadoLogroEActive(){
    this.asignarLogroEActive = false;
    this.modificarLogroEActive = false;
    this.consultarLogroEActive = false;
    this.resultadoLogroEActive = true;

  }


  public obtenerLogrosCantidadDTO(idPartido: number)
   {
          this.dtoPartidoId = new DTOLogroPartidoId();
          this.dtoPartidoId.idPartido = idPartido;
           const url = this.apiURL+ 'obtenerLogrosCantidadPendiente';
           this.http.put<DTOMostrarLogrosPartido[]>(url, this.dtoPartidoId, {
               responseType: 'json'
             })
             .subscribe(
               data => {
                 for (let i = 0; i < Object.keys(data).length; i++)
                  {
                     let logroEquipo: DTOMostrarLogrosPartido;
                     logroEquipo = new DTOMostrarLogrosPartido();

                     logroEquipo.IdLogro = data[i].IdLogro;
                     logroEquipo.Logro = data[i].Logro;
                     this.listaDTOLogroCantidad[i] = logroEquipo;
                     console.log(data[i]);
                  }
               },
               Error => {
                 console.log(Error);
                  alert(Error.error);
                }
             );
   }


   public AgregarLogro()
    {
      if (this._newLogro != null)
      {
        alert(this._newLogro);
        this.dtoLogroCantidad.IdPartido = this.idPartido;
        this.dtoLogroCantidad.LogroCantidad = this._newLogro;
        this.dtoLogroCantidad.TipoLogro = 1;
        this._logrosService.AgregarLogroCantidad(this.dtoLogroCantidad);
        this.obtenerLogrosCantidadDTO(this.idPartido);
      }
      else
        alert("Debe ingresar un nombre de logro correcto");

    }

    public LlamarLogroCantidad() {
      this.router2.navigate(['/logros/logroCantidad',this.idPartido]);
    }

    public LlamarLogroEquipo() {
      this.router2.navigate(['/logros/logroEquipo',this.idPartido]);
    }


}
