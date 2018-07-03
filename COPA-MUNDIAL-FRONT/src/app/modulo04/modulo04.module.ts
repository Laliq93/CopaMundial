import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Modulo04RoutingModule } from './modulo04-routing.module';
import { ViewComponent } from './components/view/view.component';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { FormComponent } from './components/form/form.component';
import { CrearComponent } from './components/crear/crear.component';
import { EditarComponent } from './components/editar/editar.component';
import { EquipoComponent } from './components/equipo/equipo.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { EquipoService } from './services/equipo.service';


@NgModule({
  imports: [
    CommonModule,
    Modulo04RoutingModule,
    FormsModule,
    HttpClientModule,
    HttpModule
  ],
  declarations: [ViewComponent, FormComponent, CrearComponent, EditarComponent, EquipoComponent],
  providers: [LoggedInGuard, EquipoService]
})
export class Modulo04Module { }
