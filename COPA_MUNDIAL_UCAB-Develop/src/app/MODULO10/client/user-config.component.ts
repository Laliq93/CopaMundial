import { Component, NgZone, AfterViewInit } from "@angular/core";
/* tslint:disable */

declare var $: any;

@Component({
  selector: "user-config",
  templateUrl: "./user-config.component.html",
  styleUrls: ["./user.component.css"]
})
export class UserConfigComponent {
  constructor(private _zone: NgZone) {

  }
 
  ngAfterViewInit(): void {
    this._zone.runOutsideAngular(() => {
      $("#exampleInputDatePicker1").pickdate();
    });
  }
}
