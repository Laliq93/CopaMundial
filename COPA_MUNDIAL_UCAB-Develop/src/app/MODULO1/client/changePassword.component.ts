import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'changePassword',
  templateUrl: './changePassword.component.html',
  styleUrls: ['./changePassword.component.css']
})
export class ChangePasswordComponent {
	constructor(private router: Router){}

	signin(): void {
		this.router.navigate(['signin']);
	}	
}
