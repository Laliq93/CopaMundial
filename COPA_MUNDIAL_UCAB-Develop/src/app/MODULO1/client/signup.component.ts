/* import { Component, OnInit } from '@angular/core';
import { User } from './user.model';
import { NgForm } from '@angular/forms';
import { UserService } from './user.service';
import { Router } from '@angular/router';
 
@Component({
  selector: 'app-sign-up',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  user: User;
	emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
 
  constructor(private userService: UserService, private Router: Router) { }
 
  ngOnInit() {
    this.resetForm();
  }
 
  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.user = {
      Usuario: '',
      Nombre: '',
      Apellido: '',
      FechaNac: '',
			Correo: '',
			Contrasena: ''
    }
  }
 
  OnSubmit(form: NgForm) {
    this.userService.registerUser(form.value)
      .subscribe((data: any) => {
        if (data.Succeeded == true) {
          this.resetForm(form);
					this.Router.navigate(['signin']);
        }
        else
          this.Router.navigate(['signin']);
      });
  }
 
}
*/
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
 selector: 'signup',
templateUrl: './signup.component.html',
styleUrls: ['./signup.component.css']
})
export class SignupComponent {
	constructor(private router: Router){}

	signin(): void {
		this.router.navigate(['signin']);
	}	
}

