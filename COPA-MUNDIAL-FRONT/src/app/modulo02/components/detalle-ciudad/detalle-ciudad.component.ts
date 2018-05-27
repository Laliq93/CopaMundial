import { Component, OnInit } from '@angular/core';
import {CiudadService} from '../../shared/ciudad.service';
import { Ciudad } from '../../shared/ciudad.model';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-detalle-ciudad',
  templateUrl: './detalle-ciudad.component.html',
  styleUrls: ['./detalle-ciudad.component.css'],
  providers:[Ciudad]

})
export class DetalleCiudadComponent implements OnInit {

  constructor(private ciudadService : CiudadService) { }

  ngOnInit() {
    this.resetForm();
  }


  resetForm(Form? : NgForm){
    if(Form != null)
    Form.reset();
    this.ciudadService.selectedCiudad = {
      nombre:'',
      poblacion: 0,
      descripcion:'',
      localizacion:'',
      imagen:''
    }
  }
}
