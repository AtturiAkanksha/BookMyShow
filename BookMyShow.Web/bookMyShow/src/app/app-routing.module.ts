import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "Login", loadChildren: () => import('./un-authenticated/un-authenticated.module').then(mod => mod.UnAuthenticatedModule) },
  { path: "BookMyShow", loadChildren: () => import('./authenticated/authenticated.module').then(mod => mod.AuthenticatedModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
