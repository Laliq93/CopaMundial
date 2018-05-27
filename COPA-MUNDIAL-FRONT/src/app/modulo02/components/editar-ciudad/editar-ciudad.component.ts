import { Component, OnInit } from '@angular/core';
import {CiudadService} from '../../shared/ciudad.service';
import { Ciudad } from '../../shared/ciudad.model';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-editar-ciudad',
  templateUrl: './editar-ciudad.component.html',
  styleUrls: ['./editar-ciudad.component.css'],
  providers:[Ciudad]

})
export class EditarCiudadComponent implements OnInit {

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
