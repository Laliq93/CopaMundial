import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotLoggedInGuard } from 'src/app/guards/not-logged-in.guard';
import { EstgeneralComponent } from './estgeneral/estgeneral.component';
import { EstpartidoComponent } from './estpartido/estpartido.component';
import { EstjugadorComponent } from './estjugador/estjugador.component';
import { PredequipoComponent } from './predequipo/predequipo.component';
import { PredjugadorComponent } from './predjugador/predjugador.component';

const routes: Routes = [
  { path: 'estadisticas', component: EstgeneralComponent, canActivate: [NotLoggedInGuard] },
  { path: 'estpartidos', component: EstpartidoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'estjugador', component: EstjugadorComponent, canActivate: [NotLoggedInGuard] },
  { path: 'predequipo', component: PredequipoComponent, canActivate: [NotLoggedInGuard] },
  { path: 'predjugador', component: PredjugadorComponent, canActivate: [NotLoggedInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo09RoutingModule { }
