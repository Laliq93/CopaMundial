import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-detalle-ciudad',
  templateUrl: './detalle-ciudad.component.html',
  styleUrls: ['./detalle-ciudad.component.css']
})
export class DetalleCiudadComponent implements OnInit {

  lat:number =55.7498598;
  long:number =37.3523222;
  zoom:number = 10;

  ngOnInit() {

   
}
