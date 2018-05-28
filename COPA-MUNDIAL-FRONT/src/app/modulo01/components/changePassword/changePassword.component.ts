import { Component, OnInit } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Usuario } from '../../models/usuario';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Component({
  selector: 'app-changePassword',
  templateUrl: './changePassword.component.html',
  styleUrls: ['./changePassword.component.css']
})
export class ChangePasswordComponent implements OnInit {

  usuario: Usuario;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  readonly rootUrl =  'http://localhost:54059/api';

  private emailResponse;
  handleError (error: any) { console.log(error)};

  constructor(private http: HttpClient) {
    this.usuario = new Usuario();
  }

  ngOnInit() {
  }

  cambiarPassword(changePasswordForm){
    const url = `${this.rootUrl}/M1_RegistroLoginRecuperar/CambiarClave`;
    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');


    const {Correo, Password} = changePasswordForm.controls;
    

    console.log(changePasswordForm.controls, Correo.value, Password.value);
    
    
    const user = {
      correo          : Correo.value,
      password        : Password.value
    };

    this.http
      .post<Usuario>(url, user, httpOptions)
      .subscribe(
        success => {
          console.log(success)
        },
        error => alert("correo no existe")
      );

  }

}
