import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { Modulo10RoutingModule } from './modulo10-routing.module';
import { PerfilUsuarioComponent } from './components/perfil-usuario/perfil-usuario.component';
import { ConfiguracionUsuarioComponent } from './components/configuracion-usuario/configuracion-usuario.component';
import { SeguridadUsuarioComponent } from './components/seguridad-usuario/seguridad-usuario.component';

@NgModule({
  imports: [CommonModule, FormsModule, HttpClientModule, Modulo10RoutingModule],
  declarations: [
    PerfilUsuarioComponent,
    ConfiguracionUsuarioComponent,
    SeguridadUsuarioComponent
  ]
})
export class Modulo10Module {}
