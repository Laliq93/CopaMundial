import { Component, OnInit, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient} from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm, FormsModule } from '@angular/forms';
import { LogrosService } from '../../services/logros.service';
import { DTOLogroVF } from '../../models/DTOLogroVF';
import { DTOLogroPartidoId } from '../../models/DTOLogroPartidoId';
import { DTOMostrarLogrosPartido } from '../../models/DTOMostrarLogrosPartido';
import { catchError, map, tap } from 'rxjs/operators';
import {  DTOListaPartidosLogros } from '../../models/DTOListaPartidosLogros';
import { DTOLogroVFResultado } from '../../models/DTOLogroVFResultado';

@Component({
  selector: 'app-logro-vf',
  templateUrl: './logro-vf.component.html',
  styleUrls: ['./logro-vf.component.css'],
  providers: [LogrosService]
})

export class LogroVFComponent implements OnInit {
  
  
    public listaDTOLogroVF: DTOMostrarLogrosPartido[] = [];//Contiene una lista de todos los logros del partido
    public listaDTOLogroVFResultado : DTOLogroVFResultado[] = [];
    public partido:  DTOListaPartidosLogros = null;
    public dtoPartidoId: DTOLogroPartidoId;
    public dtoLogroVF: DTOLogroVF;
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
        this.dtoLogroVF = new DTOLogroVF();
        this.idPartido = parseInt(
             this.router.snapshot.paramMap.get('idPartido')
           );
     }
  
  
    ngOnInit(): void {
      this.partido = this._logrosService.ObtenerPartidoDTO(this.idPartido);
      this.obtenerLogrosVFDTO(this.idPartido);
      this.obtenerLogrosVFResultadosDTO(this.idPartido);
  
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
  
    
  
    public obtenerLogrosVFDTO(idPartido: number)
     {
            this.dtoPartidoId = new DTOLogroPartidoId();
            this.dtoPartidoId.idPartido = idPartido;
             const url = this.apiURL+ 'obtenerLogrosVFPendiente';
             this.http.put<DTOMostrarLogrosPartido[]>(url, this.dtoPartidoId, {
                 responseType: 'json'
               })
               .subscribe(
                 data => {
                   for (let i = 0; i < Object.keys(data).length; i++)
                    {
                       let logroVF: DTOMostrarLogrosPartido;
                       logroVF = new DTOMostrarLogrosPartido();
  
                       logroVF.IdLogro = data[i].IdLogro;
                       logroVF.Logro = data[i].Logro;
                       this.listaDTOLogroVF[i] = logroVF;
                       console.log(data[i]);
                    }
                 },
                 Error => {
                   console.log(Error);
                    alert(Error.error);
                  }
               );
     }


    public obtenerLogrosVFResultadosDTO(idPartido: number)
    {
           this.dtoPartidoId = new DTOLogroPartidoId();
           this.dtoPartidoId.idPartido = idPartido;
            const url = this.apiURL+ 'obtenerLogrosVFResultados';
            this.http.put<DTOLogroVFResultado[]>(url, this.dtoPartidoId, {
                responseType: 'json'
              })
              .subscribe(
                data => {
                  for (let i = 0; i < Object.keys(data).length; i++)
                   {
                      let logroVF: DTOLogroVFResultado;
                      logroVF = new DTOLogroVFResultado();
 
                      logroVF.IdLogroVF = data[i].IdLogroVF;
                      logroVF.LogroVF = data[i].LogroVF;
                      logroVF.Respuesta = data[i].Respuesta;
                      logroVF.TipoLogro = data[i].TipoLogro;
                      this.listaDTOLogroVFResultado[i] = logroVF;
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
          this.dtoLogroVF.IdPartido = this.idPartido;
          this.dtoLogroVF.LogroVF = this._newLogro;
          this.dtoLogroVF.TipoLogro = 3;
          this._logrosService.AgregarLogroVF(this.dtoLogroVF);
          this.obtenerLogrosVFDTO(this.idPartido);
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

