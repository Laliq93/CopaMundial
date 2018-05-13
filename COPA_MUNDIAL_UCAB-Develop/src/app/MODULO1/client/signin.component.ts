import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent {
	constructor(private router: Router){}

	home(): void {
		this.router.navigate(['home']);
	}	

	recoveryPassword(): void {
		this.router.navigate(['recovery']);
	}
}

