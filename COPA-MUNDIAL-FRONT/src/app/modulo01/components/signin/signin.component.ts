import { Component, OnInit, Injectable } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient, HttpParams, HttpHeaders, HttpHandler } from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { catchError, retry } from 'rxjs/operators';
import { Usuario } from '../../models/usuario';
import { Routes, RouterModule, Router } from '@angular/router';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};


@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})

@Injectable()
export class SigninComponent implements OnInit {

  usuario: Usuario;
  readonly rootUrl =  'http://localhost:54059/api';

  private emailResponse;
  private truefalse:boolean = false;

  handleError (error: any) { console.log(error)};

  constructor(private router: Router, private http: HttpClient) {
    this.usuario = new Usuario();
  }

  ngOnInit() {
  }

  

  signinUser(userLoginForm){

    const {NombreUsuario, Password} = userLoginForm.controls;
    const isUsername = NombreUsuario.value.indexOf("@") < 0 ? true : false;

    const urlUsername = `${this.rootUrl}/M1_RegistroLoginRecuperar/IniciarSesionUsuario`;
    const urlEmail = `${this.rootUrl}/M1_RegistroLoginRecuperar/IniciarSesionCorreo`;
    const url = isUsername ? urlUsername : urlEmail;
    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');
    
    
    console.log(isUsername);
    console.log(userLoginForm.controls, NombreUsuario.value, Password.value);
    
    
    const username = {
      nombreUsuario   : NombreUsuario.value,
      password        : Password.value  
    };

    const email = {
      correo          : NombreUsuario.value,
      password        : Password.value  
    };

    const userData = isUsername ? username : email;

      this.http
      .post<any>(url, userData, httpOptions)
      .subscribe(
        success => {
          console.log(success)
          const id : number = success.Id;
          const esAdmin : boolean = success.EsAdmin;
          
          console.log("ID: " + id);
          console.log("ESADMIN: " + esAdmin);
          

          if (esAdmin){
            localStorage.setItem('userId', id.toString());
            localStorage.setItem('esAdmin', 'true');
            console.log('entro un admin ', esAdmin);
            this.router.navigate(['/inicio', 'admin']);
            
           }
          else{
            this.router.navigate(['inicio']);
          }
          localStorage.setItem('userId', id.toString());
        },
        error => alert(" usuario o email equivocado")
      );

      /*.subscribe(data => {


      
      /*this.usuario.nombreUsuario = data.NombreUsuario;
      this.usuario.nombre = data.Nombre;
      this.usuario.apellido = data.Apellido;
      this.usuario.fechaNacimiento = data.FechaNacimiento;
      this.usuario.correo = data.Correo;
      this.usuario.genero = data.Genero;
      this.usuario.password = data.Password;*/

      //console.log(data);
      
   // }).catch((error)=>{})*/
    
  }

}
