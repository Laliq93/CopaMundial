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

