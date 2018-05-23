import { Component, OnInit } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard'
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard'

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
