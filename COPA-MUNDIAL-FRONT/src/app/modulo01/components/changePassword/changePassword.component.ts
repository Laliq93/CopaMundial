import { Component, OnInit } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard'
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard'

@Component({
  selector: 'app-changePassword',
  templateUrl: './changePassword.component.html',
  styleUrls: ['./changePassword.component.css']
})
export class ChangePasswordComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
