import { Component, OnInit } from '@angular/core';
import { RouterModule, Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-match-admin-create',
  templateUrl: './match-admin-create.component.html',
  styleUrls: ['./match-admin-create.component.css']
})
export class MatchAdminCreateComponent implements OnInit {

  constructor(private router: Router){}

  ngOnInit() {
  }

  matchCreate(): void {
		this.router.navigate(['admin/match/create']);
  }

  matchList(): void {
		this.router.navigate(['admin/match']);
  }

}
