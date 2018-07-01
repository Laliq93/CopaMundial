import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient} from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm, FormsModule } from '@angular/forms';
import { LogrosService } from '../../services/logros.service';
import { DTOLogroJugador } from '../../models/DTOLogroJugador';
import { DTOLogroPartidoId } from '../../models/DTOLogroPartidoId';
import { DTOMostrarLogrosPartido } from '../../models/DTOMostrarLogrosPartido';
import { catchError, map, tap } from 'rxjs/operators';
import {  DTOListaPartidosLogros } from '../../models/DTOListaPartidosLogros';
import { DTOLogroJugadorResultado } from '../../models/DTOLogroJugadorResultado';

@Component({
  selector: 'app-logro-jugador',
  templateUrl: './logro-jugador.component.html',
  styleUrls: ['./logro-jugador.component.css'],
  providers: [LogrosService]
})

export class LogroJugadorComponent implements OnInit {
  
  
    public listaDTOLogroJugador: DTOMostrarLogrosPartido[] = [];//Contiene una lista de todos los logros del partido
    public listaDTOLogroJugadorResultado : DTOLogroJugadorResultado[] = [];
    public partido:  DTOListaPartidosLogros = null;
    public dtoPartidoId: DTOLogroPartidoId;
    public dtoLogroJugador : DTOLogroJugador;
    public _newLogro;
    public idPartido : number;
  
    public asignarLogroEActive: boolean = false;
    public modificarLogroEActive: boolean = false;
    public consultarLogroEActive: boolean = false;
    public resultadoLogroEActive: boolean = false;
    public apiURL = 'http://localhost:51543/api/logros/';
    constructor(private _logrosService: LogrosService, public router: ActivatedRoute, private http: HttpClient, public router2: Router)
    {
        this._logrosService = new LogrosService(http);
        this.dtoLogroJugador = new DTOLogroJugador();
        this.idPartido = parseInt(
             this.router.snapshot.paramMap.get('idPartido')
           );
     }
  
  
    ngOnInit(): void {
      this.partido = this._logrosService.ObtenerPartidoDTO(this.idPartido);
      this.obtenerLogrosJugadorDTO(this.idPartido);
      this.obtenerLogrosJugadorResultadosDTO(this.idPartido);
  
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
  
    setResultadoLogroEActive(){
      this.asignarLogroEActive = false;
      this.modificarLogroEActive = false;
      this.consultarLogroEActive = false;
      this.resultadoLogroEActive = true;
  
    }

    clear()
    {
      this.asignarLogroEActive = false;
      this.modificarLogroEActive = false;
      this.consultarLogroEActive = false;
      this.resultadoLogroEActive = false; 
      this._newLogro = "";
    }
  
    
  
    public obtenerLogrosJugadorDTO(idPartido: number)
     {
            this.dtoPartidoId = new DTOLogroPartidoId();
            this.dtoPartidoId.idPartido = idPartido;
             const url = this.apiURL+ 'obtenerLogrosJugadorPendiente';
             this.http.put<DTOMostrarLogrosPartido[]>(url, this.dtoPartidoId, {
                 responseType: 'json'
               })
               .subscribe(
                 data => {
                   for (let i = 0; i < Object.keys(data).length; i++)
                    {
                       let logroJugador: DTOMostrarLogrosPartido;
                       logroJugador = new DTOMostrarLogrosPartido();
  
                       logroJugador.IdLogro = data[i].IdLogro;
                       logroJugador.Logro = data[i].Logro;
                       this.listaDTOLogroJugador[i] = logroJugador;
                       console.log(data[i]);
                    }
                 },
                 Error => {
                   console.log(Error);
                    alert(Error.error);
                  }
               );
     }


    public obtenerLogrosJugadorResultadosDTO(idPartido: number)
    {
           this.dtoPartidoId = new DTOLogroPartidoId();
           this.dtoPartidoId.idPartido = idPartido;
            const url = this.apiURL+ 'obtenerLogrosJugadorResultados';
            this.http.put<DTOLogroJugadorResultado[]>(url, this.dtoPartidoId, {
                responseType: 'json'
              })
              .subscribe(
                data => {
                  for (let i = 0; i < Object.keys(data).length; i++)
                   {
                      let logroJugador: DTOLogroJugadorResultado;
                      logroJugador = new DTOLogroJugadorResultado();
 
                      logroJugador.IdLogroJugador = data[i].IdLogroJugador;
                      logroJugador.LogroJugador = data[i].LogroJugador;
                      logroJugador.Jugador = data[i].Jugador;
                      logroJugador.NombreJugador = data[i].NombreJugador;
                      logroJugador.TipoLogro = data[i].TipoLogro;
                      this.listaDTOLogroJugadorResultado[i] = logroJugador;
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
          this.dtoLogroJugador.IdPartido = this.idPartido;
          this.dtoLogroJugador.LogroJugador = this._newLogro;
          this.dtoLogroJugador.TipoLogro = 3;
          this._logrosService.AgregarLogroJugador(this.dtoLogroJugador);
          this.obtenerLogrosJugadorDTO(this.idPartido);
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

      public LlamarLogroJugador() {
        this.router2.navigate(['/logros/logroJugador',this.idPartido]);
      }
  
      public LlamarLogroVF() {
        this.router2.navigate(['/logros/logroVF',this.idPartido]);
      }
  }

