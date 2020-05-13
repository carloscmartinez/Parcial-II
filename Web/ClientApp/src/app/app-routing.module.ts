import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PersonaConsultaComponent } from './persona/persona-consulta/persona-consulta.component';
import { PersonaRegistroComponent } from './persona/persona-registro/persona-registro.component';
import { ApoyoConsultaComponent } from './apoyo/apoyo-consulta/apoyo-consulta.component';
import { ApoyoRegistroComponent } from './apoyo/apoyo-registro/apoyo-registro.component';

const routes: Routes = [
    {
    path: 'personaConsulta',
    component: PersonaConsultaComponent
    },
    {
      path: 'personaRegistro',
      component: PersonaRegistroComponent
    },
  {
      path: 'apoyoConsulta',
      component: ApoyoConsultaComponent
      },
      {
        path: 'apoyoRegistro',
        component: ApoyoRegistroComponent
      }
  ];
  

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
     RouterModule.forRoot(routes)

  ],
  exports:[RouterModule]

})
export class AppRoutingModule { }
