import { Component, OnInit } from '@angular/core';
import { Ciudad } from '../../shared/ciudad.model';
import { CiudadService } from '../../shared/ciudad.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-listar-ciudades',
  templateUrl: './listar-ciudades.component.html',
  styleUrls: ['./listar-ciudades.component.css'],
  providers:[Ciudad,CiudadService]
})
export class ListarCiudadesComponent implements OnInit {

  ciudades: Ciudad[];
  
  constructor(private _location: Location,private route:Router, private ciudadservice: CiudadService) { }

  ngOnInit() {
      this.ciudadservice.ObtenerListaCiudades().subscribe(
        result =>{
          this.ciudades  = result;
          this.route.navigate(['ciudades/listarCiudades'])
        },
        error => {
          console.log(error);
        }
      )

  }
  
  regresar() {
    this._location.back(); // <-- regresar a la pagina previa al presionar cancelar
  }
  
}
