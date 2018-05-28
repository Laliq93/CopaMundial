import { Component, OnInit, Injectable } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard';
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { FormControl, FormBuilder, Validators, NgForm } from '@angular/forms';
import { Usuario } from '../../models/usuario';
import { Router } from '@angular/router';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Component({
  selector: 'app-recovery',
  templateUrl: './recovery.component.html',
  styleUrls: ['./recovery.component.css']
})

@Injectable()
export class RecoveryComponent implements OnInit {

  usuario: Usuario;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  readonly rootUrl =  'http://localhost:54059/api';

  private emailResponse;
  handleError (error: any) { console.log(error)};

  constructor(private router: Router, private http: HttpClient) {
    this.usuario = new Usuario();
  }

  ngOnInit() {
  }

  recuperarPassword(userRecoveryForm){
    const url = `${this.rootUrl}/M1_RegistroLoginRecuperar/RecuperarClave`;
    const httpHeaders = new HttpHeaders().set('Accept', 'application/json');


    const {Correo} = userRecoveryForm.controls;
    

    console.log(userRecoveryForm.controls, Correo.value);
    
    
    const user = {
      correo          : Correo.value
    };

    this.http
      .post<Usuario>(url, user, httpOptions)
      .subscribe(
        success => {
          console.log(success);
          this.router.navigate(['/inicio','changePassword']);
        },
        error => alert("correo equivocado")
      );

  }
}
