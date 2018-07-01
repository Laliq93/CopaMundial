import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient} from '@angular/common/http';
//import { HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm, FormsModule } from '@angular/forms';
import { LogrosService } from '../../services/logros.service';
import { DTOLogroEquipo } from '../../models/DTOLogroEquipo';
import { DTOLogroPartidoId } from '../../models/DTOLogroPartidoId';
import { DTOMostrarLogrosPartido } from '../../models/DTOMostrarLogrosPartido';
import { catchError, map, tap } from 'rxjs/operators';
import {  DTOListaPartidosLogros } from '../../models/DTOListaPartidosLogros';
import { DTOLogroEquipoResultado } from '../../models/DTOLogroEquipoResultado';

@Component({
  selector: 'app-logro-equipo',
  templateUrl: './logro-equipo.component.html',
  styleUrls: ['./logro-equipo.component.css'],
  providers: [LogrosService]
})

export class LogroEquipoComponent implements OnInit {
  
  
    public listaDTOLogroEquipo: DTOMostrarLogrosPartido[] = [];//Contiene una lista de todos los logros del partido
    public listaDTOLogroEquipoResultado : DTOLogroEquipoResultado[] = [];
    public partido:  DTOListaPartidosLogros = null;
    public dtoPartidoId: DTOLogroPartidoId;
    public dtoLogroEquipo : DTOLogroEquipo;
    public _newLogro;
    public _equipo;
    public idPartido : number;
    public dtoLogroEquipoResult : DTOLogroEquipoResultado;
    public dtoLogroPartido : DTOMostrarLogrosPartido; 
    

    public asignarLogroEActive: boolean = false;
    public modificarLogroEActive: boolean = false;
    public consultarLogroEActive: boolean = false;
    public resultadoLogroEActive: boolean = false;
    public apiURL = 'http://localhost:51543/api/logros/';
    constructor(private _logrosService: LogrosService, public router: ActivatedRoute, private http: HttpClient, public router2: Router)
    {
        this._logrosService = new LogrosService(http);
        this.dtoLogroEquipo = new DTOLogroEquipo();
        this.dtoLogroEquipoResult = new DTOLogroEquipoResultado();
        this.idPartido = parseInt(
             this.router.snapshot.paramMap.get('idPartido')
           );
     }
  
  
    ngOnInit(): void {
      this.partido = this._logrosService.ObtenerPartidoDTO(this.idPartido);
      this.obtenerLogrosEquipoDTO(this.idPartido);
      this.obtenerLogrosEquipoResultadosDTO(this.idPartido);
  
    }
  
  
    setAsignarLogroEActive() {
      this.asignarLogroEActive = true;
      this.modificarLogroEActive = false;
      this.consultarLogroEActive = false;
      this.resultadoLogroEActive = false;
  
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
  
    setResultadoLogroEActive(dto: DTOMostrarLogrosPartido){
      this.asignarLogroEActive = false;
      this.modificarLogroEActive = false;
      this.consultarLogroEActive = false;
      this.resultadoLogroEActive = true;
      this._newLogro = dto.Logro;
      this.dtoLogroPartido = dto;
    }
  

    clear()
    {
      this.asignarLogroEActive = false;
      this.modificarLogroEActive = false;
      this.consultarLogroEActive = false;
      this.resultadoLogroEActive = false; 
      this._newLogro = "";
    }
  
    
  
    public obtenerLogrosEquipoDTO(idPartido: number)
     {
            this.dtoPartidoId = new DTOLogroPartidoId();
            this.dtoPartidoId.idPartido = idPartido;
             const url = this.apiURL+ 'obtenerLogrosEquipoPendiente';
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
                       this.listaDTOLogroEquipo[i] = logroEquipo;
                       console.log(data[i]);
                    }
                 },
                 Error => {
                   console.log(Error);
                    alert(Error.error);
                  }
               ); 

              }
    public obtenerLogrosEquipoResultadosDTO(idPartido: number)
    {
           this.dtoPartidoId = new DTOLogroPartidoId();
           this.dtoPartidoId.idPartido = idPartido;
            const url = this.apiURL+ 'obtenerLogrosEquipoResultados';
            this.http.put<DTOLogroEquipoResultado[]>(url, this.dtoPartidoId, {
                responseType: 'json'
              })
              .subscribe(
                data => {
                  for (let i = 0; i < Object.keys(data).length; i++)
                   {
                      let logroEquipo: DTOLogroEquipoResultado;
                      logroEquipo = new DTOLogroEquipoResultado();
 
                      logroEquipo.IdLogroEquipo = data[i].IdLogroEquipo;
                      logroEquipo.LogroEquipo = data[i].LogroEquipo;
                      logroEquipo.Equipo = data[i].Equipo;
                      logroEquipo.NombreEquipo = data[i].NombreEquipo;
                      logroEquipo.TipoLogro = data[i].TipoLogro;
                      this.listaDTOLogroEquipoResultado[i] = logroEquipo;
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
      
          this.dtoLogroEquipo.IdPartido = this.idPartido;
          this.dtoLogroEquipo.LogroEquipo = this._newLogro;
          this.dtoLogroEquipo.TipoLogro = 3;
          this._logrosService.AgregarLogroEquipo(this.dtoLogroEquipo);
          this.obtenerLogrosEquipoDTO(this.idPartido);
        }
        else
          alert("Debe ingresar un nombre de logro correcto");
  
      }


      public AsignarResultado()
      {
        if (this._equipo != null)
        { 
  
          this.dtoLogroEquipoResult.IdLogroEquipo = this.dtoLogroPartido.IdLogro;
          this.dtoLogroEquipoResult.LogroEquipo = this.dtoLogroPartido.Logro;
          this.dtoLogroEquipoResult.TipoLogro = 3;
          if(this._equipo == "1")
              this.dtoLogroEquipoResult.Equipo = this.partido.IdEquipo1;
            else
              this.dtoLogroEquipoResult.Equipo = this.partido.IdEquipo2;
          this.dtoLogroEquipoResult.NombreEquipo = this._equipo;
          this._logrosService.AsignarResutadoLogroEquipo(this.dtoLogroEquipoResult);
          this.obtenerLogrosEquipoDTO(this.idPartido);
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

