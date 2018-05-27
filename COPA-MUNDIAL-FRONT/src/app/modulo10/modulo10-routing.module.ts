import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoggedInGuard } from '../guards/logged-in.guard';
import { NotLoggedInGuard } from '../guards/not-logged-in.guard';

import { PerfilUsuarioComponent } from './components/perfil-usuario/perfil-usuario.component';
import { ConfiguracionUsuarioComponent } from './components/configuracion-usuario/configuracion-usuario.component';
import { SeguridadUsuarioComponent } from './components/seguridad-usuario/seguridad-usuario.component';

const routes: Routes = [
  { path: '', component: PerfilUsuarioComponent, canActivate: [NotLoggedInGuard] },
  { path: 'configuracion', component: ConfiguracionUsuarioComponent, canActivate: [NotLoggedInGuard] },
  { path: 'seguridad', component: SeguridadUsuarioComponent, canActivate: [NotLoggedInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo10RoutingModule { }
