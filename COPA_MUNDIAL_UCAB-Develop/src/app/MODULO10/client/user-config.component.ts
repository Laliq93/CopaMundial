import { Component , NgZone  } from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

declare var $: any;

export interface IUsuario {
  id: number;
  Nombre: string;
  Apellido: string;
  FechaNacimiento: string;
  Genero: string;
  FotoPath: string;
}


class Usuario{

  public Id: number;
  public NombreUsuario:string;
  public Nombre: string;
  public Apellido: string;
  public FechaNacimiento: string;
  public Genero: string;
  public FotoPath: string;
  public Password: string;

  constructor(id:number, nombre: string, apellido: string, fechaNacimiento:string, 
    genero:string, fotoPath:string)
  {
    this.Id = id;
    this.Nombre = nombre;
    this.Apellido = apellido;
    this.FechaNacimiento = fechaNacimiento;
    this.Genero = genero;
    this.FotoPath = fotoPath;
    this.Password = 'djrex747';
  }

}


@Component({
  selector: 'user-config',
  templateUrl: './user-config.component.html',
  styleUrls: ['./user.component.css']
})

 
export class UserConfigComponent {

  apiRoot: string = 'http://localhost:54059/api/M10_Usuario/';
  //usuario: Usuario;
  usuario: Usuario;

  constructor(private http: HttpClient, private _zone: NgZone) {
    //this.usuario = new Usuario();
    this.usuario = new Usuario(2,'Felix', 'Morales', '13-12-1995','M','CD');
  }

  ngOnInit(): void {

   // this.ObtenerDatos();
	}

  ngAfterViewInit(): void {
    this._zone.runOutsideAngular(() => {
      $('#exampleInputDatePicker1').pickdate();
    });
  }

  ObtenerDatos() {

    //let idUsuario = this.usuario.id;

    let url = `${this.apiRoot}ObtenerUsuario/2`;
    let httpHeaders = new HttpHeaders()
      .set('Accept', 'application/json');

    //let search = new HttpParams().set('idUsuario', '2');

    this.http.get<IUsuario>(url, { responseType: 'json' }).subscribe(data => {

      //this.usuario.apellido = data.Apellido;
      //this.usuario.genero = data.Genero;
      //this.usuario.fechaNacimiento = data.FechaNacimiento;
      //this.usuario.fotoPath = data.FotoPath;

      console.log(data);

    });

  }

  ActualizarDatos() {
        //ActualizarPerfil/{idUsuario:int}/{nombre}/{apellido}/{fechaNacimiento}/{genero}/{fotoPath
        


        /*let url = `${this.apiRoot}ActualizarPerfil/`+this.usuario.id.toString()+`/`
        +this.usuario.nombre+'/'+this.usuario.apellido+'/'+this.usuario.fechaNacimiento+'/'
        +this.usuario.genero+'/'+this.usuario.fotoPath;*/

        let url = `${this.apiRoot}ActualizarPerfil/djrexpepe/`;

        //this.testing.Id = 12;

        let httpHeaders = new HttpHeaders()
          .set('Accept', 'application/json');
    
        this.http.put(url, this.usuario,{ responseType: 'json' }).subscribe(
          data => {
            console.log(data);
          });
        //let search = new HttpParams().set('idUsuario', '2');
    
        /*this.http.put<IUsuario>(url, { responseType: 'json' }).subscribe(data => {
  
          console.log(data);
    
        });*/
    
      }
}
