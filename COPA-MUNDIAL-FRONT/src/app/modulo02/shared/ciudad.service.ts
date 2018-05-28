import { Injectable } from '@angular/core';
import {Ciudad} from './ciudad.model';
@Injectable({
  providedIn: 'root'
})
export class CiudadService {

  selectedCiudad : Ciudad;
  constructor() { }
}
