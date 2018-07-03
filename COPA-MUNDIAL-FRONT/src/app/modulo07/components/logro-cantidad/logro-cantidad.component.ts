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
import { DTOLogroCantidadResultado } from '../../models/DTOLogroCantidadResultado';
import { DTOMostrarLogrosPartido } from '../../models/DTOMostrarLogrosPartido';
import { catchError, map, tap } from 'rxjs/operators';
import {  DTOListaPartidosLogros } from '../../models/DTOListaPartidosLogros';
import { config } from '../../../config';

@Component({
  selector: 'app-logro-cantidad',
  templateUrl: './logro-cantidad.component.html',
  styleUrls: ['./logro-cantidad.component.css'],
  providers: [LogrosService]
})
export class LogroCantidadComponent implements OnInit {

  public listaDTOLogroCantidad: DTOMostrarLogrosPartido[] = [];//Contiene una lista de todos los logros del partido
  public listaDTOLogroCantidadResultado: DTOLogroCantidadResultado [] = [];
  public partido:  DTOListaPartidosLogros = null;
  public dtoPartidoId: DTOLogroPartidoId;
  public dtoLogroCantidad : DTOLogroCantidad;
  public dtoLogroPartido : DTOMostrarLogrosPartido;
  public dtoLogroCantidadResult : DTOLogroCantidadResultado; 
  public _newLogro;
  public _newCantidad;
  public idPartido : number;

  public asignarLogroEActive: boolean = false;
  public modificarLogroEActive: boolean = false;
  public consultarLogroEActive: boolean = false;
  public resultadoLogroEActive: boolean = false;
  public apiURL = config.url + '/logros';
  constructor(private _logrosService: LogrosService, public router: ActivatedRoute, private http: HttpClient, public router2: Router)
  {
      this._logrosService = new LogrosService(http);
      this.dtoLogroCantidad = new DTOLogroCantidad();
      this.dtoLogroCantidadResult = new DTOLogroCantidadResultado();
      this.idPartido = parseInt(
           this.router.snapshot.paramMap.get('idPartido')
         );
   }




   public obtenerLogrosCantidadResultadosDTO(idPartido: number)
   {
          this.dtoPartidoId = new DTOLogroPartidoId();
          this.dtoPartidoId.idPartido = idPartido;
           const url = this.apiURL+ 'obtenerLogrosCantidadResultados';
           this.http.put<DTOLogroCantidadResultado[]>(url, this.dtoPartidoId, {
               responseType: 'json'
             })
             .subscribe(
               data => {
                 for (let i = 0; i < Object.keys(data).length; i++)
                  {
                     let logroCantidad: DTOLogroCantidadResultado;
                     logroCantidad = new DTOLogroCantidadResultado();

                     logroCantidad.IdLogroCantidad = data[i].IdLogroCantidad;
                     logroCantidad.LogroCantidad = data[i].LogroCantidad;
                     logroCantidad.Cantidad = data[i].Cantidad;
                     logroCantidad.TipoLogro = data[i].TipoLogro;
                     this.listaDTOLogroCantidadResultado[i] = logroCantidad;
                     console.log(data[i]);
                  }
               },
               Error => {
                 console.log(Error);
                  alert(Error.error);
                }
             );
   }


  ngOnInit(): void {
    this.partido = this._logrosService.ObtenerPartidoDTO(this.idPartido);
    
    this.obtenerLogrosCantidadDTO(this.idPartido);
    this.obtenerLogrosCantidadResultadosDTO(this.idPartido);

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
    this.dtoLogroPartido = dto;

  }

  setConsultarLogroEActive() {
    this.asignarLogroEActive = false;
    this.modificarLogroEActive = false;
    this.consultarLogroEActive = true;
    this.resultadoLogroEActive = false;
  }

  setResultadoLogroEActive(dto: DTOMostrarLogrosPartido){
    this.asignarLogroEActive = false;
    this.modificarLogroEActive = false;
    this.consultarLogroEActive = false;
    this.resultadoLogroEActive = true;
    this._newLogro = dto.Logro;
    this.dtoLogroPartido = dto;
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
       
        this.dtoLogroCantidad.IdPartido = this.idPartido;
        this.dtoLogroCantidad.LogroCantidad = this._newLogro;
        this.dtoLogroCantidad.TipoLogro = 1;
        this._logrosService.AgregarLogroCantidad(this.dtoLogroCantidad);
         this.obtenerLogrosCantidadDTO(this.idPartido);
         this._newLogro = "";
      }
      else
        alert("Debe ingresar un nombre de logro correcto");

    }


    public AsignarResultado()
    {
      if (this._newCantidad != null)
      { 

        this.dtoLogroCantidadResult.IdLogroCantidad = this.dtoLogroPartido.IdLogro;
        this.dtoLogroCantidadResult.LogroCantidad = this.dtoLogroPartido.Logro;
        this.dtoLogroCantidadResult.TipoLogro = 1;
        this.dtoLogroCantidadResult.Cantidad = this._newCantidad;
        this._logrosService.AsignarResutadoLogroCantidad(this.dtoLogroCantidadResult);
        this.obtenerLogrosCantidadDTO(this.idPartido);
      }
      else
        alert("Debe ingresar una cantidad valida");

    }

    
    public LlamarLogroCantidad() {
      this.router2.navigate(['/logros/logroCantidad',this.idPartido]);
    }

    public LlamarLogroEquipo() {
      this.router2.navigate(['/logros/logroEquipo',this.idPartido]);
    }

    public LlamarLogroJugador() {
      this.router2.navigate(['/logros/logroJugador',this.idPartido]);
    }

    public LlamarLogroVF() {
      this.router2.navigate(['/logros/logroVF',this.idPartido]);
    }

}
