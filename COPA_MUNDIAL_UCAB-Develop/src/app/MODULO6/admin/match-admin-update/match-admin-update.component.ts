import { Component, OnInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-match-admin-update',
  templateUrl: './match-admin-update.component.html',
  styleUrls: ['./match-admin-update.component.css']
})
export class MatchAdminUpdateComponent implements OnInit {

  constructor(private router: Router){}

  ngOnInit() {
  }

  matchList(): void {
		this.router.navigate(['admin/match']);
  }

  matchLineUp():void {
    this.router.navigate(['admin/match/lineup']);
  }

}
