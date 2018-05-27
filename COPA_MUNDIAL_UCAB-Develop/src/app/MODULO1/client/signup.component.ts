import { Component, OnInit } from '@angular/core';
/*import { User } from './user.model';*/
import { NgForm, Form, FormGroup, AbstractControl, FormBuilder, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from './user.service';
import { Router } from '@angular/router';
 
@Component({
  selector: 'app-sign-up',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  public formSignup: FormGroup;
  public nombreUsuario: AbstractControl;
  public nombre: AbstractControl;
  public apellido: AbstractControl;
  public fechaNacimiento: AbstractControl;
  public correo: AbstractControl;
  public genero: AbstractControl;
  public password: AbstractControl;
  public confirmPassword: AbstractControl;


 
  constructor(private userService: UserService, 
    private router: Router, 
    formBuilder: FormBuilder) { 

    this.formSignup= formBuilder.group({
      nombreUsuario: new FormControl(''),
      nombre: new FormControl(''),
      apellido: new FormControl(''),
      fechaNacimiento: new FormControl(''),
      correo: new FormControl(''),
      genero: new FormControl(''),
      password: new FormControl(''),
      confirmPassword: new FormControl(''),

    });


    this.nombreUsuario =this.formSignup.controls['nombreUsuario'];
    this.nombre =this.formSignup.controls['nombre'];
    this.apellido =this.formSignup.controls['apellido'];
    this.fechaNacimiento =this.formSignup.controls['fechaNacimiento'];
    this.correo =this.formSignup.controls['correo'];
    this.genero =this.formSignup.controls['genero'];
    this.password =this.formSignup.controls['password'];
    this.confirmPassword =this.formSignup.controls['confirmPassword'];

  }
 
  ngOnInit() {
    //this.resetForm();
  }
 
  /*resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.user = {
      Usuario: '',
      Nombre: '',
      Apellido: '',
      FechaNac: '',
			Correo: '',
      Genero: '',
			Contrasena: ''
    }
  }*/
 
  OnSubmit() {
  
        if (this.formSignup.valid) {
          let data={
            nombreUsuario: this.nombreUsuario.value,
            nombre: this.nombre.value,
            apellido: this.apellido.value,
            fechaNacimiento: this.fechaNacimiento.value,
            correo: this.correo.value,
            genero: this.genero.value,
            password: this.password.value,
            confirmPassword: this.confirmPassword.value
          }

          //this.resetForm(this.formSignup.value);
					this.router.navigate(['signin']);
        }
        else
          this.router.navigate(['signup']);
  }

  /*signin(): void {
		this.router.navigate(['signin']);
 
  }*/
}