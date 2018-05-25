import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EstgeneralComponent } from './estgeneral/estgeneral.component';
import { NotLoggedInGuard } from 'src/app/guards/not-logged-in.guard';

const routes: Routes = [
  { path: 'estadisticas', component: EstgeneralComponent, canActivate: [NotLoggedInGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class Modulo09RoutingModule { }
