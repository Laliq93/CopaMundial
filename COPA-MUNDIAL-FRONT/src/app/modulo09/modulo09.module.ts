import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Modulo09RoutingModule } from './modulo09-routing.module';
import { EstgeneralComponent } from './estgeneral/estgeneral.component';

@NgModule({
  imports: [
    CommonModule,
    Modulo09RoutingModule
  ],
  declarations: [EstgeneralComponent]
})
export class Modulo09Module { }
