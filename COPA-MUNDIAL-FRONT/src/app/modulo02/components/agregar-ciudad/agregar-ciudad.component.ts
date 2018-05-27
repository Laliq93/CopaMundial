import { Component, OnInit } from '@angular/core';
import { NgForOfContext } from '@angular/common';
import { NgForm } from '@angular/forms';
import {CiudadService} from '../../shared/ciudad.service';
import { Ciudad } from '../../shared/ciudad.model';

@Component({
  selector: 'app-agregar-ciudad',
  templateUrl: './agregar-ciudad.component.html',
  styleUrls: ['./agregar-ciudad.component.css'],
  providers:[Ciudad]
})
export class AgregarCiudadComponent implements OnInit {


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
