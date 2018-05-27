import { Component, OnInit } from '@angular/core';
import {AgmMap} from '@agm/core';
import { AgmCoreModule } from '@agm/core';
import {CiudadService} from '../../shared/ciudad.service';
import { Ciudad } from '../../shared/ciudad.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-consultar-ciudad',
  templateUrl: './consultar-ciudad.component.html',
  styleUrls: ['./consultar-ciudad.component.css'],
  providers:[Ciudad]
})
export class ConsultarCiudadComponent implements OnInit {
 
  nombreCiudades: string[] = ['Moscu', 'Ekaterimburgo','Leningrado ','San Petersburgo','Samara', 'Rostov','Kazan', 'Novorossiysk', 'Sochi', 'Saransk', 'Nizhni Nóvgorod']


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
