import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-stadium-detail',
  templateUrl: './stadium-detail.component.html',
  styleUrls: ['./stadium-detail.component.css']
})
export class StadiumDetailComponent implements OnInit {

  constructor(private route: ActivatedRoute) {
    console.log(this.route.snapshot.params["id"]);
   }

  ngOnInit() {
  }

}
