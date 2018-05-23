import { Component, OnInit } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard'
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
