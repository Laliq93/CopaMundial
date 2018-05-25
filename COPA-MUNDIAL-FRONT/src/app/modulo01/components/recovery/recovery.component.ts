import { Component, OnInit } from '@angular/core';
import { LoggedInGuard } from '../../../guards/logged-in.guard'
import { NotLoggedInGuard } from '../../../guards/not-logged-in.guard'

@Component({
  selector: 'app-recovery',
  templateUrl: './recovery.component.html',
  styleUrls: ['./recovery.component.css']
})
export class RecoveryComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
