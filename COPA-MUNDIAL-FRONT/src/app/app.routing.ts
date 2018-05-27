import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
   {
     path: 'inicio',
     loadChildren: './modulo01/modulo01.module#Modulo01Module'
   },
   {
     path: 'ciudades',
     loadChildren: './modulo02/modulo02.module#Modulo02Module'
   },
   {
     path: 'estadios',
     loadChildren: './modulo03/modulo03.module#Modulo03Module'
   },
   {
     path: 'equipos',
     loadChildren: './modulo04/modulo04.module#Modulo04Module'
   },
   {
     path: 'jugadores',
     loadChildren: './modulo05/modulo05.module#Modulo05Module'
   },
   {
     path: 'partidos',
     loadChildren: './modulo06/modulo06.module#Modulo06Module'
   },
   {
     path: 'logros',
     loadChildren: './modulo07/modulo07.module#Modulo07Module'
   },
   {
     path: 'apuestas',
     loadChildren: './modulo08/modulo08.module#Modulo08Module'
   },
   {
     path: 'estadisticas',
     loadChildren: './modulo09/modulo09.module#Modulo09Module'
   },
   {
     path: 'usuario',
     loadChildren: './modulo10/modulo10.module#Modulo10Module'
   },

   {
     path: '**',
     redirectTo: '/inicio/login',
     pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
