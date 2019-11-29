import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ValoresComponent } from 'src/components/valores/valores.component';
import { RegistroComponent } from 'src/components/registro/registro.component';
import { InicioComponent } from 'src/components/inicio/inicio.component';


const routes: Routes = [

  {path: 'valores', component: ValoresComponent},
  {path: 'registro', component: RegistroComponent},
  {path: 'inicio', component: InicioComponent},
  { path: '', redirectTo: 'inicio', pathMatch: 'full'},
  { path: '**', redirectTo: 'inicio', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
