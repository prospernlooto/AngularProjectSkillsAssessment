import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroesComponent } from './heroes/heroes.component';
import { PersonDetailFormComponent } from './person-details/person-detail-form/person-detail-form.component';
import { PersonDetailsComponent } from './person-details/person-details.component';

const routes: Routes = [{ path: 'personslist', component: PersonDetailsComponent },
  { path: 'heroes', component: HeroesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
