import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Modulo09RoutingModule } from './modulo09-routing.module';
import { EstgeneralComponent } from './estgeneral/estgeneral.component';
import { EstpartidoComponent } from './estpartido/estpartido.component';

@NgModule({
  imports: [
    CommonModule,
    Modulo09RoutingModule
  ],
  declarations: [EstgeneralComponent, EstpartidoComponent]
})
export class Modulo09Module { }
